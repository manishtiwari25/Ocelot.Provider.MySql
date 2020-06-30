using Dapper;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Ocelot.Provider.MySql
{
    public class OcelotConfigDbDal
    {
        public readonly string _dbConnectionString;
        public readonly string _ocelotConfigTableName;
        private readonly string _sqlUpdate;
        private readonly string _sqlQueryBySection;
        private readonly string _sqlInsert;
        private readonly string _sqlQueryAllConfig;
        private bool _isCalledOnce = false;
        public OcelotConfigDbDal(OcelotConfigDbConfiguration configDbConfiguration)
        {
            _dbConnectionString = configDbConfiguration.ConnectionString;
            _ocelotConfigTableName = configDbConfiguration.ConfigTableName;
            _sqlQueryAllConfig = $"SELECT `Id`,`Section`,`Payload`,`CreateTime`,`LastUpdate` FROM {_ocelotConfigTableName}";
            _sqlQueryBySection = $"SELECT * FROM {_ocelotConfigTableName} Where Section=@Section;";
            _sqlInsert = $"INSERT INTO{_ocelotConfigTableName}(`Section`,`Payload`,`CreateTime`,`LastUpdate`)VALUES(@Section, @Payload, @CreateTime, @LastUpdate)";
            _sqlUpdate = $"UPDATE {_ocelotConfigTableName} SET `Section` = @Section,`Payload` = @Payload,`LastUpdate` = @LastUpdate WHERE Id=@Id";
        }

        public async Task<List<OcelotConfiguration>> GetAllConfigs()
        {
            using IDbConnection conn = new MySqlConnection(_dbConnectionString);
            var data = await conn.QueryAsync<OcelotConfiguration>(_sqlQueryAllConfig);
            return data.ToList();
        }

        public async Task<OcelotConfiguration> GetOcelotConfigBySection(string section)
        {
            using IDbConnection conn = new MySqlConnection(_dbConnectionString);
            var data = await conn.QueryAsync<OcelotConfiguration>(_sqlQueryBySection, new { Section = section });
            return data.FirstOrDefault();
        }

        public async Task InsertRequestLogs(OcelotConfiguration ocelotConfig)
        {
            using IDbConnection conn = new MySqlConnection(_dbConnectionString);
            await conn.ExecuteAsync(_sqlInsert, ocelotConfig);
        }

        public async Task Update(OcelotConfiguration ocelotConfig)
        {
            if (_isCalledOnce)
            {
                ocelotConfig.LastUpdate = DateTime.Now;
                using IDbConnection connection = new MySqlConnection(_dbConnectionString);
                await connection.ExecuteAsync(_sqlUpdate, ocelotConfig);
            }
            _isCalledOnce = true;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Ocelot.Provider.MySql
{
    public class OcelotConfigDbDal
    {
        private readonly OcelotConfigDbContext _context;
 
        public OcelotConfigDbDal(OcelotConfigDbContext context)
        {
            _context = context;
        }

        public async Task<List<OcelotConfiguration>> GetAllConfigs()
        {
            return await _context.ConfigModels.ToListAsync();
        }
        public async Task<OcelotConfiguration> GetOcelotConfigBySection(string section)
        {
            return await _context.ConfigModels.Where(x => x.Section.Equals(section)).FirstOrDefaultAsync();
        }
        public async Task InsertRequestLogs(OcelotConfiguration ocelotConfig)
        {
            _context.ConfigModels.Add(ocelotConfig);
            await _context.SaveChangesAsync();
        }
        public async Task Update(OcelotConfiguration ocelotConfig)
        {
            ocelotConfig.LastUpdate = DateTime.Now;
            await InsertRequestLogs(ocelotConfig);
        }
    }
}

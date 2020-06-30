namespace Ocelot.Provider.MySql
{
    using Configuration.File;
    using Configuration.Repository;
    using Logging;
    using Newtonsoft.Json;
    using Responses;
    using System;
    using System.Net;
    using System.Threading.Tasks;

    public class MySqlFileConfigurationRepository : IFileConfigurationRepository
    {
        private readonly string _configurationKey;
        private readonly Cache.IOcelotCache<FileConfiguration> _cache;
        private readonly IOcelotLogger _logger;
        private readonly OcelotConfigDbDal _configDbDal;
        public MySqlFileConfigurationRepository(
            Cache.IOcelotCache<FileConfiguration> cache,
            IInternalConfigurationRepository repo,
            IOcelotLoggerFactory loggerFactory,
            OcelotConfigDbDal configDbDal)
        {
            _logger = loggerFactory.CreateLogger<MySqlFileConfigurationRepository>();
            _cache = cache;
            _configDbDal = configDbDal;

            var internalConfig = repo.Get();
            _configurationKey = "InternalConfiguration";
            if (!internalConfig.IsError)
            {
                _configurationKey = !string.IsNullOrEmpty(internalConfig.Data.ServiceProviderConfiguration.ConfigurationKey) ?
                    internalConfig.Data.ServiceProviderConfiguration.ConfigurationKey : _configurationKey;
            }
        }

        public async Task<Response<FileConfiguration>> Get()
        {
            _logger.LogInformation("Get route rules");
            var config = _cache.Get(_configurationKey, _configurationKey);
            if (config == null)
            {
                var ocelotCfg = await _configDbDal.GetOcelotConfigBySection(OcelotConfigurationSection.All);
                _logger.LogInformation("Get route rules from DB");
                if (ocelotCfg != null)
                {
                    config = JsonConvert.DeserializeObject<FileConfiguration>(ocelotCfg.Payload);
                    _cache.AddAndDelete(_configurationKey, config, new TimeSpan(0, 0, 15), null);
                }
            }
            foreach (var item in config.Routes)
                _logger.LogInformation($"Get Rule : {item.Key} - {item.UpstreamPathTemplate} -> {item.DownstreamPathTemplate}");
            return new OkResponse<FileConfiguration>(config);
        }

        public async Task<Response> Set(FileConfiguration ocelotConfiguration)
        {
            try
            {
                _logger.LogInformation("Set route rules");
                var cfgPayload = JsonConvert.SerializeObject(ocelotConfiguration, Formatting.Indented);
                var ocelotCfg = await _configDbDal.GetOcelotConfigBySection(OcelotConfigurationSection.All);
                if (ocelotCfg == null)
                {
                    await _configDbDal.InsertRequestLogs(new OcelotConfiguration{ Payload = cfgPayload, Section = OcelotConfigurationSection.All });
                }
                else
                {
                    ocelotCfg.Payload = cfgPayload;
                    await _configDbDal.Update(ocelotCfg);
                }
                _cache.AddAndDelete(_configurationKey, ocelotConfiguration, new TimeSpan(0, 0, 15), null);
                _logger.LogInformation("Set route rules cache");
                return new OkResponse();
            }
            catch (Exception ex)
            {
                return new ErrorResponse(new SetConfigInMySqlError($"Failed to set FileConfiguration in sql server, error message:{ex.Message}", (int)HttpStatusCode.NotFound));
            }
        }
    }
}

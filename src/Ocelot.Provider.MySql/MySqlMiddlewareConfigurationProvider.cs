namespace Ocelot.Provider.MySql
{
    using Configuration.Creator;
    using Configuration.File;
    using Configuration.Repository;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;
    using Middleware;
    using Ocelot.Configuration.Setter;
    using Responses;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    public static class MySqlMiddlewareConfigurationProvider
    {
        public static OcelotMiddlewareConfigurationDelegate Get = async builder =>
        {
            var fileConfigRepo = builder.ApplicationServices.GetService<IFileConfigurationRepository>();
            var fileConfig = builder.ApplicationServices.GetService<IOptionsMonitor<FileConfiguration>>();
            var internalConfigCreator = builder.ApplicationServices.GetService<IInternalConfigurationCreator>();
            var internalConfigRepo = builder.ApplicationServices.GetService<IInternalConfigurationRepository>();

            if (UsingMySql(fileConfigRepo))
            {
                await SetFileConfigInMySql(builder, fileConfigRepo, fileConfig, internalConfigCreator, internalConfigRepo);
            }
        };

        private static bool UsingMySql(IFileConfigurationRepository fileConfigRepo)
        {
            return fileConfigRepo.GetType() == typeof(MySqlFileConfigurationRepository);
        }

        private static async Task SetFileConfigInMySql(IApplicationBuilder builder,
            IFileConfigurationRepository fileConfigRepo, IOptionsMonitor<FileConfiguration> fileConfig,
            IInternalConfigurationCreator internalConfigCreator, IInternalConfigurationRepository internalConfigRepo)
        {
            var fileConfigFromMySql = await fileConfigRepo.Get();

            if (IsError(fileConfigFromMySql))
            {
                ThrowToStopOcelotStarting(fileConfigFromMySql);
            }
            else if (ConfigNotStoredInConsul(fileConfigFromMySql))
            {
                await fileConfigRepo.Set(fileConfig.CurrentValue);
            }
            else
            {
                var internalConfig = await internalConfigCreator.Create(fileConfigFromMySql.Data);

                if (IsError(internalConfig))
                {
                    ThrowToStopOcelotStarting(internalConfig);
                }
                else
                {
                    var response = internalConfigRepo.AddOrReplace(internalConfig.Data);

                    if (IsError(response))
                    {
                        ThrowToStopOcelotStarting(response);
                    }
                }

                if (IsError(internalConfig))
                {
                    ThrowToStopOcelotStarting(internalConfig);
                }
            }
        }

        private static void ThrowToStopOcelotStarting(Response config)
        {
            throw new Exception($"Unable to start Ocelot, errors are: {string.Join(",", config.Errors.Select(x => x.ToString()))}");
        }

        private static bool IsError(Response response)
        {
            return response == null || response.IsError;
        }

        private static bool ConfigNotStoredInConsul(Response<FileConfiguration> fileConfigFromMySql)
        {
            return fileConfigFromMySql.Data == null;
        }
    }
}

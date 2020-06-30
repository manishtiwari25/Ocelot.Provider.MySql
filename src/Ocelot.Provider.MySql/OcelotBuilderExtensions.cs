
namespace Ocelot.Provider.MySql
{
    using Configuration.Repository;
    using DependencyInjection;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Ocelot.Cache;
    using Ocelot.Configuration.File;
    using System;

    public static class OcelotBuilderExtensions
    {
        public static IOcelotBuilder AddConfigStoredInMySql(this IOcelotBuilder builder)
        {
            builder.Services.AddSingleton(MySqlMiddlewareConfigurationProvider.Get);
            builder.Services.AddSingleton<IFileConfigurationRepository, MySqlFileConfigurationRepository>();
            builder.Services.AddSingleton<IOcelotCache<FileConfiguration>, OcelotConfigCache>();
            builder.Services.Remove(new ServiceDescriptor(typeof(IFileConfigurationRepository), typeof(DiskFileConfigurationRepository)));
            return builder;
        }
    }
}

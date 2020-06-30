using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;

namespace Ocelot.Provider.MySql
{
    public class OcelotConfigDbContext : DbContext
    {
        public OcelotConfigDbContext(DbContextOptions<OcelotConfigDbContext> options) : base(options)
        {
        }
        public DbSet<OcelotConfiguration> ConfigModels { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<OcelotConfiguration>().Property(o => o.Section).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<OcelotConfiguration>().Property(o => o.Payload).IsRequired();
            modelBuilder.Entity<OcelotConfiguration>().Property(o => o.CreateTime).HasDefaultValue(DateTime.Now).IsRequired();
            modelBuilder.Entity<OcelotConfiguration>().Property(o => o.LastUpdate).HasDefaultValue(DateTime.Now).IsRequired();
            modelBuilder.Entity<OcelotConfiguration>().HasData(new OcelotConfiguration()
            {
                Id=1,
                Payload = @"{
                                'routes': [],
                                'dynamicRoutes': [],
                                'aggregates': [],
                                'globalConfiguration': {
                                'requestIdKey': null,
                                'serviceDiscoveryProvider': {
                                    'scheme': null,
                                    'host': null,
                                    'port': 0,
                                    'type': null,
                                    'token': null,
                                    'configurationKey': null,
                                    'pollingInterval': 0,
                                    'namespace': null
                                    },
        'rateLimitOptions': {
                    'clientIdHeader': 'ClientId',
            'quotaExceededMessage': null,
            'rateLimitCounterPrefix': 'ocelot',
            'disableRateLimitHeaders': false,
            'httpStatusCode': 429
        },
        'qoSOptions': {
                    'exceptionsAllowedBeforeBreaking': 0,
            'durationOfBreak': 0,
            'timeoutValue': 0
        },
        'baseUrl': 'https://localhost:5001',
        'loadBalancerOptions': {
                    'type': null,
            'key': null,
            'expiry': 0
        },
        'downstreamScheme': null,
        'httpHandlerOptions': {
                    'allowAutoRedirect': false,
            'useCookieContainer': false,
            'useTracing': false,
            'useProxy': true,
            'maxConnectionsPerServer': 2147483647
        },
        'downstreamHttpVersion': null
    }
        }'rateLimitOptions': {
                    'clientIdHeader': 'ClientId',
            'quotaExceededMessage': null,
            'rateLimitCounterPrefix': 'ocelot',
            'disableRateLimitHeaders': false,
            'httpStatusCode': 429
        },
        'qoSOptions': {
                    'exceptionsAllowedBeforeBreaking': 0,
            'durationOfBreak': 0,
            'timeoutValue': 0
        },
        'baseUrl': 'https://localhost:5001',
        'loadBalancerOptions': {
                    'type': null,
            'key': null,
            'expiry': 0
        },
        'downstreamScheme': null,
        'httpHandlerOptions': {
                    'allowAutoRedirect': false,
            'useCookieContainer': false,
            'useTracing': false,
            'useProxy': true,
            'maxConnectionsPerServer': 2147483647
        },
        'downstreamHttpVersion': null
    }
        }"
            });
        }

    }
}

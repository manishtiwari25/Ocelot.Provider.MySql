using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace Ocelot.Provider.MySql.Migrations
{
    public partial class AddContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConfigModels",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    section = table.Column<string>(maxLength: 200, nullable: false),
                    payload = table.Column<string>(nullable: false),
                    createTime = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 6, 30, 13, 42, 50, 676, DateTimeKind.Local).AddTicks(7337)),
                    lastUpdate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 6, 30, 13, 42, 50, 679, DateTimeKind.Local).AddTicks(6342))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigModels", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "ConfigModels",
                columns: new[] { "id", "createTime", "lastUpdate", "payload", "section" },
                values: new object[] { 1, new DateTime(2020, 6, 30, 13, 42, 50, 679, DateTimeKind.Local).AddTicks(7471), new DateTime(2020, 6, 30, 13, 42, 50, 679, DateTimeKind.Local).AddTicks(7479), @"{
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
        }", "Ocelot" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfigModels");
        }
    }
}

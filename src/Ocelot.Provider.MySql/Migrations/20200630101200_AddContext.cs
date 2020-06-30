using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;
using System;

namespace Ocelot.Provider.MySql.Migrations
{
    public partial class AddContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "configmodels",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    section = table.Column<string>(maxLength: 200, nullable: false),
                    payload = table.Column<string>(nullable: false),
                    createTime = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 6, 30, 15, 42, 0, 230, DateTimeKind.Local).AddTicks(3390)),
                    lastUpdate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 6, 30, 15, 42, 0, 233, DateTimeKind.Local).AddTicks(7))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_configmodels", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "configmodels",
                columns: new[] { "id", "createTime", "lastUpdate", "payload", "section" },
                values: new object[] { 1, new DateTime(2020, 6, 30, 15, 42, 0, 233, DateTimeKind.Local).AddTicks(1038), new DateTime(2020, 6, 30, 15, 42, 0, 233, DateTimeKind.Local).AddTicks(1046), "{   \"routes\":[   ],   \"dynamicRoutes\":[   ],   \"aggregates\":[   ],   \"globalConfiguration\":{      \"requestIdKey\":\"OcRequestId\",      \"serviceDiscoveryProvider\":{         \"scheme\":null,         \"host\":null,         \"port\":0,         \"type\":null,         \"token\":null,         \"configurationKey\":null,         \"pollingInterval\":0,         \"namespace\":null      },      \"rateLimitOptions\":{         \"clientIdHeader\":\"ClientId\",         \"quotaExceededMessage\":null,         \"rateLimitCounterPrefix\":\"ocelot\",         \"disableRateLimitHeaders\":false,         \"httpStatusCode\":429      },      \"qoSOptions\":{         \"exceptionsAllowedBeforeBreaking\":0,         \"durationOfBreak\":0,         \"timeoutValue\":0      },      \"baseUrl\":\"https://localhost:5001\",      \"loadBalancerOptions\":{         \"type\":null,         \"key\":null,         \"expiry\":0      },      \"downstreamScheme\":null,      \"httpHandlerOptions\":{         \"allowAutoRedirect\":false,         \"useCookieContainer\":false,         \"useTracing\":false,         \"useProxy\":true,         \"maxConnectionsPerServer\":2147483647      },      \"downstreamHttpVersion\":null   }}", "Ocelot" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "configmodels");
        }
    }
}

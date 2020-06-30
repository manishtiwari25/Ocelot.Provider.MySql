﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Ocelot.Provider.MySql;

namespace Ocelot.Provider.MySql.Migrations
{
    [DbContext(typeof(OcelotConfigDbContext))]
    [Migration("20200630101200_AddContext")]
    partial class AddContext
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Ocelot.Provider.MySql.OcelotConfiguration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("createTime")
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2020, 6, 30, 15, 42, 0, 230, DateTimeKind.Local).AddTicks(3390));

                    b.Property<DateTime>("LastUpdate")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("lastUpdate")
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2020, 6, 30, 15, 42, 0, 233, DateTimeKind.Local).AddTicks(7));

                    b.Property<string>("Payload")
                        .IsRequired()
                        .HasColumnName("payload")
                        .HasColumnType("text");

                    b.Property<string>("Section")
                        .IsRequired()
                        .HasColumnName("section")
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("ConfigModels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateTime = new DateTime(2020, 6, 30, 15, 42, 0, 233, DateTimeKind.Local).AddTicks(1038),
                            LastUpdate = new DateTime(2020, 6, 30, 15, 42, 0, 233, DateTimeKind.Local).AddTicks(1046),
                            Payload = "{   \"routes\":[   ],   \"dynamicRoutes\":[   ],   \"aggregates\":[   ],   \"globalConfiguration\":{      \"requestIdKey\":\"OcRequestId\",      \"serviceDiscoveryProvider\":{         \"scheme\":null,         \"host\":null,         \"port\":0,         \"type\":null,         \"token\":null,         \"configurationKey\":null,         \"pollingInterval\":0,         \"namespace\":null      },      \"rateLimitOptions\":{         \"clientIdHeader\":\"ClientId\",         \"quotaExceededMessage\":null,         \"rateLimitCounterPrefix\":\"ocelot\",         \"disableRateLimitHeaders\":false,         \"httpStatusCode\":429      },      \"qoSOptions\":{         \"exceptionsAllowedBeforeBreaking\":0,         \"durationOfBreak\":0,         \"timeoutValue\":0      },      \"baseUrl\":\"https://localhost:5001\",      \"loadBalancerOptions\":{         \"type\":null,         \"key\":null,         \"expiry\":0      },      \"downstreamScheme\":null,      \"httpHandlerOptions\":{         \"allowAutoRedirect\":false,         \"useCookieContainer\":false,         \"useTracing\":false,         \"useProxy\":true,         \"maxConnectionsPerServer\":2147483647      },      \"downstreamHttpVersion\":null   }}",
                            Section = "Ocelot"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
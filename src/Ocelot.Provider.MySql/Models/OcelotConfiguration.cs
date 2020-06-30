using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ocelot.Provider.MySql
{
    public class OcelotConfiguration
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("section")]
        public string Section { get; set; } = OcelotConfigurationSection.All;
        [Column("payload")]
        public string Payload { get; set; }
        [Column("createTime")]
        public DateTime CreateTime { get; set; } = DateTime.Now;
        [Column("lastUpdate")]
        public DateTime LastUpdate { get; set; } = DateTime.Now;
    }
}

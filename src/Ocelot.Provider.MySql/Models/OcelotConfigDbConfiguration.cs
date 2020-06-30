namespace Ocelot.Provider.MySql
{
    public class OcelotConfigDbConfiguration
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string ConfigTableName { get; set; } = "configmodels";
    }
}

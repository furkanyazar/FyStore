namespace Core.CrossCuttingConcerns.Logging.Serilog.ConfigurationModels
{
    public class MsSqlConfiguration
    {
        public string ConnectionString { get; set; }
        public string TableName { get; set; }
    }
}

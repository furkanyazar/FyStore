using Core.CrossCuttingConcerns.Logging.Serilog.ConfigurationModels;
using Core.CrossCuttingConcerns.Logging.Serilog.Messages;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Sinks.MSSqlServer;

namespace Core.CrossCuttingConcerns.Logging.Serilog.Loggers
{
    public class MsSqlLogger : LoggerServiceBase
    {
        private IConfiguration _configuration;

        public MsSqlLogger(IConfiguration configuration)
        {
            _configuration = configuration;

            var logConfig = configuration.GetSection("SeriLogConfigurations:MsSqlConfiguration")
                                .Get<MsSqlConfiguration>() ??
                            throw new Exception(SerilogMessages.NullOptionsMessage);

            var conString = logConfig.ConnectionString;
            var tableName = logConfig.TableName;

            Logger = new LoggerConfiguration()
                .WriteTo.MSSqlServer(
                    connectionString: conString,
                    sinkOptions: new MSSqlServerSinkOptions { TableName = tableName })
                .CreateLogger();
        }
    }
}

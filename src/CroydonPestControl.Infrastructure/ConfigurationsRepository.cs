using CroydonPestControl.Infrastructure.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace CroydonPestControl.Infrastructure
{
    public class ConfigurationsRepository : BaseRepository, IConfigurationsRepository
    {
        private readonly ILogger<ConfigurationsRepository> _logger;
        public ConfigurationsRepository(IConfiguration config, ILogger<ConfigurationsRepository> logger) : base(config)
        {
            _logger = logger;
        }

        public async Task<string> GetPestControlConfigAsync()
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("Result", dbType: DbType.Xml, direction: ParameterDirection.Output);

                _logger.LogInformation("Calling stored procedure dbo.GetDictionaryList with Parameters:  {@0}", param);

                return await WithConnection(async c =>
                {
                    var result = await c.ExecuteAsync("dbo.GetDictionaryList", param, commandType: CommandType.StoredProcedure);
                    return param.Get<string>("@Result");
                });
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
           
        }

        public async Task<string> GetTreatmentConfigAsync()
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("Config", dbType: DbType.Xml, direction: ParameterDirection.Output);

                _logger.LogInformation("Calling stored procedure dbo.GetTreatmentConfig with Parameters:  {0}", param);

                return await WithConnection(async c =>
                {
                    var result = await c.ExecuteAsync("dbo.GetTreatmentConfig", param, commandType: CommandType.StoredProcedure);
                    return param.Get<string>("@Config");
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
           
        }
    }
}

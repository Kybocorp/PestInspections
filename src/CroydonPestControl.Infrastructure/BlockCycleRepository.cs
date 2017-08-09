using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CroydonPestControl.Infrastructure.Interfaces;
using CroydonPestControl.Infrastructure.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Dapper;
using System.Data;

namespace CroydonPestControl.Infrastructure
{
    public class BlockCycleRepository : BaseRepository, IBlockCycleRepository
    {
        private readonly ILogger<BlockCycleRepository> _logger;
        public BlockCycleRepository(IConfiguration config, ILogger<BlockCycleRepository> logger) 
            : base(config)
        {
            _logger = logger;
        }

        public Task<BlockCycle> AddBlockCycleAsync(AddBlockCycleRequest addBlockCycleRequest)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddBlocksAsync(string requestXml)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BlockCycle>> GetBlockCyclesAsync()
        {
            try
            {
                _logger.LogInformation("Calling stored procedure dbo.GetBlockCyclesAsync ");
                return await WithConnection(async c =>
                {
                    return await c.QueryAsync<BlockCycle>("dbo.GetBlockCycles", commandType: CommandType.StoredProcedure);
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

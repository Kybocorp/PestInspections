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

        public async Task<int> AddBlockCycleAsync(AddBlockCycleRequest addBlockCycleRequest)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("StartDate", addBlockCycleRequest.StartDate, dbType: DbType.DateTime);
                param.Add("EndDate", addBlockCycleRequest.EndDate, dbType: DbType.DateTime);
              

                _logger.LogInformation($"Calling stored procedure BlockCycle.AddBlockCycle with Parameters:[StartDate: {addBlockCycleRequest.StartDate}, EndDate:{addBlockCycleRequest.EndDate}");

                return await WithConnection(async c =>
                {
                    return await c.ExecuteAsync("BlockCycle.AddBlockCycle", param, commandType: CommandType.StoredProcedure);
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public Task<bool> AddBlocksAsync(string requestXml)
        {
            throw new NotImplementedException();
        }

        public async Task<int> AddBlockToBlockCycleAsync(AddBlockToBlockCycleRequest request)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("BlockCycleId", request.BlockCycleId, dbType: DbType.Int32);
                param.Add("BlockId", request.BlockId, dbType: DbType.Int32);
                param.Add("StartDate", request.StartDate, dbType: DbType.DateTime);


                _logger.LogInformation($"Calling stored procedure BlockCycle.AddBlockCycle with Parameters:[StartDate: {request.StartDate}, BlockCycleId:{request.BlockCycleId}, BlockId:{request.BlockId}");

                return await WithConnection(async c =>
                {
                    return await c.ExecuteAsync("BlockCycle.AddBlockToBlockCycle", param, commandType: CommandType.StoredProcedure);
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
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

        public async Task<IEnumerable<Block>> GetBlocksByBlockCycleIdAsync(int blockCycleId)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("BlockCycleId", blockCycleId, dbType: DbType.Int32);

                _logger.LogInformation($"Calling stored procedure [BlockCycle].[GetBlocksByBlockCycleId] with blockCycleId : {blockCycleId}");
                return await WithConnection(async c =>
                {
                    return await c.QueryAsync<Block>("BlockCycle.GetBlocksByBlockCycleId", commandType: CommandType.StoredProcedure);
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Property>> GetPropertiesByBlockIdAsync(int blockId)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("BlockId", blockId, dbType: DbType.Int32);

                _logger.LogInformation($"Calling stored procedure [BlockCycle].[GetPropertiesByBlockId] with blockId : {blockId}");
                return await WithConnection(async c =>
                {
                    return await c.QueryAsync<Property>("BlockCycle.GetPropertiesByBlockId", commandType: CommandType.StoredProcedure);
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

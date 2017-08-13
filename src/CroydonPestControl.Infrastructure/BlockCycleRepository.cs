using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CroydonPestControl.Infrastructure.Interfaces;
using CroydonPestControl.Infrastructure.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Dapper;
using System.Data;
using System.Linq;

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

        public async Task<BlockCycle> AddBlockCycleAsync(AddBlockCycleRequest addBlockCycleRequest)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("StartDate", addBlockCycleRequest.StartDate, dbType: DbType.DateTime);
                param.Add("EndDate", addBlockCycleRequest.EndDate, dbType: DbType.DateTime);
              

                _logger.LogInformation($"Calling stored procedure BlockCycle.AddBlockCycle with Parameters:[StartDate: {addBlockCycleRequest.StartDate}, EndDate:{addBlockCycleRequest.EndDate}");

                var blockCycle = await WithConnection(async c =>
                {
                    return await c.QueryAsync<BlockCycle>("BlockCycle.AddBlockCycle", param, commandType: CommandType.StoredProcedure);
                });
                return blockCycle.FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> AssignBlocksToBlockCycleAsync(string requestXml)
        {
            try
            {
                _logger.LogInformation($"Calling stored procedure BlockCycle.UpdateBlockCycleBlocks with requestXml:{requestXml}");
                var param = new DynamicParameters();
                param.Add("BlockList", requestXml, dbType: DbType.Xml);
                param.Add("Result", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                return await WithConnection(async c =>
                {
                    await c.ExecuteAsync("BlockCycle.UpdateBlockCycleBlocks", param, commandType: CommandType.StoredProcedure);
                    return param.Get<bool>("@Result");
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<Block> AddBlockToBlockCycleAsync(AddBlockToBlockCycleRequest request)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("BlockCycleId", request.BlockCycleId, dbType: DbType.Int32);
                param.Add("BlockId", request.BlockId, dbType: DbType.Int32);
                param.Add("StartDate", request.StartDate, dbType: DbType.DateTime);


                _logger.LogInformation($"Calling stored procedure [BlockCycle].[AddBlockToBlockCycle] with Parameters:[StartDate: {request.StartDate}, BlockCycleId:{request.BlockCycleId}, BlockId:{request.BlockId}");

                return await WithConnection(async c =>
                {
                    return await c.ExecuteScalarAsync<Block>("BlockCycle.AddBlockToBlockCycle", param, commandType: CommandType.StoredProcedure);
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
                    return await c.QueryAsync<BlockCycle>("BlockCycle.GetBlockCycles", commandType: CommandType.StoredProcedure);
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
                    return await c.QueryAsync<Block>("BlockCycle.GetBlocksByBlockCycleId", param, commandType: CommandType.StoredProcedure);
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Property>> GetPropertiesByBlockIdAsync(int blockId, int blockCycleId)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("BlockId", blockId, dbType: DbType.Int32);
                param.Add("BlockCycleId", blockCycleId, dbType: DbType.Int32);


                _logger.LogInformation($"Calling stored procedure [BlockCycle].[GetPropertiesByBlockId] with blockId : {blockId}");
                return await WithConnection(async c =>
                {
                    return await c.QueryAsync<Property>("BlockCycle.GetPropertiesByBlockId",param, commandType: CommandType.StoredProcedure);
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateBlockCycleAsync(BlockCycle blockCycle)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("BlockCycleId", blockCycle.BlockCycleId, dbType: DbType.Int32);
                param.Add("StartDate", blockCycle.StartDate, dbType: DbType.DateTime);
                param.Add("EndDate", blockCycle.EndDate, dbType: DbType.DateTime);
                param.Add("StatusId", blockCycle.StatusId, dbType: DbType.Int32);

                _logger.LogInformation("Calling stored procedure [BlockCycle].[UpdateBlockCycle] with blockCycle : {@0}", blockCycle);
                await WithConnection(async c =>
                {
                    return await c.ExecuteAsync("BlockCycle.UpdateBlockCycle",param, commandType: CommandType.StoredProcedure);
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateBlockCyclePropertyAsync(UpdateBlockCyclePropertyRequest updateBlockCyclePropertyRequest)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("BlockCycleId", updateBlockCyclePropertyRequest.BlockCycleId, dbType: DbType.Int32);
                param.Add("PropertyId", updateBlockCyclePropertyRequest.PropertyId, dbType: DbType.Int32);
                param.Add("StatusId", updateBlockCyclePropertyRequest.StatusId, dbType: DbType.Int32);
                param.Add("AmPm", updateBlockCyclePropertyRequest.AmPm, dbType: DbType.String);
                param.Add("NextInspectionDate", updateBlockCyclePropertyRequest.NextInspectionDate, dbType: DbType.DateTime);
                param.Add("Comments", updateBlockCyclePropertyRequest.Comments, dbType: DbType.String);
                param.Add("LastUpdatedBy", updateBlockCyclePropertyRequest.LastUpdatedBy, dbType: DbType.Int32);

                _logger.LogInformation("Calling stored procedure [BlockCycle].[UpdateBlockCycleProperty] with blockCycle : {@0}", updateBlockCyclePropertyRequest);
                await WithConnection(async c =>
                {
                    return await c.ExecuteAsync("BlockCycle.UpdateBlockCycleProperty", commandType: CommandType.StoredProcedure);
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

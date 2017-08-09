using System;
using System.Threading.Tasks;
using CroydonPestControl.Infrastructure.Interfaces;
using CroydonPestControl.Infrastructure.Models;
using Microsoft.Extensions.Configuration;

namespace CroydonPestControl.Infrastructure
{
    public class BlockCycleRepository : BaseRepository, IBlockCycleRepository
    {
        public BlockCycleRepository(IConfiguration config) : base(config)
        {
        }

        public Task<BlockCycle> AddBlockCycleAsync(AddBlockCycleRequest addBlockCycleRequest)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddBlocksAsync(string requestXml)
        {
            throw new NotImplementedException();
        }
    }
}

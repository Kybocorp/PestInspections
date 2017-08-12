using CroydonPestControl.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CroydonPestControl.Infrastructure.Interfaces
{
    public interface IBlockCycleRepository
    {
        Task<BlockCycle> AddBlockCycleAsync(AddBlockCycleRequest addBlockCycleRequest);
        Task<bool> AssignBlocksToBlockCycleAsync(string requestXml);
        Task<IEnumerable<BlockCycle>> GetBlockCyclesAsync();
        Task<IEnumerable<Block>> GetBlocksByBlockCycleIdAsync(int blockCycleId);
        Task<Block> AddBlockToBlockCycleAsync(AddBlockToBlockCycleRequest request);
        Task<IEnumerable<Property>> GetPropertiesByBlockIdAsync(int blockId);
    }
}

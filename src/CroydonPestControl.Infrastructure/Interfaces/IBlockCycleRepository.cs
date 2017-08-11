using CroydonPestControl.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CroydonPestControl.Infrastructure.Interfaces
{
    public interface IBlockCycleRepository
    {
        Task<int> AddBlockCycleAsync(AddBlockCycleRequest addBlockCycleRequest);
        Task<bool> AddBlocksAsync(string requestXml);
        Task<IEnumerable<BlockCycle>> GetBlockCyclesAsync();
        Task<IEnumerable<Block>> GetBlocksByBlockCycleIdAsync(int blockCycleId);
        Task<int> AddBlockToBlockCycleAsync(AddBlockToBlockCycleRequest request);
        Task<IEnumerable<Property>> GetPropertiesByBlockIdAsync(int blockId);
    }
}

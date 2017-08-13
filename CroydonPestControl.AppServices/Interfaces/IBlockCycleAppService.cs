using CroydonPestControl.AppServices.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CroydonPestControl.AppServices.Interfaces
{
    public interface IBlockCycleAppService
    {
        Task<BlockCycle> AddBlockCycleAsync(AddBlockCycleRequest request);
        Task<bool> AssignBlocksToBlockCycleAsync(string requestXml);
        Task<IEnumerable<BlockCycle>> GetBlockCyclesAsync();
        Task UpdateBlockCycleAsync(BlockCycle blockCycle);
        Task UpdateBlockCyclePropertyAsync(UpdateBlockCyclePropertyRequest request);
    }
}

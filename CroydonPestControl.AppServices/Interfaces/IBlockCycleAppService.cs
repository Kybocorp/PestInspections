using CroydonPestControl.AppServices.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CroydonPestControl.AppServices.Interfaces
{
    public interface IBlockCycleAppService
    {
        Task<int> AddBlockCycleAsync(AddBlockCycleRequest request);
        Task<bool> AddBlocksAsync(string requestXml);
        Task<IEnumerable<BlockCycle>> GetBlockCyclesAsync();
    }
}

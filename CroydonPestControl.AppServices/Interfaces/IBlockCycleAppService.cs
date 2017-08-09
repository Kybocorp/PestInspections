using CroydonPestControl.AppServices.Models;
using System.Threading.Tasks;

namespace CroydonPestControl.AppServices.Interfaces
{
    public interface IBlockCycleAppService
    {
        Task<BlockCycle> AddBlockCycleAsync(AddBlockCycleRequest request);
        Task<bool> AddBlocksAsync(string requestXml);
    }
}

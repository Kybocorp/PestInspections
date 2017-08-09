using CroydonPestControl.Infrastructure.Models;
using System.Threading.Tasks;

namespace CroydonPestControl.Infrastructure.Interfaces
{
    public interface IBlockCycleRepository
    {
        Task<BlockCycle> AddBlockCycleAsync(AddBlockCycleRequest addBlockCycleRequest);
        Task<bool> AddBlocksAsync(string requestXml);
    }
}

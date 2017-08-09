using CroydonPestControl.AppServices.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CroydonPestControl.AppServices.Interfaces
{
    public interface IBlocksAppService
    {
        Task<IEnumerable<Block>> GetAllBlocksAsync();
    }
}

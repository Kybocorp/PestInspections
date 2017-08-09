using CroydonPestControl.API.Models;
using System.Collections.Generic;

namespace CroydonPestControl.API.Controllers.Models
{
    public class AddBlocksRequest
    {
        public int BlockCycleId { get; set; }
        public IEnumerable<Block> Blocks { get; set; }
    }
}
using System;
using System.Threading.Tasks;
using CroydonPestControl.AppServices.Interfaces;
using CroydonPestControl.AppServices.Models;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace CroydonPestControl.AppServices
{
    public class BlocksAppService : IBlocksAppService
    {
        private readonly ILogger<BlocksAppService> _logger;
        public BlocksAppService(ILogger<BlocksAppService> logger)
        {
            _logger = logger;
        }
        public Task<IEnumerable<Block>> GetAllBlocksAsync()
        {
            throw new NotImplementedException();
        }
    }
}

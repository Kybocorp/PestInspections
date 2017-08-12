using System;
using System.Threading.Tasks;
using CroydonPestControl.AppServices.Interfaces;
using CroydonPestControl.AppServices.Models;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using CroydonPestControl.Infrastructure.Interfaces;
using AutoMapper;

namespace CroydonPestControl.AppServices
{
    public class BlocksAppService : IBlocksAppService
    {
        private readonly ILogger<BlocksAppService> _logger;
        private readonly IBlockCycleRepository _blockCycleRepository;
        private readonly IMapper _mapper;

        public BlocksAppService(ILogger<BlocksAppService> logger, IBlockCycleRepository blockCycleRepository, IMapper mapper)
        {
            _logger = logger;
            _blockCycleRepository = blockCycleRepository;
            _mapper = mapper;
        }
        public Task<IEnumerable<Block>> GetAllBlocksAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Block>> GetBlocksByBlockCycleIdAsync(int blockCycleId)
        {
            return _mapper.Map<IEnumerable<Block>>(await _blockCycleRepository.GetBlocksByBlockCycleIdAsync(blockCycleId));
        }

        public async Task<Block> AddBlockToBlockCycleAsync(AddBlockToBlockCycleRequest request)
        {
            return _mapper.Map<Block>(await _blockCycleRepository.AddBlockToBlockCycleAsync(_mapper.Map< Infrastructure.Models.AddBlockToBlockCycleRequest> (request)));
        }
    }
}

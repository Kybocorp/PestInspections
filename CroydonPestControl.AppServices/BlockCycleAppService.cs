using CroydonPestControl.AppServices.Interfaces;
using System;
using System.Threading.Tasks;
using CroydonPestControl.AppServices.Models;
using CroydonPestControl.Infrastructure.Interfaces;
using AutoMapper;
using System.Collections.Generic;

namespace CroydonPestControl.AppServices
{
    public class BlockCycleAppService : IBlockCycleAppService
    {
        private readonly IBlockCycleRepository _blockCycleRepository;
        private readonly IMapper _mapper;

        public BlockCycleAppService(IBlockCycleRepository blockCycleRepository, IMapper mapper)
        {
            _blockCycleRepository = blockCycleRepository;
            _mapper = mapper;
        }

        public async Task<BlockCycle> AddBlockCycleAsync(AddBlockCycleRequest request)
        {
            return _mapper.Map<BlockCycle>(await _blockCycleRepository.AddBlockCycleAsync(_mapper.Map<Infrastructure.Models.AddBlockCycleRequest>(request)));
        }
        public async Task<bool> AddBlocksAsync(string requestXml)
        {
            return await _blockCycleRepository.AddBlocksAsync(requestXml);
        }

        public async Task<IEnumerable<BlockCycle>> GetBlockCyclesAsync()
        {
            return _mapper.Map<IEnumerable<BlockCycle>>(await _blockCycleRepository.GetBlockCyclesAsync());
        }
    }
}

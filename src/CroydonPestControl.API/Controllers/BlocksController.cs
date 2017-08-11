using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CroydonPestControl.AppServices.Interfaces;
using AutoMapper;
using CroydonPestControl.AppServices.Models;

namespace CroydonPestControl.API.Controllers
{
    [Route("api/[controller]")]
    public class BlocksController : Controller
    {
        private readonly IBlocksAppService _blocksAppService;
        private readonly ILogger<BlocksController> _logger;
        private readonly IMapper _mapper;
        public BlocksController(IBlocksAppService blocksAppService, ILogger<BlocksController> logger, IMapper mapper)
        {
            _blocksAppService = blocksAppService;
            _logger = logger;
            _mapper = mapper;
        }
        /// <summary>
        /// Get Blocks by Block Cycle Id
        /// </summary>
        /// <returns>list of Block objects</returns>
        [HttpGet]
        public async Task<IActionResult> Get(int blockCycleId)
        {
            _logger.LogInformation("Calling Getfrom BlocksController");
            return Ok(await _blocksAppService.GetBlocksByBlockCycleIdAsync(blockCycleId));
        }

        /// <summary>
        /// Adds Block To BlockCycle
        /// </summary>
        /// <returns>The Newly Block Id created</returns>
        [HttpPost]
        public async Task<IActionResult> AddBlockToBlockCycle([FromBody]AddBlockToBlockCycleRequest request)
        {
            _logger.LogInformation("Calling AddBlockToBlockCycle from BlockCycleController with request : {@0}", request);
            if (!ModelState.IsValid) return BadRequest();
            return Ok(await _blocksAppService.AddBlockToBlockCycleAsync(_mapper.Map<AddBlockToBlockCycleRequest>(request)));
        }
    }
}

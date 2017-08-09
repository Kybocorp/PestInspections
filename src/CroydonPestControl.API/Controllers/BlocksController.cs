using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CroydonPestControl.AppServices.Interfaces;

namespace CroydonPestControl.API.Controllers
{
    [Route("api/[controller]")]
    public class BlocksController : Controller
    {
        private readonly IBlocksAppService _blocksAppService;
        private readonly ILogger<BlocksController> _logger;
        public BlocksController(IBlocksAppService blocksAppService, ILogger<BlocksController> logger)
        {
            _blocksAppService = blocksAppService;
            _logger = logger;
        }
        /// <summary>
        /// Get All Blocks
        /// </summary>
        /// <returns>list of Block object</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("Calling Getfrom BlocksController");
            return Ok(await _blocksAppService.GetAllBlocksAsync());
        }
    }
}

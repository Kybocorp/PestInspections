using AutoMapper;
using CroydonPestControl.API.Controllers.Models;
using CroydonPestControl.API.Models;
using CroydonPestControl.AppServices.Interfaces;
using CroydonPestControl.Core.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CroydonPestControl.API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class BlockCycleController : Controller
    {
        private readonly IBlockCycleAppService _blockCycleAppService;
        private readonly IXmlHelper _xmlHelper;
        private readonly ILogger<InspectionController> _logger;
        private readonly IMapper _mapper;

        public BlockCycleController(IBlockCycleAppService blockCycleAppService, IXmlHelper xmlHelper, ILogger<InspectionController> logger, IMapper mapper)
        {
            _blockCycleAppService = blockCycleAppService;
            _xmlHelper = xmlHelper;
            _logger = logger;
            _mapper = mapper;
        }
        /// <summary>
        /// Add BlockCycle
        /// </summary>
        /// <returns>The New BlockCycle object created</returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody]AddBlockCycleRequest request)
        {
            _logger.LogInformation("Calling Add from BlockCycleController with request : {@0}", request);
            if (!ModelState.IsValid) return BadRequest();
            var response = await _blockCycleAppService.AddBlockCycleAsync(_mapper.Map<AppServices.Models.AddBlockCycleRequest>(request));
            if (response==null) return NotFound();
            return Ok(response);
        }

        /// <summary>
        /// Add Blocks to BlockCycle
        /// </summary>
        /// <returns>200 status code</returns>
        [HttpPost]
        public async Task<IActionResult> AddBlocks([FromBody]AddBlocksRequest request)
        {
            _logger.LogInformation("Calling Add from BlockCycleController with request : {@0}", request);
            if (!ModelState.IsValid) return BadRequest();
            var requestXml = _xmlHelper.ConvertToXml(request);
            if (!await _blockCycleAppService.AddBlocksAsync(requestXml)) return NotFound();
            return Ok();
        }

       
    }
}

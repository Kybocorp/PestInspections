using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using CroydonPestControl.AppServices.Interfaces;

namespace CroydonPestControl.API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class PropertiesController : Controller
    {
        private readonly IPropertiesAppService _propertiesAppService;
        private readonly ILogger<PropertiesController> _logger;
        public PropertiesController(IPropertiesAppService propertiesAppService, ILogger<PropertiesController> logger)
        {
            _propertiesAppService = propertiesAppService;
            _logger = logger;
        }
        /// <summary>
        /// Get All Properties by blockId
        /// </summary>
        /// <returns>list of Property object</returns>
        [HttpGet("{blockId}")]
        public async Task<IActionResult> GetByBlockId(int blockId)
        {
            _logger.LogInformation("Calling Get from PropertiesController");
            return Ok(await _propertiesAppService.GetPropertiesByBlockIdAsync(blockId));
        }
    }
}

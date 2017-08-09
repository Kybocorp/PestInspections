using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CroydonPestControl.AppServices.Interfaces;
using CroydonPestControl.Core.Helpers;
using CroydonPestControl.API.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace CroydonPestControl.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class ConfigurationsController : Controller
    {
        private readonly IConfigurationsAppService _configurationsAppService;
        private readonly IXmlHelper _xmlHelper;
        private readonly ILogger<ConfigurationsController> _logger;

        public ConfigurationsController(IConfigurationsAppService configurationsAppService, IXmlHelper xmlHelper, ILogger<ConfigurationsController> logger)
        {
            _configurationsAppService = configurationsAppService;
            _xmlHelper = xmlHelper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<Dictionary> GetPestControlConfig()
        {
            _logger.LogInformation("Calling GetPestControlConfig from ConfigurationsController");
            return _xmlHelper.ConvertFromXml<Dictionary>(await _configurationsAppService.GetPestControlConfigAsync());
        }

        [HttpGet]
        public async Task<TreatmentConfig> GetTreatmentConfig()
        {
            _logger.LogInformation("Calling GetTreatmentConfig from ConfigurationsController");
            return _xmlHelper.ConvertFromXml<TreatmentConfig>(await _configurationsAppService.GetTreatmentConfigAsync());
        }
    }
}
    
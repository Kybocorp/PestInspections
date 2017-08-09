using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CroydonPestControl.AppServices.Interfaces;
using System.Threading.Tasks;
using CroydonPestControl.AppServices.Models;
using CroydonPestControl.API.Models;
using CroydonPestControl.Core.Helpers;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;

namespace CroydonPestControl.API.Controllers
{
    [Route("api/[controller]/[action]")]
    //[Authorize]
    public class InspectionController : Controller
    {
        private readonly IInspectionAppService _inspectionAppService;
        private readonly IXmlHelper _xmlHelper;
        private readonly ILogger<InspectionController> _logger;
        private readonly IMapper _mapper;
        public InspectionController(IInspectionAppService inspectionAppService, IXmlHelper xmlHelper, ILogger<InspectionController> logger, IMapper mapper)
        {
            _inspectionAppService = inspectionAppService;
            _xmlHelper = xmlHelper;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Get inspections by userId
        /// </summary>
        /// <returns>list of Inspection object</returns>
        [HttpGet("{userId}")]
        public async Task<IEnumerable<InspectionViewModel>> GetInspectionsByUserId(int userId)
        {
            _logger.LogInformation("Calling GetInspectionsByUserId from InspectionController with UserId : {0}", userId);
            return await _inspectionAppService.GetInspectionsByUserIdAsync(userId);
        }

        /// <summary>
        /// Save inspection
        /// </summary>
        /// <returns>200 status code</returns>
        [HttpPost]
        public async Task<IActionResult> SaveInspection([FromBody]InspectionRequest inspectionRequest)
        {
            _logger.LogInformation("Calling SaveInspection from InspectionController with request : {@0}", inspectionRequest);
            if (!ModelState.IsValid) return BadRequest();
            var inspection = _xmlHelper.ConvertToXml(inspectionRequest);
            if (!await _inspectionAppService.SaveInspectionAsync(inspection)) return NotFound();
            return Ok();
        }

        /// <summary>
        /// Save inspection
        /// </summary>
        /// <returns>200 status code</returns>
        [HttpPost]
        public async Task<IActionResult> UpdateInspectionNoAccess([FromBody] API.Models.UpdateInspectionRequest request)
        {
            _logger.LogInformation("Calling UpdateInspectionNoAccess from InspectionController with request : {@0}", request);
            if (!ModelState.IsValid) return BadRequest();
            if (!await _inspectionAppService.UpdateInspectionNoAccessAsync(_mapper.Map<AppServices.Models.UpdateInspectionRequest>(request))) return NotFound();
            return Ok();
        }
        /// <summary>
        /// Get follow up dates for inspection
        /// </summary>
        /// <returns>200 status code</returns>
        [HttpPost]
        public async Task<IActionResult> GetFollowUpDates([FromBody] FollowUpDatesRequest request)
        {
            _logger.LogInformation("Calling GetFollowUpDates from InspectionController with request : {@0}", request);
            if (!ModelState.IsValid) return BadRequest();
            return Ok(await _inspectionAppService.GetFollowUpDatesAsync(request.InspectionId, string.Join("|",request.Pests)));  
        }
    }
}

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CroydonPestControl.AppServices.Models;
using CroydonPestControl.AppServices.Interfaces;
using CroydonPestControl.API.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace CroydonPestControl.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IAdminAppService _adminAppService;
        private readonly ILogger<AdminController> _logger;
        public AdminController(IAdminAppService adminAppService, ILogger<AdminController> logger)
        {
            _adminAppService = adminAppService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> GetAllInspections([FromBody] GetAllInspectionsRequest request)
        {
            _logger.LogInformation("Calling GetAllInspections from AdminController with request: {@0}", request);
            if (!ModelState.IsValid) return BadRequest();
            return Ok(await _adminAppService.GetAllInspectionsAsync(request.UserId,request.InspectionDate));
        }

        [HttpGet]
        public async Task<IEnumerable<OfficerViewModel>> GetAllOfficers()
        {
            _logger.LogInformation("Calling GetAllOfficers from AdminController");
            return await _adminAppService.GetAllOfficersAsync();
        }
        
        [HttpPost]
        public async Task<IActionResult> AssignInspections([FromBody] AssignInspectionsRequest request)
        {
            _logger.LogInformation("Calling AssignInspections from AdminController with request: {@0}", request);
            if (!ModelState.IsValid) return BadRequest();
            if (!await _adminAppService.AssignInspectionsAsync(request)) return NotFound();
            return Ok();
        }
    }
}

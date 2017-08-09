using CroydonPestControl.AppServices.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CroydonPestControl.AppServices.Interfaces
{
    public interface IAdminAppService
    {
        Task<IEnumerable<InspectionViewModel>> GetAllInspectionsAsync(int userId, DateTime? inspectionDate = null);
        Task<IEnumerable<OfficerViewModel>> GetAllOfficersAsync();
        Task<bool> AssignInspectionsAsync(AssignInspectionsRequest request);
    }
}

using CroydonPestControl.AppServices.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CroydonPestControl.AppServices.Interfaces
{
    public interface IInspectionAppService
    {
        Task<IEnumerable<InspectionViewModel>> GetInspectionsByUserIdAsync(int userId);
        Task<bool> SaveInspectionAsync(string inspection);
        Task<bool> UpdateInspectionNoAccessAsync(UpdateInspectionRequest request);
        Task<IEnumerable<FollowUpDatesResponse>> GetFollowUpDatesAsync(int inspectionId, string pests);
    }
}

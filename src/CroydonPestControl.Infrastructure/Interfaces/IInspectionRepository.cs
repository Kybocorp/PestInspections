using CroydonPestControl.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CroydonPestControl.Infrastructure.Interfaces
{
    public interface IInspectionRepository
    {
        Task<List<Inspection>> GetInspectionsByUserIdAsync(int userId);
        Task<bool> SaveInspectionAsync(string inspection);
        Task<IEnumerable<Inspection>> GetAllInspectionsAsync(int userId, DateTime? inspectionDate = null);
        Task<bool> AssignInspectionsAsync(AssignInspectionsRequest request);
        Task<IEnumerable<Officer>> GetAllOfficersAsync();
        Task<bool> UpdateInspectionNoAccessAsync(UpdateInspectionRequest request);
        Task<IEnumerable<FollowUpDatesResponse>> GetFollowUpDatesAsync(int inspectionId, string pests);
        Task<IEnumerable<Inspection>> GetInspectionsByPropertyIdAsync(int propertyId);
    }
}

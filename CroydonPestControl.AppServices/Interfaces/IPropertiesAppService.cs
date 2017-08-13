using CroydonPestControl.AppServices.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CroydonPestControl.AppServices.Interfaces
{
    public interface IPropertiesAppService
    {
        Task<IEnumerable<Property>> GetPropertiesByBlockIdAsync(int blockId,int blockCycleId);
        Task<IEnumerable<InspectionViewModel>> GetInspectionsByPropertyIdAsync(int propertyId);
    }
}

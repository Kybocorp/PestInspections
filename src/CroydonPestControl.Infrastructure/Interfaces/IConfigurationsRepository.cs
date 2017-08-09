using CroydonPestControl.Infrastructure.Models;
using System.Threading.Tasks;

namespace CroydonPestControl.Infrastructure.Interfaces
{
    public interface IConfigurationsRepository
    {
        Task<string> GetPestControlConfigAsync();
        Task<string> GetTreatmentConfigAsync();
    }
}

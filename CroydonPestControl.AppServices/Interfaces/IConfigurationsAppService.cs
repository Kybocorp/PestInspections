using System.Threading.Tasks;

namespace CroydonPestControl.AppServices.Interfaces
{
    public interface IConfigurationsAppService
    {
        Task<string> GetPestControlConfigAsync();
        Task<string> GetTreatmentConfigAsync();
    }
}

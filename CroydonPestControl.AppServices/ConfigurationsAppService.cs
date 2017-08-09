using System;
using CroydonPestControl.AppServices.Interfaces;
using System.Threading.Tasks;
using CroydonPestControl.Infrastructure.Interfaces;

namespace CroydonPestControl.AppServices
{
    public class ConfigurationsAppService: IConfigurationsAppService
    {
        private readonly IConfigurationsRepository _configurationsRepository;
        public ConfigurationsAppService(IConfigurationsRepository configurationsRepository)
        {
            _configurationsRepository = configurationsRepository;
        }

        public async Task<string> GetPestControlConfigAsync()
        {
            var result =await _configurationsRepository.GetPestControlConfigAsync();
            if (result == null) throw new Exception("Pest Control App Configuration not found");
            return result;
        }

        public async Task<string> GetTreatmentConfigAsync()
        {
            var result = await _configurationsRepository.GetTreatmentConfigAsync();
            if (result == null) throw new Exception("reatment Configuration not found");
            return result;
        }
    }
}

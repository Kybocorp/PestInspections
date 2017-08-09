using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CroydonPestControl.AppServices.Interfaces;
using CroydonPestControl.AppServices.Models;
using Microsoft.Extensions.Logging;

namespace CroydonPestControl.AppServices
{
    public class PropertiesAppService : IPropertiesAppService
    {
        private readonly ILogger<PropertiesAppService> _logger;
        public PropertiesAppService(ILogger<PropertiesAppService> logger)
        {
            _logger = logger;
        }
        public Task<IEnumerable<Property>> GetPropertiesByBlockIdAsync(int blockId)
        {
            throw new NotImplementedException();
        }
    }
}

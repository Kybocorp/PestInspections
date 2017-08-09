using CroydonPestControl.AppServices.Interfaces;
using CroydonPestControl.Infrastructure.Interfaces;
using System.Threading.Tasks;
using CroydonPestControl.AppServices.Models;
using AutoMapper;
using System.Collections.Generic;
using System;

namespace CroydonPestControl.AppServices
{
    public class AdminAppService: IAdminAppService
    {
        private readonly IInspectionRepository _inspectionRepository;
        private readonly IMapper _mapper;
        public AdminAppService(IInspectionRepository inspectionRepository, IMapper mapper)
        {
            _inspectionRepository = inspectionRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InspectionViewModel>> GetAllInspectionsAsync(int userId, DateTime? inspectionDate = null)
        {
            return _mapper.Map<IEnumerable<InspectionViewModel>>(await _inspectionRepository.GetAllInspectionsAsync(userId, inspectionDate));
        }

        public async Task<bool> AssignInspectionsAsync(AssignInspectionsRequest assignInspectionsRequest)
        {
            var request = _mapper.Map<Infrastructure.Models.AssignInspectionsRequest>(assignInspectionsRequest);
           return await _inspectionRepository.AssignInspectionsAsync(request);
        }

        public async Task<IEnumerable<OfficerViewModel>> GetAllOfficersAsync()
        {
            return _mapper.Map< IEnumerable<OfficerViewModel>>(await _inspectionRepository.GetAllOfficersAsync());
        }
    }
}

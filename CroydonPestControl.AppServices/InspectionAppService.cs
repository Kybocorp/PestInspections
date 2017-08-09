using System.Collections.Generic;
using System.Threading.Tasks;
using CroydonPestControl.AppServices.Interfaces;
using CroydonPestControl.AppServices.Models;
using CroydonPestControl.Infrastructure.Interfaces;
using AutoMapper;

namespace CroydonPestControl.AppServices
{
    public class InspectionAppService : IInspectionAppService
    {
        private readonly IInspectionRepository _inspectionRepository;
        private readonly IMapper _mapper;

        public InspectionAppService(IInspectionRepository inspectionRepository, IMapper mapper)
        {
            _inspectionRepository = inspectionRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FollowUpDatesResponse>> GetFollowUpDatesAsync(int inspectionId, string pests)
        {
            return _mapper.Map<IEnumerable<FollowUpDatesResponse>>(await _inspectionRepository.GetFollowUpDatesAsync(inspectionId, pests));
        }

        public async Task<IEnumerable<InspectionViewModel>> GetInspectionsByUserIdAsync(int userId)
        {
            return _mapper.Map<IEnumerable<InspectionViewModel>>(await _inspectionRepository.GetInspectionsByUserIdAsync(userId));
        }
        public async Task<bool> SaveInspectionAsync(string inspection)
        {
            return await _inspectionRepository.SaveInspectionAsync(inspection);
        }

        public async Task<bool> UpdateInspectionNoAccessAsync(UpdateInspectionRequest request)
        {
            return await _inspectionRepository.UpdateInspectionNoAccessAsync(_mapper.Map<Infrastructure.Models.UpdateInspectionRequest>(request));
        }
    }
}

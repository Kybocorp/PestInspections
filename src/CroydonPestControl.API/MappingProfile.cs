﻿using AutoMapper;
using CroydonPestControl.AppServices.Models;
using CroydonPestControl.Infrastructure.Models;

namespace CroydonPestControl.API
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<InspectionViewModel, Inspection>().ReverseMap();
            CreateMap<OfficerViewModel, Officer>().ReverseMap();
            CreateMap<AppServices.Models.AssignInspectionsRequest, Infrastructure.Models.AssignInspectionsRequest>().ReverseMap();
            CreateMap<AppServices.Models.FollowUpDatesResponse, Infrastructure.Models.FollowUpDatesResponse>().ReverseMap();
            CreateMap<AppServices.Models.FollowUp, Infrastructure.Models.FollowUp>().ReverseMap();
            CreateMap<AppServices.Models.FollowUp, Models.FollowUp>().ReverseMap();
            CreateMap<AppServices.Models.UpdateInspectionRequest, Infrastructure.Models.UpdateInspectionRequest>().ReverseMap();
            CreateMap<AppServices.Models.UpdateInspectionRequest, Models.UpdateInspectionRequest>().ReverseMap();
            CreateMap<AppServices.Models.AddBlockCycleRequest, Infrastructure.Models.AddBlockCycleRequest>().ReverseMap();
            CreateMap<Infrastructure.Models.AddBlockCycleRequest, AppServices.Models.AddBlockCycleRequest>().ReverseMap();
            CreateMap<AppServices.Models.BlockCycle, Infrastructure.Models.BlockCycle>().ReverseMap();
            CreateMap<AppServices.Models.Block, Infrastructure.Models.Block>().ReverseMap();
            CreateMap<AppServices.Models.AddBlockCycleRequest, Infrastructure.Models.AddBlockCycleRequest>().ReverseMap();
            CreateMap<AppServices.Models.AddBlockToBlockCycleRequest, Infrastructure.Models.AddBlockToBlockCycleRequest>().ReverseMap();
            CreateMap<AppServices.Models.Property, Infrastructure.Models.Property>().ReverseMap();
            CreateMap<AppServices.Models.UpdateBlockCyclePropertyRequest, Infrastructure.Models.UpdateBlockCyclePropertyRequest>().ReverseMap();
        }
    }
}

using AutoMapper;
using ColomboAutoImports.Core.Entities;
using ColomboAutoImports.Core.Models;

namespace ColomboAutoImports.Api.MappingProfiles
{
    public class VehicleDetailsMappings : Profile
    {
        public VehicleDetailsMappings()
        {
            CreateMap<BrandEntity, BrandDto>();
            CreateMap<ModelEntity, ModelDto>();
            CreateMap<SubModelEntity, SubModelDto>();
            CreateMap<SubModelEntity, EstimationSummary>();
        }
    }
}

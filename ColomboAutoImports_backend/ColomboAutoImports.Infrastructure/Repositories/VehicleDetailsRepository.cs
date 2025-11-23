using AutoMapper;
using ColomboAutoImports.Core.Entities;
using ColomboAutoImports.Core.Interfaces.Repositories;
using ColomboAutoImports.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace ColomboAutoImports.Infrastructure.Repositories
{
    public class VehicleDetailsRepository : IVehicleDetailsRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public VehicleDetailsRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<BrandDto>> GetBrandsAsync()
        {
            List<BrandEntity> brandEntities = await _context.Brands
                .OrderBy(b => b.Name)
                .ToListAsync();

            return _mapper.Map<List<BrandDto>>(brandEntities);
        }

        public async Task<List<ModelDto>> GetModelsByBrandIdAsync(int brandId)
        {
            List<ModelEntity> modelEntities = await _context.Models
                .Where(m => m.BrandId == brandId)
                .OrderBy(m => m.Name)
                .ToListAsync();

            return _mapper.Map<List<ModelDto>>(modelEntities);
        }

        public async Task<List<SubModelDto>> GetSubModelsByModelIdAsync(int modelId)
        {
            List<SubModelEntity> subModelEntities = await _context.SubModels
                .Where(s => s.ModelId == modelId)
                .OrderBy(s => s.Name)
                .ToListAsync();

            return _mapper.Map<List<SubModelDto>>(subModelEntities);
        }

        public async Task<EstimationSummary> GetEstimationDetailsAsync(EstimationRequest estimationRequest)
        {
            VehicleEntity vehicle = await _context.Vehicles
                .FirstOrDefaultAsync(v => v.SubModelId == estimationRequest.SubModelId &&
                                        v.Year == estimationRequest.Year &&
                                        v.Color == estimationRequest.Color);

            if (vehicle == null) throw new KeyNotFoundException("No vehicle found matching the specified terms");

            FuelTypeEntity fuelType = await _context.FuelTypes
                                     .FirstOrDefaultAsync(f => f.Id == vehicle.FuelTypeId);

            SubModelEntity subModel = await _context.SubModels.FirstOrDefaultAsync(x => x.Id == estimationRequest.SubModelId);

            if (subModel == null) return null;

            EstimationSummary estimationSummary = _mapper.Map<EstimationSummary>(subModel);
            estimationSummary.EngineCapacity = vehicle.EngineCapacity;
            estimationSummary.ChassisId = vehicle.ChassisId;
            estimationSummary.FuelType = fuelType.Name;

            return estimationSummary;
        }
    }
}

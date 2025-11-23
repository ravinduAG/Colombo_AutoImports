using ColomboAutoImports.Core.Entities;
using ColomboAutoImports.Core.Interfaces.Repositories;
using ColomboAutoImports.Core.Interfaces.Services;
using ColomboAutoImports.Core.Models;

namespace ColomboAutoImports.Core.Services
{
    public class VehicleDetailsService : IVehicleDetailsService
    {
        private readonly IVehicleDetailsRepository _vehicleDetailsRepository;

        public VehicleDetailsService(IVehicleDetailsRepository vehicleDetailsRepository)
        {
            _vehicleDetailsRepository = vehicleDetailsRepository;
        }

        public async Task<List<BrandDto>> GetBrandsAsync()
        {
            return await _vehicleDetailsRepository.GetBrandsAsync();
        }

        public async Task<List<ModelDto>> GetModelsByBrandIdAsync(int brandId)
        {
            return await _vehicleDetailsRepository.GetModelsByBrandIdAsync(brandId);
        }

        public async Task<List<SubModelDto>> GetSubModelsByModelIdAsync(int modelId)
        {
            return await _vehicleDetailsRepository.GetSubModelsByModelIdAsync(modelId);
        }
    }
}

using ColomboAutoImports.Core.Entities;
using ColomboAutoImports.Core.Models;

namespace ColomboAutoImports.Core.Interfaces.Repositories
{
    public interface IVehicleDetailsRepository
    {
        Task<List<BrandDto>> GetBrandsAsync();
        Task<List<ModelDto>> GetModelsByBrandIdAsync(int brandId);
        Task<List<SubModelDto>> GetSubModelsByModelIdAsync(int modelId);
        Task<EstimationSummary> GetEstimationDetailsAsync(EstimationRequest estimationRequest);
    }
}

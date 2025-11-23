using ColomboAutoImports.Core.Entities;
using ColomboAutoImports.Core.Models;
using System.Threading.Tasks;

namespace ColomboAutoImports.Core.Interfaces.Services
{
    public interface IVehicleDetailsService
    {
        Task<List<BrandDto>> GetBrandsAsync();
        Task<List<ModelDto>> GetModelsByBrandIdAsync(int brandId);
        Task<List<SubModelDto>> GetSubModelsByModelIdAsync(int modelId);
    }
}

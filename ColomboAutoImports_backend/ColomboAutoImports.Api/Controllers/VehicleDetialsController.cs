using ColomboAutoImports.Core.Entities;
using ColomboAutoImports.Core.Interfaces.Services;
using ColomboAutoImports.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace ColomboAutoImports.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleDetailsController : ControllerBase
    {
        private readonly IVehicleDetailsService _vehicleDetailsService;

        public VehicleDetailsController(IVehicleDetailsService vehicleDetailsService)
        {
            _vehicleDetailsService = vehicleDetailsService;
        }

        [HttpGet("brands")]
        public async Task<ActionResult<List<BrandDto>>> GetBrands()
        {
            var brands = await _vehicleDetailsService.GetBrandsAsync();
            return Ok(brands);
        }

        [HttpGet("models/{brandId}")]
        public async Task<ActionResult<List<ModelDto>>> GetModels(int brandId)
        {
            var models = await _vehicleDetailsService.GetModelsByBrandIdAsync(brandId);
            return Ok(models);
        }

        [HttpGet("submodels/{modelId}")]
        public async Task<ActionResult<List<SubModelDto>>> GetSubModels(int modelId)
        {
            var subModels = await _vehicleDetailsService.GetSubModelsByModelIdAsync(modelId);
            return Ok(subModels);
        }
    }
}

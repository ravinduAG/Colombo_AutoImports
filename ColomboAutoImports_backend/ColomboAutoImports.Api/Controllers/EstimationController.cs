using ColomboAutoImports.Core.Interfaces.Services;
using ColomboAutoImports.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace ColomboAutoImports.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstimationController : ControllerBase
    {
        private readonly IEstimationService _estimationService;

        public EstimationController(IEstimationService estimationService)
        {
            _estimationService = estimationService;
        }

        [HttpPost("calculate")]
        public async Task<IActionResult> Calculate([FromBody] EstimationRequest estimationRequest)
        {
            EstimationSummary estimation = await _estimationService.CalculateAsync(estimationRequest);
            return Ok(estimation);
        }

    }
}

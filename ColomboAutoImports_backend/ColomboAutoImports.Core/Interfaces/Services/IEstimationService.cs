using ColomboAutoImports.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace ColomboAutoImports.Core.Interfaces.Services
{
    public interface IEstimationService
    {
        Task<EstimationSummary> CalculateAsync(EstimationRequest estimationRequest);
    }
}

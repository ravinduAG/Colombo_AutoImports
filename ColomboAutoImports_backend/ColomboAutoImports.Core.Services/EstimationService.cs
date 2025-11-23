using ColomboAutoImports.Core.Interfaces.Repositories;
using ColomboAutoImports.Core.Interfaces.Services;
using ColomboAutoImports.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace ColomboAutoImports.Core.Services
{
    public class EstimationService : IEstimationService
    {
        private readonly IVehicleDetailsRepository _vehicleDetailsRepository;

        public EstimationService(IVehicleDetailsRepository vehicleDetailsRepository)
        {
            _vehicleDetailsRepository = vehicleDetailsRepository;
        }
        public async Task<EstimationSummary> CalculateAsync(EstimationRequest estimationRequest)
        {
            EstimationSummary summary = await _vehicleDetailsRepository.GetEstimationDetailsAsync(estimationRequest);

            return summary;
        }
    }
}

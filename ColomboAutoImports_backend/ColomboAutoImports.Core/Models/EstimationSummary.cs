using ColomboAutoImports.Core.Entities;

namespace ColomboAutoImports.Core.Models
{
    public class EstimationSummary
    {
        public string FuelType { get; set; }
        public string EngineCapacity { get; set; }
        public string ChassisId { get; set; }
        public decimal CIF_JPY { get; set; }
        public decimal ExchangeRate { get; set; }
        public decimal CIF_LKR { get; set; }
        public decimal TotalDuty { get; set; }
        public decimal ClearingCharges { get; set; }
        public decimal BankDocCharge { get; set; }
        public decimal DeliveryCharges { get; set; }
        public decimal TotalCost =>
            CIF_JPY
            + ExchangeRate
            + CIF_LKR
            + TotalDuty
            + ClearingCharges
            + BankDocCharge
            + DeliveryCharges;
    }
}

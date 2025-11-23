namespace ColomboAutoImports.Core.Entities
{
    public class SubModelEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ModelId { get; set; }
        public virtual ModelEntity Model { get; set; }
        public decimal CIF_JPY { get; set; }
        public decimal ExchangeRate { get; set; }
        public decimal CIF_LKR { get; set; }
        public decimal TotalDuty { get; set; }
        public decimal ClearingCharges { get; set; }
        public decimal BankDocCharge { get; set; }
        public decimal DeliveryCharges { get; set; }
        public virtual ICollection<VehicleEntity> Vehicles { get; set; }
    }

}

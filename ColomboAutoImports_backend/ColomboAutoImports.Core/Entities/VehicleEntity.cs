namespace ColomboAutoImports.Core.Entities
{
    public class VehicleEntity
    {
        public int Id { get; set; }
        public int SubModelId { get; set; }
        public virtual SubModelEntity SubModel { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public int? FuelTypeId { get; set; }
        public virtual FuelTypeEntity FuelType { get; set; }
        public string EngineCapacity { get; set; }
        public string ChassisId { get; set; }
    }

}

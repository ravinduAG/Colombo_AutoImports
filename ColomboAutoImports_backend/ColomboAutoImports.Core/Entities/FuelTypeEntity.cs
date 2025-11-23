namespace ColomboAutoImports.Core.Entities
{
    public class FuelTypeEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<VehicleEntity> Vehicles { get; set; }
    }
}

namespace ColomboAutoImports.Core.Entities
{
    public class ModelEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
        public virtual BrandEntity Brand { get; set; }
        public virtual ICollection<SubModelEntity> SubModels { get; set; }
    }
}

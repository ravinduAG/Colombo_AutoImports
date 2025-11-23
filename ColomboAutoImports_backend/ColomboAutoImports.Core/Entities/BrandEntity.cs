using System.Reflection;

namespace ColomboAutoImports.Core.Entities
{
    public class BrandEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ModelEntity> Models { get; set; }
    }

}

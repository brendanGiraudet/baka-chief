using System.ComponentModel.DataAnnotations;

namespace bakaChiefApplication.DatabaseModels
{
    public class NutrimentType
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; }
    }
}

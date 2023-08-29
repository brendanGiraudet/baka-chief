namespace bakaChiefApplication.Models
{
    public class Ingredient
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; }

        public string? SvgImage { get; set; }

        public ICollection<NutrimentType> NutrimentTypes { get; set; } = new HashSet<NutrimentType>();
    }
}

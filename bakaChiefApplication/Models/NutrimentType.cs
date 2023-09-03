using bakaChiefApplication.Constants;
using System.Text.Json.Serialization;

namespace bakaChiefApplication.Models
{
    public class NutrimentType
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("imageUrl")]
        public string ImageUrl { get; set; } = SvgConstants.EmptySvg;
    }
}

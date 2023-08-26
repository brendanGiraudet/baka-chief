using System.Text.Json.Serialization;

namespace bakaChiefApplication.Models
{
    public class NutrimentType
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}

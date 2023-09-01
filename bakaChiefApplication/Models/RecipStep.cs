using System.Text.Json.Serialization;

namespace bakaChiefApplication.Models
{
    public class RecipStep
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [JsonPropertyName("number")]
        public int Number { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}

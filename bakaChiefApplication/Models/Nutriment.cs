using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace bakaChiefApplication.Models
{
    public class Nutriment
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [JsonPropertyName("name")]
        [Required]
        public string Name { get; set; }

        [JsonPropertyName("imageUrl")]
        [Required]
        public string ImageUrl { get; set; }
    }
}

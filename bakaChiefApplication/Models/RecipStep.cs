using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace bakaChiefApplication.Models
{
    public class RecipStep
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [JsonPropertyName("number")]
        [Required]
        public int? Number { get; set; }

        [JsonPropertyName("description")]
        [Required]
        public string Description { get; set; }
    }
}

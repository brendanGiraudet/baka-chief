using System.Text.Json.Serialization;

namespace bakaChiefApplication.Models;

public class SelectedRecipHistory
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [JsonPropertyName("date")]
    public DateTime Date { get; set; } = DateTime.Now;

    [JsonPropertyName("recips")]
    public ICollection<Recip> Recips { get; set; } = new HashSet<Recip>();
}

using System.Text.Json.Serialization;

namespace Memes;

public class Relationship
{
    [JsonPropertyName("is")]
    public List<string>? Is { get; set; }
    [JsonPropertyName("can")]
    public List<string>? Can { get; set; }
    [JsonPropertyName("are")]
    public List<string>? Are { get; set; }
}
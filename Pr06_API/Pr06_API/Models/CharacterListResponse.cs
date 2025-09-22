using System.Text.Json.Serialization;

namespace Pr06_API.Models;

public class CharacterListResponse
{
    [JsonPropertyName("info")]
    public Info Info { get; set; } = new();

    [JsonPropertyName("results")]
    public List<Character> Results { get; set; } = new();
}
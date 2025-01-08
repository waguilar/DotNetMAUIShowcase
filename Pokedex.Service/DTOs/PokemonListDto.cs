using System.Text.Json.Serialization;

namespace Pokedex.Service.DTOs
{
    public class PokemonListDto
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("next")]
        public string Next { get; set; }

        [JsonPropertyName("previous")]
        public string Previous { get; set; }

        [JsonPropertyName("results")]
        public List<PokemonItemDto> Results { get; set; }
    }

    public class PokemonItemDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

}

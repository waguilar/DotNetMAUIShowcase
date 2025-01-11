using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Pokedex.Service.DTOs;

public class PokemonSpeciesDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("order")]
    public int Order { get; set; }

    [JsonPropertyName("gender_rate")]
    public int GenderRate { get; set; }

    [JsonPropertyName("capture_rate")]
    public int CaptureRate { get; set; }

    [JsonPropertyName("base_happiness")]
    public int BaseHappiness { get; set; }

    [JsonPropertyName("is_baby")]
    public bool IsBaby { get; set; }

    [JsonPropertyName("is_legendary")]
    public bool IsLegendary { get; set; }

    [JsonPropertyName("is_mythical")]
    public bool IsMythical { get; set; }

    [JsonPropertyName("hatch_counter")]
    public int HatchCounter { get; set; }

    [JsonPropertyName("has_gender_differences")]
    public bool HasGenderDifferences { get; set; }

    [JsonPropertyName("forms_switchable")]
    public bool FormsSwitchable { get; set; }

    [JsonPropertyName("growth_rate")]
    public NamedApiResource GrowthRate { get; set; }

    [JsonPropertyName("pokedex_numbers")]
    public List<PokemonSpeciesDexEntry> PokedexNumbers { get; set; }

    [JsonPropertyName("egg_groups")]
    public List<NamedApiResource> EggGroups { get; set; }

    [JsonPropertyName("color")]
    public NamedApiResource Color { get; set; }

    [JsonPropertyName("shape")]
    public NamedApiResource Shape { get; set; }

    [JsonPropertyName("evolves_from_species")]
    public NamedApiResource EvolvesFromSpecies { get; set; }

    [JsonPropertyName("evolution_chain")]
    public ApiResource EvolutionChain { get; set; }

    [JsonPropertyName("habitat")]
    public NamedApiResource Habitat { get; set; }

    [JsonPropertyName("generation")]
    public NamedApiResource Generation { get; set; }

    [JsonPropertyName("names")]
    public List<Name> Names { get; set; }

    [JsonPropertyName("flavor_text_entries")]
    public List<FlavorText> FlavorTextEntries { get; set; }

    [JsonPropertyName("form_descriptions")]
    public List<Description> FormDescriptions { get; set; }

    [JsonPropertyName("genera")]
    public List<Genus> Genera { get; set; }

    [JsonPropertyName("varieties")]
    public List<PokemonSpeciesVariety> Varieties { get; set; }
}

public class ApiResource
{
    [JsonPropertyName("url")]
    public string Url { get; set; }
}

public class PokemonSpeciesDexEntry
{
    [JsonPropertyName("entry_number")]
    public int EntryNumber { get; set; }

    [JsonPropertyName("pokedex")]
    public NamedApiResource Pokedex { get; set; }
}

public class Name
{
    [JsonPropertyName("name")]
    public string NameValue { get; set; }

    [JsonPropertyName("language")]
    public NamedApiResource Language { get; set; }
}

public class FlavorText
{
    [JsonPropertyName("flavor_text")]
    public string FlavorTextValue { get; set; }

    [JsonPropertyName("language")]
    public NamedApiResource Language { get; set; }

    [JsonPropertyName("version")]
    public NamedApiResource Version { get; set; }
}

public class Description
{
    [JsonPropertyName("description")]
    public string DescriptionValue { get; set; }

    [JsonPropertyName("language")]
    public NamedApiResource Language { get; set; }
}

public class Genus
{
    [JsonPropertyName("genus")]
    public string GenusValue { get; set; }

    [JsonPropertyName("language")]
    public NamedApiResource Language { get; set; }
}

public class PokemonSpeciesVariety
{
    [JsonPropertyName("is_default")]
    public bool IsDefault { get; set; }

    [JsonPropertyName("pokemon")]
    public NamedApiResource Pokemon { get; set; }
}


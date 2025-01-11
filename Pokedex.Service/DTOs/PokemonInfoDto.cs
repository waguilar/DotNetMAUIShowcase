using System.Text.Json.Serialization;

namespace Pokedex.Service.DTOs;
public class PokemonInfoDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("base_experience")]
    public int BaseExperience { get; set; }

    [JsonPropertyName("height")]
    public int Height { get; set; }

    [JsonPropertyName("is_default")]
    public bool IsDefault { get; set; }

    [JsonPropertyName("order")]
    public int Order { get; set; }

    [JsonPropertyName("weight")]
    public int Weight { get; set; }

    [JsonPropertyName("abilities")]
    public List<Ability> Abilities { get; set; }

    [JsonPropertyName("forms")]
    public List<Form> Forms { get; set; }

    [JsonPropertyName("game_indices")]
    public List<GameIndex> GameIndices { get; set; }

    [JsonPropertyName("held_items")]
    public List<HeldItem> HeldItems { get; set; }

    [JsonPropertyName("location_area_encounters")]
    public string LocationAreaEncounters { get; set; }

    [JsonPropertyName("moves")]
    public List<Move> Moves { get; set; }

    [JsonPropertyName("species")]
    public NamedApiResource Species { get; set; }

    [JsonPropertyName("sprites")]
    public Sprites Sprites { get; set; }

    [JsonPropertyName("cries")]
    public Cries Cries { get; set; }

    [JsonPropertyName("stats")]
    public List<Stat> Stats { get; set; }

    [JsonPropertyName("types")]
    public List<Type> Types { get; set; }

    [JsonPropertyName("past_types")]
    public List<PastType> PastTypes { get; set; }
}

public class Ability
{
    [JsonPropertyName("is_hidden")]
    public bool IsHidden { get; set; }

    [JsonPropertyName("slot")]
    public int Slot { get; set; }

    [JsonPropertyName("ability")]
    public NamedApiResource AbilityResource { get; set; }
}

public class Form
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }
}

public class GameIndex
{
    [JsonPropertyName("game_index")]
    public int GameIndexValue { get; set; }

    [JsonPropertyName("version")]
    public NamedApiResource Version { get; set; }
}

public class HeldItem
{
    [JsonPropertyName("item")]
    public NamedApiResource Item { get; set; }

    [JsonPropertyName("version_details")]
    public List<VersionDetail> VersionDetails { get; set; }
}

public class Move
{
    [JsonPropertyName("move")]
    public NamedApiResource MoveResource { get; set; }

    [JsonPropertyName("version_group_details")]
    public List<VersionGroupDetail> VersionGroupDetails { get; set; }
}

public class VersionDetail
{
    [JsonPropertyName("rarity")]
    public int Rarity { get; set; }

    [JsonPropertyName("version")]
    public NamedApiResource Version { get; set; }
}

public class VersionGroupDetail
{
    [JsonPropertyName("level_learned_at")]
    public int LevelLearnedAt { get; set; }

    [JsonPropertyName("version_group")]
    public NamedApiResource VersionGroup { get; set; }

    [JsonPropertyName("move_learn_method")]
    public NamedApiResource MoveLearnMethod { get; set; }
}

public class Sprites
{
    [JsonPropertyName("back_default")]
    public string BackDefault { get; set; }

    [JsonPropertyName("back_female")]
    public string BackFemale { get; set; }

    [JsonPropertyName("back_shiny")]
    public string BackShiny { get; set; }

    [JsonPropertyName("back_shiny_female")]
    public string BackShinyFemale { get; set; }

    [JsonPropertyName("front_default")]
    public string FrontDefault { get; set; }

    [JsonPropertyName("front_female")]
    public string FrontFemale { get; set; }

    [JsonPropertyName("front_shiny")]
    public string FrontShiny { get; set; }

    [JsonPropertyName("front_shiny_female")]
    public string FrontShinyFemale { get; set; }
}

public class Cries
{
    [JsonPropertyName("latest")]
    public string Latest { get; set; }

    [JsonPropertyName("legacy")]
    public string Legacy { get; set; }
}

public class Stat
{
    [JsonPropertyName("base_stat")]
    public int BaseStat { get; set; }

    [JsonPropertyName("effort")]
    public int Effort { get; set; }

    [JsonPropertyName("stat")]
    public NamedApiResource StatResource { get; set; }
}

public class Type
{
    [JsonPropertyName("slot")]
    public int Slot { get; set; }

    [JsonPropertyName("type")]
    public NamedApiResource TypeResource { get; set; }
}

public class PastType
{
    [JsonPropertyName("generation")]
    public NamedApiResource Generation { get; set; }

    [JsonPropertyName("types")]
    public List<Type> Types { get; set; }
}


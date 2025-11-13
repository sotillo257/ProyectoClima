using System.Text.Json.Serialization;

namespace ClassLibrary1.Recursos
{
    internal class PokedexDTO
    {
        public class Pokemon
        {
            [JsonPropertyName("abilities")]
            public List<AbilitySlot> Abilities { get; set; } = new();

            [JsonPropertyName("base_experience")]
            public int BaseExperience { get; set; }

            [JsonPropertyName("cries")]
            public Cries Cries { get; set; } = new();

            [JsonPropertyName("forms")]
            public List<NamedApiResource> Forms { get; set; } = new();

            [JsonPropertyName("game_indices")]
            public List<GameIndex> GameIndices { get; set; } = new();

            [JsonPropertyName("height")]
            public int Height { get; set; }

            [JsonPropertyName("held_items")]
            public List<HeldItem> HeldItems { get; set; } = new();

            [JsonPropertyName("id")]
            public int Id { get; set; }

            [JsonPropertyName("is_default")]
            public bool IsDefault { get; set; }

            [JsonPropertyName("location_area_encounters")]
            public string LocationAreaEncounters { get; set; } = string.Empty;

            [JsonPropertyName("moves")]
            public List<Move> Moves { get; set; } = new();

            [JsonPropertyName("name")]
            public string Name { get; set; } = string.Empty;

            [JsonPropertyName("order")]
            public int Order { get; set; }

            [JsonPropertyName("past_abilities")]
            public List<PastAbility> PastAbilities { get; set; } = new();

            [JsonPropertyName("past_types")]
            public List<object> PastTypes { get; set; } = new();

            [JsonPropertyName("species")]
            public NamedApiResource Species { get; set; } = new();

            [JsonPropertyName("sprites")]
            public Sprites Sprites { get; set; } = new();

            [JsonPropertyName("stats")]
            public List<Stat> Stats { get; set; } = new();

            [JsonPropertyName("types")]
            public List<TypeSlot> Types { get; set; } = new();

            [JsonPropertyName("weight")]
            public int Weight { get; set; }
        }

        public class AbilitySlot
        {
            [JsonPropertyName("ability")]
            public NamedApiResource Ability { get; set; } = new();

            [JsonPropertyName("is_hidden")]
            public bool IsHidden { get; set; }

            [JsonPropertyName("slot")]
            public int Slot { get; set; }
        }

        public class Cries
        {
            [JsonPropertyName("latest")]
            public string Latest { get; set; } = string.Empty;

            [JsonPropertyName("legacy")]
            public string Legacy { get; set; } = string.Empty;
        }

        public class GameIndex
        {
            [JsonPropertyName("game_index")]
            public int Game_Index { get; set; }

            [JsonPropertyName("version")]
            public NamedApiResource Version { get; set; } = new();
        }

        public class HeldItem
        {
            [JsonPropertyName("item")]
            public NamedApiResource Item { get; set; } = new();

            [JsonPropertyName("version_details")]
            public List<VersionDetail> VersionDetails { get; set; } = new();
        }

        public class VersionDetail
        {
            [JsonPropertyName("rarity")]
            public int Rarity { get; set; }

            [JsonPropertyName("version")]
            public NamedApiResource Version { get; set; } = new();
        }

        public class Move
        {
            [JsonPropertyName("move")]
            public NamedApiResource MoveInfo { get; set; } = new();

            [JsonPropertyName("version_group_details")]
            public List<VersionGroupDetail> VersionGroupDetails { get; set; } = new();
        }

        public class VersionGroupDetail
        {
            [JsonPropertyName("level_learned_at")]
            public int LevelLearnedAt { get; set; }

            [JsonPropertyName("move_learn_method")]
            public NamedApiResource MoveLearnMethod { get; set; } = new();

            [JsonPropertyName("order")]
            public object? Order { get; set; }

            [JsonPropertyName("version_group")]
            public NamedApiResource VersionGroup { get; set; } = new();
        }

        public class PastAbility
        {
            [JsonPropertyName("abilities")]
            public List<AbilitySlot> Abilities { get; set; } = new();

            [JsonPropertyName("generation")]
            public NamedApiResource Generation { get; set; } = new();
        }

        public class Sprites
        {
            [JsonPropertyName("back_default")]
            public string BackDefault { get; set; } = string.Empty;

            [JsonPropertyName("back_female")]
            public string BackFemale { get; set; } = string.Empty;

            [JsonPropertyName("back_shiny")]
            public string BackShiny { get; set; } = string.Empty;

            [JsonPropertyName("back_shiny_female")]
            public string BackShinyFemale { get; set; } = string.Empty;

            [JsonPropertyName("front_default")]
            public string FrontDefault { get; set; } = string.Empty;

            [JsonPropertyName("front_female")]
            public string FrontFemale { get; set; } = string.Empty;

            [JsonPropertyName("front_shiny")]
            public string FrontShiny { get; set; } = string.Empty;

            [JsonPropertyName("front_shiny_female")]
            public string FrontShinyFemale { get; set; } = string.Empty;

            [JsonPropertyName("other")]
            public OtherSprites Other { get; set; } = new();

            [JsonPropertyName("versions")]
            public object Versions { get; set; } = new();
        }

        public class OtherSprites
        {
            [JsonPropertyName("dream_world")]
            public DreamWorld DreamWorld { get; set; } = new();

            [JsonPropertyName("home")]
            public HomeSprites Home { get; set; } = new();

            [JsonPropertyName("official-artwork")]
            public OfficialArtwork OfficialArtwork { get; set; } = new();

            [JsonPropertyName("showdown")]
            public ShowdownSprites Showdown { get; set; } = new();
        }

        public class DreamWorld
        {
            [JsonPropertyName("front_default")]
            public string FrontDefault { get; set; } = string.Empty;

            [JsonPropertyName("front_female")]
            public string FrontFemale { get; set; } = string.Empty;
        }

        public class HomeSprites
        {
            [JsonPropertyName("front_default")]
            public string FrontDefault { get; set; } = string.Empty;

            [JsonPropertyName("front_female")]
            public string FrontFemale { get; set; } = string.Empty;

            [JsonPropertyName("front_shiny")]
            public string FrontShiny { get; set; } = string.Empty;

            [JsonPropertyName("front_shiny_female")]
            public string FrontShinyFemale { get; set; } = string.Empty;
        }

        public class OfficialArtwork
        {
            [JsonPropertyName("front_default")]
            public string FrontDefault { get; set; } = string.Empty;

            [JsonPropertyName("front_shiny")]
            public string FrontShiny { get; set; } = string.Empty;
        }

        public class ShowdownSprites
        {
            [JsonPropertyName("back_default")]
            public string BackDefault { get; set; } = string.Empty;

            [JsonPropertyName("back_female")]
            public string BackFemale { get; set; } = string.Empty;

            [JsonPropertyName("back_shiny")]
            public string BackShiny { get; set; } = string.Empty;

            [JsonPropertyName("back_shiny_female")]
            public string BackShinyFemale { get; set; } = string.Empty;

            [JsonPropertyName("front_default")]
            public string FrontDefault { get; set; } = string.Empty;

            [JsonPropertyName("front_female")]
            public string FrontFemale { get; set; } = string.Empty;

            [JsonPropertyName("front_shiny")]
            public string FrontShiny { get; set; } = string.Empty;

            [JsonPropertyName("front_shiny_female")]
            public string FrontShinyFemale { get; set; } = string.Empty;
        }

        public class Stat
        {
            [JsonPropertyName("base_stat")]
            public int BaseStat { get; set; }

            [JsonPropertyName("effort")]
            public int Effort { get; set; }

            [JsonPropertyName("stat")]
            public NamedApiResource StatInfo { get; set; } = new();
        }

        public class TypeSlot
        {
            [JsonPropertyName("slot")]
            public int Slot { get; set; }

            [JsonPropertyName("type")]
            public NamedApiResource Type { get; set; } = new();
        }

        public class NamedApiResource
        {
            [JsonPropertyName("name")]
            public string Name { get; set; } = string.Empty;

            [JsonPropertyName("url")]
            public string Url { get; set; } = string.Empty;
        }
    }
}

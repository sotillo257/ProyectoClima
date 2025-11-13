using System.Text.Json.Serialization;

namespace ClassLibrary1.Recursos
{
    internal class PokedexDTO
    {
            [JsonPropertyName("ability")]
            public string Ability { get; set; } = string.Empty;

            [JsonPropertyName("berry")]
            public string Berry { get; set; } = string.Empty;

            [JsonPropertyName("berry-firmness")]
            public string BerryFirmness { get; set; } = string.Empty;

            [JsonPropertyName("berry-flavor")]
            public string BerryFlavor { get; set; } = string.Empty;

            [JsonPropertyName("characteristic")]
            public string Characteristic { get; set; } = string.Empty;

            [JsonPropertyName("contest-effect")]
            public string ContestEffect { get; set; } = string.Empty;

            [JsonPropertyName("contest-type")]
            public string ContestType { get; set; } = string.Empty;

            [JsonPropertyName("egg-group")]
            public string EggGroup { get; set; } = string.Empty;

            [JsonPropertyName("encounter-condition")]
            public string EncounterCondition { get; set; } = string.Empty;

            [JsonPropertyName("encounter-condition-value")]
            public string EncounterConditionValue { get; set; } = string.Empty;

            [JsonPropertyName("encounter-method")]
            public string EncounterMethod { get; set; } = string.Empty;

            [JsonPropertyName("evolution-chain")]
            public string EvolutionChain { get; set; } = string.Empty;

            [JsonPropertyName("evolution-trigger")]
            public string EvolutionTrigger { get; set; } = string.Empty;

            [JsonPropertyName("gender")]
            public string Gender { get; set; } = string.Empty;

            [JsonPropertyName("generation")]
            public string Generation { get; set; } = string.Empty;

            [JsonPropertyName("growth-rate")]
            public string GrowthRate { get; set; } = string.Empty;

            [JsonPropertyName("item")]
            public string Item { get; set; } = string.Empty;

            [JsonPropertyName("item-attribute")]
            public string ItemAttribute { get; set; } = string.Empty;

            [JsonPropertyName("item-category")]
            public string ItemCategory { get; set; } = string.Empty;

            [JsonPropertyName("item-fling-effect")]
            public string ItemFlingEffect { get; set; } = string.Empty;

            [JsonPropertyName("item-pocket")]
            public string ItemPocket { get; set; } = string.Empty;

            [JsonPropertyName("language")]
            public string Language { get; set; } = string.Empty;

            [JsonPropertyName("location")]
            public string Location { get; set; } = string.Empty;

            [JsonPropertyName("location-area")]
            public string LocationArea { get; set; } = string.Empty;

            [JsonPropertyName("machine")]
            public string Machine { get; set; } = string.Empty;

            [JsonPropertyName("move")]
            public string Move { get; set; } = string.Empty;

            [JsonPropertyName("move-ailment")]
            public string MoveAilment { get; set; } = string.Empty;

            [JsonPropertyName("move-battle-style")]
            public string MoveBattleStyle { get; set; } = string.Empty;

            [JsonPropertyName("move-category")]
            public string MoveCategory { get; set; } = string.Empty;

            [JsonPropertyName("move-damage-class")]
            public string MoveDamageClass { get; set; } = string.Empty;

            [JsonPropertyName("move-learn-method")]
            public string MoveLearnMethod { get; set; } = string.Empty;

            [JsonPropertyName("move-target")]
            public string MoveTarget { get; set; } = string.Empty;

            [JsonPropertyName("nature")]
            public string Nature { get; set; } = string.Empty;

            [JsonPropertyName("pal-park-area")]
            public string PalParkArea { get; set; } = string.Empty;

            [JsonPropertyName("pokeathlon-stat")]
            public string PokeathlonStat { get; set; } = string.Empty;

            [JsonPropertyName("pokedex")]
            public string Pokedex { get; set; } = string.Empty;

            [JsonPropertyName("pokemon")]
            public string Pokemon { get; set; } = string.Empty;

        [JsonPropertyName("pokemon-color")]
            public string PokemonColor { get; set; } = string.Empty;

            [JsonPropertyName("pokemon-form")]
            public string PokemonForm { get; set; } = string.Empty;

            [JsonPropertyName("pokemon-habitat")]
            public string PokemonHabitat { get; set; } = string.Empty;

            [JsonPropertyName("pokemon-shape")]
            public string PokemonShape { get; set; } = string.Empty;

            [JsonPropertyName("pokemon-species")]
            public string PokemonSpecies { get; set; } = string.Empty;

            [JsonPropertyName("region")]
            public string Region { get; set; } = string.Empty;

            [JsonPropertyName("stat")]
            public string Stat { get; set; } = string.Empty;

            [JsonPropertyName("super-contest-effect")]
            public string SuperContestEffect { get; set; } = string.Empty;

        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;

        [JsonPropertyName("version")]
            public string Version { get; set; } = string.Empty;

            [JsonPropertyName("version-group")]
            public string VersionGroup { get; set; } = string.Empty;
        }
    }

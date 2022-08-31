using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GraphQL_HotChocolate.Model
{
    public class SwapiPeople : ResponseBase
    {
        private string _origin = "Star Wars API";
        public string Origin { get => _origin; set => _origin = value; }

        [Key]
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }

        public SwapiPerson[]? results { get; set; }
    }

    public class SwapiPerson : ResponseBase
    {

        [Key]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("height")]
        public string Height { get; set; }

        [JsonProperty("mass")]
        public string Mass { get; set; }

        [JsonProperty("hair_color")]
        public string HairColor { get; set; }

        [JsonProperty("skin_color")]
        public string SkinColor { get; set; }

        [JsonProperty("eye_color")]
        public string EyeColor { get; set; }

        [JsonProperty("birth_year")]
        public string BirthYear { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("homeworld")]
        public string HomeworId { get; set; }

        [JsonProperty("films")]
        public string[]? Films { get; set; }

        [JsonProperty("species")]
        public string[]? Species { get; set; }

        [JsonProperty("vehicles")]
        public string[]? Vehicles { get; set; }

        [JsonProperty("starships")]
        public string[]? Starships { get; set; }

        [JsonProperty("created")]
        public string Created { get; set; }

        [JsonProperty("edited")]
        public string Edited { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}

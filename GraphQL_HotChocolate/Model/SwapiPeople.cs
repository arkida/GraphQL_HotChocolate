using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GraphQL_HotChocolate.Model
{
    public class People
    {
        private string _origin = "Star Wars API";
        public string Origin { get => _origin; set => _origin = value; }
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }

        public SwapiPerson[] Results { get; set; }
    }

    //public class SwapiPerson
    //{
    //    [Key]
    //    public int Id { get; set; }

    //    public string Name { get; set; }
    //    public string Height { get; set; }
    //    public string Mass { get; set; }
    //    public string Hair_Color { get; set; }
    //    public string Skin_Color { get; set; }
    //    public string Eye_Color { get; set; }
    //    public string Birth_Year { get; set; }
    //    public string Gender { get; set; }
    //    public string Homeworld { get; set; }
    //    public string[] Films { get; set; }
    //    public string[] Species { get; set; }
    //    public string[] Vehicles { get; set; }
    //    public string[] Starships { get; set; }
    //}
    public class SwapiPerson
    {

        [Key]
        public int Id { get; set; }

        [JsonProperty("vehicles")]
        public string[] Vehicles { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("Url")]
        public string Url { get; set; }

        [JsonProperty("height")]
        public string Height { get; set; }

        [JsonPropertyName("hair_color")]
        [JsonProperty("hair_color")]
        public string HairColor { get; set; }

        [JsonPropertyName("skin_color")]
        [JsonProperty("skin_color")]
        public string SkinColor { get; set; }

        [JsonProperty("starships")]
        public string[] Starships { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("films")]
        public string[] Films { get; set; }

        [JsonPropertyName("birth_year")]
        [JsonProperty("birth_year")]
        public string BirthYear { get; set; }

        [JsonPropertyName("homeworld")]
        [JsonProperty("homeworld")]
        public string HomeworId { get; set; }

        [JsonProperty("species")]
        public string[] Species { get; set; }

        [JsonPropertyName("eye_color")]
        [JsonProperty("eye_color")]
        public string EyeColor { get; set; }

        [JsonProperty("mass")]
        public string Mass { get; set; }

        [JsonProperty("created")]
        public string Created { get; set; }

        [JsonProperty("edited")]
        public string Edited { get; set; }
    }
}

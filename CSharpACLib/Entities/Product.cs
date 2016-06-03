using System;
using Newtonsoft.Json;

namespace CSharpACLib.Entities
{
    public class Product
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "addition_date")]
        public DateTime? AdditionDate { get; set; }
        [JsonProperty(PropertyName = "decription")]
        public string Description { get; set; }
    }
}

using System;
using Newtonsoft.Json;

namespace CSharpACLib.Entities
{
    class Product
    {
        [JsonProperty(PropertyName = "id")]
        public int Id;
        [JsonProperty(PropertyName = "name")]
        public string Name;
        [JsonProperty(PropertyName = "addition_date")]
        public DateTime? AdditionDate;
        [JsonProperty(PropertyName = "decription")]
        public string Description;
    }
}

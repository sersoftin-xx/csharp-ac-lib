using System;
using Newtonsoft.Json;

namespace CSharpACLib.Entities
{
    public class Bid
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "product_id")]
        public int ProductId { get; set; }
        [JsonProperty(PropertyName = "pc_id")]
        public int PcId { get; set; }
        [JsonProperty(PropertyName = "application_date")]
        public DateTime? ApplicationDate;
        [JsonProperty(PropertyName = "is_active")]
        public bool IsActive { get; set; }
        [JsonProperty(PropertyName = "is_expired")]
        public bool IsExpired { get; set; }
        [JsonProperty(PropertyName = "activation_date")]
        public DateTime? ActivationDate { get; set; }
        [JsonProperty(PropertyName = "expiration_date")]
        public DateTime? ExpirationDate { get; set; }
    }
}

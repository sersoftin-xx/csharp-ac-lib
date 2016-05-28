using System;
using Newtonsoft.Json;

namespace CSharpACLib.Entities
{
    class Bid
    {
        [JsonProperty(PropertyName = "id")]
        public int Id;
        [JsonProperty(PropertyName = "product_id")]
        public int ProductId;
        [JsonProperty(PropertyName = "pc_id")]
        public int PcId;
        [JsonProperty(PropertyName = "application_date")]
        public DateTime? ApplicationDate;
        [JsonProperty(PropertyName = "is_active")]
        public bool IsActive;
        [JsonProperty(PropertyName = "is_expired")]
        public bool IsExpired;
        [JsonProperty(PropertyName = "activation_date")]
        public DateTime? ActivationDate;
        [JsonProperty(PropertyName = "expiration_date")]
        public DateTime? ExpirationDate;
    }
}

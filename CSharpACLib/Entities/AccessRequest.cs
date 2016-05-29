using Newtonsoft.Json;

namespace CSharpACLib.Entities
{
    class AccessRequest
    {
        [JsonProperty(PropertyName = "pc_name")]
        public string PcName { get; set; }
        [JsonProperty(PropertyName = "pc_unique_key")]
        public string PcUniqueKey { get; set; }
        [JsonProperty(PropertyName = "product_id")]
        public int ProductId { get; set; }
    }
}

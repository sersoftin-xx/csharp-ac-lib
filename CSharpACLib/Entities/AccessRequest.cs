using Newtonsoft.Json;

namespace CSharpACLib.Entities
{
    class AccessRequest
    {
        [JsonProperty(PropertyName = "pc_name")]
        public string PcName;
        [JsonProperty(PropertyName = "pc_unique_key")]
        public string PcUniqueKey;
        [JsonProperty(PropertyName = "product_id")]
        public int ProductId;
    }
}

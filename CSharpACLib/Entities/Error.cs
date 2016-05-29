using Newtonsoft.Json;

namespace CSharpACLib.Entities
{
    class Error
    {
        [JsonProperty(PropertyName = "code")]
        public int Code { get; set; }
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
    }
}

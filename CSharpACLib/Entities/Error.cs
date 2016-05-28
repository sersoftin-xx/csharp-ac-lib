using Newtonsoft.Json;

namespace CSharpACLib.Entities
{
    class Error
    {
        [JsonProperty(PropertyName = "code")]
        public int Code;
        [JsonProperty(PropertyName = "message")]
        public string Message;
        [JsonProperty(PropertyName = "url")]
        public string Url;
    }
}

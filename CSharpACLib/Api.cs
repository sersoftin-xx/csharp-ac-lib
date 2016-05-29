using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using CSharpACLib.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CSharpACLib
{
    class Api
    {
        private readonly string _baseUrl;
        private readonly byte[] _certHash;
        public Api(string baseUrl, byte[] certHash)
        {
            _baseUrl = baseUrl;
            _certHash = certHash;
            ServicePointManager.ServerCertificateValidationCallback += CheckCertificate;
        }
        private string ExecuteGetApiMethod(string methodName)
        {
            var client = new WebClient();
            client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            client.Encoding = Encoding.UTF8;
            return client.DownloadString(new Uri(_baseUrl + "client_api" + methodName));
        }

        private string ExecutePostApiMethod(string methodName, AccessRequest request)
        {
            var client = new WebClient();
            client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            client.Encoding = Encoding.UTF8;
            var bodyString = JsonConvert.SerializeObject(request);
            return client.UploadString(new Uri(_baseUrl + "client_api" + methodName), bodyString);
        }

        private bool CheckCertificate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors error)
        {
            //return cert.GetCertHash().SequenceEqual(_certHash);
            return true;
        }

        public List<Product> GetProductsList()
        {
            var jsonResponse = ExecuteGetApiMethod("/products/list");

            var jsonObject = JObject.Parse(jsonResponse);
            return jsonObject.SelectToken("products", false).ToObject<List<Product>>();
        }

        public Product GetProductInfo(int productId)
        {
            var jsonResponse = ExecuteGetApiMethod("/products/info/" + productId);

            var jsonObject = JObject.Parse(jsonResponse);
            return jsonObject.SelectToken("product", false).ToObject<Product>();
        }

        public Bid Check(string pcUniqueKey, int productId)
        {
            try
            {
                var accessRequest = new AccessRequest
                {
                    PcName = null,
                    PcUniqueKey = pcUniqueKey,
                    ProductId = productId
                };
                var jsonResponse = ExecutePostApiMethod("/bids/check", accessRequest);
                var jsonObject = JObject.Parse(jsonResponse);
                return jsonObject.SelectToken("bid", false).ToObject<Bid>();
            }
            catch (WebException exception)
            {
                using (var response = exception.Response as HttpWebResponse)
                {
                    var responseStream = response?.GetResponseStream();
                    if (responseStream == null) throw;
                    using (var streamReader = new StreamReader(responseStream))
                    {
                        var jsonResponse = streamReader.ReadToEnd();
                        var error = JsonConvert.DeserializeObject<Error>(jsonResponse);
                        throw new Exception($"Code: {error.Code}, Url: {error.Url}, Messsage: {error.Message}");
                    }
                }
            }
        }

        public Bid Add(string pcName, string pcUniqueKey, int productId)
        {
            try
            {
                var accessRequest = new AccessRequest
                {
                    PcName = pcName,
                    PcUniqueKey = pcUniqueKey,
                    ProductId = productId
                };
                var jsonResponse = ExecutePostApiMethod("/bids/add", accessRequest);
                var jsonObject = JObject.Parse(jsonResponse);
                return jsonObject.SelectToken("bid", false).ToObject<Bid>();
            }
            catch (WebException exception)
            {
                using (var response = exception.Response as HttpWebResponse)
                {
                    var responseStream = response?.GetResponseStream();
                    if (responseStream == null) throw;
                    using (var streamReader = new StreamReader(responseStream))
                    {
                        var jsonResponse = streamReader.ReadToEnd();
                        var error = JsonConvert.DeserializeObject<Error>(jsonResponse);
                        throw new Exception($"Code: {error.Code}, Url: {error.Url}, Messsage: {error.Message}");
                    }
                }
            }
        }
    }
}

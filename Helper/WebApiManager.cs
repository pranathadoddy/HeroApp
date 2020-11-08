using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HeroApp.Helper
{
    public class WebApiManager : IWebApiManager
    {
        private string BaseEndPoint = "https://staging.hero.travel/api/v2/";

        private string ApiKey = "";

        public IDictionary<string, string> Headers { get; set; }

        public string EndPoint { get; set; }

        public async Task<T> GetRequestAsync<T>()
        {
            try
            {
                var endPoint = $"{this.BaseEndPoint}{this.EndPoint}"; 
                using (var request = new HttpRequestMessage(HttpMethod.Get, endPoint))
                using (var client = new HttpClient())
                {
                    request.Headers.Add("apiKey", this.ApiKey);
                    
                    if(this.Headers != null)
                    {
                        foreach (var header in this.Headers)
                        {
                            request.Headers.Add(header.Key, header.Value);
                        }
                    }
                   
                    var apiResponse = await client.SendAsync(request).ConfigureAwait(false);

                    if (!apiResponse.IsSuccessStatusCode)
                    {
                        throw new Exception("Error When Sending request");
                    };

                    var responseString = await apiResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var basicResponse = JsonConvert.DeserializeObject<T>(responseString);

                    return basicResponse;
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}

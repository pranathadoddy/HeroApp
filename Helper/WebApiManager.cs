using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace HeroApp.Helper
{
    public class WebApiManager : IWebApiManager
    {
        private string BaseEndPoint = "https://staging.hero.travel/api/v2/";

        private string ApiKey = "";

        public IDictionary<string, string> Headers { get; set; }

        public string EndPoint { get; set; }

        public string BodyContent { get; set; }

        public HttpMethod HttpMethod { get; set; }

        public async Task<T> SendRequestAsync<T>()
        {
            try
            {
                var endPoint = $"{this.BaseEndPoint}{this.EndPoint}"; 
                using (var request = new HttpRequestMessage(this.HttpMethod, endPoint))
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

                    if(this.BodyContent != null)
                    {
                        request.Content = new StringContent(this.BodyContent, Encoding.UTF8, "application/json");
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

using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HeroApp.Helper
{
    public interface IWebApiManager
    {
        IDictionary<string, string> Headers { get; set; }

        string EndPoint { get; set; }

        string BodyContent { get; set; }

        HttpMethod HttpMethod { get; set; }

        Task<T> SendRequestAsync<T>();
    }
}

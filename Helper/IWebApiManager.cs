using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeroApp.Helper
{
    public interface IWebApiManager
    {
        IDictionary<string, string> Headers { get; set; }

        string EndPoint { get; set; }

        Task<T> GetRequestAsync<T>();
    }
}

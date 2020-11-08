using DalSoft.RestClient;
using HeroApp.Helper;
using HeroApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeroApp.Controllers
{
    public class SearchProductController : Controller
    {
        private readonly IWebApiManager _webApiManager;
        private const string DefaultLat = "-8.739184";
        private const string DefaultLng = "115.171127";

        public SearchProductController(IWebApiManager webApiManager)
        {
            this._webApiManager = webApiManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ProductList(string keyword)
        {
            this._webApiManager.EndPoint = $"search?q={keyword}&lat={DefaultLat}&lng={DefaultLng}";
            var result = await this._webApiManager.GetRequestAsync<IEnumerable<ProductVm>>();

            return this.PartialView(result);
        }

        public IActionResult ViewBookingDate()
        {
            return this.View();
        }
    }
}

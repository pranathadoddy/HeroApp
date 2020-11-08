using HeroApp.Helper;
using HeroApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;

namespace HeroApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebApiManager _webApiManager;

        public HomeController(IWebApiManager webApiManager)
        {
            this._webApiManager = webApiManager;
        }

        public IActionResult Index()
        {
            var cultureInfo = CultureInfo.GetCultures(CultureTypes.AllCultures);
            var model = new IndexVm();
            model.Countries = new Dictionary<string, string>();

            foreach (var item in cultureInfo)
            {
                if (!model.Countries.ContainsKey(item.ThreeLetterISOLanguageName))
                {
                    model.Countries.Add(item.ThreeLetterISOLanguageName, item.EnglishName);
                }
            }

            return View(model);
        }

        public async Task<IActionResult> CreateProfile(CreateProfileModel model)
        {
            this._webApiManager.HttpMethod = HttpMethod.Post;
            this._webApiManager.BodyContent = JsonConvert.SerializeObject(model);
            this._webApiManager.EndPoint = "pax";
            var response = await this._webApiManager.SendRequestAsync<CreateProfileModel>();

            return this.Json(new { response });
           
        }
    }
}

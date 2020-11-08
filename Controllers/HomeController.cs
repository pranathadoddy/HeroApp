using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HeroApp.Models;
using System.Globalization;

namespace HeroApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

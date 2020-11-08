using HeroApp.Helper;
using HeroApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HeroApp.Controllers
{
    public class BookingController : Controller
    {
        private readonly IWebApiManager _webApiManager;

        public BookingController(IWebApiManager webApiManager)
        {
            this._webApiManager = webApiManager;
        }


        public IActionResult ViewBookingDate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking(CreateBookingModel model)
        {
            model.BookingName = string.Empty;

            this._webApiManager.HttpMethod = HttpMethod.Post;
            this._webApiManager.BodyContent = JsonConvert.SerializeObject(model);
            this._webApiManager.EndPoint = "bookings";
            var response = await this._webApiManager.SendRequestAsync<BookingModel>();

            return this.Json(new { response });
        }


        public async Task<IActionResult> GetAvailableSchedule(int productId, DateTime startDateTime, DateTime endDateTime)
        {
            this._webApiManager.HttpMethod = HttpMethod.Get;
            this._webApiManager.EndPoint = $"/schedule/{productId}/{startDateTime:yyyy-MM-dd}/{endDateTime:yyyy-MM-dd}";
            var response = await this._webApiManager.SendRequestAsync<IEnumerable<ScheduleModel>>();

            return this.Json(new { response });
        }
    }
}

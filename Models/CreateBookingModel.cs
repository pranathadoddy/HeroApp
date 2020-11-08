using Newtonsoft.Json;
using System.Collections.Generic;

namespace HeroApp.Models
{
    public class CreateBookingModel
    {
        [JsonProperty("bookingName")]
        public string BookingName { get; set; }

        [JsonProperty("bookingProducts")]
        public ICollection<BookingProductModel> BookingProducts { get; set; }

    }
}

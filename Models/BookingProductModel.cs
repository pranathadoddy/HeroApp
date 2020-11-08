using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroApp.Models
{
    public class BookingProductModel
    {
        [JsonProperty("productId")]
        public int ProductId { get; set; }

        [JsonProperty("paxId")]
        public ICollection<string> PaxIds { get; set; }

        [JsonProperty("dateCheckIn")]
        public DateTime DateCheckIn { get; set; }
    }
}

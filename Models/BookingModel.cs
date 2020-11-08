using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroApp.Models
{
    public class BookingModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("create")]
        public string Created { get; set; }

        [JsonProperty("rrp")]
        public int Rrp { get; set; }

        [JsonProperty("commision")]
        public int Commision { get; set; }

        [JsonProperty("payable")]
        public int Payable { get; set; }

        [JsonProperty("adjustment")]
        public int Adjustment { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }
    }
}

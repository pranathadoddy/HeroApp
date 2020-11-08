using Newtonsoft.Json;

namespace HeroApp.Models
{
    public class ScheduleModel
    {
        [JsonProperty("start")]
        public string Start { get; set; }

        [JsonProperty("end")]
        public string End { get; set; }

        [JsonProperty("available")]
        public bool IsAvailable { get; set; }
    }
}

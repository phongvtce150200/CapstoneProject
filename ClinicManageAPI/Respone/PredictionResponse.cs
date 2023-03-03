using Newtonsoft.Json;
using System.Collections.Generic;

namespace ClinicManageAPI.Respone
{
    public class PredictionResponse
    {
        [JsonProperty("percentage")]
        public Dictionary<string, double> Percentage { get; set; }
    }
}

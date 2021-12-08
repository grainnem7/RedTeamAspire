using Newtonsoft.Json;
using System;

namespace RedTeamAspire.Models
{
    public class container1
    {
        [JsonProperty(PropertyName = "id")]
        public string Pond_Key { get; set; }

        [JsonProperty(PropertyName = "startDate")]
        public DateTimeOffset Start_Date { get; set; }

        [JsonProperty(PropertyName = "initialPopulation")]
        public int Intial_Population { get; set; }

        [JsonProperty(PropertyName = "initialAverageWeight")]
        public double Intial_Average_Weight { get; set; }

        [JsonProperty(PropertyName = "estimatedEndDate")]

        public DateTimeOffset Estimated_End_Date { get; set; }

        [JsonProperty(PropertyName = "estimatedHarvestWeight")]
        public double Estimated_Harvest_Average_Weight { get; set; }

        [JsonProperty(PropertyName = "estimatedSurvival")]
        public int Estimated_Survival { get; set; }

        [JsonProperty(PropertyName = "foodType")]
        public string Food_Type { get; set; }
    }
}

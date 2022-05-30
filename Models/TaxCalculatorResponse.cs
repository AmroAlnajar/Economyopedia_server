using Newtonsoft.Json;

namespace economyopedia_server.Models
{
    public class TaxCalculatorResponse
    {
        [JsonProperty("Gross monthly")]
        public double GrossMonthly { get; set; }

        [JsonProperty("Net Monthly")]
        public double NetMonthly { get; set; }

        [JsonProperty("Tax payed")]
        public double TaxPayed { get; set; }

    }
}

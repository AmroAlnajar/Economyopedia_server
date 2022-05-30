using Newtonsoft.Json;

namespace economyopedia_server.Models
{
    public class TaxCalculatorResponse
    {
        [JsonProperty("GrossMonthly")]
        public double GrossMonthly { get; set; }

        [JsonProperty("NetMonthly")]
        public double NetMonthly { get; set; }

        [JsonProperty("TaxPaid")]
        public double TaxPaid { get; set; }

    }
}

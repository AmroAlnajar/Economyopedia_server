using economyopedia_server.Common;

namespace economyopedia_server.Models
{
    public class Income: BaseModel
    {
        public IncomeTypeEnum IncomeType { get; set; }
    }
}

namespace economyopedia_server.Helpers
{
    public static class ExternalData
    {
        public static double GetVacationMoney(double grossYearly)
        {
            var monthlySalary = grossYearly / 12;
            var holidayPayBasis = grossYearly - monthlySalary;
            var vacationMoneyPercent = 0.12;

            var vacationMoney = monthlySalary + (holidayPayBasis * vacationMoneyPercent) - (monthlySalary / 26) * 30;

            return Math.Round(vacationMoney, 0);
        }

    }
}

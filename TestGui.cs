using System.Collections.Generic;
using System;

namespace StockcheckIITestGui
{
    public class TestGui : IGui
    {
        public void SetStocks(List<StockCheckerII.StockEntity> stocks)
        {
            // Display header
            var header = String.Format("{0,-20}{1,8}{2,7}{3,18}{4,16}{5,15}{6,19}\n",
                                        "Name",
                                        "Jahr",
                                        "Rating",
                                        "Gewinnkorrelation",
                                        "Dividenwachstum",
                                        "Gewinnwachstum",
                                        "Ausschüttungsquote");
            Console.WriteLine(header);
            foreach (StockCheckerII.StockEntity stock in stocks)
            {
                var output = String.Format("{0,-20}{1,7}{2,8}{3,18}{4,16}{5,15}{6,19}",
                    stock.Name.Substring(0, Math.Min(stock.Name.Length, 20)),
                    stock.GetYearData()[stock.GetYearData().Count - 1].Year,
                    RatingToString(stock.Rating),
                    stock.EarningCorrelation,
                    stock.DividendGrowthFiveYears,
                    stock.EarningGrowthTreeYears,
                    stock.PayoutRatio);
                Console.WriteLine(output);
            }
        }

        private string RatingToString(StockCheckerII.StockEntity.Rate rate)
        {
            if (rate == StockCheckerII.StockEntity.Rate.A)
            {
                return "A";
            }
            if (rate == StockCheckerII.StockEntity.Rate.B)
            {
                return "B";
            }
            return "C";
        }
    }
}

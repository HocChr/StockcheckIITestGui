using System.Collections.Generic;
using System;

namespace StockcheckIITestGui
{
    public class TestGui : IGui
    {
        public void SetStocks(List<StockCheckerII.StockEntity> stocks)
        {

            // Display header
            var header = String.Format("{0,-20}{1,8}{2,20}{3,18}{4,16}{5,20}{6,20}\n",
                                          "Name",
                                           "Jahr",
                                            "Gewinnkorrelation",
                                             "Dividenwachstum",
                                             "Gewinnwachstum",
                                             "Ausschüttungsquote",
                                             "Bemerkung");
            Console.WriteLine(header);
            foreach (StockCheckerII.StockEntity stock in stocks)
            {
                var output = String.Format("{0,-20}{1,8}{2,20}{3,18}{4,16}{5,20}{6,45}",
                       stock.Name.Substring(0, Math.Min(stock.Name.Length, 20)),
                        stock.GetYearData()[stock.GetYearData().Count - 1].Year,
                         stock.EarningCorrelation,
                          stock.DividendGrowthFiveYears,
                          stock.EarningGrowthTreeYears,
                          stock.PayoutRatio,
                          stock.GetRemarks().Substring(0, Math.Min(stock.GetRemarks().Length, 45)));
                Console.WriteLine(output);
            }
        }
    }
}

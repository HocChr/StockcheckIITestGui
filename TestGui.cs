using System.Collections.Generic;
using System;
using System.IO;

namespace StockcheckIITestGui
{
    class Program
    {
        static void Main(string[] args)
        {
            var stockcheck = new StockCheckerII.Stockcheck(GetDatabaseFullPath());
            Write(stockcheck.GetStocks());
        }

        static string GetCurrentDatabase()
        {
            string[] paths = { Directory.GetCurrentDirectory(), "database", "currentDatabase.txt" };
            string fullPath = Path.Combine(paths);

            string currentDatabase;
            using (StreamReader sr = new StreamReader(fullPath))
            {
                currentDatabase = sr.ReadToEnd();
            }
            return currentDatabase + ".db";
        }
        static string GetDatabaseFullPath()
        {
            string currentDatabase = GetCurrentDatabase();
            string[] paths = { Directory.GetCurrentDirectory(), "database", currentDatabase };
            string fullPath = Path.Combine(paths);
            return fullPath;
        }

        static void Write(List<StockCheckerII.StockEntity> stocks)
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

        static string RatingToString(StockCheckerII.StockEntity.Rate rate)
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

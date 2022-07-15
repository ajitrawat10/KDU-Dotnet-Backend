using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2.Models
{
    public class CoinsData
    {
        public int Rank { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }

        public double Price { get; set; }

        public long CirculatingSupply { get; set; }

      

        public static CoinsData GetCoinsData(string csvLine)
        {
            string[] values = csvLine.Split(',');
            CoinsData coinsData = new CoinsData();

            coinsData.Rank = Convert.ToInt32(values[1]);
            coinsData.Name = values[2];
            coinsData.Symbol = values[3];
            coinsData.Price = Convert.ToDouble(values[4]);
            coinsData.CirculatingSupply = Convert.ToInt64(values[5]);

            return coinsData;
        }

    }
}

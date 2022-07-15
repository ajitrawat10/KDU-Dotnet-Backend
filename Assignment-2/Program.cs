using Assignment_2.Models;
using System.Text.Json;

namespace Assignment_2
{
    internal class Program
    {
        static List<Assignment_2.Models.CoinsData> coinsList;
        private static Stream jsonArray;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Wosafdsasdfasrldsdfasfd!");
            coinsList = File.ReadAllLines("D:\\KDU\\Assignment-2\\Files\\coins.csv")
                                         .Skip(1)
                                         .Select(v => CoinsData.GetCoinsData(v))
                                         .ToList();


         

            
            Console.WriteLine("1. Given the name or code of a coin, retrieve all its details");
            Console.WriteLine("2. Display top 50 coins in the market based on price.");
            Console.WriteLine("3. For a given trader, show his portfolio.");
            Console.WriteLine("4. For a given trader, display the total profit or loss they have made trading in the crypto market.");
            Console.WriteLine("Show top 5 and bottom 5 traders based on their profit/loss.");
                


            Console.WriteLine("Select a choice from above menu");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {


                case 1:
                    RetriveCoinsDetails();
                    break;

                case 2:
                    Top50Coins();
                    break;

                case 3:
                    TraderPortfolio();
                    break;

               default:
                    Console.WriteLine("No match found");
                    break;

            }
        }

        

        static void RetriveCoinsDetails()
        {
            Console.WriteLine("Enter Name of Coin");
            string coinName = Console.ReadLine();

            foreach(var coin in coinsList)
            {
                if (coin.Name == coinName)
                {
                    Console.WriteLine(coin.Name + " " + coin.Symbol + " " + coin.Price + " " + coin.CirculatingSupply);
                }
            }
        }

        static void Top50Coins()
        {
            var top50CoinsList = coinsList.OrderByDescending(c => c.Price).Take(50);

            foreach (var coin in top50CoinsList)
            {
                Console.WriteLine(coin.Name + " "+ coin.Price);
            }
        }

        static void TraderPortfolio()
        {
            Console.WriteLine("Enter Name of Coin");
            string traderName = Console.ReadLine();

            Console.WriteLine(traderName);


            Dictionary<string, List<string>> traderPortfolio = new Dictionary<string, List<string>>();




        }

    }
}
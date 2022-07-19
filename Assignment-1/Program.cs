
namespace Assignment_1
{

    public class Program
    {
        static List<Assignment_1.IplTournament>? playerList;
        public static void Main(string[] args)
        {

            playerList = GetListOfPlayers();


            Console.WriteLine("Case 1 : Get Bowlers who have taken 40 wickets");
            Console.WriteLine("Case 2 : Get Players by the Name");
            Console.WriteLine("Case 3 : Top Batsmen and Wicket Taker of the team");
            Console.WriteLine("Case 4 : Top three batsmen ,Top three Bowler and Top three All Rounder in the season");
            Console.WriteLine("Case 5 : Score of the two teams if each team plays with 11 best players");
            Console.WriteLine("Case 6 : Next-Generation Player of Each team");




            Console.WriteLine("Enter a number along side with the feature available\n");
            int num = Convert.ToInt32(Console.ReadLine());

            switch (num)
            {
                

                case 1:
                    BowlersTaken40Wickets();
                    break;

                case 2:
                    GetPlayersByName();
                    break;

                case 3:
                    TopBatsmenAndTopBowler();
                    break;

                case 4:
                    TopThreeBatsmenBowlerAndAllRounder();
                    break;
                case 5:
                    PredictedScoreOfTwoBestTeam();
;
                    break;
                case 6:
                    NextGenPlayerOfEachTeam();
                    break;

                default:
                    Console.WriteLine("No match found");
                    break;

            }
        }

        
        static void GetPlayersByName()
        {
            Console.WriteLine("Enter the Name of the Player");
            string playerName = Console.ReadLine();
            List<Assignment_1.IplTournament> listOfPlayers = new List<Assignment_1.IplTournament>();

            foreach(var list in playerList)
            {
                string name = list.Name;
                int lengthOfGivenName = playerName.Count();
                
                    for (int i = 0; i < name.Length - lengthOfGivenName + 1; i++)
                    {
                        string subName = name.Substring(i, lengthOfGivenName);
                        if (subName == playerName)
                        {
                            listOfPlayers.Add(list);
                        }
                    }
                
                
            }

            
            Console.WriteLine(new String('=', 80));
            Console.WriteLine("List of the Players");
            Console.WriteLine(new String('=', 80));
            foreach (var list in listOfPlayers)
            {
                Console.WriteLine("Name of players " + list.Name );
                Console.WriteLine("Wickets " + list.Wickets);
                Console.WriteLine("Runs " + list.Runs);
            }

        }

        static void PredictedScoreOfTwoBestTeam()
        {

            var CskTop11List = playerList.Where(t => t.Team == "CSK")
                .OrderByDescending(x => x.Average).ToList().Take(11);

            double cskAverage = 0;
            foreach (var item in CskTop11List)
            {

                cskAverage += item.Average;
            }
            var MITop11List = playerList.Where(t => t.Team == "MI")
                       .OrderByDescending(x => x.Average).ToList().Take(11);

            double miAverage = 0;
            foreach (var item in MITop11List)
            {
                miAverage += item.Average;
            }
            var RrTop11List = playerList.Where(t => t.Team == "RR")
                       .OrderByDescending(x => x.Average).ToList().Take(11);

            double rrAverage = 0;
            foreach (var item in RrTop11List)
            {
                rrAverage += item.Average;
            }
            var SrhTop11List = playerList.Where(t => t.Team == "SRH")
                       .OrderByDescending(x => x.Average).ToList().Take(11);

            double srhAverage = 0;
            foreach (var item in SrhTop11List)
            {
                srhAverage += item.Average;
            }
            var PbksTop11List = playerList.Where(t => t.Team == "PBKS")
                       .OrderByDescending(x => x.Average).ToList().Take(11);

            double pbksAverage = 0;
            foreach (var item in PbksTop11List)
            {
                pbksAverage += item.Average;
            }
            var RcbTop11List = playerList.Where(t => t.Team == "RCB")
                       .OrderByDescending(x => x.Average).ToList().Take(11);

            double rcbAverage = 0;
            foreach (var item in RcbTop11List)
            {
                rcbAverage += item.Average;
            }
            var DcTop11List = playerList.Where(t => t.Team == "DC")
                       .OrderByDescending(x => x.Average).ToList().Take(11);

            double dcAverage = 0;
            foreach (var item in DcTop11List)
            {
                dcAverage += item.Average;
            }
            var KkrTop11List = playerList.Where(t => t.Team == "KKR")
                       .OrderByDescending(x => x.Average).ToList().Take(11);

            double kkrAverage = 0;
            foreach (var item in KkrTop11List)
            {
                kkrAverage += item.Average;

            }

            Dictionary<double, string> dict = new Dictionary<double, string>()
            {
                {cskAverage,"CSK" },{miAverage,"MI"},{rrAverage,"RR"},{srhAverage,"SRH"},{pbksAverage,"PBKS"},
                { rcbAverage,"RCB"},{dcAverage,"DC" },{kkrAverage,"KKR"}
            };

          
            var TopTwoTeams = dict.OrderByDescending(u => u.Key).ToList().Take(2);

            Console.WriteLine(new String('=', 80));
            Console.WriteLine("Top 2 teams and Their Predicted Score are :");
            Console.WriteLine(new String('=', 80));

            foreach (var x in TopTwoTeams)
            {

                Console.WriteLine("Team : " + x.Value + " Predicted Score: "+ Convert.ToInt32(x.Key));
            }


        }
        static void NextGenPlayerOfEachTeam()
        {
            var CskTop11List = playerList.Where(t => t.Team == "CSK")
                .OrderByDescending(x => x.Average).ThenByDescending(y => y.Wickets).ToList().Take(11);


            var MITop11List = playerList.Where(t => t.Team == "MI")
                .OrderByDescending(x => x.Average).ThenByDescending(y => y.Wickets).ToList().Take(11);


            var RrTop11List = playerList.Where(t => t.Team == "RR")
                .OrderByDescending(x => x.Average).ThenByDescending(y => y.Wickets).ToList().Take(11);


            var SrhTop11List = playerList.Where(t => t.Team == "SRH")
                .OrderByDescending(x => x.Average).ThenByDescending(y => y.Wickets).ToList().Take(11);


            var PbksTop11List = playerList.Where(t => t.Team == "PBKS")
                .OrderByDescending(x => x.Average).ThenByDescending(y => y.Wickets).ToList().Take(11);

            var RcbTop11List = playerList.Where(t => t.Team == "RCB")
                .OrderByDescending(x => x.Average).ThenByDescending(y => y.Wickets).ToList().Take(11);


            var DcTop11List = playerList.Where(t => t.Team == "DC")
                .OrderByDescending(x => x.Average).ThenByDescending(y => y.Wickets).ToList().Take(11);


            var KkrTop11List = playerList.Where(t => t.Team == "KKR")
                .OrderByDescending(x => x.Average).ThenByDescending(y => y.Wickets).ToList().Take(11);

            Console.WriteLine(new string('=', 80));
            Console.WriteLine("CSk Playing 11 are :");
            Console.WriteLine(new string('=', 80));

            foreach (var item in CskTop11List)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine(new string('=', 80));
            Console.WriteLine("MI Playing 11 are :");
            Console.WriteLine(new string('=', 80));

            foreach (var item in MITop11List)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine(new string('=', 80));
            Console.WriteLine("RR Playing 11 are :");
            Console.WriteLine(new string('=', 80));

            foreach (var item in RrTop11List)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine(new string('=', 80));
            Console.WriteLine("SRH Playing 11 are :");
            Console.WriteLine(new string('=', 80));

            foreach (var item in SrhTop11List)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine(new string('=', 80));
            Console.WriteLine("PBKS Playing 11 are :");
            Console.WriteLine(new string('=', 80));

            foreach (var item in PbksTop11List)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine(new string('=', 80));
            Console.WriteLine("RCB Playing 11 are :");
            Console.WriteLine(new string('=', 80));

            foreach (var item in RcbTop11List)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine(new string('=', 80));
            Console.WriteLine("DC Playing 11 are :");
            Console.WriteLine(new string('=', 80));

            foreach (var item in DcTop11List)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine(new string('=', 80));
            Console.WriteLine("KKR Playing 11 are :");
            Console.WriteLine(new string('=', 80));

            foreach (var item in KkrTop11List)
            {
                Console.WriteLine(item.Name);
            }



        }
        static void BowlersTaken40Wickets()
        {
            Console.WriteLine("Enter a Team Name");
            string teamName = Console.ReadLine();

            Console.WriteLine(new String('=', 80));
            Console.WriteLine("Bowlers of " + teamName + " Team who have taken atleast 40 Wickets");
            Console.WriteLine(new String('=', 80));
            foreach (var x in playerList)
            {

                if (x.Team == teamName && x.Wickets >= 40)
                {
                    Console.WriteLine(x.Name);
                }

            }

        }

        static void TopBatsmenAndTopBowler()
        {
            Console.WriteLine("Enter a Team Name");
            string teamName = Console.ReadLine();

            int wicket = -1;
            string highestWicketTakerPlayer = "";
            int run = -1;
            string highestRunScorerPlayer = "";

            // Highest Wicket Taker Player
            foreach (var cr in playerList)
            {
                if (cr.Wickets > wicket && cr.Team == teamName)
                {
                    wicket = cr.Wickets;
                    highestWicketTakerPlayer = cr.Name;
                }
                if (cr.Runs > run && cr.Team == teamName)
                {
                    run = cr.Runs;
                    highestRunScorerPlayer = cr.Name;
                }


            }
            Console.WriteLine(new String('=', 80));
            Console.WriteLine(highestWicketTakerPlayer + " has Taken " + wicket + " Wickets");
            Console.WriteLine(highestRunScorerPlayer + " has Scored " + run + " Runs");

        }

        static void TopThreeBatsmenBowlerAndAllRounder()
        {
            var topBatsmenList = playerList.OrderByDescending(x => x.Runs).ToList().Take(3);
            Console.WriteLine(new String('=', 80));
            Console.WriteLine("\nTop Three Batsmen in the Season");

            foreach (var list in topBatsmenList)
            {
                Console.WriteLine(list.Name);
            }
            var topBowlerList = playerList.OrderByDescending(x => x.Wickets).ToList().Take(3);
            Console.WriteLine(new String('=', 80));
            Console.WriteLine("\nTop Three Bowler in the Season");

            foreach (var list in topBowlerList)
            {
                Console.WriteLine(list.Name);
            }

            var topAllRounderList = playerList.OrderByDescending(x => x.Average).ThenByDescending(y => y.Wickets).ToList().Take(3);

            Console.WriteLine("\nTop Three All Rounder in the Season");
            Console.WriteLine(new String('=', 80));

            foreach (var list in topAllRounderList)
            {
                Console.WriteLine(list.Name);
            }





        }
        static List<Assignment_1.IplTournament> GetListOfPlayers()
        {
            var importer = new Importer();
            importer.Mappings = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("Name","Name"),
                        new KeyValuePair<string, string>("Team","Team"),
                        new KeyValuePair<string, string>("Role","Role"),
                        new KeyValuePair<string, string>("Matches","Matches"),
                        new KeyValuePair<string, string>("Runs","Runs"),
                        new KeyValuePair<string, string>("Average","Average"),
                        new KeyValuePair<string, string>("SR","SR"),
                        new KeyValuePair<string, string>("Wickets","Wickets"),


                    };

            List<Assignment_1.IplTournament> list = importer.Import<IplTournament>(@"D:\KDU\KDU-Dotnet-Backend\Assignment-1\data.csv");
            return list;
        }



    }



    public class IplTournament

    {

        public string Name { get; set; }
        public string Team { get; set; }
        public string Role { get; set; }
        public int Matches { get; set; }

        public int Runs { get; set; }
        public double Average { get; set; }

        public double SR { get; set; }

        public int Wickets { get; set; }

    }


    public class Importer
    {
        public List<KeyValuePair<string, string>> Mappings;
        public List<T> Import<T>(string file)
        {
            List<T> list = new List<T>();
            List<string> lines = System.IO.File.ReadAllLines(file).ToList();
            string headerLine = lines[0];
            var headerInfo = headerLine.Split(',').ToList().Select((v, i) => new { ColName = v, ColIndex = i });

            Type type = typeof(T);
            var properties = type.GetProperties();
            var dataLines = lines.Skip(1);
            dataLines.ToList().ForEach(line =>
            {
                var values = line.Split(',');
                T obj = (T)Activator.CreateInstance(type);
                //Set values to object properties from csv columns
                foreach (var prop in properties)
                {
                    //find mapping for the prop
                    var mapping = Mappings.SingleOrDefault(m => m.Value == prop.Name);
                    var colName = mapping.Key;
                    var colIndex = headerInfo.SingleOrDefault(s => s.ColName == colName).ColIndex;
                    var value = values[colIndex];
                    var propType = prop.PropertyType;
                    prop.SetValue(obj, Convert.ChangeType(value, propType));
                }
                list.Add(obj);
            });
            return list;
        }
    }

}
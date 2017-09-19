namespace MainApp
{
    using System;
    using System.Linq;

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Please Enter Map Coordinate");
            string[] mapCoordinates = Console.ReadLine().TrimEnd().Split(null);
            int[] coordinates = Array.ConvertAll(mapCoordinates, int.Parse);

            MarsPlateau platau = new MarsPlateau(coordinates[0], coordinates[1]);
            Nasa nasa = new Nasa(platau);
            Strategy strategy = new Strategy(platau, 1);

            Console.WriteLine("Now you can add new rower. If you want to show results please enter q");

            GetRowersInput(nasa, strategy);
            nasa.DisplayRowers();

            Console.ReadKey();
        }

        private static void GetRowersInput(Nasa nasa, Strategy strategy)
        {
            while (true)
            {
                string input = Console.ReadLine().TrimEnd().ToUpper();

                if (input.Any(char.IsDigit))
                {
                    string[] rowerValues = input.Split(null);
                    nasa.AddRower(GenerateId(), Convert.ToInt32(rowerValues[0]), Convert.ToInt32(rowerValues[1]), DirectionState.CreateCommand(rowerValues[2]));
                }
                else if (!input.ToUpperInvariant().Equals("Q"))
                {
                    nasa.ExecuteCommands(input, strategy);
                }
                else
                {
                    break;
                }
            }
        }

        private static int GenerateId()
        {
            Random random = new Random();
            int i = random.Next();

            return i;
        }
    }
}

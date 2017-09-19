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

            var platau = new MarsPlateau(coordinates[0], coordinates[1]);
            var nasa = new Nasa(platau);

            Strategy strategy = new Strategy(platau, 1);

            Console.WriteLine("Now you can add new rower. If you want to show results please enter ");
            string input = string.Empty;

            do
            {
                IRower lastAddedRower = null;
                input = Console.ReadLine().TrimEnd().ToUpper();

                if (input.Any(char.IsDigit))
                {
                    string[] rowerValues = input.Split(null);

                    lastAddedRower = nasa.AddRower(
                        GenerateId(),
                        Convert.ToInt32(rowerValues[0]),
                        Convert.ToInt32(rowerValues[1]),
                        DirectionState.CreateCommand(rowerValues[2]));
                }
                else
                {
                    nasa.ExecuteCommands(input.ToRowerCommands(lastAddedRower, strategy));
                }
            }
            while (!input.Equals("q"));
        }

        private static int GenerateId()
        {
            Random random = new Random();
            int i = random.Next();

            return i;
        }
    }
}

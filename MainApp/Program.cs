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
            Nasa.CreateMap(coordinates[0], coordinates[1]);

            Strategy strategy = new MoveOneStepStrategy(Nasa.GetPlateau);

            Console.WriteLine("At least add a rower to system");
            string[] rowerValues = Console.ReadLine().TrimEnd().ToUpper().Split(null);
            Nasa.AddRower(GenerateId(), Convert.ToInt32(rowerValues[0]), Convert.ToInt32(rowerValues[1]), rowerValues[2].ToDirectionState());

            Console.WriteLine("Now you can add new rower or give command for rowers. If you want to exit please enter q");
            string input = string.Empty;

            IRower lastAddedRower = null;

            do
            {
                input = Console.ReadLine().TrimEnd().ToUpper();

                if (input.Any(char.IsDigit))
                {
                    rowerValues = input.Split(null);
                    lastAddedRower = Nasa.AddRower(GenerateId(), Convert.ToInt32(rowerValues[0]), Convert.ToInt32(rowerValues[1]), rowerValues[2].ToDirectionState());
                }
                else
                {
                    Nasa.ExecuteCommands(input.ToRowerCommands(lastAddedRower, strategy));
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

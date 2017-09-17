namespace MainApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using MainApp.Command;

    public static class Nasa
    {
        private static MarsPlateau Plateau;

        public static IPlateau GetPlateau
        {
            get
            {
                return Plateau;
            }
        }

        public static IPlateau CreateMap(int x, int y)
        {
            if (Plateau == null)
            {
                Plateau = new MarsPlateau(x, y);
                Console.WriteLine("Map Created");
            }
            else
            {
                Console.WriteLine("Map Already Created");
            }

            return Plateau;
        }

        public static IRower AddRower(int id,int x, int y, IDirectionState directionState)
        {
            IRower resultRower = null;

            if (Plateau.RowerList.Any(r => r.X == x && r.Y == y))
            {
                Console.WriteLine("You cannot add the rower because another rower on the same coordinate");
            }
            else
            {
                resultRower = new Rower(id, x, y, directionState);
                Plateau.RowerList.AddItem(resultRower);
                Console.WriteLine("Rower Added Id :{0}", id);
            }

            return resultRower;
        }

        public static void ExecuteCommands(List<RowerCommand> commands)
        {
            commands.ForEach(x => x.Apply());
        }
    }
}

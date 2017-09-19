namespace MainApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using MainApp.Command;

    public class Nasa
    {
        private IPlateau plateau;

        public Nasa(IPlateau plateau)
        {
            this.plateau = plateau;
        }

        public IRower AddRower(int id,int x, int y, DirectionState directionState)
        {
            IRower resultRower = null;

            if (this.plateau.RowerList.Any(r => r.X == x && r.Y == y))
            {
                Console.WriteLine("You cannot add the rower because another rower on the same coordinate");
            }
            else
            {
                resultRower = new Rower(id, x, y, directionState);
                this.plateau.RowerList.AddItem(resultRower);
                Console.WriteLine("Rower Added Id :{0}", id);
            }

            return resultRower;
        }

        public void ExecuteCommands(List<RowerCommand> commands)
        {
            commands.ForEach(x => x.Apply());
        }
    }
}

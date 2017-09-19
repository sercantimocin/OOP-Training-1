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

        public IRower AddRower(int id, int x, int y, DirectionState directionState)
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

        private List<RowerCommand> ConvertToRowerCommands(string rowerLetters, IRower rower, Strategy strategy)
        {
            return rowerLetters.Select(rowerLetter => RowerCommand.CreateCommand(rowerLetter, rower, strategy)).ToList();
        }

        public void ExecuteCommands(string commands, Strategy strategy)
        {
            var orderedtRower = this.plateau.RowerList.GetOrderedItem();

            var rowerCommands = this.ConvertToRowerCommands(commands, orderedtRower, strategy);

            rowerCommands.ForEach(x => x.Apply());
        }

        public void DisplayRowers()
        {
            this.plateau.RowerList.ToList().ForEach(x => x.GetStatus());
        }
    }
}

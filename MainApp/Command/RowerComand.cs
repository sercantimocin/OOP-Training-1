namespace MainApp.Command
{
    using System;
    using System.Linq;
    using System.Reflection;

    public abstract class RowerCommand
    {
        protected IRower Rower { get; private set; }

        protected RowerCommand(IRower rower)
        {
            this.Rower = rower;
        }

        protected internal abstract void Apply();

        public static RowerCommand CreateCommand(char commandChar, IRower rower, Strategy strategy)
        {
            RowerCommand resultCommand = null;

            if (commandChar == 'L')
            {
                resultCommand = new LeftCommand(rower);
            }
            else if (commandChar == 'R')
            {
                resultCommand = new RightCommand(rower);
            }
            else if (commandChar == 'M')
            {
                resultCommand = new MoveCommand(rower, strategy);
            }


            if (resultCommand == null)
            {
                throw new ArgumentOutOfRangeException("Invalid rower command");
            }

            return resultCommand;
        }
    }
}

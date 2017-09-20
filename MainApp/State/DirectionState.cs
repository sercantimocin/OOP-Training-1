namespace MainApp
{
    using System;
    using System.Linq;
    using System.Reflection;

    public abstract class DirectionState
    {
        private readonly string stateName;

        protected DirectionState(string stateName)
        {
            this.stateName = stateName;
        }

        protected internal abstract void Left(IRower rower);

        protected internal abstract void Right(IRower rower);

        protected internal abstract void Move(IRower rower, Strategy strategy);

        protected internal string GetName()
        {
            return this.stateName;
        }

        protected internal void ErrorMessage(IRower rower)
        {
            Console.WriteLine("This move cannot apply. Id: {0}  X: {1}  Y: {2} Direction: {3}", rower.Id, rower.X, rower.Y, this.GetName());
        }

        public static DirectionState CreateCommand(string stateChar)
        {
            Type type = Assembly.GetAssembly(typeof(DirectionState))
                                .ExportedTypes
                                .FirstOrDefault(x => x.IsClass
                                                  && x.IsSubclassOf(typeof(DirectionState))
                                                  && x.Name.StartsWith(stateChar.ToUpper()));

            if (type == null)
            {
                throw new ArgumentOutOfRangeException("Invalid rower state");
            }

            return (DirectionState)Activator.CreateInstance(type);
        }
    }
}

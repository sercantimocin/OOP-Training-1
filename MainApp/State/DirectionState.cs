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

        void ToString()
        {
            Console.Write(this.stateName);
        }

        public static DirectionState CreateCommand(string stateChar)
        {
            Type type = Assembly.GetAssembly(typeof(DirectionState))
                                .DefinedTypes
                                .FirstOrDefault(x => x.IsClass
                                                  && x.IsAssignableFrom(typeof(DirectionState))
                                                  && x.Name.StartsWith(stateChar.ToUpper()));

            if (type == null)
            {
                throw new ArgumentOutOfRangeException("Invalid rower state");
            }

            return (DirectionState)Activator.CreateInstance(type);
        }
    }
}

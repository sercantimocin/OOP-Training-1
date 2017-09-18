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
            Type type = Assembly.GetAssembly(typeof(RowerCommand))
                                .DefinedTypes
                                .FirstOrDefault(x => x.IsClass
                                                  && x.IsAssignableFrom(typeof(RowerCommand))
                                                  && x.Name.StartsWith(commandChar.ToString().ToUpper()));

            if (type == null)
            {
                throw new ArgumentOutOfRangeException("Invalid rower command");
            }

            return (RowerCommand)Activator.CreateInstance(type, rower, strategy);
        }
    }
}

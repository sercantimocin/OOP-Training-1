namespace MainApp
{
    using System.Collections.Generic;
    using System.Linq;

    using MainApp.Command;

    public static class Extensions
    {
        public static List<RowerCommand> ToRowerCommands(this string rowerLetters, IRower rower, Strategy strategy)
        {
            return rowerLetters.Select(rowerLetter => RowerCommand.CreateCommand(rowerLetter, rower, strategy)).ToList();
        }
    }
}

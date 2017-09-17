namespace MainApp
{
    using System;
    using System.Collections.Generic;

    using MainApp.Command;

    public static class Extensions
    {
        public static List<RowerCommand> ToRowerCommands(this string rowerLetters, IRower rower,Strategy strategy)
        {
            List<RowerCommand> comands = new List<RowerCommand>();

            foreach (char rowerLetter in rowerLetters)
            {
                switch (rowerLetter)
                {
                    case 'M':
                        comands.Add(new MoveCommand(rower, strategy));
                        break;
                    case 'L':
                        comands.Add(new TurnLeftCommand(rower));
                        break;
                    case 'R':
                        comands.Add(new TurnRightCommand(rower));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Rower command is invalid");
                }
            }

            return comands;
        }

        public static IDirectionState ToDirectionState(this string rowerDirection)
        {
            IDirectionState resultRowerDirection = null;

            switch (rowerDirection)
            {
                case "N":
                    resultRowerDirection = new North();
                    break;
                case "S":
                    resultRowerDirection = new South();
                    break;
                case "W":
                    resultRowerDirection = new West();
                    break;
                case "E":
                    resultRowerDirection = new East();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Rower direction is invalid");
            }

            return resultRowerDirection;
        }
    }
}

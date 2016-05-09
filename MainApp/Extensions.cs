namespace MainApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Reflection;

    /// <summary>
    /// The extensions.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// To the rower letter.
        /// </summary>
        /// <param name="rowerLetters">The rower letters.</param>
        /// <returns>RowerLetter list</returns>
        public static List<RowerLetter> ToRowerLetters(this string rowerLetters)
        {
            List<RowerLetter> resultRowerLetters = new List<RowerLetter>();

            foreach (char rowerLetter in rowerLetters)
            {
                switch (rowerLetter)
                {
                    case 'M':
                        resultRowerLetters.Add(RowerLetter.Move);
                        break;
                    case 'L':
                        resultRowerLetters.Add(RowerLetter.Left);
                        break;
                    case 'R':
                        resultRowerLetters.Add(RowerLetter.Right);
                        break;
                }
            }

            return resultRowerLetters;
        }

        /// <summary>
        /// To the rower direction.
        /// </summary>
        /// <param name="rowerDirection">The rower direction.</param>
        /// <returns>Direction</returns>
        public static Direction ToRowerDirection(this string rowerDirection)
        {
            Direction resultRowerDirection = Direction.Unknown;

            switch (rowerDirection)
                {
                    case "N":
                        resultRowerDirection = Direction.North;
                        break;
                    case "S":
                        resultRowerDirection = Direction.South;
                        break;
                    case "W":
                        resultRowerDirection = Direction.West;
                        break;
                    case "E":
                        resultRowerDirection = Direction.East;
                        break;
                }

            return resultRowerDirection;

        }

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>Description</returns>
        public static string GetDescription(this Enum value)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name != null)
            {
                FieldInfo field = type.GetField(name);
                if (field != null)
                {
                    DescriptionAttribute attr =
                           Attribute.GetCustomAttribute(field,
                             typeof(DescriptionAttribute)) as DescriptionAttribute;
                    if (attr != null)
                    {
                        return attr.Description;
                    }
                }
            }
            return null;
        }
    }
}

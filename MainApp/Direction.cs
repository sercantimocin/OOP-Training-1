namespace MainApp
{
    using System.ComponentModel;

    /// <summary>
    /// Direction
    /// </summary>
    public enum Direction
    {
        /// <summary>
        /// The north.
        /// </summary>
        [Description("N")] 
        North = 0,

        /// <summary>
        /// The east
        /// </summary>
        [Description("E")] 
        East = 1,

        /// <summary>
        /// The south
        /// </summary>
        [Description("S")] 
        South = 2,

        /// <summary>
        /// The west
        /// </summary>
        [Description("W")] 
        West = 3,

        /// <summary>
        /// The unknown
        /// </summary>
        [Description("Unknown")] 
        Unknown = 4
    }
}

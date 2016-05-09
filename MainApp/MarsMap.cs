namespace MainApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// MarsMap
    /// </summary>
    public class MarsMap : IMap
    {
        /// <summary>
        /// The _rower list
        /// </summary>
        private readonly IList<IRower> _rowerList;

        /// <summary>
        /// Initializes a new instance of the <see cref="MarsMap"/> class.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public MarsMap(int x, int y)
        {
            X = x;
            Y = y;
            _rowerList = new List<IRower>();
        }

        /// <summary>
        /// Gets the x.
        /// </summary>
        /// <value>
        /// The x.
        /// </value>
        public int X { get; set; }

        /// <summary>
        /// Gets the y.
        /// </summary>
        /// <value>
        /// The y.
        /// </value>
        public int Y { get; set; }

        /// <summary>
        /// Gets the rower list.
        /// </summary>
        /// <value>
        /// The rower list.
        /// </value>
        public IList<IRower> RowerList
        {
            get
            {
                return _rowerList;
            }
        }
    }
}

namespace MainApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Nasa
    {
        #region Private Fields

        /// <summary>
        /// The Mars Map
        /// </summary>
        private static MarsMap _map;

        /// <summary>
        /// The _rower order
        /// </summary>
        private static int _rowerOrder;

        /// <summary>
        /// Gets or sets the rower order.
        /// </summary>
        /// <value>
        /// The rower order.
        /// </value>
        private static int RowerOrder
        {
            get
            {
                return _rowerOrder;
            }
            set
            {
                _rowerOrder = value;

                if (_map.RowerList.Count != 0 && _rowerOrder > _map.RowerList.Count - 1)
                {
                    _rowerOrder = _rowerOrder % _map.RowerList.Count;
                }
            }
        }

        #endregion Private Fields

        #region Public Fields

        public static IMap GetMap
        {
            get
            {
                return _map;
            }
        }

        #endregion Public Fields

        #region Public Methods

        /// <summary>
        /// Creates the map.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>
        /// bool
        /// </returns>
        public static IMap CreateMap(int x, int y)
        {
            if (_map == null)
            {
                _map = new MarsMap(x, y);
                Console.WriteLine("Map Created");
            }
            else
            {
                Console.WriteLine("Map Already Created");
            }

            return _map;
        }

        /// <summary>
        /// Adds the rower.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="direction">The direction.</param>
        public static IRower AddRower(int id,int x, int y, Direction direction, Strategy strategy)
        {
            IRower resultRower = null;

            if (_map.RowerList.Any(r => r.X == x && r.Y == y))
            {
                Console.WriteLine("You cannot add the rower beacuse another rower on the same coordinate");
            }
            else
            {
                resultRower = new Rower(id, x, y, direction, strategy);
                _map.RowerList.Add(resultRower);
                Console.WriteLine("Rower Added Id :{0}", id);
            }

            RowerOrder++;

            return resultRower;
        }

        /// <summary>
        /// Executes the rover command.
        /// </summary>
        public static void ExecuteRoverLetters(List<RowerLetter> rowerLetters)
        {
            var rower = GetQueuedRower();
            rowerLetters.ForEach(x => ExecuteRowerLetter(rower, x));
            RowerOrder++;
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Executes the rower letter.
        /// </summary>
        private static void ExecuteRowerLetter(IRower rower, RowerLetter rowerLetter)
        {
            if (rowerLetter == RowerLetter.Move)
            {
                rower.Move();
            }
            else if (rowerLetter == RowerLetter.Left)
            {
                rower.TurnLeft();
            }
            else if (rowerLetter == RowerLetter.Right)
            {
                rower.TurnRight();
            }
        }

        /// <summary>
        /// Gets the queued rower.
        /// </summary>
        /// <returns>Rower</returns>
        private static IRower GetQueuedRower()
        {
            return _map.RowerList[RowerOrder];
        }

        #endregion Private Methods
    }
}

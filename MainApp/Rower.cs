namespace MainApp
{
    using System;

    /// <summary>
    /// Rower
    /// </summary>
    public class Rower : IRower
    {
        /// <summary>
        /// The compass point count.
        /// </summary>
        private const byte COMPASS_POINT_COUNT = 4;

        /// <summary>
        /// The move strategcy
        /// </summary>
        private readonly Strategy _moveStrategcy;

        /// <summary>
        /// The _id
        /// </summary>
        private int _id;

        /// <summary>
        /// Initializes a new instance of the <see cref="Rower"/> class.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="direction">The direction.</param>
        public Rower(int id, int x, int y, Direction direction, Strategy moveStrategcy)
        {
            _id = id;
            X = x;
            Y = y;
            Direction = direction;
            _moveStrategcy = moveStrategcy;
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
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public Direction Direction { get; private set; }

        public int Id
        {
            get
            {
                return _id;
            }
        }

        /// <summary>
        /// Moves this instance.
        /// </summary>
        public void Move()
        {
            // Rower move given strategcy. Movement define in this class. It provide that some rower can move one step some rover can move according to different algorithm
            // More information http://www.dofactory.com/net/strategy-design-pattern
            _moveStrategcy.Move(Id);
            Console.WriteLine("Rower State {0} {1} {2} {3}", Id, X, Y, Direction);
        }

        /// <summary>
        /// Turns the left.
        /// </summary>
        public void TurnLeft()
        {
            Direction--;

            if (Direction < 0)
            {
                Direction += COMPASS_POINT_COUNT;
            }

            Console.WriteLine("Rower Turned Left Id : {0}", Id);
        }

        /// <summary>
        /// Turns the left.
        /// </summary>
        public void TurnRight()
        {
            Direction++;

            int rowerDirection = (int)Direction;

            if (rowerDirection == COMPASS_POINT_COUNT)
            {
                Direction -= COMPASS_POINT_COUNT;
            }

            Console.WriteLine("Rower Turned Right Id : {0}", Id);
        }
    }
}

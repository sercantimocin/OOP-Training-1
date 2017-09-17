namespace MainApp
{
    using System;

    public class Rower : IRower
    {
        private int id;

        private IDirectionState state;

        public Rower(int id, int x, int y, IDirectionState state)
        {
            this.X = x;
            this.Y = y;
            this.id = id;
            this.state = state;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public void ChangeState(IDirectionState state)
        {
            this.state = state;
        }

        public int Id
        {
            get
            {
                return this.id;
            }
        }

        public void Move(Strategy strategy)
        {
            this.state.Move(this, strategy);
            Console.WriteLine("Rower State {0} {1} {2} {3}", Id, X, Y, this.state);
        }

        /// <summary>
        /// Turns the left.
        /// </summary>
        public void TurnLeft()
        {
            this.state.Left(this);
            Console.WriteLine("Rower Turned Left Id : {0}", Id);
        }

        /// <summary>
        /// Turns the left.
        /// </summary>
        public void TurnRight()
        {
            this.state.Right(this);
            Console.WriteLine("Rower Turned Right Id : {0}", Id);
        }
    }
}

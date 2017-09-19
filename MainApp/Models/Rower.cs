namespace MainApp
{
    using System;

    public class Rower : IRower
    {
        private int id;

        private DirectionState state;

        public Rower(int id, int x, int y, DirectionState state)
        {
            this.X = x;
            this.Y = y;
            this.id = id;
            this.state = state;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public void ChangeState(DirectionState state)
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
        }

        public void TurnLeft()
        {
            this.state.Left(this);
        }

        public void TurnRight()
        {
            this.state.Right(this);
        }

        public void GetStatus()
        {
            Console.WriteLine($"{this.X} {this.Y} {this.state.GetName()}");
        }
    }
}

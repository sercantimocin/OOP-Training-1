namespace MainApp
{
    using System;

    public class West : DirectionState
    {
        public West() : base("W")
        {
        }

        protected internal override void Left(IRower rower)
        {
            rower.ChangeState(new South());
        }

        protected internal override void Right(IRower rower)
        {
            rower.ChangeState(new North());
        }

        protected internal override void Move(IRower rower, Strategy strategy)
        {
            int newX = rower.X - strategy.Step;

            if (strategy.IsOutOfMap(newX, strategy.Plateau.X) || strategy.IsCollisionCase(rower))
            {
                Console.WriteLine("This move cannot apply. Id: {0}  X: {1}  Y: {2}", rower.Id, rower.X, rower.Y);
            }
            else
            {
                rower.X = newX;
            }
        }
    }
}
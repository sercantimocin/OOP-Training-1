namespace MainApp
{
    using System;

    public class North : IDirectionState
    {
        public North() : base("N")
        {
        }

        protected internal override void Left(IRower rower)
        {
            rower.ChangeState(new West());
        }

        protected internal override void Right(IRower rower)
        {
            rower.ChangeState(new East());
        }

        protected internal override void Move(IRower rower, Strategy strategy)
        {
            int newY = rower.Y + strategy.Step;

            if (strategy.IsOutOfMap(newY, strategy.Plateau.Y) || strategy.IsCollisionCase(rower))
            {
                Console.WriteLine("This move cannot apply. Id: {0}  X: {1}  Y: {2}", rower.Id, rower.X, rower.Y);
            }
            else
            {
                rower.Y = newY;
            }
        }
    }
}
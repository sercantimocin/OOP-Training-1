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
                this.ErrorMessage(rower);
            }
            else
            {
                rower.X = newX;
            }
        }
    }
}
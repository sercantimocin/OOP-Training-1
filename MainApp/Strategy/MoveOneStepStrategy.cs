namespace MainApp
{
    public class MoveOneStepStrategy : Strategy
    {
        public MoveOneStepStrategy(IPlateau plateau)
            : base(plateau, 1)
        {
        }

        /// <summary>
        /// Moves the specified rower.
        /// </summary>
        /// <param name="rower">The rower.</param>
        public override void Move(IRower rower)
        {
            rower.Move(this);
        }
    }
}

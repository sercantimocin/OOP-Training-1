namespace MainApp.Command
{
    public class RightCommand:RowerCommand
    {
        public RightCommand(IRower rower)
            : base(rower)
        {
        }

        protected internal override void Apply()
        {
            base.Rower.TurnRight();
        }
    }
}

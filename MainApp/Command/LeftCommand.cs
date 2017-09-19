namespace MainApp.Command
{
    public class LeftCommand : RowerCommand
    {
        public LeftCommand(IRower rower)
            : base(rower)
        {
        }

        protected internal override void Apply()
        {
            base.Rower.TurnLeft();
        }
    }
}

namespace MainApp.Command
{
    class TurnLeftCommand : RowerCommand
    {
        public TurnLeftCommand(IRower rower)
            : base(rower)
        {
        }

        protected internal override void Apply()
        {
            base.Rower.TurnLeft();
        }
    }
}

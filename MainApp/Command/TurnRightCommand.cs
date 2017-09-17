namespace MainApp.Command
{
    class TurnRightCommand:RowerCommand
    {
        public TurnRightCommand(IRower rower)
            : base(rower)
        {
        }

        protected internal override void Apply()
        {
            base.Rower.TurnRight();
        }
    }
}

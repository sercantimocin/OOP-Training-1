namespace MainApp.Command
{
    class MoveCommand : RowerCommand
    {
        private readonly Strategy strategy;

        public MoveCommand(IRower rower, Strategy strategy)
            : base(rower)
        {
            this.strategy = strategy;
        }

        protected internal override void Apply()
        {
            base.Rower.Move(strategy);
        }
    }
}

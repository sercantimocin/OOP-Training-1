namespace MainApp.Command
{
    public abstract class RowerCommand
    {
        protected  IRower Rower { get; private set; }

        protected RowerCommand(IRower rower)
        {
            this.Rower = rower;
        }

        protected internal abstract void Apply();
    }
}

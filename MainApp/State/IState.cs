namespace MainApp
{
    using System;

    public abstract class IDirectionState
    {
        private readonly string _stateName;

        protected IDirectionState(string stateName)
        {
            this._stateName = stateName;
        }

        protected internal abstract void Left(IRower rower);

        protected internal abstract void Right(IRower rower);

        protected internal abstract void Move(IRower rower, Strategy strategy);

        void ToString()
        {
            Console.Write(this._stateName);
        }
    }
}

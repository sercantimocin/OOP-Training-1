namespace MainApp
{
    using System.Linq;

    public abstract class Strategy
    {
        private int _stepValue;

        protected internal IPlateau Plateau;

        protected internal int Step
        {
            get
            {
                return _stepValue;
            }
        }

        public Strategy(IPlateau plateau, int step)
        {
            this.Plateau = plateau;
            _stepValue = step;
        }

        public abstract void Move(IRower rower);

        protected internal bool IsOutOfMap(int finalValue, int controlValue)
        {
            return (finalValue > 0 && finalValue > controlValue) || finalValue < 0;
        }

        protected internal bool IsCollisionCase(IRower rower)
        {
            return this.Plateau.RowerList.Any(r => r.X == rower.X && r.Y == rower.Y && r.Id != rower.Id);
        }
    }
}

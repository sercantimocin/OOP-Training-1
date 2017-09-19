namespace MainApp
{
    using System.Linq;

    public class Strategy
    {
        private int stepValue;

        protected internal IPlateau Plateau;

        public Strategy(IPlateau plateau, int step)
        {
            this.Plateau = plateau;
            this.stepValue = step;
        }

        protected internal int Step
        {
            get
            {
                return this.stepValue;
            }
        }

        public bool IsOutOfMap(int finalValue, int controlValue)
        {
            return (finalValue > 0 && finalValue > controlValue) || finalValue < 0;
        }

        public bool IsCollisionCase(IRower rower)
        {
            return this.Plateau.RowerList.Any(r => r.X == rower.X && r.Y == rower.Y && r.Id != rower.Id);
        }
    }
}

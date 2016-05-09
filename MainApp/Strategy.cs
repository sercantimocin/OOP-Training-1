namespace MainApp
{
    using System;
    using System.Linq;

    public abstract class Strategy
    {
        protected IMap _map;

        public Strategy(IMap map)
        {
            _map = map;
        }

        public abstract void Move(int rowerId);

        /// <summary>
        /// Validates the move.
        /// </summary>
        /// <param name="finalValue">The final value.</param>
        /// <param name="controlValue">The control value.</param>
        /// <returns>
        /// Final Value
        /// </returns>
        protected bool IsOutOfMap(int finalValue, int controlValue)
        {
            return (finalValue > 0 && finalValue > controlValue) || finalValue < 0;
        }

        /// <summary>
        /// Validates the move.
        /// </summary>
        /// <param name="rower">The rower.</param>
        /// <returns>
        /// Final Value
        /// </returns>
        protected bool IsCollisionCase(IRower rower)
        {
            return _map.RowerList.Any(r => r.X == rower.X && r.Y == rower.Y && r.Id != rower.Id);
        }

    }
}

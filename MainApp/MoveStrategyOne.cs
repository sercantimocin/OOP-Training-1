namespace MainApp
{
    using System;
    using System.Linq;

    public class MoveStrategySlowly : Strategy
    {
        public MoveStrategySlowly(IMap map)
            : base(map)
        {
        }

        /// <summary>
        /// Moves the specified rower.
        /// </summary>
        /// <param name="rower">The rower.</param>
        public override void Move(int rowerId)
        {
            var rower = _map.RowerList.First(r => r.Id == rowerId);

            switch (rower.Direction)
            {
                case Direction.North:
                    rower.Y++;
                    if (IsOutOfMap(rower.Y, _map.Y) || IsCollisionCase(rower))
                    {
                        Console.WriteLine("This move cannot apply. Id: {0}  X: {1}  Y: {2}", rower.Id, rower.X, rower.Y);
                        rower.Y--;
                    }
                    break;
                case Direction.South:
                    rower.Y--;
                    if (IsOutOfMap(rower.Y, _map.Y) || IsCollisionCase(rower))
                    {
                        Console.WriteLine("This move cannot apply. Id: {0}  X: {1}  Y: {2}", rower.Id, rower.X, rower.Y);
                        rower.Y++;
                    }
                    break;
                case Direction.West:
                    rower.X--;
                    if (IsOutOfMap(rower.X, _map.X) || IsCollisionCase(rower))
                    {
                        Console.WriteLine("This move cannot apply. Id: {0}  X: {1}  Y: {2}",rower.Id, rower.X, rower.Y);
                        rower.X++;
                    }
                    break;
                case Direction.East:
                    rower.X++;
                    if (IsOutOfMap(rower.X, _map.X) || IsCollisionCase(rower))
                    {
                        Console.WriteLine("This move cannot apply. Id: {0}  X: {1}  Y: {2}", rower.Id, rower.X, rower.Y);
                        rower.X--;
                    }
                    break;
            }


        }
    }
}

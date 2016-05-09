using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp
{
    public interface IRower : IHaveCoordinate
    {
        void Move();

        void TurnLeft();

        void TurnRight();

        Direction Direction { get; }

        int Id { get; }
    }
}

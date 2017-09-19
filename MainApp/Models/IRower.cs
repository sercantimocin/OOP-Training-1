namespace MainApp
{
    public interface IRower : ICoordinate
    {
        int Id { get; }

        void Move(Strategy strategy);

        void TurnLeft();

        void TurnRight();

        void ChangeState(DirectionState state);

        void GetStatus();
    }
}

namespace MainApp
{
    public interface IRower : ICoordinate
    {
        void Move(Strategy strategy);

        void TurnLeft();

        void TurnRight();

        void ChangeState(DirectionState state);

        int Id { get; }
    }
}

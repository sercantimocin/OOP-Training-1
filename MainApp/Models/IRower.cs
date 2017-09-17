namespace MainApp
{
    public interface IRower : ICoordinate
    {
        void Move(Strategy strategy);

        void TurnLeft();

        void TurnRight();

        void ChangeState(IDirectionState state);

        int Id { get; }
    }
}

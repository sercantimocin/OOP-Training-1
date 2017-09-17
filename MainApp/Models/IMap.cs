namespace MainApp
{
    using MainApp.CircularList;

    public interface IPlateau : ICoordinate
    {
        ISimpleCircularList<IRower> RowerList { get; }
    }
}

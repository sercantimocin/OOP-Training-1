namespace MainApp
{
    using MainApp.CircularLinkedList;
    using MainApp.CircularList;

    public class MarsPlateau : IPlateau
    {
        private readonly ISimpleCircularList<IRower> _rowerList;

        public MarsPlateau(int x, int y)
        {
            X = x;
            Y = y;
            _rowerList = new SimpleCircularList<IRower>();
        }

        public int X { get; set; }

        public int Y { get; set; }

        public ISimpleCircularList<IRower> RowerList
        {
            get
            {
                return _rowerList;
            }
        }
    }
}

namespace MainApp.CircularLinkedList
{
    using System.Collections.Generic;

    using MainApp.CircularList;

    public class SimpleCircularList<T> : List<T>, ISimpleCircularList<T>
    {
        private readonly IList<T> _list;

        private int _itemOrder;

        private int ItemOrder
        {
            get
            {
                return _itemOrder;
            }
            set
            {
                _itemOrder = value;

                if (_list.Count != 0 && _itemOrder > _list.Count - 1)
                {
                    _itemOrder = _itemOrder % _list.Count;
                }
            }
        }

        public SimpleCircularList()
        {
            _list = new List<T>();
        }

        public void AddItem(T item)
        {
            _list.Add(item);
            ItemOrder++;
        }

        public T IterateItem()
        {
            var item = _list[ItemOrder];
            ItemOrder++;
            return item;
        }
    }
}

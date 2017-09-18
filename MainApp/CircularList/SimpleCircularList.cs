namespace MainApp.CircularLinkedList
{
    using System.Collections.Generic;

    using MainApp.CircularList;

    public class SimpleCircularList<T> : List<T>, ISimpleCircularList<T>
    {
        private readonly IList<T> list;

        private int itemOrder;

        private int ItemOrder
        {
            get
            {
                return this.itemOrder;
            }
            set
            {
                this.itemOrder = value;

                if (this.list.Count != 0 && this.itemOrder > this.list.Count - 1)
                {
                    this.itemOrder = this.itemOrder % this.list.Count;
                }
            }
        }

        public SimpleCircularList()
        {
            this.list = new List<T>();
        }

        public void AddItem(T item)
        {
            this.list.Add(item);
            ItemOrder++;
        }

        public T IterateItem()
        {
            var item = this.list[ItemOrder];
            ItemOrder++;
            return item;
        }
    }
}

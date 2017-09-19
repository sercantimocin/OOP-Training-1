namespace MainApp.CircularLinkedList
{
    using System.Collections.Generic;

    using MainApp.CircularList;

    public class SimpleCircularList<T> : List<T>, ISimpleCircularList<T>
    {
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

                if (this.Count != 0 && this.itemOrder > this.Count - 1)
                {
                    this.itemOrder = this.itemOrder % this.Count;
                }
            }
        }

        public void AddItem(T item)
        {
            this.Add(item);
            ItemOrder++;
        }

        public T IterateItem()
        {
            var item = this[ItemOrder];
            ItemOrder++;
            return item;
        }
    }
}

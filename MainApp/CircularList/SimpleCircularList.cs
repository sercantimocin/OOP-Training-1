namespace MainApp.CircularLinkedList
{
    using System;
    using System.Collections.Generic;

    using MainApp.CircularList;

    public class SimpleCircularList<T> : List<T>, ISimpleCircularList<T>
    {
        private int itemOrder;

        private int ItemOrder
        {
            get
            {
                if (this.itemOrder > this.Count - 1)
                {
                    this.itemOrder = this.itemOrder % this.Count;
                }

                return this.itemOrder;
            }
        }

        public void AddItem(T item)
        {
            this.Add(item);
        }

        public T GetOrderedItem()
        {
            if (this.Count == 0)
            {
                throw new ArgumentNullException("There is no rower");
            }

            var item = this[this.ItemOrder];
            this.itemOrder++;

            return item;
        }
    }
}

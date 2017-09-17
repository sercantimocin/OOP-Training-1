namespace MainApp.CircularList
{
    using System.Collections.Generic;

    public interface ISimpleCircularList<T> :IEnumerable<T>
    {
        void AddItem(T item);

        T IterateItem();
    }
}

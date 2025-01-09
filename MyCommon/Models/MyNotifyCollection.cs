using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace MyCommon.Models
{
    public class MyNotifyCollection : IList, INotifyCollectionChanged
    {
        public ObservableCollection<MyObject> Items = new ObservableCollection<MyObject>();

        public MyNotifyCollection()
        {
            Items.CollectionChanged += Items_CollectionChanged;
        }

        private void Items_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            CollectionChanged?.Invoke(this, e);
        }

        public void Clear()
        {
            Items.Clear();
        }

        public int Count => Items.Count;

        public bool IsReadOnly => false;

        public bool IsFixedSize => throw new NotImplementedException();

        public bool IsSynchronized => throw new NotImplementedException();

        public object SyncRoot => throw new NotImplementedException();

        object? IList.this[int index]
        {
            get => Items[index];
            set
            {
                Items[index] = value as MyObject;
            }
        }

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public IEnumerator<MyObject> GetEnumerator() => Items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public int Add(object? value)
        {
            Items.Add(value as MyObject);
            return Items.Count;
        }

        public bool Contains(object? value)
        {
            return Items.Contains(value as MyObject);
        }

        public int IndexOf(object? value)
        {
            return Items.IndexOf(value as MyObject); 
        }

        public void Insert(int index, object? value)
        {
            Items.Insert(index, value as MyObject);
        }

        public void Remove(object? value)
        {
            Items.Remove(value as MyObject);
        }

        public void RemoveAt(int index)
        {
            Items.RemoveAt(index);
        }

        public void CopyTo(Array array, int index)
        {
            Items.CopyTo(array.Cast<MyObject>().ToArray(), index);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Common.Models
{
    //public class MyNotifyCollection : IList, INotifyCollectionChanged
    public class MyNotifyCollection : IEnumerable, INotifyCollectionChanged
    {
        private readonly ObservableCollection<MyObject> _items = new ObservableCollection<MyObject>();

        public MyNotifyCollection()
        {
            _items.CollectionChanged += _items_CollectionChanged;
        }

        private void _items_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            CollectionChanged?.Invoke(this, e);
        }

        public void Clear()
        {
            _items.Clear();
        }

        public int Count => _items.Count;

        public bool IsReadOnly => false;

        public bool IsFixedSize => throw new NotImplementedException();

        public bool IsSynchronized => throw new NotImplementedException();

        public object SyncRoot => throw new NotImplementedException();

        //object? IList.this[int index]
        //{
        //    get => _items[index];
        //    set
        //    {
        //        _items[index] = value as MyObject;
        //    }
        //}

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public IEnumerator<MyObject> GetEnumerator() => _items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public int Add(object? value)
        {
            _items.Add(value as MyObject);
            return _items.Count;
        }

        public bool Contains(object? value)
        {
            return _items.Contains(value as MyObject);
        }

        public int IndexOf(object? value)
        {
            return _items.IndexOf(value as MyObject); 
        }

        public void Insert(int index, object? value)
        {
            _items.Insert(index, value as MyObject);
        }

        public void Remove(object? value)
        {
            _items.Remove(value as MyObject);
        }

        public void RemoveAt(int index)
        {
            _items.RemoveAt(index);
        }

        public void CopyTo(Array array, int index)
        {
            _items.CopyTo(array.Cast<MyObject>().ToArray(), index);
        }
    }
}

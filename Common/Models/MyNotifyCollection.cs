using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Common.Models
{
    public class MyNotifyCollection : IList<MyObject>, INotifyCollectionChanged
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

        public void Add(MyObject person)
        {
            _items.Add(person);
        }

        public void Remove(MyObject person)
        {
            _items.Remove(person);
        }

        public void Clear()
        {
            _items.Clear();
        }

        public int Count => _items.Count;

        public bool IsReadOnly => false;

        public MyObject this[int index]
        {
            get => _items[index];
            set
            {
                _items[index] = value;
            }
        }

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public IEnumerator<MyObject> GetEnumerator() => _items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public int IndexOf(MyObject item)
        {
            return _items.IndexOf(item);
        }

        public void Insert(int index, MyObject item)
        {
            _items.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _items.RemoveAt(index);
        }

        public bool Contains(MyObject item)
        {
            return _items.Contains(item);
        }

        public void CopyTo(MyObject[] array, int arrayIndex)
        {
            _items.CopyTo(array, arrayIndex);
        }

        bool ICollection<MyObject>.Remove(MyObject item)
        {
            return _items.Remove(item);
        }
    }
}

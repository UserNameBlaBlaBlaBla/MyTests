using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Common.Models
{
    public class MyNotifyCollection : INotifyCollectionChanged, IEnumerable<MyObject>
    {
        private readonly ObservableCollection<MyObject> _items = new ObservableCollection<MyObject>();

        public MyNotifyCollection()
        {
            _items.CollectionChanged += (s, e) => CollectionChanged?.Invoke(this, e);
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
    }
}

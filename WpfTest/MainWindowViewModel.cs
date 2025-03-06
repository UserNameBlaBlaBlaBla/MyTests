using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net;
using System.Security;
using Common.Models;

namespace WpfTest
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<MyObject> _myObjects;
        public ObservableCollection<MyObject> MyObjects
        {
            get => _myObjects;
            set
            {
                _myObjects = value;
                OnPropertyChanged(nameof(MyObjects));
            }
        }

        private int? _nullableInt;
        public int? NullableInt
        {
            get => _nullableInt;
            set
            {
                _nullableInt = value;
                OnPropertyChanged(nameof(NullableInt));
            }
        }

        public MainWindowViewModel()
        {
            MyObjects = new ObservableCollection<MyObject>()
            {
                new MyObject(){ Login = "qwe", EndPoint = new DnsEndPoint("127.0.0.1", 1234), NullableInt = 1},
                new MyObject(){ Login = "asd", EndPoint = new DnsEndPoint("127.0.0.1", 1234), NullableInt = 2},
                new MyObject(){ Login = "zxc", NullableInt = null},
                new MyObject(){ NullableInt = null }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

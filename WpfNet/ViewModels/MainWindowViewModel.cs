using MyCommon.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace WpfNet.ViewModels
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        private MyNotifyCollection _myNotifyCollection;
        public MyNotifyCollection MyNotifyCollection
        {
            get => _myNotifyCollection;
            set { _myNotifyCollection = value; OnPropertyChanged(nameof(MyNotifyCollection)); }
        }

        private ObservableCollection<MyObject> _myObjects;
        public ObservableCollection<MyObject> MyObjects
        {
            get => _myObjects;
            set { _myObjects = value; OnPropertyChanged(nameof(MyObjects)); }
        }

        private int? _nullableInt;
        public int? NullableInt
        {
            get => _nullableInt;
            set { _nullableInt = value; OnPropertyChanged(nameof(NullableInt)); }
        }

        public MainWindowViewModel()
        {
            MyNotifyCollection = new MyNotifyCollection() { new MyObject() { Login = "1" }, new MyObject() { Login = "2" }, new MyObject() { Login = "3" } };

            MyObjects = new ObservableCollection<MyObject>()
            {
                new MyObject(){ Login = "qwe", EndPoint = new DnsEndPoint("127.0.0.1", 1234), NullableInt = 1},
                new MyObject(){ Login = "asd", EndPoint = new DnsEndPoint("127.0.0.1", 1234), NullableInt = 2},
                new MyObject(){ Login = "zxc", NullableInt = null},
                new MyObject(){ NullableInt = null }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

using MyCommon.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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

        public MainWindowViewModel()
        {
            MyNotifyCollection = new MyNotifyCollection() { new MyObject() { Login = "1" }, new MyObject() { Login = "2" }, new MyObject() { Login = "3" } };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

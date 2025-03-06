using MyCommon.Models;
using System.ComponentModel;

namespace WpfTest.ViewModels
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        private MyNotifyCollection _myNotifyCollection;
        public MyNotifyCollection MyNotifyCollection;

        public MyObject m123;


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

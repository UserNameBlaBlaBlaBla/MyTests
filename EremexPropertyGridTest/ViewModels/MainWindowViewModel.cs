using CommunityToolkit.Mvvm.ComponentModel;
using EremexPropertyGridTest.Models;
using System.Collections.ObjectModel;
using System.Net;

namespace EremexPropertyGridTest.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        [ObservableProperty]
        public ObservableCollection<MyObject> myObjects;

        [ObservableProperty]
        public MyObject? selectedMyObject;

        public MainWindowViewModel()
        {
            MyObjects = new ObservableCollection<MyObject>()
            {
                new MyObject(){ Login = "qwe"}, // у этого объекта в PropertyGrid зависает фокус на свойствах login и password
                new MyObject(){ Login = "asd", EndPoint = new DnsEndPoint("127.0.0.1", 1234)}, // // у этого объекта в PropertyGrid фокус зависнет только на свойстве password
                new MyObject(){ Login = "zxc"} // у этого объекта в PropertyGrid зависает фокус на свойствах login и password
            };
        }
    }
}

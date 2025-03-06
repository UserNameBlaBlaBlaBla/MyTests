using Common.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Net;
using System.Security;

namespace EremexPropertyGridTest.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        [ObservableProperty]
        public ObservableCollection<string> myStrings;

        [ObservableProperty]
        public ObservableCollection<MyObject> myObjects;

        [ObservableProperty]
        public MyObject? selectedMyObject;

        [ObservableProperty]
        public int? nullableInt;

        public MainWindowViewModel()
        {
            var secureString = new SecureString();
            foreach (var ch in "qwe_password")
                secureString.AppendChar(ch);

            MyObjects = new ObservableCollection<MyObject>()
            {
                new MyObject(){ Login = "qwe", EndPoint = new DnsEndPoint("127.0.0.1", 1234), Password = secureString, NullableInt = 1},
                new MyObject(){ Login = "asd", EndPoint = new DnsEndPoint("127.0.0.1", 1234), NullableInt = 2},
                new MyObject(){ Login = "zxc", NullableInt = null},
                new MyObject(){ NullableInt = null }
            };

            myStrings = new ObservableCollection<string>() { "first string", "second string" };
        }
    }
}

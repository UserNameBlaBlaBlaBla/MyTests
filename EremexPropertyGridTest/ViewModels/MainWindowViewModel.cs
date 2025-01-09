using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using MyCommon.Models;
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

        public MainWindowViewModel()
        {
            var secureString = new SecureString();
            foreach (var ch in "qwe_password")
                secureString.AppendChar(ch);

            MyObjects = new ObservableCollection<MyObject>()
            {
                new MyObject(){ Login = "qwe", EndPoint = new DnsEndPoint("127.0.0.1", 1234), Password = secureString},
                new MyObject(){ Login = "asd", EndPoint = new DnsEndPoint("127.0.0.1", 1234)},
                new MyObject(){ Login = "zxc"},
                new MyObject()
            };

            myStrings = new ObservableCollection<string>() { "first string", "second string" };
        }
    }
}

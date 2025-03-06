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

        [ObservableProperty]
<<<<<<< HEAD
        public int? nullableInt;
=======
        public MySubObject? mySubObject;
>>>>>>> e0e514ea032bb2e3bf0f32b9b5e5985376ec3363

        public MainWindowViewModel()
        {
            var secureString = new SecureString();
            foreach (var ch in "qwe_password")
                secureString.AppendChar(ch);

            MyObjects = new ObservableCollection<MyObject>()
            {
<<<<<<< HEAD
                new MyObject(){ Login = "qwe", EndPoint = new DnsEndPoint("127.0.0.1", 1234), Password = secureString, NullableInt = 1},
                new MyObject(){ Login = "asd", EndPoint = new DnsEndPoint("127.0.0.1", 1234), NullableInt = 2},
                new MyObject(){ Login = "zxc", NullableInt = null},
                new MyObject(){ NullableInt = null }
=======
                new MyObject(){ Login = "qwe", EndPoint = new DnsEndPoint("127.0.0.1", 1234), Password = secureString, Collection = new ObservableCollection<string>(){ "a","b", "c"} },
                new MyObject(){ Login = "asd", EndPoint = new DnsEndPoint("127.0.0.1", 1234)},
                new MyObject(){ Login = "zxc"},
                new MyObject()
>>>>>>> e0e514ea032bb2e3bf0f32b9b5e5985376ec3363
            };

            myStrings = new ObservableCollection<string>() { "first string", "second string" };

            mySubObject = new MySubObject() { MyInteger = 5, MyString = "qwerty", MyBool = true };
        }
    }
}

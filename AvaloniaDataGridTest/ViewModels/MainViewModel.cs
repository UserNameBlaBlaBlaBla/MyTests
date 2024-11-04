using Common.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Net;
using System.Security;

namespace AvaloniaDataGridTest.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    public string Greeting => "Welcome to Avalonia!";

    [ObservableProperty]
    public ObservableCollection<MyObject> myObjects;

    [ObservableProperty]
    public MyNotifyCollection myNotifyCollection;

    public MainViewModel()
    {
        MyNotifyCollection = new MyNotifyCollection();

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
    }

    [RelayCommand]
    public void Add()
    {
        MyObjects.Add(new MyObject() { Login = MyObjects.Count.ToString() });
        MyNotifyCollection.Add(new MyObject() { Login = MyNotifyCollection.Count.ToString() });
    }
}

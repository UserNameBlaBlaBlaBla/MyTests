﻿using MyCommon.Models;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfNet.ViewModels;

namespace WpfNet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = new MainWindowViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is MainWindowViewModel mainWindowViewModel)
            {
                Task.Run(() =>
                {
                    mainWindowViewModel.MyNotifyCollection.Add(new MyObject() { Login = (mainWindowViewModel.MyNotifyCollection.Count + 1).ToString() });

                    /*
                    var tempCollection = new ObservableCollection<MyObject>(mainWindowViewModel.MyNotifyCollection.Items);
                    tempCollection.Add(new MyObject() { Login = (mainWindowViewModel.MyNotifyCollection.Count + 1).ToString() });
                    mainWindowViewModel.MyNotifyCollection.Items = tempCollection;
                     */
                });
            }
        }
    }
}
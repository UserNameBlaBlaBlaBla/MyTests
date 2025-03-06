<<<<<<< HEAD
﻿using System.Windows;
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfTest.ViewModels;
>>>>>>> e0e514ea032bb2e3bf0f32b9b5e5985376ec3363

namespace WpfTest
{
    /// <summary>
<<<<<<< HEAD
    /// Interaction logic for MainWindow.xaml
=======
    /// Логика взаимодействия для MainWindow.xaml
>>>>>>> e0e514ea032bb2e3bf0f32b9b5e5985376ec3363
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
<<<<<<< HEAD
            DataContext = new MainWindowViewModel();
        }
    }
}
=======
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = new MainWindowViewModel();
        }
    }
}
>>>>>>> e0e514ea032bb2e3bf0f32b9b5e5985376ec3363

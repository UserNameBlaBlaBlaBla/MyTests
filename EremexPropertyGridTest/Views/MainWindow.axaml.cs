using Eremex.AvaloniaUI.Controls.Common;
using MyCommon.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace EremexPropertyGridTest.Views
{
    public partial class MainWindow : MxWindow
    {
        private List<Type> types = new List<Type>() { typeof(MySubObject) };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void PropertyGridControl_UsingComplexDataContext(object? sender, Eremex.AvaloniaUI.Controls.PropertyGrid.UsingComplexDataContextEventArgs e)
        {
            e.Cancel = e.Value is object;
        }

        private void PropertyGridControl_CustomCellTemplateData(object? sender, Eremex.AvaloniaUI.Controls.PropertyGrid.CustomCellTemplateDataEventArgs e)
        {
            if (e.Data is MySubObject || e.Data is IList)
            {
                var prop = e.Row.GetType().GetProperty("HasChildren");
                prop.SetValue(e.Row, true);
            }
        }

        private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var myWindow = new MyWindow();
            myWindow.Show();
        }
    }
}
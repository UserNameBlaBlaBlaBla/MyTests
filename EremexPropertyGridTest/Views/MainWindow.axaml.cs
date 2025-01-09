using Eremex.AvaloniaUI.Controls.Common;
using MyCommon.Models;
using System;
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
            if (types.Contains(e.Value.GetType()))
                e.Cancel = false;
            else
                e.Cancel = e.Value is object;
        }

        private void PropertyGridControl_CustomCellTemplateData(object? sender, Eremex.AvaloniaUI.Controls.PropertyGrid.CustomCellTemplateDataEventArgs e)
        {
            if (e.Data is MySubObject mySubObject)
            {
                //e.Row.Rows.Add(new PropertyGridRow() { FieldName = "MyInteger", DataContext = e.Data });
                //e.Row.Rows.Add(new PropertyGridRow() { FieldName = "MyString", DataContext = e.Data });
                var prop = e.Row.GetType().GetProperty("HasChildren");
                prop.SetValue(e.Row, true);
            }
        }
    }
}
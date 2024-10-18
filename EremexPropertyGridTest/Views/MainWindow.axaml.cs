using Eremex.AvaloniaUI.Controls.Common;

namespace EremexPropertyGridTest.Views
{
    public partial class MainWindow : MxWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void PropertyGridControl_UsingComplexDataContext(object? sender, Eremex.AvaloniaUI.Controls.PropertyGrid.UsingComplexDataContextEventArgs e)
        {
            e.Cancel = e.Value is object;
        }
    }
}
using Eremex.AvaloniaUI.Controls.Common;
using Eremex.AvaloniaUI.Controls.DataGrid;

namespace EremexDataGridTest.Views
{
    public partial class MainWindow : MxWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            new DataGridControl();
        }
    }
}
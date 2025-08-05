using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Eremex.AvaloniaUI.Controls.DataControl.Visuals;

namespace EremexDataGridTest.Views
{
    internal class TestDataTemplate : IDataTemplate
    {
        public Control? Build(object? param)
        {
            if (param is CellData cellData)
                return new TextBlock() { Text = cellData.Value == null ? "value is null" : cellData.Value.ToString() };
            else
                return new TextBlock() { Text = param == null ? "param is null" : param.ToString() };
        }

        public bool Match(object? data)
        {
            return data is CellData;
        }
    }
}

using Avalonia.Collections;
using Avalonia.Controls.Templates;
using Avalonia.Controls;
using System;
using System.Linq;
using Avalonia.Markup.Xaml.Templates;

namespace EremexPropertyGridTest
{
    public class CellTemplateLocator : AvaloniaList<IDataTemplate>, IDataTemplate
    {
        public Control Build(object? param)
        {
            if (param is Type type)
            {
                var template = this.First(x => ((DataTemplate)x).DataType.FullName.Equals(type.FullName));
                return template.Build(null);
            }
            else
                return this.First(x => x.Match(param)).Build(param);
        }

        public bool Match(object? data)
        {
            if (data is Type type)
                return this.Any(x => ((DataTemplate)x).DataType.FullName.Equals(type.FullName));
            else
                return this.Any(x => x.Match(data));
        }
    }
}

using Avalonia.Collections;
using Avalonia.Controls.Templates;
using Avalonia.Controls;
using System;
using System.Linq;
using Avalonia.Markup.Xaml.Templates;
using DynamicData.Binding;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            else if (param.GetType().IsGenericType)
                return this.First(x => ((DataTemplate)x).DataType.Equals(param.GetType().GetGenericTypeDefinition())).Build(param);
            else
                return this.First(x => x.Match(param)).Build(param);
        }

        public bool Match(object? data)
        {
            if (data is Type type)
                return this.Any(x => ((DataTemplate)x).DataType.FullName.Equals(type.FullName));
            else if (data.GetType().IsGenericType)
                return this.Any(x => ((DataTemplate)x).DataType.Equals(data.GetType().GetGenericTypeDefinition()));
            else
                return this.Any(x => x.Match(data));
        }
    }
}

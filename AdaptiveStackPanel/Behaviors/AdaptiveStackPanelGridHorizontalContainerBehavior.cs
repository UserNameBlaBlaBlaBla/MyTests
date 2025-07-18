using Avalonia.Xaml.Interactivity;
using Avalonia.Controls;
using System.Collections.Generic;
using Avalonia;
using AdaptiveStackPanel.Controls;
using Avalonia.Interactivity;

namespace AdaptiveStackPanel.Behaviors
{
    internal class AdaptiveStackPanelGridHorizontalContainerBehavior : Behavior<Grid>
    {
        #region Protected methods

        protected override void OnAttached()
        {
            base.OnAttached();
            if (AssociatedObject != null)
            {
                AssociatedObject.Loaded += AssociatedObject_Loaded;
            }
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            if (AssociatedObject != null)
            {
                AssociatedObject.Loaded -= AssociatedObject_Loaded;
            }
        }

        #endregion

        #region Private methods

        private void AssociatedObject_Loaded(object? sender, RoutedEventArgs e)
        {
            var indexToWidth = new Dictionary<int, double>();

            for (int i = 0; i < AssociatedObject.Children.Count; i++)
            {
                if (AssociatedObject.Children[i] is Controls.AdaptiveStackPanel adaptiveStackPanel)
                {
                    indexToWidth[i] = adaptiveStackPanel.MaxWidth;
                }
            }

            foreach (var index in indexToWidth.Keys)
            {
                AssociatedObject.ColumnDefinitions[index].Width = new GridLength(indexToWidth[index], GridUnitType.Star);
            }
        }

        #endregion
    }
}

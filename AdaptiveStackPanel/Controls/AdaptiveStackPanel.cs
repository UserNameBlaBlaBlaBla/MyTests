using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Layout;
using Avalonia.VisualTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace AdaptiveStackPanel.Controls
{
    public enum AdaptiveStackPanelDirection
    {
        LeftToRight,
        RightToLeft
    }

    public class AdaptiveStackPanel : Panel
    {
        public required StackPanel _mainStackPanel;
        public required Button _overflowButton;
        public required Flyout _overflowFlyout;
        public required StackPanel _overflowStackPanel;
        private bool _isMeasuring;
        private List<Control> _originalChildren = new();
        private bool _initialized = false;
        private static readonly MethodInfo? _invalidateStylesMethod = typeof(Control).GetMethod("InvalidateStyles", BindingFlags.NonPublic | BindingFlags.Instance);

        public static readonly DirectProperty<AdaptiveStackPanel, Orientation> OrientationProperty =
            AvaloniaProperty.RegisterDirect<AdaptiveStackPanel, Orientation>(
                nameof(Orientation),
                o => o.Orientation,
                (o, v) => o.Orientation = v);

        public static readonly DirectProperty<AdaptiveStackPanel, double> SpacingProperty =
            AvaloniaProperty.RegisterDirect<AdaptiveStackPanel, double>(
                nameof(Spacing),
                o => o.Spacing,
                (o, v) => o.Spacing = v);

        public static readonly DirectProperty<AdaptiveStackPanel, AdaptiveStackPanelDirection> DirectionProperty =
            AvaloniaProperty.RegisterDirect<AdaptiveStackPanel, AdaptiveStackPanelDirection>(
                nameof(Direction),
                o => o.Direction,
                (o, v) => o.Direction = v);

        private Orientation _orientation = Orientation.Horizontal;
        private double _spacing = 0;
        private AdaptiveStackPanelDirection _direction = AdaptiveStackPanelDirection.RightToLeft;

        public Orientation Orientation
        {
            get => _orientation;
            set => SetAndRaise(OrientationProperty, ref _orientation, value);
        }

        public double Spacing
        {
            get => _spacing;
            set => SetAndRaise(SpacingProperty, ref _spacing, value);
        }

        public AdaptiveStackPanelDirection Direction
        {
            get => _direction;
            set => SetAndRaise(DirectionProperty, ref _direction, value);
        }

        public AdaptiveStackPanel()
        {
            InitializeComponents();
        }

        private void InvalidateStyles(Control control)
        {
            _invalidateStylesMethod?.Invoke(control, [true]);
        }

        private void InitializeComponents()
        {
            // Основной StackPanel для видимых элементов
            _mainStackPanel = new StackPanel
            {
                Orientation = _orientation,
                Spacing = _spacing
            };

            // Кнопка переполнения
            _overflowButton = new Button
            {
                Content = "⋮",
                IsVisible = false,
            };

            // Flyout для скрытых элементов
            _overflowFlyout = new Flyout
            {
                Placement = PlacementMode.Bottom,
                ShowMode = FlyoutShowMode.Transient
            };

            // StackPanel внутри Flyout
            _overflowStackPanel = new StackPanel
            {
                Orientation = Orientation.Vertical,
                Spacing = _spacing,
                Margin = new Thickness(10)
            };

            _overflowFlyout.Content = _overflowStackPanel;
            _overflowButton.Flyout = _overflowFlyout;

            // Добавляем дочерние элементы
            Children.Add(_mainStackPanel);
            Children.Add(_overflowButton);
        }

        protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
        {
            base.OnPropertyChanged(change);

            if (change.Property == OrientationProperty)
            {
                _mainStackPanel.Orientation = _orientation;
                _overflowStackPanel.Orientation = _orientation;
            }
            else if (change.Property == SpacingProperty)
            {
                _mainStackPanel.Spacing = _spacing;
                _overflowStackPanel.Spacing = _spacing;
            }
        }

        protected override Size MeasureOverride(Size constraint)
        {
            if (_isMeasuring) return base.MeasureOverride(constraint);

            _isMeasuring = true;

            try
            {
                // Инициализация: переносим все элементы, кроме внутренних, в _originalChildren
                if (!_initialized)
                {
                    _originalChildren.Clear();
                    foreach (var child in Children.ToList())
                    {
                        if (child != _mainStackPanel && child != _overflowButton)
                        {
                            _originalChildren.Add(child);
                        }
                    }

                    foreach (var child in _originalChildren)
                    {
                        Children.Remove(child);
                    }

                    _initialized = true;
                }

                var wasOverflow = _overflowStackPanel.Children.Count > 0;

                // Очищаем все панели
                _mainStackPanel.Children.Clear();
                _overflowStackPanel.Children.Clear();

                // Измеряем кнопку переполнения для расчёта доступного пространства
                _overflowButton.Measure(constraint);
                var buttonSize = _orientation == Orientation.Horizontal ? _overflowButton.DesiredSize.Width : _overflowButton.DesiredSize.Height;

                // Вычисляем доступное пространство с учётом возможной кнопки переполнения
                var availableSpace = _orientation == Orientation.Horizontal ? constraint.Width : constraint.Height;
                var availableForMain = wasOverflow ? availableSpace - buttonSize : availableSpace;

                var currentSize = 0.0;
                var mainElements = new List<Control>();
                var overflowElements = new List<Control>();

                var moveAllNextToOverflowStackPanel = false;

                for (int i = 0; i < _originalChildren.Count; i++)
                {
                    var processingChild = Direction == AdaptiveStackPanelDirection.RightToLeft ? _originalChildren[i] : _originalChildren[_originalChildren.Count - i - 1];

                    processingChild.Measure(constraint);
                    var childSize = new Size(processingChild.Bounds.Width, processingChild.Bounds.Height);

                    var elementSize = _orientation == Orientation.Horizontal ? childSize.Width : childSize.Height;
                    var spacing = i != _originalChildren.Count - 1 ? _spacing : 0;

                    if (currentSize + elementSize + spacing <= availableForMain && !moveAllNextToOverflowStackPanel)
                    {
                        mainElements.Add(processingChild);
                        currentSize += elementSize + spacing;
                    }
                    else
                    {
                        overflowElements.Add(processingChild);
                        moveAllNextToOverflowStackPanel = true;
                    }
                }

                if (Direction == AdaptiveStackPanelDirection.LeftToRight)
                    mainElements.Reverse();

                // Добавляем элементы в соответствующие панели
                foreach (var element in mainElements)
                {
                    _mainStackPanel.Children.Add(element);
                    // Принудительно обновляем стили для корректного применения Classes
                    InvalidateStyles(element);
                }

                foreach (var element in overflowElements)
                {
                    _overflowStackPanel.Children.Add(element);
                    // Принудительно обновляем стили для корректного применения Classes
                    InvalidateStyles(element);
                }

                // Показываем/скрываем кнопку переполнения
                _overflowButton.IsVisible = overflowElements.Count > 0;

                // Принудительно обновляем стили для внутренних панелей
                InvalidateStyles(_mainStackPanel);
                InvalidateStyles(_overflowStackPanel);

                // Измеряем наши внутренние контролы
                _mainStackPanel.Measure(constraint);
                if (_overflowButton.IsVisible)
                    _overflowButton.Measure(constraint);

                // Вычисляем общий размер
                var mainSize = _mainStackPanel.DesiredSize;
                var overflowButtonSize = _orientation == Orientation.Horizontal ? _overflowButton.DesiredSize.Width : _overflowButton.DesiredSize.Height;

                Size totalSize;
                if (_orientation == Orientation.Horizontal)
                {
                    if (_direction == AdaptiveStackPanelDirection.LeftToRight)
                    {
                        totalSize = new Size(mainSize.Width + (_overflowButton.IsVisible ? overflowButtonSize : 0), Math.Max(mainSize.Height, _overflowButton.DesiredSize.Height));
                    }
                    else // RightToLeft
                    {
                        totalSize = new Size(mainSize.Width + (_overflowButton.IsVisible ? overflowButtonSize : 0), Math.Max(mainSize.Height, _overflowButton.DesiredSize.Height));
                    }
                }
                else
                {
                    totalSize = new Size(Math.Max(mainSize.Width, _overflowButton.DesiredSize.Width), mainSize.Height + (_overflowButton.IsVisible ? overflowButtonSize : 0));
                }

                return totalSize;
            }
            finally
            {
                _isMeasuring = false;
            }
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            var mainSize = _mainStackPanel.DesiredSize;
            var overflowButtonSize = _overflowButton.DesiredSize;

            if (_orientation == Orientation.Horizontal)
            {
                if (_direction == AdaptiveStackPanelDirection.RightToLeft)
                {
                    // Размещаем основной StackPanel слева
                    _mainStackPanel.Arrange(new Rect(0, 0, mainSize.Width, finalSize.Height));

                    // Размещаем кнопку переполнения справа
                    if (_overflowButton.IsVisible)
                    {
                        _overflowButton.Arrange(new Rect(mainSize.Width, 0, overflowButtonSize.Width, finalSize.Height));
                    }
                }
                else
                {
                    // Размещаем кнопку переполнения слева
                    if (_overflowButton.IsVisible)
                    {
                        if (_mainStackPanel.Children.Count > 0)
                            _overflowButton.Arrange(new Rect(finalSize.Width - overflowButtonSize.Width - mainSize.Width, 0, overflowButtonSize.Width, finalSize.Height));
                        else
                            _overflowButton.Arrange(new Rect(finalSize.Width - overflowButtonSize.Width, 0, overflowButtonSize.Width, finalSize.Height));

                        // Размещаем основной StackPanel справа от кнопки
                        _mainStackPanel.Arrange(new Rect(finalSize.Width - mainSize.Width, 0, mainSize.Width, finalSize.Height));
                    }
                    else
                    {
                        // Если кнопка не видна, размещаем основной StackPanel справа
                        _mainStackPanel.Arrange(new Rect(finalSize.Width - mainSize.Width, 0, mainSize.Width, finalSize.Height));
                    }
                }
            }
            else
            {
                // Размещаем основной StackPanel
                _mainStackPanel.Arrange(new Rect(0, 0, finalSize.Width, mainSize.Height));

                // Размещаем кнопку переполнения
                if (_overflowButton.IsVisible)
                {
                    _overflowButton.Arrange(new Rect(0, mainSize.Height, finalSize.Width, overflowButtonSize.Height));
                }
            }

            return finalSize;
        }
    }
}
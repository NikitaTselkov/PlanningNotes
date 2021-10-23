using Models;
using Models.Interfaces;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using ViewModels.Cards;

namespace ViewModels
{
    public class DragBehavior
    {
        public readonly TranslateTransform Transform = new TranslateTransform();
        private readonly TranslateTransform _transformLeftPoints = new TranslateTransform();
        private readonly TranslateTransform _transformRightPoints = new TranslateTransform();
        private Point _elementStartPosition2;
        private Point _mouseStartPosition2;
        private static DragBehavior _instance = new DragBehavior();
        public static DragBehavior Instance
        {
            get { return _instance; }
            set { _instance = value; }
        }

        public static bool GetDrag(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsDragProperty);
        }

        public static void SetDrag(DependencyObject obj, bool value)
        {
            obj.SetValue(IsDragProperty, value);
        }

        public static readonly DependencyProperty IsDragProperty =
          DependencyProperty.RegisterAttached("Drag",
          typeof(bool), typeof(DragBehavior),
          new PropertyMetadata(false, OnDragChanged));


        private static void OnDragChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            // ignoring error checking
            var element = (UIElement)sender;
            var isDrag = (bool)(e.NewValue);

            Instance = new DragBehavior();
            ((UIElement)sender).RenderTransform = Instance.Transform;

            if (isDrag)
            {
                element.MouseLeftButtonDown += Instance.ElementOnMouseLeftButtonDown;
                element.MouseLeftButtonUp += Instance.ElementOnMouseLeftButtonUp;
                element.MouseMove += Instance.ElementOnMouseMove;
            }
            else
            {
                element.MouseLeftButtonDown -= Instance.ElementOnMouseLeftButtonDown;
                element.MouseLeftButtonUp -= Instance.ElementOnMouseLeftButtonUp;
                element.MouseMove -= Instance.ElementOnMouseMove;
            }
        }

        private void ElementOnMouseLeftButtonDown(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            mouseButtonEventArgs.Handled = true;

            if (((FrameworkElement)sender).DataContext is CardVM cardVM)
            {
                CardsControl.SelectCard(cardVM);

                _transformLeftPoints.X = cardVM.LeftPoint.X;
                _transformLeftPoints.Y = cardVM.LeftPoint.Y;

                _transformRightPoints.X = cardVM.RightPoint.X;
                _transformRightPoints.Y = cardVM.RightPoint.Y;
            }

            UIElement parent = VisualTreeHelper.GetParent((FrameworkElement)sender) as UIElement;
            _mouseStartPosition2 = mouseButtonEventArgs.GetPosition(parent);
            ((UIElement)sender).CaptureMouse();
        }

        private void ElementOnMouseLeftButtonUp(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            ((UIElement)sender).ReleaseMouseCapture();
            _elementStartPosition2.X = Transform.X;
            _elementStartPosition2.Y = Transform.Y;
        }

        private void ElementOnMouseMove(object sender, MouseEventArgs mouseEventArgs)
        {
            UIElement parent = VisualTreeHelper.GetParent((FrameworkElement)sender) as UIElement;
            var mousePos = mouseEventArgs.GetPosition(parent);
            var diff = mousePos - _mouseStartPosition2;

            if (((UIElement)sender).IsMouseCaptured)
            {
                Transform.X = _elementStartPosition2.X + diff.X;
                Transform.Y = _elementStartPosition2.Y + diff.Y;

                if (((FrameworkElement)sender).DataContext is CardVM cardVM)
                {
                    cardVM.LeftPoint = new Point(_transformLeftPoints.X + diff.X, _transformLeftPoints.Y + diff.Y);
                    cardVM.RightPoint = new Point(_transformRightPoints.X + diff.X, _transformRightPoints.Y + diff.Y);

                    CardsControl.GetConnectionPoints();
                }
            }

        }
    }
}

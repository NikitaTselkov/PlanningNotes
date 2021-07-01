using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ViewModels.Cards;

namespace UI.UserControls
{
    /// <summary>
    /// Логика взаимодействия для DrawConnection.xaml
    /// </summary>
    public partial class DrawConnection : UserControl
    {
        public DrawConnection()
        {
            InitializeComponent();
        }

        public PathGeometry Data
        {
            get => (PathGeometry)GetValue(DataProperty);
            set => SetValue(DataProperty, value);
        }

        public static readonly DependencyProperty DataProperty =
            DependencyProperty.Register("Data", typeof(PathGeometry),
                typeof(DrawConnection), new PropertyMetadata(null));


        public Point StartPoint
        {
            get => (Point)GetValue(StartPointProperty);
            set => SetValue(StartPointProperty, value);
        }

        public static readonly DependencyProperty StartPointProperty =
            DependencyProperty.Register("StartPoint", typeof(Point),
                typeof(DrawConnection), new PropertyMetadata(new Point(), OnValueChanged));


        public Point EndPoint
        {
            get => (Point)GetValue(EndPointProperty);
            set => SetValue(EndPointProperty, value);
        }

        public static readonly DependencyProperty EndPointProperty =
            DependencyProperty.Register("EndPoint", typeof(Point),
                typeof(DrawConnection), new PropertyMetadata(new Point(), OnValueChanged));


        private static void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var start = sender.GetValue(StartPointProperty);

            var end = sender.GetValue(EndPointProperty);

            if ((Point)end != new Point())
            {
                sender.SetValue(DataProperty, DrawLine((Point)start, (Point)end));
            }
        }


        public static PolyLineSegment DrawArrow(Point a, Point b)
        {
            double HeadWidth = 10; // Ширина между ребрами стрелки
            double HeadHeight = 5; // Длина ребер стрелки

            double X1 = a.X;
            double Y1 = a.Y;

            double X2 = b.X;
            double Y2 = b.Y;

            double theta = Math.Atan2(Y1 - Y2, X1 - X2);
            double sint = Math.Sin(theta);
            double cost = Math.Cos(theta);

            Point pt3 = new Point(
                X2 + (HeadWidth * cost - HeadHeight * sint),
                Y2 + (HeadWidth * sint + HeadHeight * cost));

            Point pt4 = new Point(
                X2 + (HeadWidth * cost + HeadHeight * sint),
                Y2 - (HeadHeight * cost - HeadWidth * sint));

            PolyLineSegment arrow = new PolyLineSegment();
            arrow.Points.Add(b);
            arrow.Points.Add(pt3);
            arrow.Points.Add(pt4);
            arrow.Points.Add(b);

            return arrow;
        }

        private static PathGeometry DrawLine(Point startPoint, Point endPoint)
        {

            PathFigure pathFigure = new PathFigure
            {
                StartPoint = startPoint,
                IsClosed = false
            };

            //Кривая Безье
            Vector vector = endPoint - startPoint;
            Point point1 = new Point(startPoint.X + 3 * vector.X / 8,
                                     startPoint.Y + 1 * vector.Y / 8);
            Point point2 = new Point(startPoint.X + 5 * vector.X / 8,
                                     startPoint.Y + 7 * vector.Y / 8);

            BezierSegment curve = new BezierSegment(point1, point2, endPoint, true);
            PolyLineSegment arrow = DrawArrow(point2, endPoint);

            pathFigure.Segments.Clear();
            pathFigure.Segments.Add(curve);
            pathFigure.Segments.Add(arrow);

            return new PathGeometry() { Figures = { pathFigure } };
        }
    }
}

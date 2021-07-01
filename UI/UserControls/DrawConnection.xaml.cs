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

        public PathGeometry LineData
        {
            get => (PathGeometry)GetValue(LineDataProperty);
            set => SetValue(LineDataProperty, value);
        }

        public static readonly DependencyProperty LineDataProperty =
            DependencyProperty.Register("LineData", typeof(PathGeometry),
                typeof(DrawConnection), new PropertyMetadata(null));


        public PathGeometry ArrowData
        {
            get => (PathGeometry)GetValue(ArrowDataProperty);
            set => SetValue(ArrowDataProperty, value);
        }

        public static readonly DependencyProperty ArrowDataProperty =
            DependencyProperty.Register("ArrowData", typeof(PathGeometry),
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
                sender.SetValue(LineDataProperty, DrawLine((Point)start, (Point)end));
                sender.SetValue(ArrowDataProperty, DrawArrow((Point)start, (Point)end));
            }
        }

        public static ArcSegment DrawEllipse(Point startPoint, Point endPoint)
        {
            ArcSegment ellipse = new ArcSegment();

            ellipse.Point = new Point(startPoint.X + 0, startPoint.Y + 0.5);
            ellipse.SweepDirection = SweepDirection.Counterclockwise;
            ellipse.Size = new Size(3, 3);
            ellipse.IsLargeArc = true;

            if (startPoint.X > endPoint.X)
            {
                ellipse.SweepDirection = SweepDirection.Clockwise;
            }

            return ellipse;
        }

        public static PathGeometry DrawArrow(Point startPoint, Point endPoint)
        {
            Vector vector = endPoint - startPoint;
            var point = new Point(startPoint.X + 5 * vector.X / 8, startPoint.Y + 7 * vector.Y / 8);

            double HeadWidth = 8; // Ширина между ребрами стрелки
            double HeadHeight = 4; // Длина ребер стрелки

            double X1 = point.X;
            double Y1 = point.Y;

            double X2 = endPoint.X;
            double Y2 = endPoint.Y;

            double theta = Math.Atan2(Y1 - Y2, X1 - X2);
            double sint = Math.Sin(theta);
            double cost = Math.Cos(theta);

            Point pt3 = new Point(
                X2 + (HeadWidth * cost - HeadHeight * sint),
                Y2 + (HeadWidth * sint + HeadHeight * cost));

            Point pt4 = new Point(
                X2 + (HeadWidth * cost + HeadHeight * sint),
                Y2 - (HeadHeight * cost - HeadWidth * sint));

            PathFigure pathFigure = new PathFigure
            {
                StartPoint = pt4,
                IsClosed = false,
                IsFilled = true
            };

            PolyLineSegment arrow = new PolyLineSegment();
            arrow.Points.Add(endPoint);
            arrow.Points.Add(pt3);
            arrow.Points.Add(pt4);
            arrow.Points.Add(endPoint);

            pathFigure.Segments.Clear();
            pathFigure.Segments.Add(arrow);

            return new PathGeometry() { Figures = { pathFigure } };
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
            ArcSegment ellipse = DrawEllipse(startPoint, point1);

            pathFigure.Segments.Clear();
            pathFigure.Segments.Add(ellipse);
            pathFigure.Segments.Add(curve);

            return new PathGeometry() { Figures = { pathFigure } };
        }

    }
}

using Models.Interfaces;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для PointOfConnection.xaml
    /// </summary>
    public partial class PointOfConnection : UserControl
    {
        public PointOfConnection()
        {
            InitializeComponent();

            Loaded += ControlLoaded;
        }

        // Ключ.
        public Guid Key
        {
            get { return (Guid)GetValue(KeyProperty); }
            set { SetValue(KeyProperty, value); }
        }

        public static readonly DependencyProperty KeyProperty =
            DependencyProperty.Register("Key", typeof(Guid), typeof(PointOfConnection));

        // Позиция.
        public Point Position
        {
            get { return (Point)GetValue(PositionProperty); }
            set { SetValue(PositionProperty, value); }
        }

        public static readonly DependencyProperty PositionProperty =
            DependencyProperty.Register("Position", typeof(Point),
                typeof(PointOfConnection), new PropertyMetadata(new Point()));



        public void ControlLoaded(object sender, EventArgs e)
        {
            Position = PointToScreen(new Point(0, -58)); // -58 значение для подгонки PointOfConnection к DrawConnection.

            ICard card = ConnectionsControl.GetCard(Key);

            if (card.LeftPoint == new Point())
            {
                card.LeftPoint = Position;
            }
            else
            {
                card.RightPoint = Position;
            }
        }
    }
}

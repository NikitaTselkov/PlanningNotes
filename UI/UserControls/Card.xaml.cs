using GalaSoft.MvvmLight.Messaging;
using Models.Interfaces;
using System.Windows.Controls;
using UI.UserControls.CardPanels;

namespace UI.UserControls
{
    /// <summary>
    /// Логика взаимодействия для Card.xaml
    /// </summary>
    public partial class Card : UserControl
    {
        public Card()
        {
            InitializeComponent();

            Messenger.Default.Register<ICardPanel>(this, (x) =>
            {
                UserControl textCardPanel = new TextCardPanel();
                textCardPanel.DataContext = x;
                content.Children.Add(textCardPanel);
            });
        }
    }
}

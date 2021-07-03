using Catel.Collections;
using Catel.MVVM;
using Models;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;
using ViewModels.Cards;
using ViewModels.Cards.CardPanels;

namespace ViewModels.Windows
{
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Ширина левой панели в процентах.
        /// </summary>
        private GridLength leftPanelWidth = new GridLength(50, GridUnitType.Star);
        public GridLength LeftPanelWidth
        {
            get => leftPanelWidth;
            set
            {
                leftPanelWidth = value;
                RaisePropertyChanged("LeftPanelWidth");
            }
        }

        /// <summary>
        /// Ширина правой панели в процентах.
        /// </summary>
        private GridLength rightPanelWidth = new GridLength(50, GridUnitType.Star);
        public GridLength RightPanelWidth
        {
            get => rightPanelWidth;
            set
            {
                rightPanelWidth = value;
                RaisePropertyChanged("RightPanelWidth");
            }
        }

        /// <summary>
        /// Номер колонки с CardsPanel.
        /// </summary>
        private byte cardsPanelColumnNumber = 0;
        public byte CardsPanelColumnNumber
        {
            get => cardsPanelColumnNumber;
            set 
            {
                cardsPanelColumnNumber = value;
                RaisePropertyChanged("CardsPanelColumnNumber");
            }
        }

        /// <summary>
        /// Номер колонки с NotesPanel.
        /// </summary>
        private byte notesPanelColumnNumber = 1;
        public byte NotesPanelColumnNumber
        {
            get => notesPanelColumnNumber;
            set
            {
                notesPanelColumnNumber = value;
                RaisePropertyChanged("NotesPanelColumnNumber");
            }
        }

        /// <summary>
        /// Список карт.
        /// </summary>
        public ObservableCollection<ICard> Cards { get; private set; } = new ObservableCollection<ICard>();

        /// <summary>
        /// Точки подключения.
        /// </summary>
        private List<ConnectionPoints> connectionPoints;
        public List<ConnectionPoints> ConnectionPoints
        {
            get => connectionPoints;
            set
            {
                connectionPoints = value;
                RaisePropertyChanged("ConnectionPoints");
            }
        }


        public RelayCommand SwitchPanels { get; set; }

        public RelayCommand SwitchEditMode{ get; set; }

        public MainViewModel()
        {
            SwitchPanels = new RelayCommand(SwitchPanelsMethod);

            SwitchEditMode = new RelayCommand(SwitchEditModeMethod);

            #region Test

            var cardPanels = new ObservableCollection<ICardPanel>();

            var uri = new Uri(@"D:\Downloads\Space.png", UriKind.Absolute);

            cardPanels.Add(new TextCardPanelVM() { Text = "Rank tall boy man them over post now. Off into she bed long fat room. Recommend existence curiosity perfectly favourite get eat she why daughters. Not may too nay busy last song must sell. An newspaper assurance discourse ye certainly. Soon gone game and why many calm have. " });

            cardPanels.Add(new MetaTextCardPanelVM() { Title = "Sunlight", Text = "Rank tall boy tall boy man them over post now. Off into she bed long fat room. Recommend existence post now. Off into she bed long fat room. Recommend existence curiosity" });

            cardPanels.Add(new ImageCardPanelVM() { Image = new BitmapImage(uri), Text = "Inhabit hearing perhaps on ye do no. It maids decay as there he. Smallest on suitable disposed do although blessing he juvenile in. Society or if excited forbade. Here name off yet she long sold easy whom. Differed oh cheerful procured pleasure securing suitable in. Hold rich on an he oh fine. Chapter ability shyness article welcome be do on service. And produce say the ten moments parties.Simple innate summer fat appear basket his desire joy.Outward clothes promise at gravity do excited.Sufficient particular impossible by reasonable oh expressiInhabit hearing perhaps on ye do no. It maids decay as there he. Smallest on suitable disposed do although blessing he juvenile in. Society or if excited forbade. Here name off yet she long sold easy whom. Differed oh cheerful procured pleasure securing suitable in. Hold rich on an he oh fine. Chapter ability shyness article welcome be do on service. And produce say the ten moments parties.Simple innate summer fat appear basket his desire joy.Outward clothes promise at gravity do excited.Sufficient particular impossible by reasonable oh expressiInhabit hearing perhaps on ye do no. It maids decay as there he. Smallest on suitable disposed do although blessing he juvenile in. Society or if excited forbade. Here name off yet she long sold easy whom. Differed oh cheerful procured pleasure securing suitable in. Hold rich on an he oh fine. Chapter ability shyness article welcome be do on service. And produce say the ten moments parties.Simple innate summer fat appear basket his desire joy.Outward clothes promise at gravity do excited.Sufficient particular impossible by reasonable oh expressiInhabit hearing perhaps on ye do no. It maids decay as there he. Smallest on suitable disposed do although blessing he juvenile in. Society or if excited forbade. Here name off yet she long sold easy whom. Differed oh cheerful procured pleasure securing suitable in. Hold rich on an he oh fine. Chapter ability shyness article welcome be do on service. And produce say the ten moments parties.Simple innate summer fat appear basket his desire joy.Outward clothes promise at gravity do excited.Sufficient particular impossible by reasonable oh expressiRank tall boy man them over post now. Off into she bed long fat room. Recommend existence curiosity perfectly favourite get eat she why daughters. Not may too nay busy last song must sell. An newspaper assurance discourse ye certainly" });


            var cardPanels2 = new ObservableCollection<ICardPanel>();

            cardPanels2.Add(new TextCardPanelVM() { Text = "Rank tall boy man them over post now. Off into she bed long fat room. Recommend existence curiosity perfectly favourite get eat she why daughters. Not may too nay busy last song must sell. An newspaper assurance discourse ye certainly. Soon gone game and why many calm have. " });

            cardPanels2.Add(new ImageCardPanelVM() { Image = new BitmapImage(uri), Text = "Inhabit hearing perhaps on ye do no. It maids decay as there he. Smallest on suitable disposed do although blessing he juvenile in. Society or if excited forbade. Here name off yet she long sold easy whom. Differed oh cheerful procured pleasure securing suitable in. Hold rich on an he oh fine. Chapter ability shyness article welcome be do on service. And produce say the ten moments parties.Simple innate summer fat appear basket his desire joy.Outward clothes promise at gravity do excited.Sufficient particular impossible by reasonable oh expressiInhabit hearing perhaps on ye do no. It maids decay as there he. Smallest on suitable disposed do although blessing he juvenile in. Society or if excited forbade. Here name off yet she long sold easy whom. Differed oh cheerful procured pleasure securing suitable in. Hold rich on an he oh fine. Chapter ability shyness article welcome be do on service. And produce say the ten moments parties.Simple innate summer fat appear basket his desire joy.Outward clothes promise at gravity do excited.Sufficient particular impossible by reasonable oh expressiInhabit hearing perhaps on ye do no. It maids decay as there he. Smallest on suitable disposed do although blessing he juvenile in. Society or if excited forbade. Here name off yet she long sold easy whom. Differed oh cheerful procured pleasure securing suitable in. Hold rich on an he oh fine. Chapter ability shyness article welcome be do on service. And produce say the ten moments parties.Simple innate summer fat appear basket his desire joy.Outward clothes promise at gravity do excited.Sufficient particular impossible by reasonable oh expressiInhabit hearing perhaps on ye do no. It maids decay as there he. Smallest on suitable disposed do although blessing he juvenile in. Society or if excited forbade. Here name off yet she long sold easy whom. Differed oh cheerful procured pleasure securing suitable in. Hold rich on an he oh fine. Chapter ability shyness article welcome be do on service. And produce say the ten moments parties.Simple innate summer fat appear basket his desire joy.Outward clothes promise at gravity do excited.Sufficient particular impossible by reasonable oh expressiRank tall boy man them over post now. Off into she bed long fat room. Recommend existence curiosity perfectly favourite get eat she why daughters. Not may too nay busy last song must sell. An newspaper assurance discourse ye certainly" });

            #endregion

            Cards.Add(new CardVM(cardPanels));

            Cards.Add(new CardVM(cardPanels2));

            Cards.Add(new CardVM(cardPanels2));

            var key = ConnectionsControl.GetKey(Cards[0]);
            var foreginKey = ConnectionsControl.GetKey(Cards[1]);
            var foreginKey2 = ConnectionsControl.GetKey(Cards[2]);

            ConnectionsControl.CreateConnection(key, foreginKey);

            ConnectionsControl.CreateConnection(key, foreginKey2);


            ConnectionsControl.СonnectionPointsChanged += (sender, e) =>
            {
                var points = (List<ConnectionPoints>)sender;

                ConnectionPoints = new List<ConnectionPoints>(points);
            };
        }

        /// <summary>
        /// Метод меняющий панели местами.
        /// </summary>
        public void SwitchPanelsMethod(object param)
        {
            byte num = CardsPanelColumnNumber;
            CardsPanelColumnNumber = NotesPanelColumnNumber;
            NotesPanelColumnNumber = num;
        }
        
        /// <summary>
        /// Метод меняющий режим редактирования.
        /// </summary>
        public void SwitchEditModeMethod(object param)
        {
            if (Convert.ToBoolean(param) == true)
            {
                Cards.ForEach(f => f.IsEdit = true);
            }
            else
            {
                Cards.ForEach(f => f.IsEdit = false);
            }
        }

    }
}

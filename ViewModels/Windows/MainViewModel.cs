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
    public sealed class MainViewModel : ViewModelBase
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
        public ObservableCollection<ICard> Cards { get; private set; } = CardsControl.Cards;

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

        public RelayCommand AddCardOrConnection { get; set; }

        public MainViewModel()
        {
            SwitchPanels = new RelayCommand(SwitchPanelsMethod);

            SwitchEditMode = new RelayCommand(SwitchEditModeMethod);

            AddCardOrConnection = new RelayCommand(ShowAddCardOrConnectionMethod);

            #region Test

            var cardPanels = new ObservableCollection<ICardPanel>();

            cardPanels.Add(new MetaTextCardPanelVM() { Title = "RadioButtons", Text = " 'Создать карточку' или 'Создать связь'" });
            cardPanels.Add(new TextCardPanelVM() { Text = "Добавить возможность создавать панели" });

            #endregion

            CardsControl.AddCard(new CardVM("Card 1", cardPanels));

            //var key = CardsControl.GetKey(Cards[0]);
            //var foreginKey = CardsControl.GetKey(Cards[1]);
            //var foreginKey2 = CardsControl.GetKey(Cards[2]);

            //CardsControl.CreateConnection(key, foreginKey);

            //CardsControl.CreateConnection(key, foreginKey2);


            CardsControl.СonnectionPointsChanged += (sender, e) =>
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

        /// <summary>
        /// Открывает диалоговое окно создания карты или связи.
        /// </summary>
        public void ShowAddCardOrConnectionMethod(object param)
        {
            var addCardOrConnectionVM = new AddCardOrConnectionVM();

            WindowAndPageService.DisplayRootRegistry.ShowModalPresentation(addCardOrConnectionVM);
        }
    }
}

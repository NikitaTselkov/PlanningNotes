using Catel.MVVM;
using Models;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ViewModels.Cards;

namespace ViewModels.Windows
{
    public sealed class AddCardOrConnectionVM : ViewModelBase
    {
        public bool IsSelectedCard
        {
            get { return _isSelectedCard; }
            set 
            {
                _isSelectedCard = value;
                RaisePropertyChanged(nameof(IsSelectedCard));
            }
        }
        public bool IsSelectedConnection
        {
            get => _isSelectedConnection;
            set
            {
                _isSelectedConnection = value;
                RaisePropertyChanged(nameof(IsSelectedConnection));
            }
        }
        public string CardTitle
        {
            get => cardTitle;
            set
            {
                cardTitle = value;
                RaisePropertyChanged(nameof(CardTitle));
            }
        }
        public string FirstSelectedCard
        {
            get => firstSelectedCard;
            set
            {
                firstSelectedCard = value;
                RaisePropertyChanged(nameof(FirstSelectedCard));
            }
        }
        public string SecondSelectedCard
        {
            get => secondSelectedCard;
            set
            {
                secondSelectedCard = value;
                RaisePropertyChanged(nameof(SecondSelectedCard));
            }
        }
        public List<string> CardTitles
        {
            get => cardTitles;
            set
            {
                cardTitles = value;
                RaisePropertyChanged(nameof(CardTitles));
            }
        }

        public RelayCommand Accept { get; set; }


        private bool _isSelectedCard = true;
        private bool _isSelectedConnection;
        private string cardTitle;
        private string firstSelectedCard;
        private string secondSelectedCard;
        private List<string> cardTitles = CardsControl.GetCardTitles();

        public AddCardOrConnectionVM()
        {
            Accept = new RelayCommand(AcceptMethod);
        }

        /// <summary>
        /// Закрывает текущее окно.
        /// </summary>
        public void AcceptMethod(object param)
        {
            if (IsSelectedCard)
            {
                var cardPanels = new ObservableCollection<ICardPanel>();

                CardsControl.AddCard(new CardVM(CardTitle, cardPanels));
            }
            else if (IsSelectedConnection)
            {
                if (FirstSelectedCard != SecondSelectedCard)
                {
                    var key = CardsControl.GetCardByTitle(FirstSelectedCard).Key;
                    var foreginKey = CardsControl.GetCardByTitle(SecondSelectedCard).Key;

                    CardsControl.CreateConnection(key, foreginKey);
                }
            }

            WindowAndPageService.DisplayRootRegistry.ClosePresentation(this);
        }
    }
}

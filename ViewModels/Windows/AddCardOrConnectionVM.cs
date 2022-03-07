using Catel.MVVM;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels.Windows
{
    public sealed class AddCardOrConnectionVM : ViewModelBase
    {
        private bool _isSelectedCard = true;
        public bool IsSelectedCard
        {
            get { return _isSelectedCard; }
            set 
            {
                _isSelectedCard = value;
                RaisePropertyChanged(nameof(IsSelectedCard));
            }
        }

        private bool _isSelectedConnection;
        public bool IsSelectedConnection
        {
            get { return _isSelectedConnection; }
            set
            {
                _isSelectedConnection = value;
                RaisePropertyChanged(nameof(IsSelectedConnection));
            }
        }

        private string cardTitle;
        public string CardTitle
        {
            get { return cardTitle; }
            set
            { 
                cardTitle = value;
                RaisePropertyChanged(nameof(CardTitle));
            }
        }


        private List<string> cardTitles = new List<string>() { "card1", "card2", "card3" };
        public List<string> CardTitles
        {
            get { return cardTitles; }
            set
            {
                cardTitles = value;
                RaisePropertyChanged(nameof(CardTitles));
            }
        }


        public RelayCommand Accept { get; set; }

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

            }
            else if (IsSelectedConnection)
            { 
            
            }

            WindowAndPageService.DisplayRootRegistry.ClosePresentation(this);
        }
    }
}

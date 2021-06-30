﻿using Catel.MVVM;
using Models.Interfaces;

namespace ViewModels.Cards.CardPanels
{
    public class TextCardPanelVM : ViewModelBase, ICardPanel
    {
        /// <summary>
        /// Если выполнено.
        /// </summary>
        private bool isDone;
        public bool IsDone
        {
            get => isDone;
            set
            {
                isDone = value;
                RaisePropertyChanged("IsDone");
            }
        }

        /// <summary>
        /// Текст.
        /// </summary>
        private string text;
        public string Text
        {
            get => text;
            set
            {
                text = value;
                RaisePropertyChanged("Text");
            }
        }
    }
}

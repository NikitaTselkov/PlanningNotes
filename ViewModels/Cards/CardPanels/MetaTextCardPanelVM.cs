using Catel.MVVM;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels.Cards.CardPanels
{
    public class MetaTextCardPanelVM : ViewModelBase, ICardPanel
    {
        /// <summary>
        /// Ширина.
        /// </summary>
        private double width;
        public double Width
        {
            get => width;
            set
            {
                width = value;
                RaisePropertyChanged("Width");
            }
        }

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
        /// Заголовок.
        /// </summary>
        private string title;
        public string Title
        {
            get => title;
            set
            {
                title = value;
                RaisePropertyChanged("Title");
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

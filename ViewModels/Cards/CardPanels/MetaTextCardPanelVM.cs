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
        /// Событие изменения IsDone.
        /// </summary>
        public event EventHandler IsDoneChanged;

        /// <summary>
        /// Если включен режим редактирования.
        /// </summary>
        private bool isEdit;
        public bool IsEdit
        {
            get => isEdit;
            set
            {
                isEdit = value;
                RaisePropertyChanged("IsEdit");
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
                IsDoneChanged?.Invoke(isDone, new EventArgs());
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

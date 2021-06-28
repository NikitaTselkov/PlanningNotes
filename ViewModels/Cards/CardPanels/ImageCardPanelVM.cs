using Catel.MVVM;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;

namespace ViewModels.Cards.CardPanels
{
    public class ImageCardPanelVM : ViewModelBase, ICardPanel
    {
        /// <summary>
        /// Возможность редактировать содержимое. 
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
                RaisePropertyChanged("IsDone");
            }
        }

        /// <summary>
        /// Изображение.
        /// </summary>
        private BitmapImage image;
        public BitmapImage Image
        {
            get => image;
            set
            {
                image = value;
                RaisePropertyChanged("Image");
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

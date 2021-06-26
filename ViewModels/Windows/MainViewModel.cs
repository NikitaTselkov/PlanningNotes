using Catel.MVVM;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

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
    }
}

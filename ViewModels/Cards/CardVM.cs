using Catel.Collections;
using Catel.Linq;
using Catel.MVVM;
using GalaSoft.MvvmLight.Messaging;
using Models;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using ViewModels.Cards.CardPanels;

namespace ViewModels.Cards
{
    public class CardVM : ViewModelBase, ICard
    {
        /// <summary>
        ///  Список панелей.
        /// </summary>
        public ObservableCollection<ICardPanel> CardPanels { get; private set; } = new ObservableCollection<ICardPanel>();

        /// <summary>
        /// Если в процессе.
        /// </summary>
        private bool inProgress = true; //
        public bool InProgress
        {
            get => inProgress;
            set
            {
                inProgress = value;
                RaisePropertyChanged("InProgress");
            }
        }

        /// <summary>
        /// Если высокий приоритет.
        /// </summary>
        private bool isTopPriority = true; //
        public bool IsTopPriority
        {
            get => isTopPriority;
            set
            {
                isTopPriority = value;
                RaisePropertyChanged("IsTopPriority");
            }
        }

        /// <summary>
        /// Прогресс выполнения.
        /// </summary>
        public double Progress
        {
            get => NumberOfTasks != 0 ? NumberOfCompletedTasks / NumberOfTasks * 100 : 0;
        }

        /// <summary>
        /// Кол-во выполненных заданий.
        /// </summary>
        public double NumberOfCompletedTasks
        {
            get => CardPanels.Count(c => c.IsDone == true);
        }

        /// <summary>
        /// Кол-во заданий.
        /// </summary>
        public double NumberOfTasks
        {
            get => CardPanels.Count;
        }

        /// <summary>
        /// Максимальная ширина.
        /// </summary>
        private double width = 380; 
        public double Width 
        {
            get => width;
            set
            {
                width = value;                
                RaisePropertyChanged("Width");
            }
        }

        public CardVM(ObservableCollection<ICardPanel> cardPanels)
        {
            CardPanels.CollectionChanged += (s, e) =>
            {
                // Проверка, если в списке панелей есть MetaTextCardPanelVM.
                if (CardPanels.Any(a => a.GetType() == typeof(MetaTextCardPanelVM)))
                {
                    this.Width = 500;

                    // Получает все ImageCardPanelVM.
                    var imageCardPanels = CardPanels.Where(w => w.GetType() == typeof(ImageCardPanelVM)).ToList();

                    // Меняет Width у всех ImageCardPanelVM на this.Width.
                    for (int i = 0; i < imageCardPanels.Count(); i++)
                    {
                        ((ImageCardPanelVM)CardPanels[CardPanels.IndexOf(imageCardPanels[i])]).Width = this.Width;
                    }
                }

                Update();
            };

            cardPanels.ForEach(f => CardPanels.Add(f));
        }

        /// <summary>
        /// Обновление.
        /// </summary>
        private void Update()
        {
            RaisePropertyChanged("CardPanels");
            RaisePropertyChanged("NumberOfCompletedTasks");
            RaisePropertyChanged("NumberOfTasks");
            RaisePropertyChanged("Progress");
        }
    }
}

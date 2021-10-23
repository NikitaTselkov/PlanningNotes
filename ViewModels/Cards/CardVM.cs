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
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using ViewModels.Cards.CardPanels;

namespace ViewModels.Cards
{
    public sealed class CardVM : ViewModelBase, ICard
    {
        /// <summary>
        ///  Список панелей.
        /// </summary>
        public ObservableCollection<ICardPanel> CardPanels { get; private set; } = new ObservableCollection<ICardPanel>();

        /// <summary>
        /// Ключ.
        /// </summary>
        private Guid key;
        public Guid Key
        {
            get => key;
            set 
            {
                key = value;
                RaisePropertyChanged("Key");
            }
        }

        /// <summary>
        /// Левая точка подключения.
        /// </summary>
        private Point leftPoint;
        public Point LeftPoint
        {
            get => leftPoint;
            set
            {
                leftPoint = value;
                RaisePropertyChanged("LeftPoint");
            }
        }

        /// <summary>
        /// Правая точка подключения.
        /// </summary>
        private Point rightPoint;
        public Point RightPoint
        {
            get => rightPoint;
            set
            {
                rightPoint = value;
                RaisePropertyChanged("RightPoint");
            }
        }

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
                EnableEditMode(isEdit);
                RaisePropertyChanged("IsEdit");
            }
        }

        /// <summary>
        /// Если в процессе видимый.
        /// </summary>
        private bool isProgressVisible;
        public bool IsProgressVisible
        {
            get => isProgressVisible;
            set
            {
                isProgressVisible = value;
                RaisePropertyChanged("IsProgressVisible");
            }
        }

        /// <summary>
        /// Если высокий приоритет видимый.
        /// </summary>
        private bool isTopPriorityVisible;
        public bool IsTopPriorityVisible
        {
            get => isTopPriorityVisible;
            set
            {
                isTopPriorityVisible = value;
                RaisePropertyChanged("IsTopPriorityVisible");
            }
        }

        /// <summary>
        /// Если в процессе.
        /// </summary>
        private bool inProgress = true;
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
        private bool isTopPriority;
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
        public int Progress
        {
            get => Convert.ToInt32(NumberOfTasks != 0 ? NumberOfCompletedTasks / NumberOfTasks * 100 : 0);
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


        public RelayCommand SwitchTopPriority { get; set; }

        public RelayCommand SwitchStatus { get; set; }


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

            CardPanels.ForEach(f => f.IsDoneChanged += (s, e) => Update());

            SwitchTopPriority = new RelayCommand(SwitchTopPriorityMethod);
            SwitchStatus = new RelayCommand(SwitchStatusMethod);
        }

        /// <summary>
        /// Включает режим редактирования.
        /// </summary>
        private void EnableEditMode(bool isEdit)
        {
            IsProgressVisible = !InProgress;
            IsTopPriorityVisible = !IsTopPriority;

            if (isEdit == true)
            {
                CardPanels.ForEach(f => f.IsEdit = true);
            }
            else
            {
                CardPanels.ForEach(f => f.IsEdit = false);

                IsProgressVisible = false;
                IsTopPriorityVisible = false;
            }     
        }

        /// <summary>
        /// Меняет приоритет.
        /// </summary>
        public void SwitchTopPriorityMethod(object param)
        {
            IsTopPriority = !IsTopPriority;
            IsTopPriorityVisible = !IsTopPriority;
        }
        
        /// <summary>
        /// Меняет статус.
        /// </summary>
        public void SwitchStatusMethod(object param)
        {
            InProgress = !InProgress;
            IsProgressVisible = !InProgress;
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

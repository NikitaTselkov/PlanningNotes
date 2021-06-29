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
        public ObservableCollection<ICardPanel> CardPanels { get; set; } = new ObservableCollection<ICardPanel>();

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
            set
            {
                RaisePropertyChanged("NumberOfCompletedTasks");
                RaisePropertyChanged("Progress");
            }
        }

        /// <summary>
        /// Кол-во заданий.
        /// </summary>
        public double NumberOfTasks
        {
            get => CardPanels.Count;
            set
            {
                RaisePropertyChanged("NumberOfTasks");
                RaisePropertyChanged("Progress");
            }
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


        public CardVM()
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
                        CardPanels[CardPanels.IndexOf(imageCardPanels[i])].Width = this.Width;
                    }
                }
            };

            CardPanels.Add(new TextCardPanelVM() { Text = "Rank tall boy man them over post now. Off into she bed long fat room. Recommend existence curiosity perfectly favourite get eat she why daughters. Not may too nay busy last song must sell. An newspaper assurance discourse ye certainly. Soon gone game and why many calm have. " });

            var uri = new Uri(@"D:\Downloads\Space.png", UriKind.Absolute);

            CardPanels.Add(new ImageCardPanelVM() { Width = Width, Image = new BitmapImage(uri), Text = "Inhabit hearing perhaps on ye do no. It maids decay as there he. Smallest on suitable disposed do although blessing he juvenile in. Society or if excited forbade. Here name off yet she long sold easy whom. Differed oh cheerful procured pleasure securing suitable in. Hold rich on an he oh fine. Chapter ability shyness article welcome be do on service. And produce say the ten moments parties.Simple innate summer fat appear basket his desire joy.Outward clothes promise at gravity do excited.Sufficient particular impossible by reasonable oh expressiInhabit hearing perhaps on ye do no. It maids decay as there he. Smallest on suitable disposed do although blessing he juvenile in. Society or if excited forbade. Here name off yet she long sold easy whom. Differed oh cheerful procured pleasure securing suitable in. Hold rich on an he oh fine. Chapter ability shyness article welcome be do on service. And produce say the ten moments parties.Simple innate summer fat appear basket his desire joy.Outward clothes promise at gravity do excited.Sufficient particular impossible by reasonable oh expressiInhabit hearing perhaps on ye do no. It maids decay as there he. Smallest on suitable disposed do although blessing he juvenile in. Society or if excited forbade. Here name off yet she long sold easy whom. Differed oh cheerful procured pleasure securing suitable in. Hold rich on an he oh fine. Chapter ability shyness article welcome be do on service. And produce say the ten moments parties.Simple innate summer fat appear basket his desire joy.Outward clothes promise at gravity do excited.Sufficient particular impossible by reasonable oh expressiInhabit hearing perhaps on ye do no. It maids decay as there he. Smallest on suitable disposed do although blessing he juvenile in. Society or if excited forbade. Here name off yet she long sold easy whom. Differed oh cheerful procured pleasure securing suitable in. Hold rich on an he oh fine. Chapter ability shyness article welcome be do on service. And produce say the ten moments parties.Simple innate summer fat appear basket his desire joy.Outward clothes promise at gravity do excited.Sufficient particular impossible by reasonable oh expressiRank tall boy man them over post now. Off into she bed long fat room. Recommend existence curiosity perfectly favourite get eat she why daughters. Not may too nay busy last song must sell. An newspaper assurance discourse ye certainly" });

            CardPanels.Add(new TextCardPanelVM() { Text = "Rank tall boy man them over post now. Off into she bed long fat room. Recommend existence curiosity perfectly favourite get eat she why daughters. Not may too nay busy last song must sell. An newspaper assurance discourse ye certainly. Soon gone game and why many calm have. " });

            CardPanels.Add(new MetaTextCardPanelVM() { Title = "Sunlight", Text = "Rank tall boy tall boy man them over post now. Off into she bed long fat room. Recommend existence post now. Off into she bed long fat room. Recommend existence curiosity" });

            CardPanels.Add(new MetaTextCardPanelVM() { Title = "Sunlight", Text = "Rank tall boy tall boy man them over post now. Off into she bed long fat room. Recommend existence post now. Off into she bed long fat room. Recommend existence curiosity" });

            CardPanels.Add(new TextCardPanelVM() { Text = "Rank tall boy man them over post now. Off into she bed long fat room. Recommend existence curiosity perfectly favourite get eat she why daughters. Not may too nay busy last song must sell. An newspaper assurance discourse ye certainly. Soon gone game and why many calm have. " });

            CardPanels.Add(new MetaTextCardPanelVM() { Title = "Sunlight", Text = "Rank tall boy tall boy man them over post now. Off into she bed long fat room. Recommend existence post now. Off into she bed long fat room. Recommend existence curiosity" });

            CardPanels.Add(new ImageCardPanelVM() { Width = Width, Image = new BitmapImage(uri), Text = "Inhabit hearing perhaps on ye do no. It maids decay as there he. Smallest on suitable disposed do although blessing he juvenile in. Society or if excited forbade. Here name off yet she long sold easy whom. Differed oh cheerful procured pleasure securing suitable in. Hold rich on an he oh fine. Chapter ability shyness article welcome be do on service. And produce say the ten moments parties.Simple innate summer fat appear basket his desire joy.Outward clothes promise at gravity do excited.Sufficient particular impossible by reasonable oh expressiInhabit hearing perhaps on ye do no. It maids decay as there he. Smallest on suitable disposed do although blessing he juvenile in. Society or if excited forbade. Here name off yet she long sold easy whom. Differed oh cheerful procured pleasure securing suitable in. Hold rich on an he oh fine. Chapter ability shyness article welcome be do on service. And produce say the ten moments parties.Simple innate summer fat appear basket his desire joy.Outward clothes promise at gravity do excited.Sufficient particular impossible by reasonable oh expressiInhabit hearing perhaps on ye do no. It maids decay as there he. Smallest on suitable disposed do although blessing he juvenile in. Society or if excited forbade. Here name off yet she long sold easy whom. Differed oh cheerful procured pleasure securing suitable in. Hold rich on an he oh fine. Chapter ability shyness article welcome be do on service. And produce say the ten moments parties.Simple innate summer fat appear basket his desire joy.Outward clothes promise at gravity do excited.Sufficient particular impossible by reasonable oh expressiInhabit hearing perhaps on ye do no. It maids decay as there he. Smallest on suitable disposed do although blessing he juvenile in. Society or if excited forbade. Here name off yet she long sold easy whom. Differed oh cheerful procured pleasure securing suitable in. Hold rich on an he oh fine. Chapter ability shyness article welcome be do on service. And produce say the ten moments parties.Simple innate summer fat appear basket his desire joy.Outward clothes promise at gravity do excited.Sufficient particular impossible by reasonable oh expressiRank tall boy man them over post now. Off into she bed long fat room. Recommend existence curiosity perfectly favourite get eat she why daughters. Not may too nay busy last song must sell. An newspaper assurance discourse ye certainly" });
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

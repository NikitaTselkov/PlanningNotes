using GalaSoft.MvvmLight.Messaging;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using ViewModels.Cards.CardPanels;

namespace ViewModels.Cards
{
    public class CardVM
    {
        /// <summary>
        ///  Список панелей.
        /// </summary>
        public ObservableCollection<ICardPanel> CardPanels { get; set; } = new ObservableCollection<ICardPanel>();

        public CardVM()
        {
            CardPanels.Add(new TextCardPanelVM() { Text = "Rank tall boy man them over post now. Off into she bed long fat room. Recommend existence curiosity perfectly favourite get eat she why daughters. Not may too nay busy last song must sell. An newspaper assurance discourse ye certainly. Soon gone game and why many calm have. " });

            CardPanels.CollectionChanged += (s, e) =>
            {
                Messenger.Default.Send<ICardPanel>(CardPanels.Last());
            };
        }

    }
}

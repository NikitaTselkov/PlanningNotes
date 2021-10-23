using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.ObjectModel;
using Models.Interfaces;

namespace ViewModels.Cards.Tests
{
    [TestClass()]
    public class CardsControlTests
    {
        [TestMethod()]
        public void CreateNewKeyTest()
        {
            CardVM card = new CardVM(new ObservableCollection<ICardPanel>());

            CardsControl.AddCard(card);

            Assert.IsTrue(CardsControl.HasKey(card.Key));

            CardsControl.DeleteKey(card.Key);
        }

        [TestMethod()]
        public void GetKeysTest()
        {
            CardVM card1 = new CardVM(new ObservableCollection<ICardPanel>());
            CardVM card2 = new CardVM(new ObservableCollection<ICardPanel>());
            CardVM card3 = new CardVM(new ObservableCollection<ICardPanel>());

            CardsControl.AddCard(card1);
            CardsControl.AddCard(card2);
            CardsControl.AddCard(card3);

            var keys = CardsControl.GetKeys();

            Assert.AreEqual(card1.Key, keys[0]);
            Assert.AreEqual(card2.Key, keys[1]);
            Assert.AreEqual(card3.Key, keys[2]);

            CardsControl.DeleteKey(card1.Key);
            CardsControl.DeleteKey(card2.Key);
            CardsControl.DeleteKey(card3.Key);
        }

        [TestMethod()]
        public void GetKeyTest()
        {
            CardVM card = new CardVM(new ObservableCollection<ICardPanel>());

            CardsControl.AddCard(card);

            var key = CardsControl.GetKey(card);

            Assert.AreEqual(card.Key, key);

            CardsControl.DeleteKey(card.Key);
        }

        [TestMethod()]
        public void GetCardTest()
        {
            CardVM card = new CardVM(new ObservableCollection<ICardPanel>());

            CardsControl.AddCard(card);

            var card1 = CardsControl.GetCard(card.Key);

            Assert.AreEqual(card, card1);

            CardsControl.DeleteKey(card.Key);
        }
    }
}
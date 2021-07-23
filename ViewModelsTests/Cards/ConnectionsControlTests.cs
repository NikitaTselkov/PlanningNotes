using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.ObjectModel;
using Models.Interfaces;

namespace ViewModels.Cards.Tests
{
    [TestClass()]
    public class ConnectionsControlTests
    {
        [TestMethod()]
        public void CreateNewKeyTest()
        {
            // CreateNewKey вызывается в конструкторе класса CardVM.

            CardVM card = new CardVM(new ObservableCollection<ICardPanel>());

            Assert.IsTrue(ConnectionsControl.HasKey(card.Key));

            ConnectionsControl.DeleteKey(card.Key);
        }

        [TestMethod()]
        public void GetKeysTest()
        {
            CardVM card1 = new CardVM(new ObservableCollection<ICardPanel>());
            CardVM card2 = new CardVM(new ObservableCollection<ICardPanel>());
            CardVM card3 = new CardVM(new ObservableCollection<ICardPanel>());

            var keys = ConnectionsControl.GetKeys();

            Assert.AreEqual(card1.Key, keys[0]);
            Assert.AreEqual(card2.Key, keys[1]);
            Assert.AreEqual(card3.Key, keys[2]);

            ConnectionsControl.DeleteKey(card1.Key);
            ConnectionsControl.DeleteKey(card2.Key);
            ConnectionsControl.DeleteKey(card3.Key);
        }

        [TestMethod()]
        public void GetKeyTest()
        {
            CardVM card = new CardVM(new ObservableCollection<ICardPanel>());

            var key = ConnectionsControl.GetKey(card);

            Assert.AreEqual(card.Key, key);

            ConnectionsControl.DeleteKey(card.Key);
        }

        [TestMethod()]
        public void GetCardTest()
        {
            CardVM card = new CardVM(new ObservableCollection<ICardPanel>());

            var card1 = ConnectionsControl.GetCard(card.Key);

            Assert.AreEqual(card, card1);

            ConnectionsControl.DeleteKey(card.Key);
        }
    }
}
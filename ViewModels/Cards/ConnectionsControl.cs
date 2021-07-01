using Models;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace ViewModels.Cards
{
    public static class ConnectionsControl
    {
        // Ключи.
        private static readonly Dictionary<Guid, ICard> Keys = new Dictionary<Guid, ICard>();

        // Связи.
        private static readonly Dictionary<ConnectionData, ConnectionData> Connections = new Dictionary<ConnectionData, ConnectionData>();

        // Точки подключения.
        private static readonly Dictionary<Point, Point> СonnectionPoints = new Dictionary<Point, Point>();


        // Событие изменения точек подключения.
        public static event EventHandler СonnectionPointsChanged;


        /// <summary>
        /// Проверка, если такой ключ уже есть.
        /// </summary>
        public static bool HasKey(Guid key)
        {
            return Keys.Any(a => a.Key == key);
        }

        /// <summary>
        /// Создать новый ключ.
        /// </summary>
        public static Guid CreateNewKey(ICard card)
        {
            var key = Guid.NewGuid();

            while (HasKey(key))
            {
                key = Guid.NewGuid();
            }

            Keys.Add(key, card);

            return key;
        }

        /// <summary>
        /// Создать связь.
        /// </summary>
        public static void CreateConnection(Guid key, Guid foreignKey)
        {
            if (key != foreignKey)
            {
                var connectionData1 = new ConnectionData(key, Keys[key]);
                var connectionData2 = new ConnectionData(foreignKey, Keys[foreignKey]);

                Connections.Add(connectionData1, connectionData2);
            }
        }

        /// <summary>
        /// Получить список ключей.
        /// </summary>
        public static List<Guid> GetKeys()
        {
            return Keys.Keys.ToList();
        }

        /// <summary>
        /// Получает ключ этого элемента.
        /// </summary>
        public static Guid GetKey(ICard card)
        {
            return Keys.Single(s => s.Value == card).Key;
        }

        /// <summary>
        /// Получает элемент по ключу.
        /// </summary>
        public static ICard GetCard(Guid key)
        {
            return Keys.Single(s => s.Key == key).Value;
        }

        /// <summary>
        /// Получает связи этого элемента.
        /// </summary>
        public static Dictionary<ConnectionData, ConnectionData> GetConnections(ICard card)
        {
            var result = new Dictionary<ConnectionData, ConnectionData>();

            foreach (var item in Connections)
            {
                if (item.Key.Card == card || item.Value.Card == card)
                {
                    result.Add(item.Key, item.Value);
                }
            }

            return result;
        }

        /// <summary>
        /// Получает точки связи элемента.
        /// </summary>
        public static void GetConnectionPoints()
        {
            ICard card1;
            ICard card2;

            СonnectionPoints.Clear();

            foreach (var item in Connections)
            {
                card1 = item.Key.Card;
                card2 = item.Value.Card;

                if (card1.LeftPoint.X > card2.RightPoint.X)
                {
                    СonnectionPoints.Add(card1.LeftPoint, card2.RightPoint);
                }
                else if (card1.RightPoint.X < card2.LeftPoint.X)
                {
                    СonnectionPoints.Add(card1.RightPoint, card2.LeftPoint);
                }
            }

            СonnectionPointsChanged?.Invoke(СonnectionPoints, new EventArgs());
        }
    }
}

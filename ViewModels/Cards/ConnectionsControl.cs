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
        private static readonly List<ConnectionPoints> СonnectionPoints = new List<ConnectionPoints>();


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
        /// Удалить ключ.
        /// </summary>
        public static void DeleteKey(Guid key)
        {
            Keys.Remove(key);
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
        /// Получает точки связи элемента.
        /// </summary>
        public static void GetConnectionPoints()
        {
            ICard card1;
            ICard card2;
            ConnectionPoints points;

            СonnectionPoints.Clear();

            foreach (var item in Connections)
            {
                card1 = item.Key.Card;
                card2 = item.Value.Card;

                if (card1.LeftPoint.X > card2.RightPoint.X)
                {
                    points = new ConnectionPoints(card1.LeftPoint, card2.RightPoint);

                    СonnectionPoints.Add(points);
                }
                else if (card1.RightPoint.X < card2.LeftPoint.X)
                {
                    points = new ConnectionPoints(card1.RightPoint, card2.LeftPoint);

                    СonnectionPoints.Add(points);
                }
                else if (card1.RightPoint.X < card2.RightPoint.X && card1.LeftPoint.X < card2.LeftPoint.X)
                {
                    points = new ConnectionPoints(card1.RightPoint, card2.RightPoint);

                    СonnectionPoints.Add(points);
                }
                else if (card1.RightPoint.X > card2.RightPoint.X && card1.LeftPoint.X > card2.LeftPoint.X)
                {
                    points = new ConnectionPoints(card1.LeftPoint, card2.LeftPoint);

                    СonnectionPoints.Add(points);
                }
            }

            СonnectionPointsChanged?.Invoke(СonnectionPoints, new EventArgs());
        }
    }
}

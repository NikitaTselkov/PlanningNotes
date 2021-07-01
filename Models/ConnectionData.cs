using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Models
{
    public class ConnectionData
    {
        public Guid Key { get; private set; }

        public ICard Card { get; private set; }


        public ConnectionData(Guid key, ICard card)
        {
            Key = key;
            Card = card;
        }
    }
}

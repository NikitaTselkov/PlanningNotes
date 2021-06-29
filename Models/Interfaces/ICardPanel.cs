using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Interfaces
{
    public interface ICardPanel
    {
        /// <summary>
        /// Ширина.
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// Если выполнено.
        /// </summary>
        public bool IsDone { get; set; }
    }
}

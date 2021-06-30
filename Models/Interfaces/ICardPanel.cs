using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Interfaces
{
    public interface ICardPanel
    {
        /// <summary>
        /// Если выполнено.
        /// </summary>
        public bool IsDone { get; set; }
    }
}

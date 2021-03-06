using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Interfaces
{
    public interface ICardPanel
    {
        /// <summary>
        /// Событие изменения IsDone.
        /// </summary>
        public event EventHandler IsDoneChanged;

        /// <summary>
        /// Если режим редактирования включен.
        /// </summary>
        public bool IsEdit { get; set; }

        /// <summary>
        /// Если выполнено.
        /// </summary>
        public bool IsDone { get; set; }
    }
}

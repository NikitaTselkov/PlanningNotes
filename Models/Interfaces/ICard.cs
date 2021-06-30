using System.Collections.ObjectModel;

namespace Models.Interfaces
{
    public interface ICard 
    {
        /// <summary>
        /// Если в процессе.
        /// </summary>
        public bool InProgress { get; set; }

        /// <summary>
        /// Если высокий приоритет.
        /// </summary>
        public bool IsTopPriority { get; set; }

        /// <summary>
        ///  Список панелей.
        /// </summary>
        public ObservableCollection<ICardPanel> CardPanels { get; }

        /// <summary>
        /// Прогресс выполнения.
        /// </summary>
        public double Progress { get; }

        /// <summary>
        /// Кол-во выполненных заданий.
        /// </summary>
        public double NumberOfCompletedTasks { get; }

        /// <summary>
        /// Кол-во заданий.
        /// </summary>
        public double NumberOfTasks { get; }
    }
}

using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels.Windows
{
    public sealed class AddCardOrConnectionVM
    {
        public RelayCommand Close { get; set; }

        public AddCardOrConnectionVM()
        {
            Close = new RelayCommand(CloseMethod);
        }

        /// <summary>
        /// Закрывает текущее окно.
        /// </summary>
        public void CloseMethod(object param)
        {
            WindowService.DisplayRootRegistry.ClosePresentation(this);
        }
    }
}

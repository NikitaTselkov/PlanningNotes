using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using ViewModels.Cards.CardPanels;

namespace ViewModels
{
    public class WidthTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var fe = (FrameworkElement)container;

            if (item is ImageCardPanelVM imageCardPanelVM)
            {
                if (imageCardPanelVM.Width <= 380)
                {
                    return fe.FindResource("NarrowTemplate") as DataTemplate;
                }
                else
                {
                    return fe.FindResource("WideTemplate") as DataTemplate;
                }
            }
            return null;
        }
    }
}

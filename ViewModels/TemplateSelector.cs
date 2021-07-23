using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using ViewModels.Cards.CardPanels;

namespace ViewModels
{
    public sealed class TemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var fe = (FrameworkElement)container;
            if (item is TextCardPanelVM) return fe.FindResource("TextCardPanelTemplate") as DataTemplate;
            if (item is ImageCardPanelVM) return fe.FindResource("ImageCardPanelTemplate") as DataTemplate;
            if (item is MetaTextCardPanelVM) return fe.FindResource("MetaTextCardPanelTemplate") as DataTemplate;
            return null;
        }
    }
}

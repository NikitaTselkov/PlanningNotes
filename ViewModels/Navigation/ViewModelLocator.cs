using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModels.Cards;
using ViewModels.Cards.CardPanels;

namespace ViewModels.Navigation
{
    public class ViewModelLocator
    {

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

           // SimpleIoc.Default.Register<CardVM>();
        }

        //public CardVM Card
        //{
        //    get
        //    {
        //        return ServiceLocator.Current.GetInstance<CardVM>();
        //    }
        //}

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}

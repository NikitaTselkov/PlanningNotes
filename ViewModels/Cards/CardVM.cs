﻿using Catel.MVVM;
using GalaSoft.MvvmLight.Messaging;
using Models;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Data;
using ViewModels.Cards.CardPanels;

namespace ViewModels.Cards
{
    public class CardVM : ViewModelBase
    {
        /// <summary>
        ///  Список панелей.
        /// </summary>
        public ObservableCollection<ICardPanel> CardPanels { get; private set; } = new ObservableCollection<ICardPanel>();

        /// <summary>
        /// Прогресс выполнения.
        /// </summary>
        public double Progress
        {
            get => NumberOfTasks != 0 ? NumberOfCompletedTasks / NumberOfTasks * 100 : 0;
        }

        /// <summary>
        /// Кол-во выполненных заданий.
        /// </summary>
        public double NumberOfCompletedTasks
        {
            get => CardPanels.Count(c => c.IsDone == true);
            set
            {
                RaisePropertyChanged("NumberOfCompletedTasks");
                RaisePropertyChanged("Progress");
            }
        }

        /// <summary>
        /// Кол-во заданий.
        /// </summary>
        public double NumberOfTasks
        {
            get => CardPanels.Count;
            set
            {
                RaisePropertyChanged("NumberOfTasks");
                RaisePropertyChanged("Progress");
            }
        }


        public RelayCommand Click {get; set;}

        public CardVM()
        {
            Click = new RelayCommand(d);

            CardPanels.Add(new TextCardPanelVM() { Text = "Rank tall boy man them over post now. Off into she bed long fat room. Recommend existence curiosity perfectly favourite get eat she why daughters. Not may too nay busy last song must sell. An newspaper assurance discourse ye certainly. Soon gone game and why many calm have. " });
            CardPanels.Add(new TextCardPanelVM() { Text = "R assurance discourse ye certainly. Soon gone game and why many calm have. " });
            CardPanels.Add(new TextCardPanelVM() { Text = "Inhabit hearing perhaps on ye do no. It maids decay as there he. Smallest on suitable disposed do although blessing he juvenile in. Society or if excited forbade. Here name off yet she long sold easy whom. Differed oh cheerful procured pleasure securing suitable in. Hold rich on an he oh fine. Chapter ability shyness article welcome be do on service. And produce say the ten moments parties.Simple innate summer fat appear basket his desire joy.Outward clothes promise at gravity do excited.Sufficient particular impossible by reasonable oh expression is.Yet preference connection unpleasant yet melancholy but end appearance. And excellence partiality estimating terminated day everything.It prepare is ye nothing blushes up brought.Or as gravity pasture limited evening on. Wicket around beauty say she.Frankness resembled say not new smallness you discovery. Noisier ferrars yet shyness weather ten colonel.Too him himself engaged husband pursuit musical.Man age but him determine consisted therefore.Dinner to beyond regret wished an branch he. Remain bed but expect suffer little repair.It sportsman earnestly ye preserved an on.Moment led family sooner cannot her window pulled any.Or raillery if improved landlord to speaking hastened differed he. Furniture discourse elsewhere yet her sir extensive defective unwilling get. Why resolution one motionless you him thoroughly.Noise is round to in it quick timed doors. Written address greatly get attacks inhabit pursuit our but.Lasted hunted enough an up seeing in lively letter. Had judgment out opinions property the supplied. Affronting imprudence do he he everything.Sex lasted dinner wanted indeed wished out law.Far advanced settling say finished raillery. Offered chiefly farther of my no colonel shyness. Such on help ye some door if in. Laughter proposal laughing any son law consider.Needed except up piqued an.Possession her thoroughly remarkably terminated man continuing.Removed greater to do ability.You shy shall while but wrote marry. Call why sake has sing pure. Gay six set polite nature worthy. So matter be me we wisdom should basket moment merely. Me burst ample wrong which would mr he could.Visit arise my point timed drawn no.Can friendly laughter goodness man him appetite carriage. Any widen see gay forth alone fruit bed. Is post each that just leaf no.He connection interested so we an sympathize advantages. To said is it shed want do.Occasional middletons everything so to.Have spot part for his quit may.Enable it is square my an regard.Often merit stuff first oh up hills as he.Servants contempt as although addition dashwood is procured.Interest in yourself an do of numerous feelings cheerful confined. Another journey chamber way yet females man.Way extensive and dejection get delivered deficient sincerity gentleman age. Too end instrument possession contrasted motionless. Calling offence six joy feeling.Coming merits and was talent enough far.Sir joy northward sportsmen education.Discovery incommode earnestly no he commanded if.Put still any about manor heard. " });
            CardPanels.Add(new TextCardPanelVM() { Text = "Inhabit hearing perhaps on ye do no. It maids decay as there he. Smallest on suitable disposed do although blessing he juvenile in. Society or if excited forbade. Here name off yet she long sold easy whom. Differed oh cheerful procured pleasure securing suitable in. Hold rich on an he oh fine. Chapter ability shyness article welcome be do on service. And produce say the ten moments parties.Simple innate summer fat appear basket his desire joy.Outward clothes promise at gravity do excited.Sufficient particular impossible by reasonable oh expression is.Yet preference connection unpleasant yet melancholy but end appearance. And excellence partiality estimating terminated day everything.It prepare is ye nothing blushes up brought.Or as gravity pasture limited evening on. Wicket around beauty say she.Frankness resembled say not new smallness you discovery. Noisier ferrars yet shyness weather ten colonel.Too him himself engaged husband pursuit musical.Man age but him determine consisted therefore.Dinner to beyond regret wished an branch he. Remain bed but expect suffer little repair.It sportsman earnestly ye preserved an on.Moment led family sooner cannot her window pulled any.Or raillery if improved landlord to speaking hastened differed he. Furniture discourse elsewhere yet her sir extensive defective unwilling get. Why resolution one motionless you him thoroughly.Noise is round to in it quick timed doors. Written address greatly get attacks inhabit pursuit our but.Lasted hunted enough an up seeing in lively letter. Had judgment out opinions property the supplied. Affronting imprudence do he he everything.Sex lasted dinner wanted indeed wished out law.Far advanced settling say finished raillery. Offered chiefly farther of my no colonel shyness. Such on help ye some door if in. Laughter proposal laughing any son law consider.Needed except up piqued an.Possession her thoroughly remarkably terminated man continuing.Removed greater to do ability.You shy shall while but wrote marry. Call why sake has sing pure. Gay six set polite nature worthy. So matter be me we wisdom should basket moment merely. Me burst ample wrong which would mr he could.Visit arise my point timed drawn no.Can friendly laughter goodness man him appetite carriage. Any widen see gay forth alone fruit bed. Is post each that just leaf no.He connection interested so we an sympathize advantages. To said is it shed want do.Occasional middletons everything so to.Have spot part for his quit may.Enable it is square my an regard.Often merit stuff first oh up hills as he.Servants contempt as although addition dashwood is procured.Interest in yourself an do of numerous feelings cheerful confined. Another journey chamber way yet females man.Way extensive and dejection get delivered deficient sincerity gentleman age. Too end instrument possession contrasted motionless. Calling offence six joy feeling.Coming merits and was talent enough far.Sir joy northward sportsmen education.Discovery incommode earnestly no he commanded if.Put still any about manor heard. " });
        }

        private void d(object p)
        {
            CardPanels[2].IsDone = true;
            CardPanels[1].IsDone = true;
            Update();
        }

        /// <summary>
        /// Обновление.
        /// </summary>
        private void Update()
        {
            RaisePropertyChanged("CardPanels");
            RaisePropertyChanged("NumberOfCompletedTasks");
            RaisePropertyChanged("NumberOfTasks");
            RaisePropertyChanged("Progress");
        }
    }
}

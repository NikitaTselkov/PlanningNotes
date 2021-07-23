using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ViewModels.Windows;
using ViewModels.WindowService;
using UI.Windows;

namespace UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        MainViewModel mainVM;

        public App()
        {
            DisplayRootRegistry.RegisterWindowType<MainViewModel, MainWindow>();
            DisplayRootRegistry.RegisterWindowType<AddCardOrConnectionVM, AddCardOrConnection>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            RunProgramLogic();
        }

        private void RunProgramLogic()
        {
            mainVM = new MainViewModel();
            DisplayRootRegistry.ShowPresentation(mainVM);
        }
    }
}

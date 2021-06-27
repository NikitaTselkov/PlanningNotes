using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UI.UserControls
{
    /// <summary>
    /// Логика взаимодействия для MenuButton.xaml
    /// </summary>
    public partial class MenuButton : UserControl
    {
        public MenuButton()
        {
            InitializeComponent();
        }

        public string SVGPath
        {
            get { return (string)GetValue(SVGpath); }
            set{ SetValue(SVGpath, value); }
        }

        public static readonly DependencyProperty SVGpath =
            DependencyProperty.Register("SVGPath", typeof(string), typeof(MenuButton), new PropertyMetadata(string.Empty));

    }
}

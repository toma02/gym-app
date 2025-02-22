using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FoiFitness
{
    /// <summary>
    /// Interaction logic for AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public ContentControl contentControl;
        public AuthWindow()
        {
            InitializeComponent();
            contentControl = cntControl;
        }

        private void AuthWindow1_Loaded(object sender, RoutedEventArgs e)
        {
            this.Width = 500;
            this.Height = 600;
            this.Top = 0;
            var startUserControl = new StartUserControl(this);
            cntControl.Content = startUserControl;
        }

        private void DockPanel_Loaded(object sender, RoutedEventArgs e)
        {

        }

        public void OpenLogin()
        {

        }
    }
}

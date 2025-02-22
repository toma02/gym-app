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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FoiFitness
{
    /// <summary>
    /// Interaction logic for StartUserControl.xaml
    /// </summary>
    public partial class StartUserControl : UserControl
    {
        public AuthWindow parentWindow;
        public StartUserControl(AuthWindow parentWindow1)
        {
            InitializeComponent();
            parentWindow = parentWindow1;
            
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            var loginUserControl = new LoginUserControl(parentWindow);
            parentWindow.contentControl.Content = loginUserControl;
        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            this.parentWindow.Height = 800;
            var registerUserControl = new RegisterUserControl(parentWindow);
            parentWindow.contentControl.Content = registerUserControl;
            
        }
    }
}

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
    /// Interaction logic for TrainingGenerationUserControl.xaml
    /// </summary>
    public partial class TrainingGenerationUserControl : UserControl
    {
        public MainWindow parentWindow;

        public TrainingGenerationUserControl(MainWindow parentWindow)
        {
            InitializeComponent();
            this.parentWindow = parentWindow;
        }

        private void btnAutoGeneratePlan_Click(object sender, RoutedEventArgs e)
        {
            var autoGenerationPlanSettingsWindow = new AutoPlanGenerationSettingsWindow();
            autoGenerationPlanSettingsWindow.WindowStartupLocation = WindowStartupLocation.Manual;
            autoGenerationPlanSettingsWindow.Top = 0;
            autoGenerationPlanSettingsWindow.Left = 10;
            autoGenerationPlanSettingsWindow.Height = 1000;
            autoGenerationPlanSettingsWindow.Width = 600;
            autoGenerationPlanSettingsWindow.Show();
            
        }
    }
}

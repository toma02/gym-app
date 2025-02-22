using BusinessLogicLayer;
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
    /// Interaction logic for WaterIntakeWindow.xaml
    /// </summary>
    public partial class WaterIntakeWindow : Window
    {
        public WaterIntakeTracker intakeTracker;
        public WaterIntakeWindow()
        {
            InitializeComponent();
            intakeTracker = new WaterIntakeTracker(2000);
            LoadWaterIntakeTracker();
        }

        private void LoadWaterIntakeTracker()
        {
            txtWaterIntake.Text = "";
            txtCurrentIntake.Text = intakeTracker.GetCurrentIntake().ToString();
            if (intakeTracker.GetRemainingWaterIntake() == 0)
                txtCurrentIntake.Foreground = new SolidColorBrush(Colors.Green);
            else
                txtCurrentIntake.Foreground = new SolidColorBrush(Colors.Red);
        }

        private void btnAddWaterIntake_Click(object sender, RoutedEventArgs e)
        {
            int waterIntake = (!txtWaterIntake.Text.Any(char.IsLetter) && txtWaterIntake.Text.Length>0) ? int.Parse(txtWaterIntake.Text) : 0;
            if (intakeTracker.IsValidIntake(waterIntake))
            {
                intakeTracker.AddIntake(waterIntake);
                LoadWaterIntakeTracker();
            }
            else
                MessageBox.Show("You have to enter value between 250 and 1000!");
        }

        private void btnResetTracker_Click(object sender, RoutedEventArgs e)
        {
            intakeTracker.ResetTracker();
            LoadWaterIntakeTracker();
        }
    }
}

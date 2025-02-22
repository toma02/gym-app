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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FoiFitness.userControl
{
    /// <summary>
    /// Interaction logic for DateWithoutDataUserControl.xaml
    /// </summary>
    public partial class DateWithoutDataUserControl : UserControl
    {
        private string dateString;

        public DateWithoutDataUserControl(string dateString)
        {
            InitializeComponent();
            this.dateString = dateString;
            lbDateTitle.Text = dateString;
        }

        private void btnModifyCalories_Click(object sender, RoutedEventArgs e)
        {
            var calculator = new BMRCalculator();
            int bmr = (int)calculator.CalculateBMR();
            DayRepository.AddDay(dateString,bmr);
            CalorieWindow calorieWindow = new CalorieWindow(dateString);
            calorieWindow.Show();
        }
    }
}

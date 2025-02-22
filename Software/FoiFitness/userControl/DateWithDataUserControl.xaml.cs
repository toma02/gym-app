using BusinessLogicLayer;
using DataAccessLayer;
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
    /// Interaction logic for DateWithDataUserControl.xaml
    /// </summary>
    public partial class DateWithDataUserControl : UserControl
    {
        private List<Day> dayData;
        private string dateString;

        public DateWithDataUserControl(string dateString)
        {
            InitializeComponent();
            this.dateString = dateString;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            lbDateTitle.Text = dateString;
            showCalories();
        }

        private void showCalories()
        {
            dayData = DayRepository.GetDay(dateString);
            lbBMRcilj.Text = dayData[0].bmr_calories.ToString();
            lbKalorije.Text = dayData[0].calories.ToString();

            List<Exercis> exercises = (List<Exercis>)Training_ExercisesRepository.GetExcersisesByDate(dateString);
            lbAllDateExcercises.ItemsSource = exercises;
        }

        private void btnModifyCalories_Click(object sender, RoutedEventArgs e)
        {
            BMRCalculator calculator = new BMRCalculator();
            var date = DayRepository.GetDay(dateString)[0];
            if (date.bmr_calories == 0)
            {
                DayRepository.UpdateBMR(dateString, calculator.CalculateBMR());
                CalorieWindow calorieWindow = new CalorieWindow(dateString);
                calorieWindow.Show();
            }
            else
            {
                CalorieWindow calorieWindow = new CalorieWindow(dateString);
                calorieWindow.Show();
            }
            
        }
    }
}

using BusinessLogicLayer;
using DataAccessLayer;
using FoiFitness.userControl;
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
    /// Interaction logic for CalorieWindow.xaml
    /// </summary>
    public partial class CalorieWindow : Window
    {
        private string dateString;
        private List<Day> day;

        public CalorieWindow(string dateString)
        {
            InitializeComponent();
            this.dateString = dateString;
        }

        private void btnCalories_Click(object sender, RoutedEventArgs e)
        {
            AddCaloriesUserControl addCaloriesUserControl = new AddCaloriesUserControl(dateString);
            cntShowCalories.Content = addCaloriesUserControl;
        }

        private void btnCancelCalories_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            showData();
        }

        private void btnInsertFood_Click(object sender, RoutedEventArgs e)
        {
            InsertFoodUserControl insertFoodUserControl = new InsertFoodUserControl(cntShowCalories);
            cntShowCalories.Content = insertFoodUserControl;
        }

        private void btnFoodStuff_Click(object sender, RoutedEventArgs e)
        {
            ChooseFoodstuffUserControl chooseFoodstuffUserControl = new ChooseFoodstuffUserControl(cntShowCalories,dateString);
            cntShowCalories.Content = chooseFoodstuffUserControl;
        }
        private void showData()
        {
            day = DayRepository.GetDay(dateString);
            txtBmrCalories.Text = day[0].bmr_calories.ToString();
            txtCalories.Text = day[0].calories.ToString();

            List<Days_Groceries> allUserFood = Days_GroceriesRepository.GetDayGroceries(dateString);
            lbAllDateExcercises.ItemsSource = allUserFood;
        }
    }
}

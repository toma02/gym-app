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
    /// Interaction logic for AddCaloriesUserControl.xaml
    /// </summary>
    public partial class AddCaloriesUserControl : UserControl
    {
        private string dateString;

        public AddCaloriesUserControl(string dateString)
        {
            InitializeComponent();
            this.dateString = dateString;
        }

        private void btnAddCalories_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAddCalories.Text) || !DayRepository.IsPositiveNumber(txtAddCalories.Text))
            {
                MessageBox.Show("Insert a number of calories!");
            }
            else
            {
                var calories = txtAddCalories.Text;
                DayRepository.UpdateCalories(dateString, calories);
                MessageBox.Show("Successfully inserted calories!");
            }
        }
    }
}

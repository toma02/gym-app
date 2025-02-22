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
    /// Interaction logic for InsertGramsFoodstuffUserControl.xaml
    /// </summary>
    public partial class InsertGramsFoodstuffUserControl : UserControl
    {
        private int groceryId;
        private string dateString;

        public InsertGramsFoodstuffUserControl(int groceryId, string dateString)
        {
            InitializeComponent();
            this.groceryId = groceryId; 
            this.dateString = dateString;
        }

        private void btnAddGroceryToDay_Click(object sender, RoutedEventArgs e)
        {
            BMRCalculator calculator = new BMRCalculator();
            int grams;

            if (DayRepository.IsPositiveNumber(txtFoodstuffGrams.Text))
            {
                if (int.TryParse(txtFoodstuffGrams.Text, out grams))
                {
                    Days_GroceriesRepository.AddGroceryToDate(dateString, grams, groceryId);
                    calculator.AddCaloriesToDate(dateString, groceryId, grams);
                    MessageBox.Show("Successfully inserted food to day");
                }
                else
                {
                    MessageBox.Show("Failed to insert food to day");
                }
            }
            else
            {
                MessageBox.Show("Please enter a positive number of grams!");
            }
        }
    }
}

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
    /// Interaction logic for InsertFoodGramsUserControl.xaml
    /// </summary>
    public partial class InsertFoodGramsUserControl : UserControl
    {
        private string foodName;

        public InsertFoodGramsUserControl(string foodName)
        {
            InitializeComponent();
            this.foodName = foodName;
        }

        private void btnAddFoodToDatabase_Click(object sender, RoutedEventArgs e)
        {
            int calories;
            if (DayRepository.IsPositiveNumber(txtFoodGrams.Text))
            {
                if (int.TryParse(txtFoodGrams.Text, out calories))
                {
                    GroceryRepository.AddGrocery(foodName, calories);
                    MessageBox.Show("Succesfuly inserted food!");
                }
                else
                {
                    MessageBox.Show("Failed to insert food!");
                }
            }
            else
            {
                MessageBox.Show("Please enter a positive number of grams!");
            }
            
        }
    }
}

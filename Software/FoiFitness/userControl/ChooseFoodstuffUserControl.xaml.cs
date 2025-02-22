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
    /// Interaction logic for ChooseFoodstuffUserControl.xaml
    /// </summary>
    public partial class ChooseFoodstuffUserControl : UserControl
    {
        private ContentControl cntShowCalories;
        private string dateString;

        public ChooseFoodstuffUserControl(ContentControl cntShowCalories, string dateString)
        {
            InitializeComponent();
            this.cntShowCalories = cntShowCalories; 
            this.dateString = dateString;
        }

        private void btnInsertGramsAmount_Click(object sender, RoutedEventArgs e)
        {
            var grocery = cbFoodStuff.SelectedItem as Grocery;
            if (grocery != null)
            {
                InsertGramsFoodstuffUserControl insertGramsFoodstuffUserControl = new InsertGramsFoodstuffUserControl(grocery.id, dateString);
                cntShowCalories.Content = insertGramsFoodstuffUserControl;
            }
            else
            {
                MessageBox.Show("You need to choose a food item first!");
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            List<Grocery> groceries = GroceryRepository.GetAll().ToList();
            cbFoodStuff.ItemsSource = groceries;
        }
    }
}

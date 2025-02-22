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
    /// Interaction logic for InsertFoodUserControl.xaml
    /// </summary>
    public partial class InsertFoodUserControl : UserControl
    {
        private ContentControl cntShowCalories;

        public InsertFoodUserControl(ContentControl cntShowCalories)
        {
            InitializeComponent();
            this.cntShowCalories = cntShowCalories;
        }

        private void btnNextInsertFoodOption_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFoodName.Text))
            {
                MessageBox.Show("Insert a food name first!");
            }
            else
            {
                if (GroceryRepository.CheckGroceryDuplicates(txtFoodName.Text))
                {
                    InsertFoodGramsUserControl insertFoodGramsUserControl = new InsertFoodGramsUserControl(txtFoodName.Text);
                    cntShowCalories.Content = insertFoodGramsUserControl;
                }
                else
                {
                    MessageBox.Show("This grocery already exist!");
                }

            }
            
        }
    }
}

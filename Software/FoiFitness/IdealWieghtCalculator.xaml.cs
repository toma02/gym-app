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
    /// Interaction logic for IdealWieghtCalculator.xaml
    /// </summary>
    public partial class IdealWieghtCalculator : Window
    {
        public string Gender { get; set; }
        public IdealWieghtCalculator()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            var idealWeightCalculator = new BusinessLogicLayer.IdealWeightCalculator();
            if (checkGender())
            {

                if (idealWeightCalculator.HeightIsNumber(txtHeight.Text))
                {
                    lbIdealWeight.Content = idealWeightCalculator.CalculateIdealWieght(Gender, int.Parse(txtHeight.Text));
                }
                else
                {
                    MessageBox.Show("Height must be a positive number!");
                }
            }
            else
            {
                MessageBox.Show("You need to choose a gender!");

            }

        }

        private bool checkGender()
        {
            if (radioFemale.IsChecked == true) 
            {
                Gender = "female";
                return true;
            } 
            else if (radioMale.IsChecked == true)
            {
                Gender = "male";
                return true;
            }
            return false;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

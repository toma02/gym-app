using BusinessLogicLayer;
using FoiFitness.utils;
using System.Diagnostics;
using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace FoiFitness
{
    /// <summary>
    /// Interaction logic for BMICalculatorWindow.xaml
    /// </summary>
    public partial class BMICalculatorWindow : Window
    {
        public BMICalculatorWindow()
        {
            InitializeComponent();
        }

        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            var BMICalc = new BMICalculator();

            float height = float.Parse(txtHeight.Text);
            float weight = float.Parse(txtWeight.Text);

            float bmi = BMICalc.CalculateBMI(height, weight);

            txtBMI.Text = bmi.ToString();

            lblInfo.Content = BMICalc.GetInfo(bmi);
        }
    }
}

using BusinessLogicLayer;
using DataAccessLayer;
using System;
using System.Collections;
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

namespace FoiFitness
{
    /// <summary>
    /// Interaction logic for CreatePlan.xaml
    /// </summary>
    public partial class CreatePlan : UserControl
    {
        public MainWindow parentWindow;
        public CreatePlan(MainWindow mainWindow)
        {
            InitializeComponent();
            parentWindow = mainWindow;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            cmbType.ItemsSource = LoadPlanType();
            cmbVolume.ItemsSource = LoadPlanVolume();
        }

        private IEnumerable LoadPlanVolume()
        {
            var planVolume = new PlanVolumesRepository();
            return planVolume.GetAll();
        }

        private IEnumerable LoadPlanType()
        {
            var planType = new PlanTypesRepository();
            return planType.GetAll();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string name = txtPlanName.Text;
            string description = txtDesc.Text;
            int duration;
            bool success = int.TryParse(txtDur.Text, out duration);

            var planType = cmbType.SelectedItem as PlanType;
            var planVolume = cmbVolume.SelectedItem as PlanVolume;

            if (success == false)
            {
                MessageBox.Show("Please enter a number for plan duration!");
            }
            else if (name == "")
            {
                MessageBox.Show("Please enter plan name!");
            }
            else if (cmbType.SelectedItem == null)
            {
                MessageBox.Show("Please select plan type!");
            }
            else if (cmbVolume.SelectedItem == null)
            {
                MessageBox.Show("Please select plan volume!");
            }
            else
            {
                TrainingPlanRepository.CreatePlan(name, description, duration, planType, planVolume);
                this.Visibility = Visibility.Hidden;
            }

        }

    private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }
    }
}

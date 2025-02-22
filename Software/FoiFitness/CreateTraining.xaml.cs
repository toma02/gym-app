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
    /// Interaction logic for CreateTraining.xaml
    /// </summary>
    public partial class CreateTraining : UserControl
    {
        public MainWindow parentWindow;
        public CreateTraining(MainWindow mainWindow)
        {
            InitializeComponent();
            parentWindow = mainWindow;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var trainingPlan = cmbPlan.SelectedItem as TrainingPlan;
            var day = cmbDate.SelectedItem as Day;

            TrainingRepository.CreateTraining(trainingPlan, day);
            this.Visibility = Visibility.Hidden;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            cmbPlan.ItemsSource = GetPlans();
            cmbDate.ItemsSource = GetDates();
        }

        private IEnumerable GetDates()
        {
            return DayRepository.GetAll().ToList();
        }

        private IEnumerable GetPlans()
        {
            return TrainingPlanRepository.GetAllPlans().ToList();
        }
    }
}

using BusinessLogicLayer;
using DataAccessLayer;
using FoiFitness.userControl;
using FoiFitness.utils;
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
using static System.Net.Mime.MediaTypeNames;

namespace FoiFitness
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BodyPartRepository bodyPartRepository;
        private EquipmentRepository equipmentRepository;
        public MainWindow()
        {
            InitializeComponent();
            equipmentRepository = new EquipmentRepository();
            bodyPartRepository = new BodyPartRepository();
            FillUserInputControls();
        }

        private void FillUserInputControls()
        {
            cbBodyParts.ItemsSource = bodyPartRepository.GetBodyParts();
            cbEquipment.ItemsSource = equipmentRepository.GetEquipment2();
        }

        private void SearchExcercises_Click(object sender, RoutedEventArgs e)
        {
            if (CheckIfSelectedAny())
            {
                BodyPart? selectedBodyPart = cbBodyParts.SelectedItem as BodyPart;
                Equipment? selectedEquipment = cbEquipment.SelectedItem as Equipment;
                ShowExcercisesUserControl showExcercisesUserControl = new ShowExcercisesUserControl(selectedBodyPart, selectedEquipment);
                contentExercise.Content = showExcercisesUserControl;
            }
        }

        private bool CheckIfSelectedAny()
        {
            if(cbBodyParts.SelectedItem != null && cbEquipment.SelectedItem != null)
            {
                lblValidationExcerciseFilters.Content = null;
                return true;
            }
            else if(cbBodyParts.SelectedItem == null && cbEquipment.SelectedItem != null)
            {
                lblValidationExcerciseFilters.Content = "You have to select body part!";
                return false;
            }else if(cbBodyParts.SelectedItem != null && cbEquipment.SelectedItem == null)
            {
                lblValidationExcerciseFilters.Content = "You have to select equipment!";
                return false;
            }
            lblValidationExcerciseFilters.Content = "You have to select filters!";
            return false;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var window = new MainWindow();
            contentExercise.Content = new AddExerciseUserControl(window);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnProfil_Click(object sender, RoutedEventArgs e)
        {
            var profileWindow = new ProfileWindow();
            profileWindow.Show();
        }



        private void cntControl_Loaded(object sender, RoutedEventArgs e)
        {
            var trainingGenerationUserControl = new TrainingGenerationUserControl(this);
            cntControl.Content = trainingGenerationUserControl;
            cntControl.Height = trainingGenerationUserControl.Height;
        }

        private void btnAddPlan_Click(object sender, RoutedEventArgs e)
        {
            var planWindow = new CustomPlanProfile();
            planWindow.Show();
        }

        private void btnShowProgress_Click(object sender, RoutedEventArgs e)
        {
            var showProgressWindow = new ShowProgressWindow();
            showProgressWindow.Show();
        }

        private void btnClearFilters_Click(object sender, RoutedEventArgs e)
        {
            cbBodyParts.SelectedItem = null;
            cbBodyParts.Text = "All bodyparts";
            cbEquipment.SelectedItem = null;
            cbEquipment.Text = "All equipment";
            lblValidationExcerciseFilters.Content = null;
        }
        private void Calendar_Loaded(object sender, RoutedEventArgs e)
        {
            List<Day> dates = DayRepository.GetAllUserDates();
            string format = "dd/MM/yyyy";
            Calendar calendar = sender as Calendar;
            foreach (Day day in dates)
            {
                DateTime date = DateTime.ParseExact(day.date, format, System.Globalization.CultureInfo.InvariantCulture);
                calendar.BlackoutDates.Add(new CalendarDateRange(date, date));
            }
        }

        private void btnChooseDate_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(dpChoosingDate.Text))
            {
                MessageBox.Show("You need to choose a date first!");
            }
            else
            {
                var selectedDate = DateTime.Parse(dpChoosingDate.Text);
                var dateString = DateHelper.FormatDate(selectedDate);
                dateString = dateString.Replace(".", "/");
                List<Day> dates = DayRepository.GetDay(dateString);
                if (dates.Count > 0)
                {
                    DateWithDataUserControl dateWithDataUserControl = new DateWithDataUserControl(dateString);
                    cntDateInfo.Content = dateWithDataUserControl;
                }
                else
                {
                    DateWithoutDataUserControl dateWithoutDataUserControl = new DateWithoutDataUserControl(dateString);
                    cntDateInfo.Content = dateWithoutDataUserControl;
                }
            }
        }

        private void btnTimer_Click(object sender, RoutedEventArgs e)
        {
            var timerWindow = new TimerWindow();
            timerWindow.Show();
        }

        private void btnWaterIntake_Click(object sender, RoutedEventArgs e)
        {
            var waterIntakeWindow = new WaterIntakeWindow();
            waterIntakeWindow.Show();
        }
    }
}

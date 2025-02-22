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
    /// Interaction logic for AddTrainingPlanUserControl.xaml
    /// </summary>
    public partial class AddTrainingPlanUserControl : UserControl
    {
        public MainWindow parentWindow;
        public AddTrainingPlanUserControl(MainWindow mainWindow)
        {
            InitializeComponent();
            parentWindow = mainWindow;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            cmbExerciseName.ItemsSource = GetExercises();
            cmbTraining.ItemsSource = GetTrainings();
        }

        private IEnumerable GetTrainings()
        {
            return TrainingRepository.GetAllTrainings().ToList();
        }

        private IEnumerable GetExercises()
        {
            return ExerciseRepository.GetAllExcercises().ToList();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            bool successSets;
            bool successReps;
            bool succesDur;

            int sets;
            successSets = int.TryParse(txtSets.Text, out sets);

            int reps;
            successReps = int.TryParse(txtReps.Text, out reps);

            int duration;
            succesDur = int.TryParse(txtDur.Text, out duration);

            var exercise = cmbExerciseName.SelectedItem as Exercis;
            var training = cmbTraining.SelectedItem as Training;

            if (successSets == false)
            {
                MessageBox.Show("Please enter a number for sets!");
            }
            else if (successReps == false)
            {
                MessageBox.Show("Please enter a number for repetitions!");
            }
            else if (succesDur == false)
            {
                MessageBox.Show("Please enter a number for duration!");
            }
            else if (cmbExerciseName.SelectedItem == null)
            {
                MessageBox.Show("Please select an exercise!");
            }
            else if (cmbTraining.SelectedItem == null)
            {
                MessageBox.Show("Please select a training!");
            }
            else
            {
                Training_ExercisesRepository.CreateTrainingExercise(duration, sets, reps, exercise, training);
                this.Visibility = Visibility.Hidden;
            }     
        }

    private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }
    }
}

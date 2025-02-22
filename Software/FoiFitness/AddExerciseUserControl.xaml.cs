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
    /// Interaction logic for AddExerciseUserControl.xaml
    /// </summary>
    public partial class AddExerciseUserControl : UserControl
    {
        public MainWindow parentWindow;
        public AddExerciseUserControl(MainWindow parentWindow1)
        {
            InitializeComponent();
            parentWindow = parentWindow1;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;
            string description = txtDesc.Text;
            string video_link = txtLink.Text;
            int difficulty;
            bool success = int.TryParse(txtDiff.Text, out difficulty);

            var equipment = cmbEquip.SelectedItem as Equipment;
            var bodypart = cmbBody.SelectedItem as BodyPart;

            if (success == false)
            {
                MessageBox.Show("Please enter a number for difficulty!");
            }
            else if (name == "")
            {
                MessageBox.Show("Please enter exercise name!");
            }
            else
            {
                var exerciseAdded = ExerciseRepository.CreateExercise(name, description, video_link, difficulty, equipment, bodypart);
                this.Visibility = Visibility.Hidden;
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            cmbEquip.ItemsSource = GetEquipment();
            cmbBody.ItemsSource =  GetBodypart();
        }

        private IEnumerable GetEquipment()
        {
            return EquipmentRepository.GetEquipment().ToList();
        }

        private IEnumerable GetBodypart()
        {
            return BodyPartRepository.GetBodyPart().ToList();
        }
    }
}

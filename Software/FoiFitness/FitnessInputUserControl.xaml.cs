using BusinessLogicLayer;
using DataAccessLayer;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace FoiFitness
{
    /// <summary>
    /// Interaction logic for FitnessInputUserControl.xaml
    /// </summary>
    public partial class FitnessInputUserControl : UserControl
    {
        public AuthWindow parentWindow;
        public string currentUsername;
        public FitnessInputUserControl(AuthWindow parentWindow1, string currentUsername1)
        {
            InitializeComponent();
            parentWindow = parentWindow1;
            currentUsername = currentUsername1;
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            ClearErrorMessages();

            Gender selectedGender = GetSelectedGender();
            string age = txtAge.Text;
            string weight = txtWeight.Text;
            string height = txtHeight.Text;
            ActivityLevel activityLevel = GetSelectedActivityLevel();

            bool genderSelected = CheckIfGenderSelected();
            bool ageValid = CheckIfAgeValid();
            bool heightValid = CheckIfHeightValid();
            bool weightValid = CheckIfWeightValid();
            bool activitySelected = CheckIfActivitySelected();

            if (!genderSelected || !ageValid || !heightValid || !weightValid || !activitySelected) 
            {
                return;
            }


            //string selectedActivity = cboActivity.SelectedItem.ToString();

            UserRepository.UpdateUserData(currentUsername, selectedGender, age, weight, height, activityLevel);

            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.parentWindow.Close();
        }

        private bool CheckIfActivitySelected()
        {
            if (cboActivity.SelectedIndex < 0)
            {
                errorActivity.Content = "Potrebno je odabrati razinu aktivnosti!";
                errorActivity.Visibility = Visibility.Visible;
                return false;
            }
            return true;
        }

        private bool CheckIfWeightValid()
        {
            string weight = txtWeight.Text;
            if (!InputValidator.IsValidWeight(weight))
            {
                errorWeight.Content = "Tezina mora biti broj!";
                errorWeight.Visibility = Visibility.Visible;
                return false;
            }
            return true;
        }

        private bool CheckIfHeightValid()
        {
            string height = txtHeight.Text;
            if (!InputValidator.IsValidHeight(height))
            {
                errorHeight.Content = "Visina mora biti broj";
                errorHeight.Visibility = Visibility.Visible;
                return false;
            }
            return true;
        }

        private bool CheckIfAgeValid()
        {
            string age = txtAge.Text;
            if (!InputValidator.isValidAge(age))
            {
                errorAge.Content = "Dob mora biti broj";
                errorAge.Visibility = Visibility.Visible;
                return false;
            }
            return true;
        }

        private bool CheckIfGenderSelected()
        {
            var selectedGender = GetSelectedGender();
            if (selectedGender == null)
            {
                errorGender.Content = "Potrebno je odabrati spol!";
                errorGender.Visibility = Visibility.Visible;
                return false;
            }

            return true;
        }

        private Gender GetSelectedGender()
        {
            return cboGender.SelectedItem as Gender;
            
        }

        private ActivityLevel GetSelectedActivityLevel()
        {
            return cboActivity.SelectedItem as ActivityLevel;
        }
     

        private void ClearErrorMessages()
        {
            ClearGenderError();
            ClearAgeError();
            ClearWeightError();
            ClearHeightError();
            ClearActivityError();
        }

        private void ClearActivityError()
        {
            errorActivity.Content = "";
            errorActivity.Visibility = Visibility.Hidden;
        }

        private void ClearHeightError()
        {
            errorHeight.Content = "";
            errorHeight.Visibility = Visibility.Hidden;
        }

        private void ClearWeightError()
        {
            errorWeight.Content = "";
            errorWeight.Visibility = Visibility.Hidden;
        }

        private void ClearAgeError()
        {
            errorAge.Content = "";
            errorAge.Visibility = Visibility.Hidden;
        }

        private void ClearGenderError()
        {
            errorGender.Content = "";
            errorGender.Visibility = Visibility.Hidden;
        }

        private void txtAge_LostFocus(object sender, RoutedEventArgs e)
        {
            ClearAgeError();
            CheckIfAgeValid();
        }

        private void txtWeight_LostFocus(object sender, RoutedEventArgs e)
        {
            ClearWeightError();
            CheckIfWeightValid();
        }

        private void txtHeight_LostFocus(object sender, RoutedEventArgs e)
        {
            ClearHeightError();
            CheckIfHeightValid();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var gendersRepo = new GendersRepository();
            var genders = gendersRepo.GetGenders();
            cboGender.ItemsSource = genders;
            cboGender.DisplayMemberPath = "name";

            var activityLevelsRepo = new ActivityLevelsRepository();
            var activityLevels = activityLevelsRepo.GetActivityLevels();
            activityLevelsRepo.GetActivityLevels();
            cboActivity.ItemsSource = activityLevels;
            cboActivity.DisplayMemberPath = "activity_level";
        }
    }
}

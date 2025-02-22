using BusinessLogicLayer;
using BusinessLogicLayer.utils;
using FoiFitness.utils;
using System.Diagnostics;
using System.Globalization;
using System.Windows;
using System.Windows.Media;


namespace FoiFitness
{
    /// <summary>
    /// Interaction logic for ProfileWindow.xaml
    /// </summary>
    public partial class ProfileWindow : Window
    {
        public ProfileWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadUserInfo();
        }

        private void LoadUserInfo()
        {
            var username = UserRepository.GetCurrentUser();
            var user = UserRepository.GetUser(username);

            txtName.Text = user.first_name;
            txtLastName.Text = user.last_name;
            txtWeight.Text = user.weight.ToString();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            ClearErrorMessages();

            string firstName = txtName.Text;
            string lastName = txtLastName.Text;
            string password = Hash.HashPassword(txtPassword.Password.ToString());
            double weight;
            bool success = double.TryParse(txtWeight.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out weight);


            bool allValid = true;

            if (success == false)
            {
                errorWeight.Content = "Molimo unesite kilažu s decimalnom točkom!";
                errorWeight.Visibility = Visibility.Visible;
                txtWeight.BorderBrush = Brushes.Red;
                txtWeight.BorderThickness = new Thickness(2);
                allValid = false;
            }

            if (!InputValidator.ValidateName(firstName))
            {
                errorName.Content = "Ime mora biti između 2 i 50 znakova i ne može imati specijalne znakove!";
                errorName.Visibility = Visibility.Visible;
                txtName.BorderBrush = Brushes.Red;
                txtName.BorderThickness = new Thickness(2);
                allValid = false;
            }

            if (!InputValidator.ValidateName(lastName))
            {
                errorLastName.Content = "Prezime mora biti između 2 i 50 znakova i ne može imati specijalne znakove!";
                errorLastName.Visibility = Visibility.Visible;
                txtLastName.BorderBrush = Brushes.Red;
                txtLastName.BorderThickness = new Thickness(2);
                allValid = false;
            }

            if (!InputValidator.ValidatePassword(password))
            {
                errorPassword.Content = "Lozinka mora imati barem 6 znakova";
                errorPassword.Visibility = Visibility.Visible;
                txtPassword.BorderBrush = Brushes.Red;
                txtPassword.BorderThickness = new Thickness(2);
                allValid = false;
            }

            if (txtPassword.Password.ToString() != txtPassword2.Password.ToString())
            {
                errorPassword.Content = "Lozinka mora biti ista";
                errorPassword.Visibility = Visibility.Visible;
                txtPassword.BorderBrush = Brushes.Red;
                txtPassword.BorderThickness = new Thickness(2);
                allValid = false;
            }

            if (!allValid)
                return;
            else
            {
                UserRepository.UpdateUserInfo(firstName, lastName, password, weight);
            }
            Close();
        }

        private void ClearErrorMessages()
        {
            txtPassword.BorderBrush = Brushes.Black;
        }

        private void btnIdealWeightCalculator_Click(object sender, RoutedEventArgs e)
        {
            var idealWeightCalculator = new IdealWieghtCalculator();
            idealWeightCalculator.Show();
        }

        private void btnBMI_Click(object sender, RoutedEventArgs e)
        {
            var window = new BMICalculatorWindow();
            window.Show();
        }
    }

}


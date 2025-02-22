using BusinessLogicLayer;
using BusinessLogicLayer.utils;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FoiFitness
{
    /// <summary>
    /// Interaction logic for RegisterUserControl.xaml
    /// </summary>
    public partial class RegisterUserControl : UserControl
    {
        public AuthWindow parentWindow;
        public RegisterUserControl(AuthWindow parentWindow1)
        {
            InitializeComponent();
            parentWindow = parentWindow1;
        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            ClearErrorMessages();

            bool firstnameValid = CheckFirstNameInput();
            bool lastnameValid = CheckLastNameInput();
            bool usernameValid = CheckUsernameInput();
            bool emailValid = CheckEmailInput();
            bool passwordValid = CheckPasswordInput();

            if (!firstnameValid || !lastnameValid || !usernameValid || !emailValid || !passwordValid)
            {
                return;
            }


            // Provided info from user
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string username = txtUsername.Text;
            string email = txtEmail.Text;
            string password = Hash.HashPassword(txtPassword.Password.ToString());

            // Check if username is already taken
            if (UserRepository.CheckIfUsernameTaken(username))
            {
                txtUsername.BorderBrush = Brushes.Red;
                txtUsername.BorderThickness = new Thickness(2);
                errorUsername.Content = "Username already in use!";
                errorUsername.Visibility = Visibility.Visible;
                return;
            }

            if (UserRepository.CheckIfEmailTaken(email))
            {
                txtEmail.BorderBrush = Brushes.Red;
                txtEmail.BorderThickness = new Thickness(2);
                errorEmail.Content = "Email already in use!";
                errorEmail.Visibility = Visibility.Visible;
                return;
            }


            var userCreated = UserRepository.CreateUser(firstName, lastName, username, email, password);

            // Storing current user in app settings
            UserRepository.SaveCurrentUser(username);

            // Go to Input user Data
            var fitnessInputUserControl = new FitnessInputUserControl(parentWindow, username);
            parentWindow.cntControl.Content = fitnessInputUserControl;
        }

        private bool CheckPasswordInput()
        {
            string password = txtPassword.Password.ToString();
            if (!InputValidator.ValidatePassword(password))
            {
                errorPassword.Content = "Password must have alteast 6 chars!";
                errorPassword.Visibility = Visibility.Visible;
                txtPassword.BorderBrush = Brushes.Red;
                txtPassword.BorderThickness = new Thickness(2);
                return false;
            }

            return true;
        }

        private bool CheckEmailInput()
        {
            string email = txtEmail.Text;
            if (!InputValidator.ValidateEmail(email))
            {
                errorEmail.Content = "Email not valid!";
                errorEmail.Visibility = Visibility.Visible;
                txtEmail.BorderBrush = Brushes.Red;
                txtEmail.BorderThickness = new Thickness(2);
                return false;
            }

            return true;
        }

        private bool CheckUsernameInput()
        {
            string username = txtUsername.Text;
            if (!InputValidator.ValidateUsername(username))
            {
                errorUsername.Content = "Must be between 3 and 20 chars, no special chars!";
                errorUsername.Visibility = Visibility.Visible;
                txtUsername.BorderBrush = Brushes.Red;
                txtUsername.BorderThickness = new Thickness(2);
                return false;
            }

            return true;
        }

        private bool CheckLastNameInput()
        {
            string lastName = txtLastName.Text;
            if (!InputValidator.ValidateName(lastName))
            {
                errorLastName.Content = "Must be between 3 and 50 chars, no special chars!";
                errorLastName.Visibility = Visibility.Visible;
                txtLastName.BorderBrush = Brushes.Red;
                txtLastName.BorderThickness = new Thickness(2);
                return false;
            }

            return true;
        }

        private bool CheckFirstNameInput()
        {
            string firstName = txtFirstName.Text;
            if (!InputValidator.ValidateName(firstName))
            {
                errorFirstName.Content = "Must be between 2 and 20 chars, no special chars!";
                errorFirstName.Visibility = Visibility.Visible;
                txtFirstName.BorderBrush = Brushes.Red;
                txtFirstName.BorderThickness = new Thickness(2);
                return false;
            }

            return true;
        }

        private void ClearErrorMessages()
        {
            ClearFirstnameError();
            ClearLastnameError();
            ClearUsernameError();
            ClearEmailError();
            ClearPasswordError();
           
            errorDatabase.Visibility = Visibility.Hidden;
            errorDatabase.Content = "";
        }

        private void ClearFirstnameError()
        {
            txtFirstName.BorderBrush = Brushes.Black;
            errorFirstName.Content = "";
            errorFirstName.Visibility = Visibility.Hidden;
        }

        private void ClearLastnameError()
        {
            txtLastName.BorderBrush = Brushes.Black;
            errorLastName.Content = "";
            errorLastName.Visibility = Visibility.Hidden;
        }

        private void ClearUsernameError()
        {
            txtUsername.BorderBrush = Brushes.Black;
            errorUsername.Content = "";
            errorUsername.Visibility = Visibility.Hidden;
        }

        private void ClearEmailError()
        {
            txtEmail.BorderBrush = Brushes.Black;
            errorEmail.Content = "";
            errorEmail.Visibility = Visibility.Hidden;
        }

        private void ClearPasswordError()
        {
            txtPassword.BorderBrush = Brushes.Black;
            errorPassword.Content = "";
            errorPassword.Visibility = Visibility.Hidden;
        }

        private void txtFirstName_LostFocus(object sender, RoutedEventArgs e)
        {
            ClearFirstnameError();
            CheckFirstNameInput();
        }

        private void txtLastName_LostFocus(object sender, RoutedEventArgs e)
        {
            ClearLastnameError();
            CheckLastNameInput();
        }

        private void txtUsername_LostFocus(object sender, RoutedEventArgs e)
        {
            ClearUsernameError();
            CheckUsernameInput();
        }

        private void txtEmail_LostFocus(object sender, RoutedEventArgs e)
        {
            ClearEmailError();
            CheckEmailInput();
        }

        private void txtPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            ClearPasswordError();
            CheckPasswordInput();
        }

        private void btnGoToLogin_Click(object sender, RoutedEventArgs e)
        {
            var loginUserControl = new LoginUserControl(parentWindow);
            parentWindow.contentControl.Content = loginUserControl;
        }

        private void userControlRegister_Loaded(object sender, RoutedEventArgs e)
        {
            txtFirstName.Focus();
        }
    }
}

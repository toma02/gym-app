using BusinessLogicLayer;
using BusinessLogicLayer.utils;
using FoiFitness.utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
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
    /// Interaction logic for LoginUserControl.xaml
    /// </summary>
    public partial class LoginUserControl : UserControl
    {
        public AuthWindow parentWindow;
        public LoginUserControl(AuthWindow parentWindow1)
        {
            InitializeComponent();
            parentWindow = parentWindow1;
        }


        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            HideErrorFields();

            bool usernameValid = CheckUsernameInput();
            bool passwordValid = CheckPasswordInput();
            LoginManager.IncreaseLoginAttemptCounter();

            string username = txtUsername.Text;
            string password = Hash.HashPassword(txtPassword.Password.ToString());

            if (LoginManager.MaxLoginAttemptsReached())
            {
                ShowLoginAttemptsErrorMessage();
                return;
            }
            if (!usernameValid || !passwordValid) return;
            txtUsername.Text = "";
            txtPassword.Password = "";

            if (!CheckCredentials(username, password)) return;
            
            UserRepository.SaveCurrentUser(username);
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.parentWindow.Close();
        }


        private bool CheckUsernameInput()
        {
            string username = txtUsername.Text;
            if (!InputValidator.ValidateUsername(username))
            {
                errorUsername.Content = "Username must be between 3 and 20 chars, no special chars!";
                errorUsername.Visibility = Visibility.Visible;
                return false;
            }

            return true;
        }

        private bool CheckPasswordInput()
        {
            string password = txtPassword.Password;
            if (!InputValidator.ValidatePassword(password))
            {
                errorPassword.Content = "Needs to have atleast 6 chars!";
                errorPassword.Visibility = Visibility.Visible;
                return false;
            }

            return true;
        }

        private bool CheckCredentials(string username, string password)
        {
            var credentialsValid = UserRepository.CheckCredentials(username, password);
            if (!credentialsValid)
            {
                errorDatabase.Visibility = Visibility.Visible;
                errorDatabase.Content = "Invalid Credentials!";
                return false;
            }
            return true;
        }

        private void ShowLoginAttemptsErrorMessage()
        {
            errorDatabase.Visibility = Visibility.Visible;
            errorDatabase.Content = "Max login attempts reached! Try again later.";
        }

        private void HideErrorFields()
        {
            errorPassword.Visibility = Visibility.Hidden;
            errorUsername.Visibility = Visibility.Hidden;
            errorDatabase.Visibility = Visibility.Hidden;
        }

        private void btnGoToRegister_Click(object sender, RoutedEventArgs e)
        {
            this.parentWindow.Height = 800;
            var registerUserControl = new RegisterUserControl(parentWindow);
            parentWindow.contentControl.Content = registerUserControl;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            txtUsername.Focus();
        }
    }
}

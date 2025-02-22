using BusinessLogicLayer;
using DataAccessLayer;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
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
using System.Windows.Shapes;

namespace FoiFitness
{
    /// <summary>
    /// Interaction logic for CustomPlanProfile.xaml
    /// </summary>
    public partial class CustomPlanProfile : Window
    {
        public CustomPlanProfile()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            var window = new MainWindow();
            cntCreate.Content = new CreatePlan(window);
            RefreshGUI();
        }

        private void RefreshGUI()
        {
            cmbChoosePlan.ItemsSource = GetPlans();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshGUI();
        }

        private IEnumerable GetPlans()
        {
            return TrainingPlanRepository.GetAllPlans().ToList();
        }

        private void btnCreateTraining_Click(object sender, RoutedEventArgs e)
        {
            var window = new MainWindow();
            cntCreate.Content = new CreateTraining(window);
            RefreshGUI();
        }

        private void btnCreateExercise_Click(object sender, RoutedEventArgs e)
        {
            var window = new MainWindow();
            cntCreate.Content = new AddTrainingPlanUserControl(window);
            RefreshGUI();
        }

        private void btnSendMail_Click(object sender, RoutedEventArgs e)
        {
            var username = UserRepository.GetCurrentUser();
            var user = UserRepository.GetUser(username);

            string mail = user.email;

            var selectedPlan = cmbChoosePlan.SelectedItem as TrainingPlan;

            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("mkljaic20@student.foi.hr"));
            email.To.Add(MailboxAddress.Parse(mail));
            email.Subject = "Training plan";

            var smtp = new MailKit.Net.Smtp.SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("mkljaic20@student.foi.hr", "qkzejmicoicqozvg");

            var bodyBuilder = new BodyBuilder();
            
            if (selectedPlan == null)
            {
                MessageBox.Show("Please select a training plan before sending it to mail!");
            }
            else
            {
                bodyBuilder.TextBody = "Here is your " + selectedPlan.name + " training plan!";
                bodyBuilder.Attachments.Add(selectedPlan.name + ".pdf", PDFGenerator.GeneratePDF(selectedPlan));
                email.Body = bodyBuilder.ToMessageBody();

                smtp.Send(email);
                smtp.Disconnect(true);
                RefreshGUI();
            }
        }
    }
}

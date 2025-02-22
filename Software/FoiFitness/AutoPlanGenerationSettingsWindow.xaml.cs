using BusinessLogicLayer;
using DataAccessLayer;
using EntityLayer.Extra_entities;
using FoiFitness.enums;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FoiFitness
{
    /// <summary>
    /// Interaction logic for AutoPlanGenerationSettingsWindow.xaml
    /// </summary>
    public partial class AutoPlanGenerationSettingsWindow : Window
    {
        public AutoPlanGenerationSettingsWindow()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        { 
            bool selectionsValid = ValidateSelections();
            if (!selectionsValid) return;

            String providedPlanName = GetProvidedPlanName();
            PlanType selectedPlanType = GetSelectedPlanType();
            PlanVolume selectedPlanVolume = GetSelectedPlanVolume();
            PlanLength selectedPlanLength = GetSelectedPlanLength();
            TrainingDay selectedTrainingDaysPerWeek = GetSelectedTrainingDaysPerWeek();
            List<DayOfWeek> daysOfWeek = GetSelectedDaysOfWeek();

            int duration = selectedPlanLength.LengthInWeeks * selectedTrainingDaysPerWeek.Amount;

            TrainingPlan generatedPlan = TrainingPlanRepository.CreatePlan(providedPlanName, "My auto generated plan", duration, selectedPlanType, selectedPlanVolume);

            List<DateTime> trainingDates = new List<DateTime>();

            DateTime currentDate = DateTime.Now;
            int daysUntilMonday = ((int)DayOfWeek.Monday - (int)currentDate.DayOfWeek + 7) % 7;
            currentDate = currentDate.AddDays(daysUntilMonday);

            for (int i = 0; i < selectedPlanLength.LengthInWeeks; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    DateTime trainingDate = currentDate.AddDays(j + (i * 7));
                    if (daysOfWeek.Contains(trainingDate.DayOfWeek))
                    {
                        trainingDates.Add(trainingDate);
                    }
                }
            }

            var currentUserName = UserRepository.GetCurrentUser();
            var currentUser = UserRepository.GetUser(currentUserName);
          
            var listOfDays = DayRepository.BulkAddDaysForUser(currentUser.id, trainingDates);
            var listOfTrainings = TrainingRepository.BulkAddTrainingsForPlan(generatedPlan.id, listOfDays);

            List<List<Training_Exercises>> listOfTrainingExercisesInWeek = new List<List<Training_Exercises>>();
            for (int i = 0; i < selectedTrainingDaysPerWeek.Amount; i++)
            {
                listOfTrainingExercisesInWeek.Add(Training_ExercisesRepository.GenerateExercises(selectedPlanVolume.amplifier, selectedPlanType.name));
            }

            List<Training_Exercises> listOfTrainingExercises = Training_ExercisesRepository.GenerateTrainingExercises(listOfTrainings, selectedTrainingDaysPerWeek, listOfTrainingExercisesInWeek);
            
            Training_ExercisesRepository.BulkCreateTrainingExercises(listOfTrainingExercises);

            var plan = TrainingPlanRepository.GetPlanById(generatedPlan.id).First();
            string wordFilePath = WordGenerator.GeneratePlanSummary(plan);

            if (receiveEmailCheckBox.IsChecked == true)
            {
                sendFileToEmail(wordFilePath, plan, currentUser.email);
            }

            Close();
        }

        private void sendFileToEmail(string wordFilePath, TrainingPlan plan, string userEmail)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("mkljaic20@student.foi.hr"));
            email.To.Add(MailboxAddress.Parse(userEmail));
            email.Subject = "Your Training Plan";
            var body = new TextPart("plain") { Text = "Your recently generated Training Plan" };

            var wordDocument = new MimePart("application/msword")
            {
                Content = new MimeContent(File.OpenRead(wordFilePath), ContentEncoding.Default),
                ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                ContentTransferEncoding = ContentEncoding.Base64,
                FileName = "trainingPlan.docx",
            };

            var multipart = new Multipart("mixed")
            {
                body,
                wordDocument,
            };

            email.Body = multipart;


            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                client.Authenticate("mkljaic20@student.foi.hr", "qkzejmicoicqozvg");
                client.Send(email);
                client.Disconnect(true);
            }
            Debug.WriteLine("Message successfully sent!");
        }

        
        private List<DayOfWeek> GetSelectedDaysOfWeek()
        {
            List<DayOfWeek> selectedDaysOfWeek = new List<DayOfWeek>();
            foreach (var item in listTrainingDays.SelectedItems)
            {
                selectedDaysOfWeek.Add((DayOfWeek)item);
            }
            return selectedDaysOfWeek;
        }

        private string GetProvidedPlanName()
        {
            return txtPlanName.Text;
        }

        private bool ValidatePlanName()
        {
            var planNameProvided = txtPlanName.Text.Length > 3;
            if (!planNameProvided)
            {
                errorName.Content = "Please give your plan a valid name (3+ chars)";
                errorName.Visibility = Visibility.Visible;
            }
            else
            {
                errorName.Visibility = Visibility.Hidden;
            }
            return planNameProvided;
        }

        private bool ValidatePlanType()
        {
            var planTypeSelected = cboPlanType.SelectedIndex != 0;
            if (!planTypeSelected)
            {
                errorGoal.Content = "Potrebno odabrati opciju!";
                errorGoal.Visibility = Visibility.Visible;
            }
            else
            {
                errorGoal.Visibility = Visibility.Hidden;
            }

            return planTypeSelected;
        }

        private bool ValidatePlanVolume()
        {
            var planVolumeSelected = cboPlanVolume.SelectedIndex != 0;
            if (!planVolumeSelected)
            {
                errorVolume.Content = "Potrebno odabrati opciju!";
                errorVolume.Visibility = Visibility.Visible;
            }
            else
            {
                errorVolume.Visibility = Visibility.Hidden;
            }
            return planVolumeSelected;
        }

        private bool ValidatePlanLength()
        {
            var planLengthSelected = cboPlanLength.SelectedIndex != 0;
            if (!planLengthSelected)
            {
                errorLength.Content = "Potrebno odabrati opciju!";
                errorLength.Visibility = Visibility.Visible;
            }
            else
            {
                errorLength.Visibility = Visibility.Hidden;
            }
            return planLengthSelected;
        }

        private bool ValidateNumberOfDays()
        {
            var planTrainingDaysPerWeekSelected = cboTrainingsPerWeek.SelectedIndex != 0;
            if (!planTrainingDaysPerWeekSelected)
            {
                errorTrainingsPerWeek.Content = "Potrebno odabrati opciju!";
                errorTrainingsPerWeek.Visibility = Visibility.Visible;
            }
            else
            {
                errorTrainingsPerWeek.Visibility = Visibility.Hidden;
            }
            return planTrainingDaysPerWeekSelected;
        }

        private bool ValidateSelectedDays()
        {
            var planDesiredTrainingDaysSelected = listTrainingDays.SelectedItems.Count == GetSelectedTrainingDaysPerWeek().Amount;
            if (!planDesiredTrainingDaysSelected)
            {
                errorDays.Content = $"Please select exactly {GetSelectedTrainingDaysPerWeek().Amount} Options!";
                errorDays.Visibility = Visibility.Visible;
            }
            else
            {
                errorDays.Visibility = Visibility.Hidden;
            }
            return planDesiredTrainingDaysSelected;
        }

        private bool ValidateSelections()
        {
            bool planNameValid = ValidatePlanName();
            bool planTypeValid = ValidatePlanType();
            bool planVolumeValid = ValidatePlanVolume();
            bool planLengthValid = ValidatePlanLength();
            bool planNumberOfDaysValid = ValidateNumberOfDays();
            bool planSelectedDaysValid = ValidateSelectedDays();

            if (!planNameValid || 
                !planTypeValid || 
                !planVolumeValid || 
                !planLengthValid || 
                !planNumberOfDaysValid || 
                !planSelectedDaysValid) {
                return false;
            }
            return true;
        }

        private PlanLength GetSelectedPlanLength()
        {
            return cboPlanLength.SelectedItem as PlanLength;
        }

        private PlanVolume GetSelectedPlanVolume()
        {
            return cboPlanVolume.SelectedItem as PlanVolume;
        }

        private PlanType GetSelectedPlanType()
        {
            return cboPlanType.SelectedItem as PlanType;
        }

        private TrainingDay GetSelectedTrainingDaysPerWeek()
        {
            return cboTrainingsPerWeek.SelectedItem as TrainingDay;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillCboPlanTypes();
            FillCboPlanVolumes();
            FillCboPlanLength();
            FillCboTrainingDaysPerWeek();
            FillTrainingDaysList();
        }

        private void FillTrainingDaysList()
        {
            var weekdaysList = GetEnumList<DayOfWeek>();
            listTrainingDays.ItemsSource = weekdaysList;
                
        }
        private static List<T> GetEnumList<T>()
        {
            T[] array = (T[])Enum.GetValues(typeof(T));
            List<T> list = new List<T>(array);
            return list;
        }

        private void FillCboTrainingDaysPerWeek()
        {
            List<TrainingDay> trainingDaysOptions = new List<TrainingDay>();
            foreach (var item in Enum.GetValues(typeof(TrainingDaysPerWeek)))
            {
                var trainingDay = (TrainingDaysPerWeek)item;
                var lengthDescription = GetEnumDescription(trainingDay);
                trainingDaysOptions.Add(new TrainingDay((short)trainingDay, lengthDescription));
            }

            trainingDaysOptions.Insert(0, new TrainingDay(0, "Select a number of training days in a week..."));
            cboTrainingsPerWeek.ItemsSource = trainingDaysOptions;
            cboTrainingsPerWeek.SelectedIndex = 0;
        }

        private void FillCboPlanLength()
        {
            List<PlanLength> planLengths = new List<PlanLength>();
            foreach (var item in Enum.GetValues(typeof(PlanLengths)))
            {
                var length = (PlanLengths)item;
                var lengthDescription = GetEnumDescription(length);
                planLengths.Add(new PlanLength((short)length, lengthDescription));
            }

            planLengths.Insert(0, new PlanLength(0, "Select a Plan Duration..."));
            cboPlanLength.ItemsSource = planLengths;
            cboPlanLength.SelectedIndex = 0;

        }

        private void FillCboPlanVolumes()
        {
            var planVolumesRepo = new PlanVolumesRepository();
            var planVolumesList = planVolumesRepo.GetAll();
            planVolumesList.Insert(0, new PlanVolume() { amplifier = 0 });
            cboPlanVolume.ItemsSource = planVolumesList;
            cboPlanVolume.SelectedIndex = 0;
        }

        private void FillCboPlanTypes()
        {
            var planTypesRepo = new PlanTypesRepository();
            var planTypesList = planTypesRepo.GetAll();
            planTypesList.Insert(0, new PlanType() { name = "Select your Goal..." });
            cboPlanType.ItemsSource = planTypesList;
            cboPlanType.DisplayMemberPath = "name";
            cboPlanType.SelectedIndex = 0;
        }

        private string GetEnumDescription(Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }

        private void txtPlanName_LostFocus(object sender, RoutedEventArgs e)
        {
            ValidatePlanName();
        }

        private void cboPlanType_LostFocus(object sender, RoutedEventArgs e)
        {
            ValidatePlanType();
        }

        private void cboPlanLength_LostFocus(object sender, RoutedEventArgs e)
        {
            ValidatePlanLength();
        }

        private void cboTrainingsPerWeek_LostFocus(object sender, RoutedEventArgs e)
        {
            ValidateNumberOfDays();
        }

        private void cboPlanVolume_LostFocus(object sender, RoutedEventArgs e)
        {
            ValidatePlanVolume();
        }

        private void TextBlock_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            receiveEmailCheckBox.IsChecked = !receiveEmailCheckBox.IsChecked;
        }
    }
}

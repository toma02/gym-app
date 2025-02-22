using BusinessLogicLayer;
using DataAccessLayer;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace FoiFitness
{
    /// <summary>
    /// Interaction logic for ShowExcerciseInfoControl.xaml
    /// </summary>
    public partial class ShowExcerciseInfoControl : Window
    {
        public int excerciseID { get; set; }
        public string videoThumbnail { get; set; }
        public Exercis exercis;
        public ExerciseRepository excerciseRepository;
        public YoutubeAPI youtubeAPI;
        public ShowExcerciseInfoControl(int excerciseId)
        {
            InitializeComponent();
            excerciseID = excerciseId;
            excerciseRepository = new ExerciseRepository();
            exercis = excerciseRepository.GetExcerciseByID(excerciseID);
            youtubeAPI = new YoutubeAPI(exercis.video_link);
            videoThumbnail = youtubeAPI.GetThumbnail();
            Title = exercis.name;
        }

        private void RefreshGui()
        {
            tbExcerciseName.Text = exercis.name;
            tbExcerciseDifficulty.Text = exercis.difficulty.ToString();
            tbExcerciseDescription.Text = exercis.description;
            tbExcerciseBodyPart.Text = exercis.BodyPart.name;
            tbExcerciseEquipment.Text = exercis.Equipment.name;
            imgExcercise.Source = new BitmapImage(new Uri(videoThumbnail, UriKind.Absolute));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshGui();
        }

        private void hlVideoLink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process process = new Process();
            process.StartInfo.UseShellExecute = true;
            process.StartInfo.FileName = exercis.video_link;
            process.Start();
        }
    }
}

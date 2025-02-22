using BusinessLogicLayer;
using DataAccessLayer;
using DataAccessLayer.Repositories;
using Google.Apis.YouTube.v3.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
using Google.Apis.YouTube.v3;
using System.Collections.Immutable;
using static System.Net.WebRequestMethods;

namespace FoiFitness
{
    /// <summary>
    /// Interaction logic for ShowExcercisesUserControl.xaml
    /// </summary>
    public partial class ShowExcercisesUserControl : UserControl
    {
        
        private BodyPart selectedBodyPart;
        private Equipment selectedEquipment;
        private List<Exercis> allExcercises;
        private ExerciseRepository excerciseRepository;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ShowExcercisesUserControl(BodyPart bodyPart, Equipment equipment)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            InitializeComponent();
            selectedBodyPart = bodyPart;
            selectedEquipment = equipment;
        }

        private void ShowExcercises()
        {
            excerciseRepository = new ExerciseRepository();
            if(selectedBodyPart != null && selectedEquipment != null)
            {
                allExcercises = excerciseRepository.GetAllFilteredExcercises(selectedBodyPart, selectedEquipment);
                if (allExcercises.Count > 0)
                {

                    for (int i = 0; i < allExcercises.Count; i++)
                    {
                        YoutubeAPI youtubeAPI = new YoutubeAPI(allExcercises[i].video_link);
                        allExcercises[i].image = youtubeAPI.GetThumbnail().ToString();
                    }
                    lbAllExcercises.ItemsSource = allExcercises;
                }
            }
        }

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Image image = (Image)sender;
            string imageUrl = image.Source.ToString();

            CheckOpenWindow(typeof(ImageViewer));

            ImageViewer viewer = new ImageViewer(imageUrl);
            viewer.Show();
        }

        private void btnShowExcerciseInfo_Click(object sender, RoutedEventArgs e)
        {
            CheckOpenWindow(typeof(ShowExcerciseInfoControl));

            Button button = (Button)sender;
            int id = Int32.Parse(button.Tag.ToString());
            
            ShowExcerciseInfoControl showExcerciseInfoControl = new ShowExcerciseInfoControl(id);
            showExcerciseInfoControl.Show();
        }

        private void CheckOpenWindow(Type windowType)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (windowType.IsInstanceOfType(window))
                {
                    window.Close();
                    break;
                }
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ShowExcercises();
        }
    }
}

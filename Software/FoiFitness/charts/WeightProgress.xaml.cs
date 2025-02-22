using BusinessLogicLayer;
using DataAccessLayer;
using LiveCharts;
using LiveCharts.Wpf;
using System;
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

namespace FoiFitness.charts
{
    /// <summary>
    /// Interaction logic for WeightProgress.xaml
    /// </summary>
    public partial class WeightProgress : UserControl
    {
        UserWeightRepository userWeightRepository;
        List<UserWeight> weights;
        User currentUser;
        DateTime startTime;
        DateTime endTime;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public WeightProgress(DateTime starttime, DateTime endtime)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            InitializeComponent();
            startTime = starttime;
            endTime = endtime;
            LoadData();
        }

        private void LoadData()
        {
            userWeightRepository = new UserWeightRepository();
            currentUser = UserRepository.GetUser(UserRepository.GetCurrentUser());
            weights = new List<UserWeight>();
            weights = userWeightRepository.GetWeightDataByUserId(currentUser.id);

            LoadCharts(weights);
        }

        private void LoadCharts(List<UserWeight> weights)
        {

            //DateTime startDate = new DateTime(2023, 02, 03);
            //DateTime endDate = new DateTime(2023, 02, 07);

            DateTime startDate = startTime;
            DateTime endDate = endTime;

            var filteredWeights = FilterDates(weights, startDate, endDate);

            ChartValues<double> newValues = new ChartValues<double>();
            List<String> newLabels = new List<String>();

            foreach (UserWeight weight in filteredWeights)
            {
                newValues.Add(weight.weight);
            }

            foreach (UserWeight weight in filteredWeights)
            {
                newLabels.Add(DateTime.Parse(weight.date).ToString("dd. MM. yyyy"));
            }

            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Kilaža",
                    Values = newValues
                }
            };

            Labels = newLabels.ToArray();
            YFormatter = value => value.ToString("N2") + " kg";
            DataContext = this;
        }

        private List<UserWeight> FilterDates(List<UserWeight> weights, DateTime startDate, DateTime endDate)
        {
            var newWeights = new List<UserWeight>();
            foreach (UserWeight weight in weights)
            {
                if (DateTime.Parse(weight.date) >= startDate && DateTime.Parse(weight.date) <= endDate)
                {
                    newWeights.Add(weight);
                }
            }
            return newWeights;
        }

        public SeriesCollection SeriesCollection { get; set; }
        public String[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }
    }
}

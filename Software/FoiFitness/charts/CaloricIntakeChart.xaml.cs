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
    /// Interaction logic for CaloricIntakeChart.xaml
    /// </summary>
    public partial class CaloricIntakeChart : UserControl
    {
        List<Day> days;
        User currentUser;
        DateTime startTime;
        DateTime endTime;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public CaloricIntakeChart(DateTime starttime, DateTime endtime)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            InitializeComponent();
            startTime = starttime;
            endTime = endtime;
            LoadData();
        }

        private void LoadData()
        {
            currentUser = UserRepository.GetUser(UserRepository.GetCurrentUser());
            days = new List<Day>();
            days = DayRepository.GetAllByUserId(currentUser.id);
            LoadCharts(days);
        }

        private void LoadCharts(List<Day> days)
        {
            DateTime startDate = startTime;
            DateTime endDate = endTime;

            var filteredDays = FilterDates(days, startDate, endDate);

            ChartValues<double> newValuesCalories = new ChartValues<double>();
            ChartValues<double> newValuesCaloriesBMR = new ChartValues<double>();
            List<String> newLabels = new List<String>();

            foreach (Day day in filteredDays)
            {
                newValuesCalories.Add(day.calories);
            }

            foreach (Day day in filteredDays)
            {
                newValuesCaloriesBMR.Add(day.bmr_calories);
            }

            foreach (Day day in filteredDays)
            {
                newLabels.Add(DateTime.Parse(day.date).ToString("dd. MM. yyyy"));
            }

            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Calories",
                    Values = newValuesCalories
                },
                new LineSeries
                {
                    Title = "BMR Calories",
                    Values = newValuesCaloriesBMR
                }
            };

            Labels = newLabels.ToArray();
            YFormatter = value => value.ToString("N2") + " cal";
            DataContext = this;
            
        }

        private List<Day> FilterDates(List<Day> days, DateTime startDate, DateTime endDate)
        {
            var newDays= new List<Day>();
            foreach (Day day in days)
            {
                if (DateTime.Parse(day.date) >= startDate && DateTime.Parse(day.date) <= endDate)
                {
                    newDays.Add(day);
                }
            }
            return newDays;
        }

        public SeriesCollection SeriesCollection { get; set; }
        public String[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }
    }
}

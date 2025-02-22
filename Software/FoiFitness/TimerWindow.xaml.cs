using BusinessLogicLayer;
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
using System.Windows.Shapes;

namespace FoiFitness
{
    /// <summary>
    /// Interaction logic for TimerWindow.xaml
    /// </summary>
    public partial class TimerWindow : Window
    {
        private Timerr timer;
        public TimerWindow()
        {
            InitializeComponent();
            timer = new Timerr();
            timer.CounterValueChanged += Timer_CounterValueChanged;
            txtCountdown.Text = "00:00:00";
        }

        private void Timer_CounterValueChanged(object sender, EventArgs e)
        {
            // Update the UI with the updated counter value
            txtCountdown.Text = timer.CounterValue;
        }

        private void btnStartCounter_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }

        private void btnStopCounter_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }

        private void btnResetCounter_Click(object sender, RoutedEventArgs e)
        {
            timer.Reset();
            txtCountdown.Text = timer.CounterValue;
        }
    }
}

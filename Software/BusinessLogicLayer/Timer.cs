using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace BusinessLogicLayer
{
    public class Timerr
    {
        private DispatcherTimer timer;
        private int hours;
        private int minutes;
        private int seconds;

        public string CounterValue { get; private set; }
        public bool IsActive { get; private set; }

        public event EventHandler CounterValueChanged;

        public bool Start()
        {
            if (IsActive) return false; 
            IsActive = true;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
            return true;
        }

        public void Stop()
        {
            if (IsActive)
            {
                IsActive = false;
                timer.Stop();
                timer.Tick -= Timer_Tick;
                timer = null;
            }
        }

        public void Reset()
        {
            hours = 0;
            minutes = 0;
            seconds = 0;
            UpdateCounterValue();
        } 

        private void Timer_Tick(object sender, EventArgs e)
        {
            seconds++;

            if (seconds == 60)
            {
                seconds = 0;
                minutes++;
            }

            if (minutes == 60)
            {
                minutes = 0;
                hours++;
            }

            UpdateCounterValue();
        }

        private void UpdateCounterValue()
        {
            CounterValue = $"{hours:D2}:{minutes:D2}:{seconds:D2}";
            CounterValueChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}

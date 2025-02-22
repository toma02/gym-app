using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using BusinessLogicLayer;
using MimeKit;
using MailKit;
using DataAccessLayer;
using System.IO;
using Org.BouncyCastle.Crypto.Macs;
using MailKit.Security;
using MailKit.Net.Smtp;
using System.Configuration;
using System.Runtime.Remoting.Contexts;

namespace MailerService
{
    [RunInstaller(true)]
    public partial class Mailer : ServiceBase
    {
        private Timer _timer;
        User currentUser;
        public Mailer()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string targetDirectory = currentDirectory.Replace("MailerService", "FoiFitness");
            targetDirectory = Path.Combine(targetDirectory, "net6.0-windows");
            targetDirectory = Path.Combine(targetDirectory, "Username.txt");

            string user = File.ReadAllText(targetDirectory).TrimEnd();
            currentUser = UserRepository.GetUser(user);

            SetTimer();
        }

        protected override void OnStop()
        {
            _timer.Stop();
            _timer.Dispose();
        }

        private void SetTimer()
        {
            var targetTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 2, 20, 00);
            if (DateTime.Now > targetTime)
            {
                targetTime = targetTime.AddDays(1);
            }

            var timeUntilTargetTime = targetTime - DateTime.Now;
            _timer = new Timer
            {
                Interval = timeUntilTargetTime.TotalMilliseconds,
                AutoReset = true,
                Enabled = true
            };
            _timer.Elapsed += TimerElapsed;
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            _timer.Interval = 86400000;
            SendEmail();
        }

        private void SendEmail()
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Sender", "foifitnesscentar@gmail.com"));
            message.To.Add(new MailboxAddress("Recipient", currentUser.email));
            message.Subject = "Workout reminder";
            message.Body = new BodyBuilder
            {
                HtmlBody = "" +
                    "<html>" +
                        "<body style='background-color:#f2f2f2;'>" +
                            "<table width='100%' style='background-color:#ffffff; padding:30px;'>" +
                                "<tr>" +
                                    "<td>" +
                                        $"<h1 style='font-size:36px; color:#5c5c5c; text-align:center;'>{currentUser.first_name}, you have to complete your workout today!</h1>" +
                                        "<p style='font-size:18px; color:#5c5c5c; text-align:center;'>This is a reminder for your work</p>" +
                                        $"{CaloriesLeft()}" +
                                        $"{WeightProgress()}" +
                                    "</td>" +
                                "</tr>" +
                            "</table>" +
                        "</body>" +
                    "</html>"
            }.ToMessageBody();


            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                client.Authenticate("foifitnesscentar@gmail.com", "hhbmvfucdwwsrftq");
                client.Send(message);
                client.Disconnect(true);
            }
        }

        private string CaloriesLeft()
        {
            var caloriesLeft = DayRepository.NeededCalories(currentUser.id);
            if(caloriesLeft == 0)
            {
                return "<p style = 'font-size:18px; color:#5c5c5c; text-align:center;'>You have consumed enough calories today.</p>";
            }else if (caloriesLeft>0)
            {
                return $"<p style = 'font-size:18px; color:#5c5c5c; text-align:center;'> You need to consume an additional {caloriesLeft} calories today.</p>";
            }
            else
            {
                return $"<p style = 'font-size:18px; color:#5c5c5c; text-align:center;'> You have consumed {Math.Abs(caloriesLeft)} calories more than your needs today.</p>";
            }
        }

        private string WeightProgress()
        {
            UserWeightRepository userWeightRepository = new UserWeightRepository();
            var userWeightProgress = userWeightRepository.WeightProgress(currentUser.id);
            if (userWeightProgress != 0.00)
            {
                if (userWeightProgress > 0)
                {
                    return $"<p style = 'font-size:18px; color:#5c5c5c; text-align:center;'>Compared to the start of your workout, you have gained {userWeightProgress.ToString("F2")} kilograms</p>";
                }
                else
                {
                    return $"<p style = 'font-size:18px; color:#5c5c5c; text-align:center;'>Compared to the start of your workout, you have lost {Math.Abs(userWeightProgress).ToString("F2")} kilograms</p>";
                }
            }
            return "<p style = 'font-size:18px; color:#5c5c5c; text-align:center;'>Your weight hasn't changed compared to the start of your workout.</p>";
        }
    }
}

using System;
using System.Timers;
using System.Windows.Controls;
using System.Windows.Threading;

namespace WpfWatch
{
    /// <summary>
    /// Логика взаимодействия для WatchControl.xaml
    /// </summary>
    public partial class WatchControl : UserControl
    {

        public Timer Timer = new Timer(1000);

        public WatchControl()
        {
            InitializeComponent();
            Timer.Elapsed += TimeChange;
            Timer.Enabled = true;
        }

        private void TimeChange(object sender, ElapsedEventArgs e)
        {
            var time = DateTime.Now;

            Dispatcher.Invoke(() =>
                {
                    RotateSecond.Angle = 6 * (time.Second);

                    RotateMinute.Angle = 6 * time.Minute + RotateSecond.Angle / 60;

                    RotateHour.Angle = 30 * (time.Hour % 12) + RotateMinute.Angle / 60;
                }
            );
        }



    }
}

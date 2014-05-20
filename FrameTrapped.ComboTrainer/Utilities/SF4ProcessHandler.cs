namespace FrameTrapped.ComboTrainer.Utilities
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Runtime.InteropServices;

    using Caliburn.Micro;

    public class SF4ProcessHandler : PropertyChangedBase
    {

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hwnd, WindowShowStyle nCmdShow);

        [DllImport("user32.dll")]
        private static extern bool EnableWindow(IntPtr hwnd, bool enabled);

        private enum WindowShowStyle : uint
        {
            Hide = 0,
            ShowNormal = 1,
            ShowMinimized = 2,
            ShowMaximized = 3,
            Maximize = 3,
            ShowNormalNoActivate = 4,
            Show = 5,
            Minimize = 6,
            ShowMinNoActivate = 7,
            ShowNoActivate = 8,
            Restore = 9,
            ShowDefault = 10,
            ForceMinimized = 11
        }

        public delegate void SuccessEventHandler(Process PR);
        public event SuccessEventHandler StreetFighter4StartedSuccessEventHandler;

        private static SF4ProcessHandler instance;

        private Process PR;

        private const int SW_SHOW = 5;

        private bool _isBusy;
        private string _busyContent;
        
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                if (_isBusy != value)
                {
                    _isBusy = value;
                    NotifyOfPropertyChange(() => IsBusy);
                }
            }
        }

        public string BusyContent
        {
            get { return _busyContent; }
            set
            {
                _busyContent = value;
                NotifyOfPropertyChange(() => BusyContent);
            }
        }

        public Process GetSF4()
        {

            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler((sender, e) =>
            {
                IsBusy = true;

                if (PR == null )
                {
                    // Get all instances of SSFIV.exe running on the local 
                    // computer.
                    Process[] sfivInstances = Process.GetProcessesByName("SSFIV");

                    if (sfivInstances != null && sfivInstances.Length == 0)
                    {
                        PR = new Process();
                        PR.StartInfo = new ProcessStartInfo(@"C:\Program Files (x86)\Steam\SteamApps\common\Super Street Fighter IV - Arcade Edition\SSFIV.exe");

                        // Hide it first 
                        PR.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;

                        PR.Start();
                    }
                    else
                    {
                        PR = sfivInstances[0];
                    }

                }

                if (PR.WaitForInputIdle(30000))
                {
                    //For correct responding, it's important to let sleep our thread for a while.
                    System.Threading.Thread.Sleep(1000);

                    ShowWindow(PR.Handle, WindowShowStyle.ShowNormal);
                    EnableWindow(PR.Handle, true);
                }
                else
                {
                    throw new Exception("Street Fighter unable to start. Time out.");
                }

                this.IsBusy = false;
            });

            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler((sender, e) =>
            {
                if (e.Error == null)
                {
                    if (StreetFighter4StartedSuccessEventHandler != null)
                    {
                        StreetFighter4StartedSuccessEventHandler.BeginInvoke(PR, null, null);
                        StreetFighter4StartedSuccessEventHandler = null; //clear handler.
                    }
                }
                else
                { // has errors
                    this.IsBusy = false;
                }
            });
            worker.RunWorkerAsync();

            return PR;
        }

        public void StopSF4()
        {
            if (PR != null && !PR.HasExited)
            {
                PR.Kill();
            }
        }

        public static SF4ProcessHandler Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SF4ProcessHandler();
                }
                return instance;
            }
        }
        public void Dispose()
        {
            try
            {
                PR.Kill();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }
        private SF4ProcessHandler()
        {

        }
    }
}

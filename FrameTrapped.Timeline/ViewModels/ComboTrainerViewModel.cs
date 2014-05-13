namespace FrameTrapped.ComboTrainer.ViewModels
{
    using System;
    using System.Diagnostics;

    using Caliburn.Micro;

    using FrameTrapped.ComboTrainer.Controls;
    using FrameTrapped.ComboTrainer.Utilities;

    public class ComboTrainerViewModel : Screen
    {
        private WindowsHostHelper _processHost;

        private SF4ProcessHandler _sf4ProcessHandler;

        public bool IsBusy
        {
            get
            {
                return _sf4ProcessHandler.IsBusy;
            }
        }

        public void SF4ProcessStarted(Process PR )
        {
            _processHost.SetProcess(PR);
        }

        public void StartSF4()
        {
            _sf4ProcessHandler.GetSF4();
        }

        public void InitialiseWindowsHostHelper(WindowsHostHelper sender)
        {
            _processHost = (sender as WindowsHostHelper);
        }

        ~ComboTrainerViewModel()
        {
            try
            {
                SF4ProcessHandler.Instance.StopSF4();                    
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        public ComboTrainerViewModel()
        {
            _sf4ProcessHandler = SF4ProcessHandler.Instance;
            _sf4ProcessHandler.StreetFighter4StartedSuccessEventHandler += SF4ProcessStarted;
            
        }
    }
}

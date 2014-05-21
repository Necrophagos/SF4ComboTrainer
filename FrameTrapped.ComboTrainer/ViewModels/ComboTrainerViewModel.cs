namespace FrameTrapped.ComboTrainer.ViewModels
{
    using System;
    using System.Diagnostics;

    using Caliburn.Micro;

    using FrameTrapped.ComboTrainer.Utilities;

    public class ComboTrainerViewModel : Screen
    {
        private IEventAggregator _events;

        private TimeLineViewModel _timeLineViewModel;

        private GameViewModel _gameViewModel;
 
        public TimeLineViewModel TimeLineViewModel
        {
            get
            {
                return _timeLineViewModel;
            }
            set
            {
                _timeLineViewModel = value;
                NotifyOfPropertyChange(() => TimeLineViewModel);
            }
        }

        public GameViewModel GameViewModel
        {
            get
            {
                return _gameViewModel;
            }
            set
            {
                _gameViewModel = value;
                NotifyOfPropertyChange(() => GameViewModel);
            }
        }

        public void StartSF4()
        {
            if (GameViewModel == null)
            {
                GameViewModel = new GameViewModel(_events, "SSFIV.exe");
            }
            else
            {
                GameViewModel.TryClose();
                GameViewModel = null;
                GameViewModel = new GameViewModel(_events, "SSFIV.exe");
            }
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

        public ComboTrainerViewModel(IEventAggregator events)
        {
            _events = events;

            _timeLineViewModel = new TimeLineViewModel(events);
        }
    }
}

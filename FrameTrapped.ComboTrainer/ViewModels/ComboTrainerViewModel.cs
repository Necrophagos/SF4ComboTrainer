namespace FrameTrapped.ComboTrainer.ViewModels
{
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.Windows.Controls;
    using Caliburn.Micro;
    using FrameTrapped.ComboTrainer.Utilities;

    public class ComboTrainerViewModel : Screen
    {
        private IEventAggregator _events;

        private TimeLineViewModel _timeLineViewModel;

        private GameViewModel _gameViewModel;

        private Size _selectedResolution;

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

        public BindableCollection<Size> Resolutions
        {
            get
            {
                // silly example of the collection to bind to
                return new BindableCollection<Size>(
                    new Size[] 
                    {
                        new Size(800, 600),
                        new Size(1024, 768),
                        new Size(1280, 720),
                        new Size(1600, 900),
                        new Size(1680, 1050), 
                        new Size(1920, 1080)
                    }); 
            }
        }

        public Size SelectedResolution
        {
            get { return _selectedResolution; }
            set
            {
                _selectedResolution = value;
                GameViewModel.SetResolution(value.Width, value.Height);
                NotifyOfPropertyChange(() => SelectedResolution); 
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

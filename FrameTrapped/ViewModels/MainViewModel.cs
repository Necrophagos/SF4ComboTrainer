namespace FrameTrapped.ViewModels
{
    using Caliburn.Micro;

    using FrameTrapped.Home.ViewModels;
    using FrameTrapped.ComboTrainer.ViewModels;
    using FrameTrapped.StreetFighterLibrary.ViewModels;
    using System.Windows;
    using System.Windows.Input;
    using System.ComponentModel.Composition;
    using FrameTrapped.ComboTrainer.Messages;

    /// <summary>
    /// 
    /// </summary>
    [Export(typeof(MainViewModel))]
    public class MainViewModel : Screen
    {
        /// <summary>
        /// The window manager.
        /// </summary>
        private readonly IWindowManager _windowManager;

        /// <summary>
        /// The event aggregator.
        /// </summary>
        private readonly IEventAggregator _events;

        /// <summary>
        /// The title.
        /// </summary>
        private string _title;

        /// <summary>
        /// Is the home tab item selected?
        /// </summary>
        private bool _homeTabItemSelected;

        /// <summary>
        /// Is the street fighter library tab item selected?
        /// </summary>
        private bool _streetFighterLibraryTabItemSelected;

        /// <summary>
        /// Is the combo trainer tab item selected?
        /// </summary>
        private bool _comboTrainerTabItemSelected;

        /// <summary>
        /// Is the options tab item selected?
        /// </summary>
        private bool _optionsTabItemSelected;

        /// <summary>
        /// The home view model.
        /// </summary>
        private HomeViewModel _homeViewModel;

        /// <summary>
        /// The street fighter library view model.
        /// </summary>
        private StreetFighterLibraryViewModel _streetFighterLibraryViewModel;

        /// <summary>
        /// The combo trainer view model.
        /// </summary>
        private ComboTrainerViewModel _comboTrainerViewModel;


        // private OptionsViewModel _optionsViewModel;

        /// <summary>
        /// Gets or sets window title.
        /// </summary>
        public string Title
        {
            get
            {
                return _title;
            }

            set
            {
                _title = value;
                NotifyOfPropertyChange(() => Title);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the home tab item is selected.
        /// </summary>
        public bool HomeTabItemSelected
        {
            get
            {
                return _homeTabItemSelected;
            }

            set
            {
                _homeTabItemSelected = value;
                NotifyOfPropertyChange(() => HomeTabItemSelected);
                if (value)
                {
                    UpdateTitle(string.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the street fighter library tab item is selected.
        /// </summary>
        public bool StreetFighterLibraryTabItemSelected
        {
            get
            {
                return _streetFighterLibraryTabItemSelected;
            }

            set
            {
                _streetFighterLibraryTabItemSelected = value;
                NotifyOfPropertyChange(() => StreetFighterLibraryTabItemSelected);
                if (value)
                {
                    UpdateTitle(Application.Current.TryFindResource("SFLibrary").ToString());
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the street fighter library tab item is selected.
        /// </summary>
        public bool ComboTrainerTabItemSelected
        {
            get
            {
                return _comboTrainerTabItemSelected;
            }

            set
            {
                _comboTrainerTabItemSelected = value;
                NotifyOfPropertyChange(() => ComboTrainerTabItemSelected);
                if (value)
                {
                    UpdateTitle(Application.Current.TryFindResource("ComboTrainer").ToString());
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the options tab item is selected.
        /// </summary>
        public bool OptionsTabItemSelected
        {
            get
            {
                return _optionsTabItemSelected;
            }

            set
            {
                _optionsTabItemSelected = value;
                NotifyOfPropertyChange(() => OptionsTabItemSelected);
            }
        }

        /// <summary>
        /// The main menu toolbar view model.
        /// </summary>
        public MainMenuViewModel MainMenuViewModel { get; private set; }

        /// <summary>
        /// Gets or sets the home view model.
        /// </summary>
        public HomeViewModel HomeViewModel
        {
            get
            {
                return _homeViewModel;
            }

            set
            {
                _homeViewModel = value;
                NotifyOfPropertyChange(() => HomeViewModel);
            }
        }

        /// <summary>
        /// Gets or sets the street fighter library view model.
        /// </summary>
        public StreetFighterLibraryViewModel StreetFighterLibraryViewModel
        {
            get
            {
                return _streetFighterLibraryViewModel;
            }

            set
            {
                _streetFighterLibraryViewModel = value;
                NotifyOfPropertyChange(() => StreetFighterLibraryViewModel);
            }
        }

        /// <summary>
        /// Gets or sets the time line view model.
        /// </summary>
        public ComboTrainerViewModel ComboTrainerViewModel
        {
            get
            {
                return _comboTrainerViewModel;
            }

            set
            {
                _comboTrainerViewModel = value;
                NotifyOfPropertyChange(() => ComboTrainerViewModel);
            }
        }

        /// <summary>
        /// Updates the application title with what view you are on.
        /// </summary>
        /// <param name="p"></param>
        private void UpdateTitle(string title)
        {
            string applicationName = Application.Current.TryFindResource("Title").ToString();

            Title = string.IsNullOrWhiteSpace(title)
                 ? string.Format("{0}: SF4 Combo Trainer 2.1", applicationName)
                 : string.Format("{0} - {1}", applicationName, title);
        }

        /// <summary>
        /// Opens files by drag and drop
        /// </summary>
        /// <param name="e">The <see cref="DragEventArgs"/> instance containing the event data.</param>
        public void OnDropFile(DragEventArgs e)
        {
            if (e.Data is DataObject && ((DataObject)e.Data).ContainsFileDropList())
            {
                foreach (string filePath in ((DataObject)e.Data).GetFileDropList())
                {
                    _events.Publish(new OpenTimeLineMessage(filePath, true));
                }
            }
        }

        /// <summary>
        /// Handle keyboard shortcuts.
        /// </summary>
        /// <param name="e">Key event arguments.</param>
        public void OnKeyDown(KeyEventArgs e)
        {
            bool modCtrl = Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl);
            bool modShift = Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift);
            bool modAlt = Keyboard.IsKeyDown(Key.LeftAlt);
            bool modAltGr = Keyboard.IsKeyDown(Key.RightAlt);

            switch (e.Key)
            {
                case Key.O:
                    if (modCtrl & !modShift)
                    {
                        _events.Publish(new OpenTimeLineMessage(false));
                    }
                    else if (modCtrl && modShift)
                    {
                        _events.Publish(new OpenTimeLineMessage(true));
                    }

                    break;
                case Key.S:
                    if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
                    {
                        _events.Publish(new SaveTimeLineMessage());
                    }
                    break;
                case Key.P:

                    break;                        
                default:
                    break;
            }
        }

        /// <summary>
        /// Exit the application.
        /// </summary>
        public void Exit()
        {
            Application.Current.Shutdown();
        }

        /// <summary>
        /// The Main view model.
        /// </summary>
        /// <param name="windowManager">The window manager.</param>
        /// <param name="events">The events aggregator.</param>
        [ImportingConstructor]
        public MainViewModel(IWindowManager windowManager, IEventAggregator events)
        {
            _windowManager = windowManager;
            _events = events;
            _events.Subscribe(this);

            UpdateTitle(string.Empty);

            MainMenuViewModel = new MainMenuViewModel(_windowManager,_events);

            HomeViewModel = new HomeViewModel();
            StreetFighterLibraryViewModel = new StreetFighterLibraryViewModel(_events);
            ComboTrainerViewModel = new ComboTrainerViewModel(_events);

            HomeTabItemSelected = true;
        }
    }
}

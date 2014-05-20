namespace FrameTrapped.ViewModels
{
    using Caliburn.Micro;

    using FrameTrapped.Home.ViewModels;
    using FrameTrapped.ComboTrainer.ViewModels;
    using FrameTrapped.StreetFighterLibrary.ViewModels;
    using System.Windows;
    using System.Windows.Input;
    using System.ComponentModel.Composition;

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

        ///// <summary>
        ///// Gets or sets options view model.
        ///// </summary>
        //public OptionsViewModel OptionsViewModel
        //{
        //    get
        //    {
        //        return _optionsViewModel;
        //    }

        //    set
        //    {
        //        _optionsViewModel = value;
        //        NotifyOfPropertyChange(() => OptionsViewModel);
        //    }
        //}


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
                    //_events.Publish(new SomeMessageAboutFiles(filePath));
                }
            }
        }

        /// <summary>
        /// Executes the keyboard shortcut.
        /// </summary>
        /// <param name="key">The key.</param>
        private void ExecuteKeyboardShortcut(Key key)
        {
            switch (key)
            {
                case Key.O:
                    if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
                    {
                        //OpenComboTrainerFile();
                    }

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

        [ImportingConstructor]
        public MainViewModel(IWindowManager windowManager, IEventAggregator events)
        {

            _windowManager = windowManager;
            _events = events;
            _events.Subscribe(this);

            MainMenuViewModel = new MainMenuViewModel(_events);

            HomeViewModel = new HomeViewModel();
            StreetFighterLibraryViewModel = new StreetFighterLibraryViewModel(_events);
            ComboTrainerViewModel = new ComboTrainerViewModel(_events);

        }
    }
}

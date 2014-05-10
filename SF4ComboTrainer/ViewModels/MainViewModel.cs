namespace SF4ComboTrainer.ViewModels
{
    using Caliburn.Micro;

    using SF4ComboTrainer.Home.ViewModels;
    using SF4ComboTrainer.TimeLine.ViewModels;


    public class MainViewModel : PropertyChangedBase
    {    
        /// <summary>
        /// The title.
        /// </summary>
        private string _title;

        /// <summary>
        /// The home view model.
        /// </summary>
        public HomeViewModel HomeViewModel { get; private set; }
 
        /// <summary>
        /// The main menu view model.
        /// </summary>
        public MainMenuViewModel MainMenuViewModel { get; private set; }

        /// <summary>
        /// The time line view model.
        /// </summary>
        public TimeLineViewModel TimeLineViewModel { get; private set; }


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

        public MainViewModel()
        {
            HomeViewModel = new HomeViewModel();
            MainMenuViewModel = new MainMenuViewModel();
            TimeLineViewModel = new TimeLineViewModel();
        }
    }
}

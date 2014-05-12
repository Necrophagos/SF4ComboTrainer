namespace FrameTrapped.ViewModels
{
    using Caliburn.Micro;

    using FrameTrapped.Home.ViewModels;
    using FrameTrapped.TimeLine.ViewModels;


    public class MainViewModel : PropertyChangedBase
    {    
        /// <summary>
        /// The title.
        /// </summary>
        private string _title;

        /// <summary>
        /// The home view model.
        /// </summary>
        public HomeViewModel CurrentViewModel { get; private set; }
 
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
            CurrentViewModel = new HomeViewModel();
        }
    }
}

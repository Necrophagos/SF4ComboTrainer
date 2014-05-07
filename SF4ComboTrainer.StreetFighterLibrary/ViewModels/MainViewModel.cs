namespace SF4ComboTrainer.StreetFighterLibrary.ViewModels
{
    using System.Collections.ObjectModel;
    using Caliburn.Micro;
    using Input.ViewModels;
    using SF4ComboTrainer.StreetFighterLibrary.Utilities;

    public class MainViewModel : PropertyChangedBase
    {
        /// <summary>
        /// The title.
        /// </summary>
        private string _title;

        private FighterViewModel _selectedFighter;

        /// <summary>
        /// Gets the home view model.
        /// </summary>
        public ObservableCollection<FighterViewModel> FightersList { get; private set; }

        /// <summary>
        /// Gets or sets the currently selected fighter.
        /// </summary>
        public FighterViewModel SelectedFighter
        {
            get
            {
                return _selectedFighter;
            }
            set
            {
                if (value != _selectedFighter)
                { 
                    _selectedFighter = value;
                    NotifyOfPropertyChange(() => SelectedFighter);
                }
            }
        }

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
            FightersList = new ObservableCollection<FighterViewModel>();


            FightersList.Add(FighterDataAE2012.RyuData());
            FightersList.Add(FighterDataAE2012.KenData());
        }
    }
}

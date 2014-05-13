namespace FrameTrapped.StreetFighterLibrary.ViewModels
{
    using System.Collections.ObjectModel;
    using Caliburn.Micro;

    using FrameTrapped.Input.ViewModels;
    using FrameTrapped.StreetFighterLibrary.Utilities;

    public class StreetFighterLibraryViewModel : PropertyChangedBase
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

        public StreetFighterLibraryViewModel()
        {
            FightersList = new ObservableCollection<FighterViewModel>();


            FightersList.Add(FighterDataAE2012.Ryu());
            FightersList.Add(FighterDataAE2012.Ken());
            FightersList.Add(FighterDataAE2012.EHonda());
            FightersList.Add(FighterDataAE2012.Ibuki());
            FightersList.Add(FighterDataAE2012.Makoto());
            FightersList.Add(FighterDataAE2012.Dudley());
            FightersList.Add(FighterDataAE2012.Seth());
            FightersList.Add(FighterDataAE2012.Gouken());
            FightersList.Add(FighterDataAE2012.Akuma());
            FightersList.Add(FighterDataAE2012.Gen());
            FightersList.Add(FighterDataAE2012.Dan());
            FightersList.Add(FighterDataAE2012.Sakura());
            FightersList.Add(FighterDataAE2012.Oni());

            FightersList.Add(FighterDataAE2012.Yun());
            FightersList.Add(FighterDataAE2012.Juri());
            FightersList.Add(FighterDataAE2012.ChunLi());
            FightersList.Add(FighterDataAE2012.Dhalsim());
            FightersList.Add(FighterDataAE2012.Abel());
            FightersList.Add(FighterDataAE2012.CViper());
            FightersList.Add(FighterDataAE2012.MBison());
            FightersList.Add(FighterDataAE2012.Sagat());
            FightersList.Add(FighterDataAE2012.Cammy());
            FightersList.Add(FighterDataAE2012.DeeJay());
            FightersList.Add(FighterDataAE2012.Cody());
            FightersList.Add(FighterDataAE2012.Guy());
            FightersList.Add(FighterDataAE2012.Hakan());
            FightersList.Add(FighterDataAE2012.Yang());

            FightersList.Add(FighterDataAE2012.EvilRyu());
            FightersList.Add(FighterDataAE2012.Guile());
            FightersList.Add(FighterDataAE2012.Blanka());
            FightersList.Add(FighterDataAE2012.Zangief());
            FightersList.Add(FighterDataAE2012.Rufus());
            FightersList.Add(FighterDataAE2012.ElFuerte());
            FightersList.Add(FighterDataAE2012.Vega());
            FightersList.Add(FighterDataAE2012.Balrog());
            FightersList.Add(FighterDataAE2012.FeiLong());
            FightersList.Add(FighterDataAE2012.THawk());
            FightersList.Add(FighterDataAE2012.Adon());
            FightersList.Add(FighterDataAE2012.Rose()); 

        }
    }
}

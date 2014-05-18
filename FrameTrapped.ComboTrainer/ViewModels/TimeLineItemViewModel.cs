namespace FrameTrapped.ComboTrainer.ViewModels
{
    using Caliburn.Micro;

    using FrameTrapped.Input.ViewModels;
    using FrameTrapped.Input.Models;

    public class TimeLineItemViewModel : Screen
    {
        private InputItemViewModel inputItemViewModel;
        
        /// <summary>
        /// The time line parent.
        /// </summary>
        private TimeLineViewModel _parent;

        private bool _isActiveItem;

        public InputItemViewModel InputItemViewModel
        {
            get { return inputItemViewModel; }
            set
            {
                if (value != inputItemViewModel)
                {
                    inputItemViewModel = value;
                    NotifyOfPropertyChange(() => InputItemViewModel);
                    Update();
                }
            }
        }

        public bool IsActiveItem
        {
            get
            {
                return _isActiveItem;
            }

            set
            {
                _isActiveItem = value;
                NotifyOfPropertyChange(() => IsActiveItem);
            }
        }

        //Directions
        public InputCommandModel.DirectionStateEnum Direction
        {
            get
            {
                return InputItemViewModel.Direction;
            }
        }

        //Punches
        public bool Light_Punch
        {
            get
            {
                return InputItemViewModel.Light_Punch;
            }

        }
        public bool Medium_Punch
        {
            get { return InputItemViewModel.Medium_Punch; }

        }
        public bool Hard_Punch
        {
            get { return InputItemViewModel.Hard_Punch; }

        }

        //Kicks
        public bool Light_Kick
        {
            get { return InputItemViewModel.Light_Kick; }

        }
        public bool Medium_Kick
        {
            get { return InputItemViewModel.Medium_Kick; }

        }
        public bool Hard_Kick
        {
            get { return InputItemViewModel.Hard_Kick; }

        }

        public int WaitFrames
        {
            get { return InputItemViewModel.WaitFrames; }

        }

        public void Highlight()
        {
            IsActiveItem = true;  
        }
        
        public void DeHighlight()
        {
            IsActiveItem = false; 
        }

        public void Update()
        {
            NotifyOfPropertyChange(() => Direction);
            NotifyOfPropertyChange(() => WaitFrames);
            NotifyOfPropertyChange(() => Light_Punch);
            NotifyOfPropertyChange(() => Medium_Punch);
            NotifyOfPropertyChange(() => Hard_Punch);
            NotifyOfPropertyChange(() => Light_Kick);
            NotifyOfPropertyChange(() => Medium_Kick);
            NotifyOfPropertyChange(() => Hard_Kick);
        }

        private void InputItemViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Update();
        }

        public TimeLineItemViewModel(TimeLineViewModel parent)
        {
            _parent = parent;

            inputItemViewModel = new InputItemViewModel();

            InputItemViewModel.PropertyChanged += InputItemViewModel_PropertyChanged;
            inputItemViewModel.WaitFrames = 1;
        }

        public TimeLineItemViewModel( )
        { 

            inputItemViewModel = new InputItemViewModel(); 
            inputItemViewModel.WaitFrames = 1;
        }
    }
}
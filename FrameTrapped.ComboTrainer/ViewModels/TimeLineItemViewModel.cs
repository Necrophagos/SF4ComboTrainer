namespace FrameTrapped.ComboTrainer.ViewModels
{
    using Caliburn.Micro;

    using FrameTrapped.Input.ViewModels;
    using FrameTrapped.Input.Models;
    using System.Windows.Input;
    using System.Windows.Controls.Primitives;

    /// <summary>
    /// The time line item view model.
    /// </summary>
    public class TimeLineItemViewModel : Screen
    {
        /// <summary> 
        /// Indicates if the item is active.
        /// </summary>
        private bool _isActiveItem;

        /// <summary>
        /// The time line parent.
        /// </summary>
        private TimeLineViewModel _parent;

        /// <summary>
        /// The input item view model.
        /// </summary>
        private InputItemViewModel _inputItemViewModel;

        /// <summary>
        /// Gets or sets a value indicating whether this is the current active item.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the input item view model.
        /// </summary>
        public InputItemViewModel InputItemViewModel
        {
            get { return _inputItemViewModel; }
            set
            {
                if (value != _inputItemViewModel)
                {
                    _inputItemViewModel = value;
                    NotifyOfPropertyChange(() => InputItemViewModel);
                    Update();
                }
            }
        }
        /// <summary>
        /// Gets of sets the direction input.
        /// </summary>
        public InputCommandModel.DirectionStateEnum Direction
        {
            get
            {
                return InputItemViewModel.Direction;
            }
            set
            {
                InputItemViewModel.Direction = value;
            }
        }

        //Punches
        public bool Light_Punch
        {
            get
            {
                return InputItemViewModel.Light_Punch;
            }
            set
            {
                InputItemViewModel.Light_Punch = value;
            }
        }
        public bool Medium_Punch
        {
            get
            {
                return InputItemViewModel.Medium_Punch;
            }
            set
            {
                InputItemViewModel.Medium_Punch = value;
            }
        }
        public bool Hard_Punch
        {
            get
            {
                return InputItemViewModel.Hard_Punch;
            }
            set
            {
                InputItemViewModel.Hard_Punch = value;
            }
        }

        //Kicks
        public bool Light_Kick
        {
            get
            {
                return InputItemViewModel.Light_Kick;
            }
            set
            {
                InputItemViewModel.Light_Kick = value;
            }
        }

        public bool Medium_Kick
        {
            get
            {
                return InputItemViewModel.Medium_Kick;
            }
            set
            {
                InputItemViewModel.Medium_Kick = value;
            }
        }

        public bool Hard_Kick
        {
            get
            {
                return InputItemViewModel.Hard_Kick;
            }
            set
            {
                InputItemViewModel.Hard_Kick = value;
            }
        }

        public bool PlaySound
        {
            get
            {
                return InputItemViewModel.PlaySound;
            }
            set
            {
                InputItemViewModel.PlaySound = value;
                NotifyOfPropertyChange(() => PlaySound);
            }
        }

        public int WaitFrames
        {
            get
            {
                return InputItemViewModel.WaitFrames;
            }
            set
            {
                InputItemViewModel.WaitFrames = value;
            }
        }

        /// <summary>
        /// Descreases the frame count by one.
        /// </summary>
        public void DecrementFrames()
        {
            if (WaitFrames > 1)
            {
                WaitFrames--;
            }
        }

        /// <summary>
        /// Increases the frame count by one.
        /// </summary>
        public void IncrementFrames()
        {
            if (WaitFrames < 300)
            {
                WaitFrames++;
            }
        }

        /// <summary>
        /// Alias for setting this item as not active.
        /// </summary>
        public void DeHighlight()
        {
            IsActiveItem = false;
        }

        /// <summary>
        /// Alias for setting this item as active.
        /// </summary>
        public void Highlight()
        {
            IsActiveItem = true;
        }

        /// <summary>
        /// The UI hook for highlighting the time line items.
        /// </summary>
        /// <remarks>This exists to prevent the Play Sound toggle button from activating highlighting.</remarks>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The keyboard focus changed event args.</param>
        public void TryHighlight(object sender, KeyboardFocusChangedEventArgs e)
        {
            if ((sender as ToggleButton) != null)
            {
                Highlight();
            }
        }

        /// <summary>
        /// Force update the changed property notifications.
        /// </summary>
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
            NotifyOfPropertyChange(() => PlaySound);
        }

        //// TODO: Revise the need for this.
        private void InputItemViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Update();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeLineItemViewModel"/> class.
        /// </summary>
        /// <param name="parent">The parent <see cref="TimeLineViewModel"/>.</param>
        public TimeLineItemViewModel(TimeLineViewModel parent)
        {
            _parent = parent;

            _inputItemViewModel = new InputItemViewModel();

            InputItemViewModel.PropertyChanged += InputItemViewModel_PropertyChanged;
            _inputItemViewModel.WaitFrames = 1;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeLineItemViewModel"/> class.
        /// </summary>
        public TimeLineItemViewModel()
        {

            _inputItemViewModel = new InputItemViewModel();
            _inputItemViewModel.WaitFrames = 1;
        }
    }
}
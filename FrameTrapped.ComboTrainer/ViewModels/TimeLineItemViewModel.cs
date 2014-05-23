﻿namespace FrameTrapped.ComboTrainer.ViewModels
{
    using Caliburn.Micro;

    using FrameTrapped.Input.ViewModels;
    using FrameTrapped.Input.Models;
    using System.Windows.Input;
    using System.Windows.Controls.Primitives;

    public class TimeLineItemViewModel : Screen
    {
        /// <summary>
        /// The input item view model.
        /// </summary>
        private InputItemViewModel _inputItemViewModel;

        /// <summary>
        /// The time line parent.
        /// </summary>
        private TimeLineViewModel _parent;

        /// <summary> 
        /// Indicates if the item is active.
        /// </summary>
        private bool _isActiveItem;

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

        public void DecrementFrames()
        {
            WaitFrames--;
        }

        public void IncrementFrames()
        {
            WaitFrames++;
        }

        public void DeHighlight()
        {
            IsActiveItem = false;
        }

        public void Highlight()
        {
            IsActiveItem = true;
        }

        public void TryHighlight(object sender, KeyboardFocusChangedEventArgs e)
        {
            if ((sender as ToggleButton) != null)
            {
                Highlight();
            }
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
            NotifyOfPropertyChange(() => PlaySound);
        }

        private void InputItemViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Update();
        }

        public TimeLineItemViewModel(TimeLineViewModel parent)
        {
            _parent = parent;

            _inputItemViewModel = new InputItemViewModel();

            InputItemViewModel.PropertyChanged += InputItemViewModel_PropertyChanged;
            _inputItemViewModel.WaitFrames = 1;
        }

        public TimeLineItemViewModel()
        {

            _inputItemViewModel = new InputItemViewModel();
            _inputItemViewModel.WaitFrames = 1;
        }
    }
}
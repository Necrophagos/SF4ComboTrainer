namespace FrameTrapped.ComboTrainer.ViewModels
{
    using System;

    using Caliburn.Micro;

    using FrameTrapped.Input.ViewModels;
    using FrameTrapped.Input.Utilities;
    using FrameTrapped.Input.Models;

    public class TimeLineItemViewModel : PropertyChangedBase
    {
        private InputItemViewModel inputItemViewModel;
        public InputItemViewModel InputItemViewModel
        {
            get { return inputItemViewModel; }
            set
            {
                if (value != inputItemViewModel)
                {
                    inputItemViewModel = value;
                    NotifyOfPropertyChange(() => InputItemViewModel);
                    NotifyOfPropertyChange(() => Direction);
                    NotifyOfPropertyChange(() => Light_Punch);
                    NotifyOfPropertyChange(() => Light_Punch);
                    NotifyOfPropertyChange(() => Hard_Punch);
                    NotifyOfPropertyChange(() => Light_Kick);
                    NotifyOfPropertyChange(() => Medium_Kick);
                    NotifyOfPropertyChange(() => Hard_Kick);
                }
            }
        }

        //Identifiers
        private int index;
        public int Index
        {
            get { return index; }
            set
            {
                if (value != index)
                {
                    index = value;
                    NotifyOfPropertyChange(() => Index);
                }
            }
        }

        /// <summary>
        /// Description of the Time Line Item, displays the inputs in string format.
        /// </summary>
        public string Description
        {
            get
            {
                return InputItemViewModel.Description;
            }
        }

        public int WaitFrames
        {
            get { return InputItemViewModel.WaitFrames; }
           
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
            get { 
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
        
        public TimeLineItemViewModel()
        {
            inputItemViewModel = new InputItemViewModel();
            
            InputItemViewModel.PropertyChanged  += InputItemViewModel_PropertyChanged;
            inputItemViewModel.WaitFrames = 1;
        }

    }
}
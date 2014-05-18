namespace FrameTrapped.Input.ViewModels
{

    using Caliburn.Micro;

    using FrameTrapped.Input.Models;

    public class InputItemViewModel : PropertyChangedBase
    {
        private int _index;
        private InputItemModel _inputItem;
        private bool _sendInputs;

        public InputItemModel InputItem
        {
            get { return _inputItem; }
            set
            {
                if (value != _inputItem)
                {
                    _inputItem = value;
                    NotifyOfPropertyChange(() => InputItem);
                    NotifyOfPropertyChange(() => Direction);
                    NotifyOfPropertyChange(() => Light_Punch);
                    NotifyOfPropertyChange(() => Medium_Punch);
                    NotifyOfPropertyChange(() => Hard_Punch);
                    NotifyOfPropertyChange(() => Light_Kick);
                    NotifyOfPropertyChange(() => Medium_Kick);
                    NotifyOfPropertyChange(() => Hard_Kick); 
                }
            }
        }

        //Identifiers
        public int Index
        {
            get { return _index; }
            set
            {
                if (value != _index)
                {
                    _index = value;
                    NotifyOfPropertyChange(() => Index);
                }
            }
        }         

        //Options
        public bool SendInputs
        {
            get { return _sendInputs; }
            set
            {
                if (value != _sendInputs)
                {
                    _sendInputs = value;
                    NotifyOfPropertyChange(() => SendInputs);
                }
            }
        }

        public bool PlaySound
        {
            get { return _inputItem.PlaySound; }
            set
            {
                if (value != _inputItem.PlaySound)
                {
                    _inputItem.PlaySound = value;
                    NotifyOfPropertyChange(() => PlaySound); 
                }
            }
        }

        public int WaitFrames
        {
            get { return InputItem.Frames; }
            set
            {
                if (value != _inputItem.Frames)
                {
                    InputItem.Frames = value;
                    NotifyOfPropertyChange(() => WaitFrames); 
                }
            }
        }

        #region Input Property Definitions

        //Directions
        public InputCommandModel.DirectionStateEnum Direction
        {
            get
            {
                return _inputItem.InputCommandState.DirectionState;
            }
            set
            {
                _inputItem.InputCommandState.DirectionState = value;
                NotifyOfPropertyChange(() => Direction); 
            }
        }

        //Punches
        public bool Light_Punch
        {
            get { return _inputItem.InputCommandState.LightPunch == InputCommandModel.ButtonStateEnum.Pressed; }
            set
            {
                if (value)
                {
                    _inputItem.InputCommandState.LightPunch = InputCommandModel.ButtonStateEnum.Pressed;
                }
                else
                {
                    _inputItem.InputCommandState.LightPunch = InputCommandModel.ButtonStateEnum.Released;
                }

                NotifyOfPropertyChange(() => Light_Punch);
                NotifyOfPropertyChange(() => CommandPressed); 
            }
        }

        public bool Medium_Punch
        {
            get { return _inputItem.InputCommandState.MediumPunch == InputCommandModel.ButtonStateEnum.Pressed; }
            set
            {
                if (value)
                {
                    _inputItem.InputCommandState.MediumPunch = InputCommandModel.ButtonStateEnum.Pressed;
                }
                else
                {
                    _inputItem.InputCommandState.MediumPunch = InputCommandModel.ButtonStateEnum.Released;

                }

                NotifyOfPropertyChange(() => Medium_Punch);
                NotifyOfPropertyChange(() => CommandPressed); 
            }
        }

        public bool Hard_Punch
        {
            get { return _inputItem.InputCommandState.HardPunch == InputCommandModel.ButtonStateEnum.Pressed; }
            set
            {
                if (value)
                {
                    _inputItem.InputCommandState.HardPunch = InputCommandModel.ButtonStateEnum.Pressed;
                }
                else
                {
                    _inputItem.InputCommandState.HardPunch = InputCommandModel.ButtonStateEnum.Released;

                }

                NotifyOfPropertyChange(() => Hard_Punch);
                NotifyOfPropertyChange(() => CommandPressed); 
            }
        }

        //Kicks
        public bool Light_Kick
        {
            get { return _inputItem.InputCommandState.LightKick == InputCommandModel.ButtonStateEnum.Pressed; }
            set
            {
                if (value)
                {
                    _inputItem.InputCommandState.LightKick = InputCommandModel.ButtonStateEnum.Pressed;
                }
                else
                {
                    _inputItem.InputCommandState.LightKick = InputCommandModel.ButtonStateEnum.Released;

                }

                NotifyOfPropertyChange(() => Light_Kick);
                NotifyOfPropertyChange(() => CommandPressed); 
            }
        }

        public bool Medium_Kick
        {
            get { return _inputItem.InputCommandState.MediumKick == InputCommandModel.ButtonStateEnum.Pressed; }
            set
            {
                if (value)
                {
                    _inputItem.InputCommandState.MediumKick = InputCommandModel.ButtonStateEnum.Pressed;
                }
                else
                {
                    _inputItem.InputCommandState.MediumKick = InputCommandModel.ButtonStateEnum.Released;

                }

                NotifyOfPropertyChange(() => Medium_Kick);
                NotifyOfPropertyChange(() => CommandPressed); 
            }
        }

        public bool Hard_Kick
        {
            get { return _inputItem.InputCommandState.HardKick == InputCommandModel.ButtonStateEnum.Pressed; }
            set
            {
                if (value)
                {
                    _inputItem.InputCommandState.HardKick = InputCommandModel.ButtonStateEnum.Pressed;
                }
                else
                {
                    _inputItem.InputCommandState.HardKick = InputCommandModel.ButtonStateEnum.Released;

                }

                NotifyOfPropertyChange(() => Hard_Kick);
                NotifyOfPropertyChange(() => CommandPressed); 
            }
        }

        public bool CommandPressed
        {
            get {
                return Light_Punch ||
                       Light_Kick ||
                       Medium_Punch ||
                       Medium_Kick || 
                       Hard_Punch ||
                       Hard_Kick;
            }
        }
        #endregion

        private void ResetDirections()
        {
            _inputItem.InputCommandState.DirectionState = InputCommandModel.DirectionStateEnum.Neutral;
            NotifyOfPropertyChange(() => Direction);
        } 
        public string Serialize()
        {
            return InputItem.Serialize();
        }

        public static InputItemViewModel Deserialize(string stringValue)
        {
            //Deserialize actual timeline item
            InputItemModel tmpTimeLineItem = InputItemModel.Deserialize(stringValue);

            //Setup TimeLineItemViewModel
            InputItemViewModel result = new InputItemViewModel();
            result.InputItem = tmpTimeLineItem;
            result.Index = -1;

            return result;

        }

        public InputItemViewModel()
        {
            this.InputItem = new InputItemModel();
            this.WaitFrames = 1;
            this.SendInputs = true;
        }
    }
}

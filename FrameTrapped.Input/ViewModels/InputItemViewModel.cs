namespace FrameTrapped.Input.ViewModels
{

    using Caliburn.Micro;

    using FrameTrapped.Input.Models;

    /// <summary>
    /// The input item view model class.
    /// </summary>
    public class InputItemViewModel : PropertyChangedBase
    {
        /// <summary>
        /// The index.
        /// </summary>
        private int _index;

        /// <summary>
        /// The input item model.
        /// </summary>
        private InputItemModel _inputItem;

        /// <summary>
        /// The send inputs flag.
        /// </summary>
        private bool _sendInputs;

        /// <summary>
        /// Gets or sets the input item model.
        /// </summary>
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

        /// <summary>
        /// Gets of sets the index of the item.
        /// </summary>
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

        /// <summary>
        /// Gets or sets a value indicating whether this input should be sent.
        /// </summary>
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

        /// <summary>
        /// Gets or sets a value indicating whether this input should play a sound.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the wait frames of the input.
        /// </summary>
        public int WaitFrames
        {
            get { return InputItem.Frames; }
            set
            {
                InputItem.Frames = value;
                NotifyOfPropertyChange(() => WaitFrames);

            }
        }

        #region Input Property Definitions

        /// <summary>
        /// Gets or sets the direction state.
        /// </summary>
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

        /// <summary>
        /// Gets or sets a value indicating whether the light punch is pressed.
        /// </summary>
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

        /// <summary>
        /// Gets or sets a value indicating whether the medium punch is pressed.
        /// </summary>
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

        /// <summary>
        /// Gets or sets a value indicating whether the hard punch is pressed.
        /// </summary>
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

        /// <summary>
        /// Gets or sets a value indicating whether the light kick is pressed.
        /// </summary>
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

        /// <summary>
        /// Gets or sets a value indicating whether the medium kick is pressed.
        /// </summary>
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

        /// <summary>
        /// Gets or sets a value indicating whether the hard kick is pressed.
        /// </summary>
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

        /// <summary>
        /// Gets a value indicating whether any commands were pressed.
        /// </summary>
        public bool CommandPressed
        {
            get
            {
                return Light_Punch ||
                       Light_Kick ||
                       Medium_Punch ||
                       Medium_Kick || 
                       Hard_Punch ||
                       Hard_Kick;
            }
        }
        #endregion

        /// <summary>
        /// Resets the direction.
        /// </summary>
        private void ResetDirections()
        {
            _inputItem.InputCommandState.DirectionState = InputCommandModel.DirectionStateEnum.Neutral;
            NotifyOfPropertyChange(() => Direction);
        } 

        /// <summary>
        /// The deserialize function.
        /// </summary>
        /// <param name="stringValue">The <see cref="string"/> to deserialize.</param>
        /// <returns>A new <see cref="InputItemViewModel"/>.</returns>
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

        /// <summary>
        /// Initializes a new instance of the <see cref="InputItemViewModel"/> class.
        /// </summary>
        public InputItemViewModel()
        {
            this.InputItem = new InputItemModel();
            this.WaitFrames = 1;
            this.SendInputs = true;
        }
    }
}

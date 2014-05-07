namespace SF4ComboTrainer.Input.ViewModels
{
    using System;

    using Caliburn.Micro;

    using SF4ComboTrainer.Input.Models;
    using SF4ComboTrainer.Input.Utilities;

    public class InputItemViewModel : PropertyChangedBase
    {
        private InputItemModel inputItem;
        public InputItemModel InputItem
        {
            get { return inputItem; }
            set
            {
                if (value != inputItem)
                {
                    inputItem = value;
                    NotifyOfPropertyChange(() => InputItem);
                    NotifyOfPropertyChange(() => Direction);
                    NotifyOfPropertyChange(() => Light_Punch);
                    NotifyOfPropertyChange(() => Medium_Punch);
                    NotifyOfPropertyChange(() => Hard_Punch);
                    NotifyOfPropertyChange(() => Light_Kick);
                    NotifyOfPropertyChange(() => Medium_Kick);
                    NotifyOfPropertyChange(() => Hard_Kick);
                    NotifyOfPropertyChange(() => Description);
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
                InputCommandModel state = inputItem.InputCommandState;
                if (state == null)
                {
                    return "No inputs.";
                }

                inputItem.InputItemType = state.NonePressed ? InputItemModel.InputItemTypeEnum.Wait : InputItemModel.InputItemTypeEnum.Press;

                if (!state.NonePressed && WaitFrames == 1)
                {
                    return InputItem.InputItemType.ToString() + " " + InputItem.GetInputString();
                }
                else if (!state.NonePressed && WaitFrames > 1)
                {
                    return InputItem.InputItemType.ToString() + " " + InputItem.GetInputString() + " and wait " + WaitFrames + " frames";
                }
                else
                {
                    return "Wait " + WaitFrames + " frames";
                }
            }
        }

        //Options
        private bool sendInputs;
        public bool SendInputs
        {
            get { return sendInputs; }
            set
            {
                if (value != sendInputs)
                {
                    sendInputs = value;
                    NotifyOfPropertyChange(() => SendInputs);
                }
            }
        }

        public bool PlaySound
        {
            get { return inputItem.PlaySound; }
            set
            {
                if (value != inputItem.PlaySound)
                {
                    inputItem.PlaySound = value;
                    NotifyOfPropertyChange(() => PlaySound);
                    NotifyOfPropertyChange(() => Description);
                }
            }
        }

        public int WaitFrames
        {
            get { return InputItem.Frames; }
            set
            {
                if (value != inputItem.Frames)
                {
                    InputItem.Frames = value;
                    NotifyOfPropertyChange(() => WaitFrames);
                    NotifyOfPropertyChange(() => Description);
                }
            }
        }

        #region Input Property Definitions

        //Directions
        public InputCommandModel.DirectionStateEnum Direction
        {
            get
            {
                return inputItem.InputCommandState.DirectionState;
            }
            set
            {
                inputItem.InputCommandState.DirectionState = value;
                NotifyOfPropertyChange(() => Direction);
                NotifyOfPropertyChange(() => Description);

            }
        }

        //Punches
        public bool Light_Punch
        {
            get { return inputItem.InputCommandState.LightPunch == InputCommandModel.ButtonStateEnum.Pressed; }
            set
            {
                if (value)
                {
                    inputItem.InputCommandState.LightPunch = InputCommandModel.ButtonStateEnum.Pressed;
                }
                else
                {
                    inputItem.InputCommandState.LightPunch = InputCommandModel.ButtonStateEnum.Released;
                }

                NotifyOfPropertyChange(() => Light_Punch);
                NotifyOfPropertyChange(() => CommandPressed);
                NotifyOfPropertyChange(() => Description);
            }
        }
        public bool Medium_Punch
        {
            get { return inputItem.InputCommandState.MediumPunch == InputCommandModel.ButtonStateEnum.Pressed; }
            set
            {
                if (value)
                {
                    inputItem.InputCommandState.MediumPunch = InputCommandModel.ButtonStateEnum.Pressed;
                }
                else
                {
                    inputItem.InputCommandState.MediumPunch = InputCommandModel.ButtonStateEnum.Released;

                }

                NotifyOfPropertyChange(() => Medium_Punch);
                NotifyOfPropertyChange(() => CommandPressed);
                NotifyOfPropertyChange(() => Description);
            }
        }
        public bool Hard_Punch
        {
            get { return inputItem.InputCommandState.HardPunch == InputCommandModel.ButtonStateEnum.Pressed; }
            set
            {
                if (value)
                {
                    inputItem.InputCommandState.HardPunch = InputCommandModel.ButtonStateEnum.Pressed;
                }
                else
                {
                    inputItem.InputCommandState.HardPunch = InputCommandModel.ButtonStateEnum.Released;

                }

                NotifyOfPropertyChange(() => Hard_Punch);
                NotifyOfPropertyChange(() => CommandPressed);
                NotifyOfPropertyChange(() => Description);
            }
        }

        //Kicks
        public bool Light_Kick
        {
            get { return inputItem.InputCommandState.LightKick == InputCommandModel.ButtonStateEnum.Pressed; }
            set
            {
                if (value)
                {
                    inputItem.InputCommandState.LightKick = InputCommandModel.ButtonStateEnum.Pressed;
                }
                else
                {
                    inputItem.InputCommandState.LightKick = InputCommandModel.ButtonStateEnum.Released;

                }

                NotifyOfPropertyChange(() => Light_Kick);
                NotifyOfPropertyChange(() => CommandPressed);
                NotifyOfPropertyChange(() => Description);
            }
        }
        public bool Medium_Kick
        {
            get { return inputItem.InputCommandState.MediumKick == InputCommandModel.ButtonStateEnum.Pressed; }
            set
            {
                if (value)
                {
                    inputItem.InputCommandState.MediumKick = InputCommandModel.ButtonStateEnum.Pressed;
                }
                else
                {
                    inputItem.InputCommandState.MediumKick = InputCommandModel.ButtonStateEnum.Released;

                }

                NotifyOfPropertyChange(() => Medium_Kick);
                NotifyOfPropertyChange(() => CommandPressed);
                NotifyOfPropertyChange(() => Description);
            }
        }
        public bool Hard_Kick
        {
            get { return inputItem.InputCommandState.HardKick == InputCommandModel.ButtonStateEnum.Pressed; }
            set
            {
                if (value)
                {
                    inputItem.InputCommandState.HardKick = InputCommandModel.ButtonStateEnum.Pressed;
                }
                else
                {
                    inputItem.InputCommandState.HardKick = InputCommandModel.ButtonStateEnum.Released;

                }

                NotifyOfPropertyChange(() => Hard_Kick);
                NotifyOfPropertyChange(() => CommandPressed);
                NotifyOfPropertyChange(() => Description);
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
            inputItem.InputCommandState.DirectionState = InputCommandModel.DirectionStateEnum.Neutral;
            NotifyOfPropertyChange(() => Direction);
        }

        public void Action(SF4Control sf4Control)
        {
            this.InputItem.Action(sf4Control, this.sendInputs);
        }

        public string Serialize()
        {
            return this.InputItem.Serialize();
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
        }
    }
}

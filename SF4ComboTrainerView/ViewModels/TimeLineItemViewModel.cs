using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SF4ComboTrainerModel;
using SF4ComboTrainerView;

namespace SF4ComboTrainerViewModel
{
    public class TimeLineItemViewModel : ObservableObject
    {

        private InputItemModel inputItem = new PressItemModel();
        public InputItemModel InputItem
        {
            get { return inputItem; }
            set
            {
                if (value != inputItem)
                {
                    inputItem = value;
                    OnPropertyChanged("InputItem");
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
                    OnPropertyChanged("Index");
                }
            }
        }

        private string description;
        public string Description
        {
            get { return inputItem.Description; }
            set
            {
                if (value != description)
                {
                    description = value;
                    OnPropertyChanged("Description");
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
                    OnPropertyChanged("SendInputs");
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
                    OnPropertyChanged("PlaySound");
                }
            }
        }

        private int waitFrames;
        public int WaitFrames
        {
            get { return inputItem.GetFrameDuration(); }
            set
            {
                if (value != inputItem.Frames)
                {
                    inputItem.Frames = value;
                    OnPropertyChanged("WaitFrames");
                }
            }
        }

        #region Input Property Definitions

        //Directions
        public bool Direction_Up
        {
            get { return inputItem.InputState.Up; }
            set
            {
                if (value != inputItem.InputState.Up)
                {
                    inputItem.InputState.Up = value;
                    OnPropertyChanged("Direction_Up");
                }
            }
        }
        public bool Direction_Down
        {
            get { return inputItem.InputState.Down; }
            set
            {
                if (value != inputItem.InputState.Down)
                {
                    inputItem.InputState.Down = value;
                    OnPropertyChanged("Direction_Down");
                }
            }
        }
        public bool Direction_Left
        {
            get { return inputItem.InputState.Left; }
            set
            {
                if (value != inputItem.InputState.Left)
                {
                    inputItem.InputState.Left = value;
                    OnPropertyChanged("Direction_Left");
                }
            }
        }
        public bool Direction_Right
        {
            get { return inputItem.InputState.Right; }
            set
            {
                if (value != inputItem.InputState.Right)
                {
                    inputItem.InputState.Right = value;
                    OnPropertyChanged("Direction_Right");
                }
            }
        }
        public bool Direction_Forward
        {
            get { return inputItem.InputState.Forward; }
            set
            {
                if (value != inputItem.InputState.Forward)
                {
                    inputItem.InputState.Forward = value;
                    OnPropertyChanged("Direction_Forward");
                }
            }
        }
        public bool Direction_Backward
        {
            get { return inputItem.InputState.Backward; }
            set
            {
                if (value != inputItem.InputState.Backward)
                {
                    inputItem.InputState.Backward = value;
                    OnPropertyChanged("Direction_Backward");
                }
            }
        }
        //Punches

        public bool Light_Punch
        {
            get { return inputItem.InputState.LightPunch; }
            set
            {
                if (value != inputItem.InputState.LightPunch)
                {
                    inputItem.InputState.LightPunch = value;
                    OnPropertyChanged("Light_Punch");
                }
            }
        }
        public bool Medium_Punch
        {
            get { return inputItem.InputState.MediumPunch; }
            set
            {
                if (value != inputItem.InputState.MediumPunch)
                {
                    inputItem.InputState.MediumPunch = value;
                    OnPropertyChanged("Medium_Punch");
                }
            }
        }
        public bool Hard_Punch
        {
            get { return inputItem.InputState.HardPunch; }
            set
            {
                if (value != inputItem.InputState.HardPunch)
                {
                    inputItem.InputState.HardPunch = value;
                    OnPropertyChanged("Hard_Punch");
                }
            }
        }

        //Kicks
        public bool Light_Kick
        {
            get { return inputItem.InputState.LightKick; }
            set
            {
                if (value != inputItem.InputState.LightKick)
                {
                    inputItem.InputState.LightKick = value;
                    OnPropertyChanged("Light_Kick");
                }
            }
        }
        public bool Medium_Kick
        {
            get { return inputItem.InputState.MediumKick; }
            set
            {
                if (value != inputItem.InputState.MediumKick)
                {
                    inputItem.InputState.MediumKick = value;
                    OnPropertyChanged("Medium_Kick");
                }
            }
        }
        public bool Hard_Kick
        {
            get { return inputItem.InputState.HardKick; }
            set
            {
                if (value != inputItem.InputState.Up)
                {
                    inputItem.InputState.HardKick = value;
                    OnPropertyChanged("Hard_Kick");
                }
            }
        }

        #endregion

        public TimeLineItemViewModel(){
            this.inputItem = new PressItemModel();
        }

        public void Action(SF4Record recorder)
        {
            this.InputItem.Action(recorder, this.sendInputs);
        }

        internal string Serialize()
        {
            return this.InputItem.Serialize();
        }

        static internal TimeLineItemViewModel Deserialize(string stringValue)
        {
            //Deserialize actual timeline item
            InputItemModel tmpTimeLineItem = InputItemModel.Deserialize(stringValue);

            //Setup TimeLineItemViewModel
            TimeLineItemViewModel result = new TimeLineItemViewModel();
            result.InputItem = tmpTimeLineItem;
            result.WaitFrames = tmpTimeLineItem.GetFrameDuration();
            result.Description = tmpTimeLineItem.Description;
            result.Index = -1;
            result.PlaySound = tmpTimeLineItem.PlaySound;

            return result;

        }
    }
}

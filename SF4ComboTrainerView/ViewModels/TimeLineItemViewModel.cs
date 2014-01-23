using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SF4ComboTrainerModel;

namespace SF4ComboTrainerView
{
    public class TimeLineItemViewModel : ObservableObject
    {
        private TimeLineItem timeLineItem;
        public TimeLineItem TimeLineItem
        {
            get { return timeLineItem; }
            set
            {
                if (value != timeLineItem)
                {
                    timeLineItem = value;
                    OnPropertyChanged("TimeLineItem");
                }
            }
        }

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
            get { return timeLineItem.Description; }
            set
            {
                if (value != description)
                {
                    description = value;
                    OnPropertyChanged("Description");
                }
            }
        }

        private bool sendInputs;
        public bool SendInputs
        {
            get { return sendInputs;}
            set { 
                    if(value != sendInputs)
                    {
                        sendInputs = value;
                        OnPropertyChanged("SendInputs");
                    }
                }
        }
    

        public bool PlaySound
        {
            get { return timeLineItem.PlaySound; }
            set
            {
                if (value != timeLineItem.PlaySound)
                {
                    timeLineItem.PlaySound = value;
                    OnPropertyChanged("PlaySound");
                }
            }
        }

        private int waitFrames;
        public int WaitFrames
        {
            get { return timeLineItem.GetFrameDuration(); }
            set
            {
                if (value != waitFrames)
                {
                    waitFrames = value;
                    OnPropertyChanged("WaitFrames");
                }
            }
        }

        public void Action(SF4Record recorder)
        {
            this.timeLineItem.Action(recorder, this.sendInputs);
        }

        internal string Serialize()
        {
            return this.timeLineItem.Serialize();
        }

        static internal TimeLineItemViewModel Deserialize(string stringValue)
        {
            //Deserialize actual timeline item
            TimeLineItem tmpTimeLineItem =  TimeLineItem.Deserialize(stringValue);

            //Setup TimeLineItemViewModel
            TimeLineItemViewModel result = new TimeLineItemViewModel();
            result.TimeLineItem = tmpTimeLineItem;
            result.WaitFrames = tmpTimeLineItem.GetFrameDuration();
            result.Description = tmpTimeLineItem.Description;
            result.Index = -1;
            result.PlaySound = tmpTimeLineItem.PlaySound;

            return result;

        }
    }
}

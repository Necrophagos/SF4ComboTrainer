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
    }
}

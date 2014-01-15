using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SF4ComboTrainerModel;

namespace SF4ComboTrainerView
{
    class TimeLineViewModel : ObservableObject
    {
        private ObservableCollection<TimeLineItemViewModel> timeLineItems;
        public ObservableCollection<TimeLineItemViewModel> TimeLineItems
        {
            get { return timeLineItems; }
            set
            {
                if (value != timeLineItems)
                {
                    timeLineItems = value;
                    OnPropertyChanged("TimeLineItems");
                }
            }
        }

        private SF4Record recorder;
        public SF4Record Recorder
        {
            get { return recorder; }
            set
            {
                if (value != recorder)
                {
                    recorder = value;
                    OnPropertyChanged("Recorder");
                }
            }
        }

        public void SaveTimeLine()
        {
            throw new NotImplementedException();
        }

        public void LoadTimeLine()
        {
            throw new NotImplementedException();
        }

        public void AppendTimeLine()
        {
            throw new NotImplementedException();
        }

        public void ClearTimeLine()
        {
            throw new NotImplementedException();
        }

        public void RecordStart()
        {
            throw new NotImplementedException();
        }

        public void RecordStop()
        {
            throw new NotImplementedException();
        }

        public void PlaybackStart()
        {
            throw new NotImplementedException();
        }

        public void PlaybackStop()
        {
            throw new NotImplementedException();
        }

        public void LoopPlaybackStart()
        {
            throw new NotImplementedException();
        }

        public void SetSteamVersion()
        {
            throw new NotImplementedException();
        }
    }
}

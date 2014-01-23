using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SF4ComboTrainerModel;
using Microsoft.Win32;

namespace SF4ComboTrainerView
{
    class TimeLineViewModel : ObservableObject
    {
        #region Propeties and Fields
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

        private bool autoSwitchToSF4;
        public bool AutoSwitchToSF4
        {
            get { return autoSwitchToSF4; }
            set
            {
                if (value != autoSwitchToSF4)
                {
                    autoSwitchToSF4 = value;
                    OnPropertyChanged("AutoSwitchToSF4");
                }
            }
        }

        private bool isSteamVersion;
        public bool IsSteamVersion
        {
            get { return isSteamVersion; }
            set
            {
                if (value != isSteamVersion)
                {
                    isSteamVersion = value;
                    OnPropertyChanged("IsSteamVersion");
                }
            }
        }

        private TimeLineItemViewModel selectedItem;
        public TimeLineItemViewModel SelectedItem
        {
            get { return selectedItem; }
            set
            {
                if (value != selectedItem)
                {
                    selectedItem = value;
                    OnPropertyChanged("SelectedItem");
                }
            }
        }

        #endregion

        #region Commands and Methods

        public void SaveTimeLine()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "SF4 Combo|*.cmb";
            saveFileDialog.Title = "Save your combo";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(saveFileDialog.FileName))
                {
                    foreach (TimeLineItemViewModel item in timeLineItems)
                    {
                        file.WriteLine(item.Serialize());
                    }
                }
            }
        }

        public void LoadTimeLine(bool append = false)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "SF4 Combo|*.cmb";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName != "")
            {
                string[] lines = System.IO.File.ReadAllLines(openFileDialog.FileName);

                if (!append) ClearTimeLine();

                foreach (String line in lines)
                {
                    timeLineItems.Add(TimeLineItemViewModel.Deserialize(line));
                }
            }
        }

        public void AppendTimeLine()
        {
            LoadTimeLine(true);
        }

        public void ClearTimeLine()
        {
            timeLineItems.Clear();
        }

        public void RecordStart()
        {
            recorder.StartRecording();
        }

        public void RecordStop()
        {
            recorder.StopRecording();
        }

        public void PlaybackStart()
        {
            if (AutoSwitchToSF4)
                if(!Recorder.SwitchToSF4()) return;

            Recorder.WaitFrames(10);

            
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

        private void playTimeline()
        {

            recorder.ResetLockupTimer();
            for (int i = 0; i < timeLineItems.Count; i++)
            {
                TimeLineItemViewModel item = (TimeLineItemViewModel)TimeLineItems[i];

                //highlighting of current item
                SelectedItem = item;

                // if we aren't in a match (defined by being on a menu or pause is selected) the play timeline stops.
                if (recorder.InMatch)
                    item.Action(recorder);
                else
                {
                    // Get the last item in the list
                    i = TimeLineItems.Count - 1;
                    item = (TimeLineItemViewModel)TimeLineItems[i];

                    SelectedItem = item;
                    
                    //also kill loop
                    PlaybackStop();

                    string message = "The combo trainer has detected that SF4 didn't produce any new frames in the last 3 seconds. Make sure that\n\na) Street Fighter 4 is running and inside a match or training mode\nb) Street Fighter is not paused\nc) You are running the latest version of Street Fighter 4 AEv2012\nd) Stage Quality in your SF4 graphic settings is set to HIGH";
                    throw new Exception(message);
                }
            }

            recorder.ReleaseALL();

            //// Get the last item in the list
            //TimeLineItem lastItem = (TimeLineItem)TimeLine.Items[TimeLine.Items.Count - 1];
            SelectedItem = (TimeLineItemViewModel)TimeLineItems[TimeLineItems.Count - 1];
            PlaybackStop();
        }
    } 
        #endregion
}

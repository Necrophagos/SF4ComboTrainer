namespace FrameTrapped.ComboTrainer.ViewModels
{
    using Microsoft.Win32;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Windows;

    using Caliburn.Micro;

    using FrameTrapped.Input.Models;
    using FrameTrapped.Input.Utilities;
    using FrameTrapped.Input.ViewModels;
    using FrameTrapped.ComboTrainer.Controls;
    using FrameTrapped.Utilities;
    using FrameTrapped.ComboTrainer.Utilities;
   

    public class TimeLineViewModel : Conductor<TimeLineItemViewModel>.Collection.OneActive
    {
        private bool _autoSwitchToSF4;
        private bool _isSteamVersion;
        private SF4Control _sf4Control;


        public bool AutoSwitchToSF4
        {
            get { return _autoSwitchToSF4; }
            set
            {
                if (value != _autoSwitchToSF4)
                {
                    _autoSwitchToSF4 = value;
                    NotifyOfPropertyChange(() => AutoSwitchToSF4);
                }
            }
        }

        public bool IsSteamVersion
        {
            get { return _isSteamVersion; }
            set
            {
                if (value != _isSteamVersion)
                {
                    _isSteamVersion = value;
                    NotifyOfPropertyChange(() => IsSteamVersion);
                }
            }
        }

        public SF4Control SF4Control
        {
            get { return _sf4Control; }
            set
            {
                if (value != _sf4Control)
                {
                    _sf4Control = value;
                    NotifyOfPropertyChange(() => SF4Control);
                }
            }
        }

        public bool CanRemoveItem
        {
            get { return Items.Count > 0; }
        }

        public override IEnumerable<TimeLineItemViewModel> GetChildren()
        {
            return base.GetChildren();
        }

        public void AddTimeLineItem()
        {
            TimeLineItemViewModel newItem = new TimeLineItemViewModel();
            Items.Add(newItem);

            ActivateItem(Items.Last());

            NotifyOfPropertyChange(() => CanRemoveItem);
            NotifyOfPropertyChange(() => Items);
        }

        public void RemoveTimeLineItem()
        {
            if (CanRemoveItem)
            {
                Items.RemoveAt(Items.Count - 1);

                ActivateItem(Items.Last());

                NotifyOfPropertyChange(() => CanRemoveItem);
                NotifyOfPropertyChange(() => Items);
            }
        }

        public void AppendTimeLine()
        {
            OpenTimeLine(true);
        }

        public void ClearTimeLine()
        {
            Items.Clear();
        }

        public void LoopPlaybackStart()
        {
            throw new NotImplementedException();
        }

        public void OpenTimeLine(bool append = false)
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
                    TimeLineItemViewModel timeLineItemViewModel = new TimeLineItemViewModel();
                    timeLineItemViewModel.InputItemViewModel = InputItemViewModel.Deserialize(line);
                    Items.Add(timeLineItemViewModel);
                }
            }
        }

        public void PlayTimeline()
        {

            _sf4Control.ResetLockupTimer();
            for (int i = 0; i < Items.Count; i++)
            {
                TimeLineItemViewModel item = (TimeLineItemViewModel)Items[i];

                //highlighting of current item
                //SelectedTimeLineItemViewModel = item;

                // if we aren't in a match (defined by being on a menu or pause is selected) the play timeline stops.
                if (_sf4Control.InMatch)
                    item.InputItemViewModel.Action(_sf4Control);
                else
                {
                    // Get the last item in the list
                    i = Items.Count - 1;
                    item = (TimeLineItemViewModel)Items[i];

                    //SelectedTimeLineItemViewModel = item;

                    //also kill loop
                    PlaybackStop();

                    string message = "The combo trainer has detected that SF4 didn't produce any new frames in the last 3 seconds. Make sure that\n\na) Street Fighter 4 is running and inside a match or training mode\nb) Street Fighter is not paused\nc) You are running the latest version of Street Fighter 4 AEv2012\nd) Stage Quality in your SF4 graphic settings is set to HIGH";
                    throw new Exception(message);
                }
            }

            _sf4Control.ReleaseALL();

            //// Get the last item in the list
            //TimeLineItemModel lastItem = (TimeLineItemModel)TimeLine.Items[TimeLine.Items.Count - 1];
            //SelectedTimeLineItemViewModel = (TimeLineItemViewModel)Items[Items.Count - 1];
            PlaybackStop();
        }

        public void PlaybackStart()
        {
            if (AutoSwitchToSF4)
            {
                if (!SF4Control.SwitchToSF4())
                {
                    return;
                }
                else
                {
                    
                }
            }
            SF4Control.ResetLockupTimer();
            SF4Control.WaitFrames(10);

            try
            {
                PlayTimeline();
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        public void PlaybackStop()
        {
            //throw new NotImplementedException();
        }

        //private void RecordStart()
        //{
        //    _sf4Control.StartRecording();
        //}

        //private void RecordStop()
        //{
        //    _sf4Control.StopRecording();
        //}

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
                    foreach (TimeLineItemViewModel item in Items)
                    {
                        file.WriteLine(item.InputItemViewModel.Serialize());
                    }
                }
            }
        } 

        public TimeLineViewModel()
        {

            TimeLineItemViewModel initialWaitItemViewModel = new TimeLineItemViewModel();
            
            initialWaitItemViewModel.InputItemViewModel.WaitFrames = 10;

            Items.Add(initialWaitItemViewModel);

            _autoSwitchToSF4 = true;
            _isSteamVersion = true;

            _sf4Control = new SF4Control(new SF4Memory(IsSteamVersion));

            // SelectedTimeLineItemViewModel = Items[0];
            //ActivateItem(Items[0]);
        }

    }
}

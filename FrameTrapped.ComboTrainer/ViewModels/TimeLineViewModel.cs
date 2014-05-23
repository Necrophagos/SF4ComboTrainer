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
    using FrameTrapped.Utilities;
    using FrameTrapped.ComboTrainer.Utilities;
    using FrameTrapped.ComboTrainer.Messages;


    public class TimeLineViewModel : Conductor<TimeLineViewModel>.Collection.OneActive,
                                    IHandle<AddTimeLineItemMessage>,
                                    IHandle<SaveTimeLineMessage>,
                                    IHandle<OpenTimeLineMessage>
    {
        private IEventAggregator _events;

        private bool _autoSwitchToSF4;

        private bool _isSteamVersion;

        private TimeLineItemViewModel _selectedTimeLineItem;

        public TimeLineItemViewModel SelectedTimeLineItem
        {
            get { return _selectedTimeLineItem; }
            set
            {
                if (_selectedTimeLineItem != null)
                {
                    _selectedTimeLineItem.DeHighlight();
                }

                _selectedTimeLineItem = value;
                _selectedTimeLineItem.Highlight();
                NotifyOfPropertyChange(() => SelectedTimeLineItem);
            }
        }

        public BindableCollection<TimeLineItemViewModel> TimeLineItems { get; private set; }

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

        public bool CanRemoveItem
        {
            get { return TimeLineItems.Count > 1; }
        }

        public void AddTimeLineItem()
        {
            TimeLineItemViewModel newTimeLineItemViewModel = new TimeLineItemViewModel(this);
            AddTimeLineItem(newTimeLineItemViewModel);

        }

        public void AddTimeLineItem(TimeLineItemViewModel timeLineItemViewModel)
        {
            TimeLineItems.Insert(TimeLineItems.IndexOf(SelectedTimeLineItem) + 1, timeLineItemViewModel);

            SelectedTimeLineItem = timeLineItemViewModel;


            NotifyOfPropertyChange(() => CanRemoveItem);
            NotifyOfPropertyChange(() => TimeLineItems);
        }

        public void AppendTimeLine()
        {
            OpenTimeLine(string.Empty, true);
        }

        public void RemoveTimeLineItem()
        {
            if (CanRemoveItem)
            {
                int index = TimeLineItems.IndexOf(SelectedTimeLineItem);

                TimeLineItems.Remove(SelectedTimeLineItem);
                if (index != TimeLineItems.Count)
                {
                    SelectedTimeLineItem = TimeLineItems[index];
                }
                else
                {
                    SelectedTimeLineItem = TimeLineItems.Last();
                }
                NotifyOfPropertyChange(() => CanRemoveItem);
                NotifyOfPropertyChange(() => TimeLineItems);
            }
        }

        public void ClearTimeLine()
        {
            TimeLineItems.Clear();
        }

        public void LoopPlaybackStart()
        {
            throw new NotImplementedException();
        }

        public void PlaybackStart()
        {
            if (AutoSwitchToSF4)
            {
                _events.Publish(new FocusStreetFighterMessage());
                _events.Publish(new PlayTimeLineMessage(TimeLineItems));
            }
        }

        public void OpenTimeLine(string filePath, bool append = false)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();

                openFileDialog.Filter = "SF4 Combo|*.cmb";
                openFileDialog.RestoreDirectory = true;
                openFileDialog.ShowDialog();
                if (openFileDialog.FileName == "")
                {
                    return;
                }
                filePath = openFileDialog.FileName;
            }

            string[] lines = System.IO.File.ReadAllLines(filePath);

            if (!append) ClearTimeLine();

            foreach (String line in lines)
            {
                TimeLineItemViewModel timeLineItemViewModel = new TimeLineItemViewModel(this);
                InputItemViewModel inputItem = InputItemViewModel.Deserialize(line);
                timeLineItemViewModel.WaitFrames = inputItem.WaitFrames;
                timeLineItemViewModel.Direction = inputItem.Direction;

                timeLineItemViewModel.Light_Punch = inputItem.Light_Punch;
                timeLineItemViewModel.Medium_Punch = inputItem.Medium_Punch;
                timeLineItemViewModel.Hard_Punch = inputItem.Hard_Punch;

                timeLineItemViewModel.Light_Kick = inputItem.Light_Kick;
                timeLineItemViewModel.Medium_Kick = inputItem.Medium_Kick;
                timeLineItemViewModel.Hard_Kick = inputItem.Hard_Kick;

                TimeLineItems.Add(timeLineItemViewModel);

            }
        }

        public void SaveTimeLine()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "SF4 Combo|*.cmb";
            saveFileDialog.Title = "Save your combo file...";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(saveFileDialog.FileName))
                {
                    foreach (TimeLineItemViewModel item in TimeLineItems)
                    {
                        file.WriteLine(item.InputItemViewModel.Serialize());
                    }
                }
            }
        }

        public void Handle(AddTimeLineItemMessage message)
        {
            TimeLineItemViewModel timeLineItem = message.TimeLineItemViewModel;
            AddTimeLineItem(timeLineItem);
        }

        public void Handle(OpenTimeLineMessage message)
        {
            OpenTimeLine(message.FilePath, message.Append);
        }

        public void Handle(SaveTimeLineMessage message)
        {
            SaveTimeLine();
        }

        public TimeLineViewModel(IEventAggregator events)
        {
            _events = events;
            _events.Subscribe(this);

            TimeLineItems = new BindableCollection<TimeLineItemViewModel>();
            TimeLineItems.Add(new TimeLineItemViewModel(this));

            SelectedTimeLineItem = TimeLineItems.Last();

            _autoSwitchToSF4 = true;
            _isSteamVersion = true;
        }
    }
}

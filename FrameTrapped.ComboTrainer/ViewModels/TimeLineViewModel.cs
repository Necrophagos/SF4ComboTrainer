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

    /// <summary>
    /// The time line item view model class.
    /// </summary>
    public class TimeLineViewModel : Conductor<TimeLineViewModel>.Collection.OneActive,
                                    IHandle<AddTimeLineItemMessage>,
                                    IHandle<SaveTimeLineMessage>,
                                    IHandle<OpenTimeLineMessage>
    {
        /// <summary>
        /// The events aggregator.
        /// </summary>
        private IEventAggregator _events;

        /// <summary>
        /// The auto switch to SF4 flag.
        /// </summary>
        private bool _autoSwitchToSF4;

        /// <summary>
        /// The steam version of SF4 flag.
        /// </summary>
        private bool _isSteamVersion;

        /// <summary>
        /// The currently selected time line item.
        /// </summary>
        private TimeLineItemViewModel _selectedTimeLineItem;

        /// <summary>
        /// Gets or sets the currently selected time line item.
        /// </summary>
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

        /// <summary>
        /// The collection of time line items.
        /// </summary>
        public BindableCollection<TimeLineItemViewModel> TimeLineItems { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating wether we wants to automatically switch to SF4.
        /// </summary>
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

        /// <summary>
        /// Gets or sets a value indicating whether we are using a steam version of SF4.
        /// </summary>
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

        /// <summary>
        /// Gets a value indicating whether you can remove a time line item.
        /// </summary>
        public bool CanRemoveItem
        {
            get { return TimeLineItems.Count > 1; }
        }

        /// <summary>
        /// Adds a time line item to the end of the time line.
        /// </summary>
        public void AddTimeLineItem()
        {
            TimeLineItemViewModel newTimeLineItemViewModel = new TimeLineItemViewModel(this);
            AddTimeLineItem(newTimeLineItemViewModel);

        }

        /// <summary>
        /// Adds a blank item after the current point in the time line.
        /// </summary>
        /// <param name="timeLineItemViewModel"></param>
        public void AddTimeLineItem(TimeLineItemViewModel timeLineItemViewModel)
        {
            TimeLineItems.Insert(TimeLineItems.IndexOf(SelectedTimeLineItem) + 1, timeLineItemViewModel);

            SelectedTimeLineItem = timeLineItemViewModel;


            NotifyOfPropertyChange(() => CanRemoveItem);
            NotifyOfPropertyChange(() => TimeLineItems);
        }

        /// <summary>
        /// Appends the opened file to the time line.
        /// </summary>
        public void AppendTimeLine()
        {
            OpenTimeLine(string.Empty, true);
        }

        /// <summary>
        /// Removes the time line item at the end or after the current selection.
        /// </summary>
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

        /// <summary>
        /// Clears the time line.
        /// </summary>
        public void ClearTimeLine()
        {
            TimeLineItems.Clear();
        }

        /// <summary>
        /// Loops the play back for the time line.
        /// </summary>
        public void LoopPlaybackStart()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Starts playback for the time line.
        /// </summary>
        public void PlaybackStart()
        {
            if (AutoSwitchToSF4)
            {
                _events.Publish(new FocusStreetFighterMessage());
                _events.Publish(new PlayTimeLineMessage(TimeLineItems));
            }
        }

        /// <summary>
        /// Opens a new time line from file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="append"></param>
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

                timeLineItemViewModel.PlaySound = inputItem.PlaySound;
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

        /// <summary>
        /// Saves the time line.
        /// </summary>
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
                        file.WriteLine(item.InputItemViewModel.InputItem.Serialize());
                    }
                }
            }
        }

        /// <summary>
        /// Handles the <see cref="AddTimeLineItemMessage"/>
        /// </summary>
        /// <param name="message">The add time line message.</param>
        public void Handle(AddTimeLineItemMessage message)
        {
            TimeLineItemViewModel timeLineItem = message.TimeLineItemViewModel;
            AddTimeLineItem(timeLineItem);
        }

        /// <summary>
        /// Handles the <see cref="OpenTimeLineMessage"/>
        /// </summary>
        /// <param name="message">The open time line message.</param>
        public void Handle(OpenTimeLineMessage message)
        {
            OpenTimeLine(message.FilePath, message.Append);
        }

        /// <summary>
        /// Handles the <see cref="SaveTimeLineMessage"/>
        /// </summary>
        /// <param name="message">The save time line message.</param>
        public void Handle(SaveTimeLineMessage message)
        {
            SaveTimeLine();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeLineViewmodel"/> class.
        /// </summary>
        /// <param name="events">The events aggregator.</param>
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

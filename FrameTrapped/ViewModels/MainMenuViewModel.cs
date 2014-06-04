namespace FrameTrapped.ViewModels
{
    using System;

    using Caliburn.Micro;

    using FrameTrapped.ComboTrainer.Messages;

    /// <summary>
    /// The main menu view model class.
    /// </summary>
    public class MainMenuViewModel : PropertyChangedBase
    { 
        /// <summary>
        /// The events aggregator.
        /// </summary>
        private IEventAggregator _events;

        /// <summary>
        /// The window manager.
        /// </summary>
        private IWindowManager _windowManager;

        /// <summary>
        /// Publishes the open time line message.
        /// </summary>
        public void OpenTimeLine()
        {
            _events.Publish(new OpenTimeLineMessage(false));
        }

        /// <summary>
        /// Publishes the append time line message.
        /// </summary>
        public void AppendTimeLine() {
            _events.Publish(new OpenTimeLineMessage(true));
        }

        /// <summary>
        /// Publishes the save time line message.
        /// </summary>
        public void SaveTimeLine() {

            _events.Publish(new SaveTimeLineMessage());
        }

        /// <summary>
        /// Shows the About dialog.
        /// </summary>
        public void ShowAboutDialog()
        {
           _windowManager.ShowDialog(new AboutViewModel());
        }

        /// <summary>
        /// Intializes an instance of the <see cref="MainMenuViewModel"/> class.
        /// </summary>
        /// <param name="windowManager">The window manager.</param>
        /// <param name="events">The events aggregator.</param>
        public MainMenuViewModel( IWindowManager windowManager, IEventAggregator events)
        {
            _events = events;
            _windowManager = windowManager;
        }
    }
}

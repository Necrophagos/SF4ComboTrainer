namespace FrameTrapped.ViewModels
{
    using System;

    using Caliburn.Micro;

    using FrameTrapped.ComboTrainer.Messages;

    public class MainMenuViewModel : PropertyChangedBase
    { 
        private IEventAggregator _events;

        private IWindowManager _windowManager;

        public void NewTimeLine() { }

        public void OpenTimeLine()
        {
            _events.Publish(new OpenTimeLineMessage(false));
        }
        
        public void AppendTimeLine() {
            _events.Publish(new OpenTimeLineMessage(true));
        }
        
        public void SaveTimeLine() {

            _events.Publish(new SaveTimeLineMessage());
        }

        public void ShowAbout()
        {
           _windowManager.ShowDialog(new AboutViewModel());
        }

        public MainMenuViewModel( IWindowManager windowManager, IEventAggregator events)
        {
            _events = events;
            _windowManager = windowManager;
        }
    }
}

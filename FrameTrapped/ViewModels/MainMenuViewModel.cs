namespace FrameTrapped.ViewModels
{
    using System;

    using Caliburn.Micro;

    using FrameTrapped.ComboTrainer.Messages;

    public class MainMenuViewModel : PropertyChangedBase
    { 
        private IEventAggregator _events;

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
        public void ClearTimeLineCommand() { }

        public MainMenuViewModel(IEventAggregator events)
        {
            _events = events;
        }
    }
}

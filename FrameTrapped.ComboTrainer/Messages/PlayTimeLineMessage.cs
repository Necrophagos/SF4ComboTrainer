namespace FrameTrapped.ComboTrainer.Messages
{
    using System.Collections.Generic;
    using FrameTrapped.ComboTrainer.ViewModels;

    public class PlayTimeLineMessage
    {
       public IEnumerable<TimeLineItemViewModel> TimeLineItemViewModels { get; set; }

        public PlayTimeLineMessage(IEnumerable<TimeLineItemViewModel> timeLineItemViewModels)
        {
            TimeLineItemViewModels = timeLineItemViewModels;
        }
    }
}

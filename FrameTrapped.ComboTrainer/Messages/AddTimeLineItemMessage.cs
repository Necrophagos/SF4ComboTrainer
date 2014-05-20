namespace FrameTrapped.ComboTrainer.Messages
{
    using FrameTrapped.ComboTrainer.ViewModels;

    public class AddTimeLineItemMessage
    {
        public TimeLineItemViewModel TimeLineItemViewModel { get; private set; }

        public AddTimeLineItemMessage(TimeLineItemViewModel timeLineItemViewModel)
        {
            TimeLineItemViewModel = timeLineItemViewModel;
        }
    }
}

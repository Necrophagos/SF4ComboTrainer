namespace FrameTrapped.ComboTrainer.Messages
{
    using System;

    public class OpenTimeLineMessage
    {
        public bool Append { get; private set; }

        public OpenTimeLineMessage(bool append)
        {
            Append = append;
        }
    }
}

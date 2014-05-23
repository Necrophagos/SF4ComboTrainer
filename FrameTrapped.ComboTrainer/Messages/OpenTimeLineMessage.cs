namespace FrameTrapped.ComboTrainer.Messages
{
    using System;

    public class OpenTimeLineMessage
    {
        public bool Append { get; private set; }

        public string FilePath { get; private set; }

        public OpenTimeLineMessage(string filePath, bool append)
        {
            Append = append;
            FilePath = filePath;
        }

        public OpenTimeLineMessage(bool append)
        {
            Append = append;
        }
    }
}

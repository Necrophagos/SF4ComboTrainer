namespace FrameTrapped.StreetFighterLibrary.ViewModels
{
    using System.Collections.ObjectModel;
    using FrameTrapped.Input.ViewModels;
    
    public class CommandViewModel
    {
        public ObservableCollection<InputItemViewModel> Commands { get; private set; }

        public CommandViewModel(ObservableCollection<InputItemViewModel> commands)
        {
            Commands = commands;
        }
    }
}

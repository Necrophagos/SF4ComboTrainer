namespace SF4ComboTrainer.StreetFighterLibrary.ViewModels
{
    using System.Collections.ObjectModel;
    using SF4ComboTrainer.Input.ViewModels;
    
    public class CommandViewModel
    {
        public ObservableCollection<InputItemViewModel> Commands { get; private set; }

        public CommandViewModel(ObservableCollection<InputItemViewModel> commands)
        {
            Commands = commands;
        }
    }
}

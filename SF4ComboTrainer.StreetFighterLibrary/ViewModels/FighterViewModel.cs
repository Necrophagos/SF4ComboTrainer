namespace SF4ComboTrainer.StreetFighterLibrary.ViewModels
{
    using System;
    using System.Collections.ObjectModel;

    public class FighterViewModel
    {
        public enum FighterTypeEnum
        {
            Shoto,
            Rushdown,
            Grappler,
            Zoner,
            Charge
        }

        public string Name { get; private set; }

        public Uri Image { get; private set; }
        public Uri Icon { get; private set; }

        public FighterTypeEnum FighterType { get; private set; }

        public int Stamina { get; private set; }

        public int Stun { get; private set; }

        public ObservableCollection<MoveViewModel> MovesList { get; private set; }

        public FighterViewModel( string name, FighterTypeEnum figherType, int stamina, int stun, ObservableCollection<MoveViewModel> movesList)
        {
            Name = name;
            Image = new Uri("pack://application:,,,/Resources/Images/" + Name + "Large.jpg");
            Icon = new Uri("pack://application:,,,/Resources/Images/" + Name + "Icon.png");
            FighterType = figherType;
            Stamina = stamina;
            Stun = stun;
            MovesList = movesList;
        }
    }
}

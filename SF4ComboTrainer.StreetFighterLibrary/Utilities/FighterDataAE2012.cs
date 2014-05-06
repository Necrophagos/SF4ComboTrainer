namespace SF4ComboTrainer.StreetFighterLibrary.Utilities
{
    using System.Collections.ObjectModel;

    using SF4ComboTrainer.StreetFighterLibrary.ViewModels;
    using SF4ComboTrainer.Input.ViewModels;
    using SF4ComboTrainer.Input.Models;

    public static class FighterDataAE2012
    {

        public static FighterViewModel RyuData()
        {
            ObservableCollection<HitViewModel> tmpHitList; ;
            CommandViewModel tmpCommand;

            ObservableCollection<MoveViewModel> moveList = new ObservableCollection<MoveViewModel>();

            // Close Jab
            tmpCommand = new CommandViewModel(new ObservableCollection<InputItemViewModel>() {
                new InputItemViewModel() { Light_Punch = true } 
            });

            tmpHitList = new ObservableCollection<HitViewModel>();
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 30, 0, 50, 0, 20, new[] { HitViewModel.CancelAbilityEnum.Chain, HitViewModel.CancelAbilityEnum.Special, HitViewModel.CancelAbilityEnum.Super }, 3, 3, 6, 2, 5, ""));

            moveList.Add(new MoveViewModel("Close Jab", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

            // Close Strong
            tmpCommand = new CommandViewModel(new ObservableCollection<InputItemViewModel>() { 
                new InputItemViewModel() { Medium_Punch = true }
            });
            tmpHitList = new ObservableCollection<HitViewModel>();
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 70, 0, 100, 0, 40, new[] { HitViewModel.CancelAbilityEnum.Special, HitViewModel.CancelAbilityEnum.Super }, 3, 3, 21, -3, 3, ""));

            moveList.Add(new MoveViewModel("Close Strong", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

            // Close Fierce
            tmpCommand = new CommandViewModel(new ObservableCollection<InputItemViewModel>() {
                //new InputItemViewModel() { Direction = InputCommandModel.DirectionStateEnum.Down } ,
                //new InputItemViewModel() { Direction = InputCommandModel.DirectionStateEnum.DownForward } ,
                //new InputItemViewModel() { Direction = InputCommandModel.DirectionStateEnum.Forward } ,
                new InputItemViewModel() { Hard_Punch = true } 
            });
            tmpHitList = new ObservableCollection<HitViewModel>();
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 100, 80, 200, 150, 60, new[] { HitViewModel.CancelAbilityEnum.Special, HitViewModel.CancelAbilityEnum.Super }, 5, 7, 26, -15, -10, "Forces stand, less damage and stun on frames 3~5"));

            moveList.Add(new MoveViewModel("Close Fierce", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

            // Close Short
            tmpCommand = new CommandViewModel(new ObservableCollection<InputItemViewModel>() { 
                new InputItemViewModel() { Light_Kick = true }
            });
            tmpHitList = new ObservableCollection<HitViewModel>();
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 30, 0, 50, 0, 20, new HitViewModel.CancelAbilityEnum[] {}, 5, 5, 7, -1, 2, ""));

            moveList.Add(new MoveViewModel("Close Short", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

            // Close Long
            tmpCommand = new CommandViewModel(new ObservableCollection<InputItemViewModel>() { 
                new InputItemViewModel() { Medium_Kick = true }
            });
            tmpHitList = new ObservableCollection<HitViewModel>();
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 80, 0, 100, 0, 40, new[] { HitViewModel.CancelAbilityEnum.Special, HitViewModel.CancelAbilityEnum.Super }, 3, 5, 16, -7, -2, ""));

            moveList.Add(new MoveViewModel("Close Long", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

            // Close Roundhouse
            tmpCommand = new CommandViewModel(new ObservableCollection<InputItemViewModel>() { 
                new InputItemViewModel() { Hard_Kick = true }
            });
            tmpHitList = new ObservableCollection<HitViewModel>();
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 40, 0, 125, 0, 60, new[] { HitViewModel.CancelAbilityEnum.Super }, 8, 8, 0, 0, 0, ""));
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 70, 0, 75, 0, 20, new HitViewModel.CancelAbilityEnum[] {}, 2, 4, 15, -1, 4, ""));

            moveList.Add(new MoveViewModel("Close Roundhouse", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));


            FighterViewModel ryuFighter = new FighterViewModel("Ryu", FighterViewModel.FighterTypeEnum.Shoto, 1000, 1000, moveList);
            return ryuFighter;
        }
    }
}

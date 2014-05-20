namespace FrameTrapped.StreetFighterLibrary.Utilities
{
    using System.Collections.ObjectModel;

    using FrameTrapped.StreetFighterLibrary.ViewModels;
    using FrameTrapped.Input.ViewModels;
    using FrameTrapped.Input.Models;
    using Caliburn.Micro;

    public static class FighterDataAE2012
    {

        public static FighterViewModel Ryu()
        {
            BindableCollection<HitViewModel> tmpHitList; ;
            CommandViewModel tmpCommand;

            BindableCollection<MoveViewModel> moveList = new BindableCollection<MoveViewModel>();

            // Close Punches

            // Close Jab
            tmpCommand = new CommandViewModel(new BindableCollection<InputItemViewModel>() {
                new InputItemViewModel() { Light_Punch = true } 
            });

            tmpHitList = new BindableCollection<HitViewModel>();
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 30, 0, 50, 0, 20, new[] { HitViewModel.CancelAbilityEnum.Chain, HitViewModel.CancelAbilityEnum.Special, HitViewModel.CancelAbilityEnum.Super }, 3, 3, 6, 2, 5, ""));

            moveList.Add(new MoveViewModel("Close Jab", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

            // Close Strong
            tmpCommand = new CommandViewModel(new BindableCollection<InputItemViewModel>() { 
                new InputItemViewModel() { Medium_Punch = true }
            });
            tmpHitList = new BindableCollection<HitViewModel>();
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 70, 0, 100, 0, 40, new[] { HitViewModel.CancelAbilityEnum.Special, HitViewModel.CancelAbilityEnum.Super }, 3, 3, 21, -3, 3, ""));

            moveList.Add(new MoveViewModel("Close Strong", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

            // Close Fierce
            tmpCommand = new CommandViewModel(new BindableCollection<InputItemViewModel>() {
                new InputItemViewModel() { Hard_Punch = true } 
            });
            tmpHitList = new BindableCollection<HitViewModel>();
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 100, 80, 200, 150, 60, new[] { HitViewModel.CancelAbilityEnum.Special, HitViewModel.CancelAbilityEnum.Super }, 5, 7, 26, -15, -10, "Forces stand, less damage and stun on 3~5f"));

            moveList.Add(new MoveViewModel("Close Fierce", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

            // Close Kicks

            // Close Short
            tmpCommand = new CommandViewModel(new BindableCollection<InputItemViewModel>() { 
                new InputItemViewModel() { Light_Kick = true }
            });
            tmpHitList = new BindableCollection<HitViewModel>();
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 30, 0, 50, 0, 20, new HitViewModel.CancelAbilityEnum[] { }, 5, 5, 7, -1, 2, ""));

            moveList.Add(new MoveViewModel("Close Short", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

            // Close Long
            tmpCommand = new CommandViewModel(new BindableCollection<InputItemViewModel>() { 
                new InputItemViewModel() { Medium_Kick = true }
            });
            tmpHitList = new BindableCollection<HitViewModel>();
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 80, 0, 100, 0, 40, new[] { HitViewModel.CancelAbilityEnum.Special, HitViewModel.CancelAbilityEnum.Super }, 3, 5, 16, -7, -2, ""));

            moveList.Add(new MoveViewModel("Close Long", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

            // Close Roundhouse
            tmpCommand = new CommandViewModel(new BindableCollection<InputItemViewModel>() { 
                new InputItemViewModel() { Hard_Kick = true }
            });
            tmpHitList = new BindableCollection<HitViewModel>();
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 40, 0, 125, 0, 60, new[] { HitViewModel.CancelAbilityEnum.Super }, 8, 8, 0, 0, 0, ""));
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 70, 0, 75, 0, 20, new HitViewModel.CancelAbilityEnum[] { }, 2, 4, 15, -1, 4, ""));

            moveList.Add(new MoveViewModel("Close Roundhouse", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

            // Far Punches

            // Far Jab
            tmpCommand = new CommandViewModel(new BindableCollection<InputItemViewModel>() { 
                new InputItemViewModel() { Light_Punch = true }
            });
            tmpHitList = new BindableCollection<HitViewModel>();
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 30, 0, 50, 0, 20, new[] { HitViewModel.CancelAbilityEnum.Chain, HitViewModel.CancelAbilityEnum.Special, HitViewModel.CancelAbilityEnum.Super }, 4, 3, 6, 2, 5, ""));

            moveList.Add(new MoveViewModel("Far Jab", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

            // Far Strong
            tmpCommand = new CommandViewModel(new BindableCollection<InputItemViewModel>() { 
                new InputItemViewModel() { Medium_Punch = true }
            });
            tmpHitList = new BindableCollection<HitViewModel>();
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 80, 0, 100, 0, 40, new[] { HitViewModel.CancelAbilityEnum.Special, HitViewModel.CancelAbilityEnum.Super }, 5, 4, 14, -4, -1, ""));

            moveList.Add(new MoveViewModel("Far Strong", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

            // Far Fierce
            tmpCommand = new CommandViewModel(new BindableCollection<InputItemViewModel>() { 
                new InputItemViewModel() { Hard_Punch = true }
            });
            tmpHitList = new BindableCollection<HitViewModel>();
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 120, 0, 200, 0, 60, new HitViewModel.CancelAbilityEnum[] { }, 8, 3, 15, 0, -4, ""));

            moveList.Add(new MoveViewModel("Far Fierce", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

            // Far Kicks

            // Far Short
            tmpCommand = new CommandViewModel(new BindableCollection<InputItemViewModel>() { 
                new InputItemViewModel() { Light_Kick = true }
            });
            tmpHitList = new BindableCollection<HitViewModel>();
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 40, 0, 50, 0, 20, new HitViewModel.CancelAbilityEnum[] { }, 5, 6, 6, -1, 2, ""));

            moveList.Add(new MoveViewModel("Far Short", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

            // Far Long
            tmpCommand = new CommandViewModel(new BindableCollection<InputItemViewModel>() { 
                new InputItemViewModel() { Medium_Kick = true }
            });
            tmpHitList = new BindableCollection<HitViewModel>();
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 80, 0, 100, 0, 40, new HitViewModel.CancelAbilityEnum[] { }, 8, 2, 17, -5, -2, ""));

            moveList.Add(new MoveViewModel("Far Long", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

            // Far Roundhouse
            tmpCommand = new CommandViewModel(new BindableCollection<InputItemViewModel>() { 
                new InputItemViewModel() { Hard_Kick = true }
            });
            tmpHitList = new BindableCollection<HitViewModel>();
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 110, 0, 125, 0, 60, new HitViewModel.CancelAbilityEnum[] { }, 9, 4, 20, -6, -2, ""));

            moveList.Add(new MoveViewModel("Far Roundhouse", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

            // Crouch Punches

            // Crouch Jab
            tmpCommand = new CommandViewModel(new BindableCollection<InputItemViewModel>() {
                new InputItemViewModel() { Direction=InputCommandModel.DirectionStateEnum.Down, Light_Punch = true } 
            });

            tmpHitList = new BindableCollection<HitViewModel>();
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 30, 0, 50, 0, 20, new[] { HitViewModel.CancelAbilityEnum.Chain, HitViewModel.CancelAbilityEnum.Special, HitViewModel.CancelAbilityEnum.Super }, 3, 2, 7, 2, 5, ""));

            moveList.Add(new MoveViewModel("Crouch Jab", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

            // Crouch Strong
            tmpCommand = new CommandViewModel(new BindableCollection<InputItemViewModel>() { 
                new InputItemViewModel() { Direction=InputCommandModel.DirectionStateEnum.Down, Medium_Punch = true }
            });
            tmpHitList = new BindableCollection<HitViewModel>();
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 60, 0, 100, 0, 40, new[] { HitViewModel.CancelAbilityEnum.Special, HitViewModel.CancelAbilityEnum.Super }, 4, 4, 8, 2, 5, ""));

            moveList.Add(new MoveViewModel("Crouch Strong", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

            // Crouch Fierce
            tmpCommand = new CommandViewModel(new BindableCollection<InputItemViewModel>() {
                new InputItemViewModel() { Direction=InputCommandModel.DirectionStateEnum.Down, Hard_Punch = true } 
            });
            tmpHitList = new BindableCollection<HitViewModel>();
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 90, 0, 200, 0, 60, new[] { HitViewModel.CancelAbilityEnum.Special, HitViewModel.CancelAbilityEnum.Super }, 4, 8, 28, -18, -13, "Forces stand"));

            moveList.Add(new MoveViewModel("Crouch Fierce", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

            // Crouch Kicks

            // Crouch Short
            tmpCommand = new CommandViewModel(new BindableCollection<InputItemViewModel>() { 
                new InputItemViewModel() { Direction=InputCommandModel.DirectionStateEnum.Down, Light_Kick = true }
            });
            tmpHitList = new BindableCollection<HitViewModel>();
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Low, 20, 0, 50, 0, 20, new[] { HitViewModel.CancelAbilityEnum.Chain, HitViewModel.CancelAbilityEnum.Special, HitViewModel.CancelAbilityEnum.Super }, 4, 3, 9, -1, 2, ""));

            moveList.Add(new MoveViewModel("Crouch Short", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

            // Crouch Long
            tmpCommand = new CommandViewModel(new BindableCollection<InputItemViewModel>() { 
                new InputItemViewModel() { Direction=InputCommandModel.DirectionStateEnum.Down, Medium_Kick = true }
            });
            tmpHitList = new BindableCollection<HitViewModel>();
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Low, 60, 0, 100, 0, 40, new[] { HitViewModel.CancelAbilityEnum.Special, HitViewModel.CancelAbilityEnum.Super }, 5, 5, 12, -3, 0, ""));

            moveList.Add(new MoveViewModel("Crouch Long", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

            // Crouch Roundhouse
            tmpCommand = new CommandViewModel(new BindableCollection<InputItemViewModel>() { 
                new InputItemViewModel() { Direction=InputCommandModel.DirectionStateEnum.Down, Hard_Kick = true }
            });
            tmpHitList = new BindableCollection<HitViewModel>();
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Low, 90, 0, 100, 0, 60, new HitViewModel.CancelAbilityEnum[] { }, 5, 4, 28, -14, 0, "Untechable knockdown"));

            moveList.Add(new MoveViewModel("Crouch Roundhouse", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

            // Neutral Jump Punches

            // Neutral Jump Jab
            tmpCommand = new CommandViewModel(new BindableCollection<InputItemViewModel>() {
                new InputItemViewModel() { Direction=InputCommandModel.DirectionStateEnum.Up, Light_Punch = true } 
            });

            tmpHitList = new BindableCollection<HitViewModel>();
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 50, 0, 50, 0, 20, new HitViewModel.CancelAbilityEnum[] { }, 10, 7, 0, 0, 0, "Legs projectile invincible until end of startup frames"));

            moveList.Add(new MoveViewModel("Neutral Jump Jab", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

            // Neutral Jump Strong
            tmpCommand = new CommandViewModel(new BindableCollection<InputItemViewModel>() { 
                new InputItemViewModel() { Direction=InputCommandModel.DirectionStateEnum.Up, Medium_Punch = true }
            });
            tmpHitList = new BindableCollection<HitViewModel>();
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 80, 0, 100, 0, 40, new HitViewModel.CancelAbilityEnum[] { }, 5, 5, 0, 0, 0, "Legs projectile invincible until end of startup frames"));

            moveList.Add(new MoveViewModel("Neutral Jump Strong", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

            // Neutral Jump Fierce
            tmpCommand = new CommandViewModel(new BindableCollection<InputItemViewModel>() {
                new InputItemViewModel() { Direction=InputCommandModel.DirectionStateEnum.Up, Hard_Punch = true } 
            });
            tmpHitList = new BindableCollection<HitViewModel>();
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 100, 0, 200, 0, 60, new HitViewModel.CancelAbilityEnum[] { }, 6, 5, 0, 0, 0, "Legs projectile invincible until end of startup frames"));

            moveList.Add(new MoveViewModel("Neutral Jump Fierce", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

            // Neutral Jump Kicks

            // Neutral Jump Short
            tmpCommand = new CommandViewModel(new BindableCollection<InputItemViewModel>() { 
                new InputItemViewModel() { Direction=InputCommandModel.DirectionStateEnum.Up, Light_Kick = true }
            });
            tmpHitList = new BindableCollection<HitViewModel>();
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Low, 40, 0, 50, 0, 20, new HitViewModel.CancelAbilityEnum[] { }, 5, 9, 0, 0, 0, "Legs projectile invincible until end of startup frames"));

            moveList.Add(new MoveViewModel("Neutral Jump Short", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

            // Neutral Jump Long
            tmpCommand = new CommandViewModel(new BindableCollection<InputItemViewModel>() { 
                new InputItemViewModel() { Direction=InputCommandModel.DirectionStateEnum.Up, Medium_Kick = true }
            });
            tmpHitList = new BindableCollection<HitViewModel>();
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Low, 80, 0, 100, 0, 40, new HitViewModel.CancelAbilityEnum[] { }, 6, 10, 0, 0, 0, "Legs projectile invincible until end of startup frames"));

            moveList.Add(new MoveViewModel("Neutral Jump Long", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

            // Neutral Jump Roundhouse
            tmpCommand = new CommandViewModel(new BindableCollection<InputItemViewModel>() { 
                new InputItemViewModel() { Direction=InputCommandModel.DirectionStateEnum.Up, Hard_Kick = true }
            });
            tmpHitList = new BindableCollection<HitViewModel>();
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Low, 200, 0, 100, 0, 60, new HitViewModel.CancelAbilityEnum[] { }, 4, 4, 0, 0, 0, "Legs projectile invincible until end of startup frames"));

            moveList.Add(new MoveViewModel("Neutral Jump Roundhouse", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

            // Angled Jump Punches

            // Angled Jump Jab
            tmpCommand = new CommandViewModel(new BindableCollection<InputItemViewModel>() {
                new InputItemViewModel() { Direction=InputCommandModel.DirectionStateEnum.UpForward, Light_Punch = true } 
            });

            tmpHitList = new BindableCollection<HitViewModel>();
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 50, 0, 50, 0, 20, new HitViewModel.CancelAbilityEnum[] { }, 4, 7, 0, 0, 0, "Legs projectile invincible until end of startup frames"));

            moveList.Add(new MoveViewModel("Angled Jump Jab", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

            // Angled Jump Strong
            tmpCommand = new CommandViewModel(new BindableCollection<InputItemViewModel>() { 
                new InputItemViewModel() { Direction=InputCommandModel.DirectionStateEnum.UpForward, Medium_Punch = true }
            });
            tmpHitList = new BindableCollection<HitViewModel>();
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 50, 0, 50, 0, 40, new HitViewModel.CancelAbilityEnum[] { }, 7, 3, 0, 0, 0, "Legs projectile invincible until end of startup frames, [1st Air hit] floats opponent,"));
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 30, 0, 50, 0, 20, new HitViewModel.CancelAbilityEnum[] { }, 0, 4, 0, 0, 0, "[2nd Air hit] knock down and can juggle"));

            moveList.Add(new MoveViewModel("Angled Jump Strong", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

            // Angled Jump Fierce
            tmpCommand = new CommandViewModel(new BindableCollection<InputItemViewModel>() {
                new InputItemViewModel() { Direction=InputCommandModel.DirectionStateEnum.UpForward, Hard_Punch = true } 
            });
            tmpHitList = new BindableCollection<HitViewModel>();
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 100, 0, 200, 0, 60, new HitViewModel.CancelAbilityEnum[] { }, 6, 5, 0, 0, 0, "Legs projectile invincible until end of startup frames"));

            moveList.Add(new MoveViewModel("Angled Jump Fierce", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

            // Angled Jump Kicks

            // Angled Jump Short
            tmpCommand = new CommandViewModel(new BindableCollection<InputItemViewModel>() { 
                new InputItemViewModel() { Direction=InputCommandModel.DirectionStateEnum.UpForward, Light_Kick = true }
            });
            tmpHitList = new BindableCollection<HitViewModel>();
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Low, 40, 0, 50, 0, 20, new HitViewModel.CancelAbilityEnum[] { }, 4, 8, 0, 0, 0, "Legs projectile invincible until end of startup frames"));

            moveList.Add(new MoveViewModel("Angled Jump Short", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

            // Angled Jump Long
            tmpCommand = new CommandViewModel(new BindableCollection<InputItemViewModel>() { 
                new InputItemViewModel() { Direction=InputCommandModel.DirectionStateEnum.UpForward, Medium_Kick = true }
            });
            tmpHitList = new BindableCollection<HitViewModel>();
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Low, 80, 0, 100, 0, 40, new HitViewModel.CancelAbilityEnum[] { }, 6, 6, 0, 0, 0, "Legs projectile invincible until end of startup frames"));

            moveList.Add(new MoveViewModel("Angled Jump Long", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

            // Angled Jump Roundhouse
            tmpCommand = new CommandViewModel(new BindableCollection<InputItemViewModel>() { 
                new InputItemViewModel() { Direction=InputCommandModel.DirectionStateEnum.UpForward, Hard_Kick = true }
            });
            tmpHitList = new BindableCollection<HitViewModel>();
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Low, 200, 0, 100, 0, 60, new HitViewModel.CancelAbilityEnum[] { }, 7, 7, 0, 0, 0, "Legs projectile invincible until end of startup frames"));

            moveList.Add(new MoveViewModel("Angled Jump Roundhouse", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

            // Unique Punches

            // Collarbone Breaker
            tmpCommand = new CommandViewModel(new BindableCollection<InputItemViewModel>() {
                new InputItemViewModel() { Direction=InputCommandModel.DirectionStateEnum.Forward, Medium_Punch = true } 
            });

            tmpHitList = new BindableCollection<HitViewModel>();
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 30, 0, 50, 0, 40, new HitViewModel.CancelAbilityEnum[] { }, 17, 1, 0, 1, 1, "Overhead attack"));
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 50, 0, 50, 0, 20, new HitViewModel.CancelAbilityEnum[] { }, 1, 2, 14, -2, 3, ""));

            moveList.Add(new MoveViewModel("Collarbone Breaker", MoveViewModel.MoveTypeEnum.Unique, tmpHitList, tmpCommand));

            // Solar Plexus Strike
            tmpCommand = new CommandViewModel(new BindableCollection<InputItemViewModel>() { 
                new InputItemViewModel() { Direction=InputCommandModel.DirectionStateEnum.Forward, Hard_Punch = true }
            });
            tmpHitList = new BindableCollection<HitViewModel>();
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 40, 0, 50, 0, 60, new[] { HitViewModel.CancelAbilityEnum.Special, HitViewModel.CancelAbilityEnum.Super }, 17, 2, 0, 0, 0, ""));
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 50, 0, 50, 0, 20, new[] { HitViewModel.CancelAbilityEnum.Special, HitViewModel.CancelAbilityEnum.Super }, 0, 2, 18, 0, 4, ""));

            moveList.Add(new MoveViewModel("Solar Plexus Strike", MoveViewModel.MoveTypeEnum.Unique, tmpHitList, tmpCommand));

            // Focus Attacks

            // Focus Attack Level 1
            tmpCommand = new CommandViewModel(new BindableCollection<InputItemViewModel>() {
                new InputItemViewModel() { Medium_Punch = true, Medium_Kick = true } 
            });

            tmpHitList = new BindableCollection<HitViewModel>();
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 60, 0, 100, 0, 20, new HitViewModel.CancelAbilityEnum[] { }, 21, 2, 35, -21, -21, ""));

            moveList.Add(new MoveViewModel("Focus Attack Level 1", MoveViewModel.MoveTypeEnum.Focus, tmpHitList, tmpCommand));

            // Focus Attack Level 2
            tmpCommand = new CommandViewModel(new BindableCollection<InputItemViewModel>() { 
                new InputItemViewModel() { Medium_Punch = true, Medium_Kick = true, WaitFrames = 17 }
            });
            tmpHitList = new BindableCollection<HitViewModel>();
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 80, 0, 150, 0, 40, new HitViewModel.CancelAbilityEnum[] { }, 17, 2, 35, -15, 0, ""));

            moveList.Add(new MoveViewModel("Focus Attack Level 2", MoveViewModel.MoveTypeEnum.Focus, tmpHitList, tmpCommand));

            // Focus Attack Level 3
            tmpCommand = new CommandViewModel(new BindableCollection<InputItemViewModel>() { 
                new InputItemViewModel() { Medium_Punch = true, Medium_Kick = true, WaitFrames = 65 }
            });
            tmpHitList = new BindableCollection<HitViewModel>();
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Unblockable, 140, 0, 200, 0, 60, new HitViewModel.CancelAbilityEnum[] { }, 65, 2, 35, 0, 0, ""));

            moveList.Add(new MoveViewModel("Focus Attack Level 3", MoveViewModel.MoveTypeEnum.Focus, tmpHitList, tmpCommand));

            // Throw Attacks

            // Forward Throw
            tmpCommand = new CommandViewModel(new BindableCollection<InputItemViewModel>() {
                new InputItemViewModel() { Light_Punch = true, Light_Kick = true } 
            });

            tmpHitList = new BindableCollection<HitViewModel>();
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Techable, 130, 0, 140, 0, 40, new HitViewModel.CancelAbilityEnum[] { }, 3, 2, 20, 0, 0, "Untechable knockdown, Range 0.9 Units"));

            moveList.Add(new MoveViewModel("Forward Throw", MoveViewModel.MoveTypeEnum.Throw, tmpHitList, tmpCommand));

            // Backward Throw
            tmpCommand = new CommandViewModel(new BindableCollection<InputItemViewModel>() { 
                new InputItemViewModel() { Direction = InputCommandModel.DirectionStateEnum.Back, Light_Punch = true, Light_Kick = true }
            });
            tmpHitList = new BindableCollection<HitViewModel>();
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Techable, 130, 0, 120, 0, 40, new HitViewModel.CancelAbilityEnum[] { }, 3, 2, 20, 0, 0, "Untechable knockdown, Range 0.9 Units"));

            moveList.Add(new MoveViewModel("Backward Throw", MoveViewModel.MoveTypeEnum.Throw, tmpHitList, tmpCommand));

            // Special Attacks

            #region Hadokens
            // Light Hadoken
            tmpCommand = new CommandViewModel(new BindableCollection<InputItemViewModel>() { 
                new InputItemViewModel() { Direction = InputCommandModel.DirectionStateEnum.Down },
                new InputItemViewModel() { Direction = InputCommandModel.DirectionStateEnum.DownForward },
                new InputItemViewModel() { Direction = InputCommandModel.DirectionStateEnum.Forward, Light_Punch = true }
            });
            tmpHitList = new BindableCollection<HitViewModel>();
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 70, 0, 100, 0, 10, new[] { HitViewModel.CancelAbilityEnum.Super }, 13, 0, 45, -6, -2, "[Air hit] knock down, 16~17f focus cancellable without hit"));

            moveList.Add(new MoveViewModel("Light Hadoken", MoveViewModel.MoveTypeEnum.Special, tmpHitList, tmpCommand));

            // Medium Hadoken
            tmpCommand = new CommandViewModel(new BindableCollection<InputItemViewModel>() { 
                new InputItemViewModel() { Direction = InputCommandModel.DirectionStateEnum.Down },
                new InputItemViewModel() { Direction = InputCommandModel.DirectionStateEnum.DownForward },
                new InputItemViewModel() { Direction = InputCommandModel.DirectionStateEnum.Forward, Medium_Punch = true }
            });
            tmpHitList = new BindableCollection<HitViewModel>();
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 70, 0, 100, 0, 10, new[] { HitViewModel.CancelAbilityEnum.Super }, 13, 0, 45, -6, -2, "[Air hit] knock down, 16~17f focus cancellable without hit"));

            moveList.Add(new MoveViewModel("Medium Hadoken", MoveViewModel.MoveTypeEnum.Special, tmpHitList, tmpCommand));

            // Hard Hadoken
            tmpCommand = new CommandViewModel(new BindableCollection<InputItemViewModel>() { 
                new InputItemViewModel() { Direction = InputCommandModel.DirectionStateEnum.Down },
                new InputItemViewModel() { Direction = InputCommandModel.DirectionStateEnum.DownForward },
                new InputItemViewModel() { Direction = InputCommandModel.DirectionStateEnum.Forward, Hard_Punch = true }
            });
            tmpHitList = new BindableCollection<HitViewModel>();
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 70, 0, 100, 0, 10, new[] { HitViewModel.CancelAbilityEnum.Super }, 13, 0, 45, -6, -2, "[Air hit] knock down, 16~17f focus cancellable without hit"));

            moveList.Add(new MoveViewModel("Hard Hadoken", MoveViewModel.MoveTypeEnum.Special, tmpHitList, tmpCommand));

            // EX Hadoken
            tmpCommand = new CommandViewModel(new BindableCollection<InputItemViewModel>() { 
                new InputItemViewModel() { Direction = InputCommandModel.DirectionStateEnum.Down },
                new InputItemViewModel() { Direction = InputCommandModel.DirectionStateEnum.DownForward },
                new InputItemViewModel() { Direction = InputCommandModel.DirectionStateEnum.Forward, Light_Punch = true, Medium_Punch = true }
            });
            tmpHitList = new BindableCollection<HitViewModel>();
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 50, 0, 50, 0, -250, new[] { HitViewModel.CancelAbilityEnum.Super }, 12, 0, 45, 0, 0, "Knock down, can juggle, [counterhit] floats opponent, 15~16f focus cancellable"));
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 50, 0, 50, 0, 0, new[] { HitViewModel.CancelAbilityEnum.Super }, 0, 0, 50, 1, 0, ""));

            moveList.Add(new MoveViewModel("EX Hadoken", MoveViewModel.MoveTypeEnum.ExtraSpecial, tmpHitList, tmpCommand));

            #endregion

            #region Shoryukens

            // Light Shoryuken
            tmpCommand = new CommandViewModel(new BindableCollection<InputItemViewModel>() { 
                new InputItemViewModel() { Direction = InputCommandModel.DirectionStateEnum.Forward },
                new InputItemViewModel() { Direction = InputCommandModel.DirectionStateEnum.Down },
                new InputItemViewModel() { Direction = InputCommandModel.DirectionStateEnum.DownForward, Light_Punch = true }
            });
            tmpHitList = new BindableCollection<HitViewModel>();
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 100, 70, 200, 200, 30, new[] { HitViewModel.CancelAbilityEnum.Super }, 3, 14, 24, -17, 0, "1~2f Invincible, 3~4f unthrowable, 3~16f lower body invincibility, 4f~ airborne, knock down, [] refers to active frames 3~14f"));

            moveList.Add(new MoveViewModel("Light Shoryuken", MoveViewModel.MoveTypeEnum.Special, tmpHitList, tmpCommand));

            // Medium Shoryuken
            tmpCommand = new CommandViewModel(new BindableCollection<InputItemViewModel>() {  
                new InputItemViewModel() { Direction = InputCommandModel.DirectionStateEnum.Forward },
                new InputItemViewModel() { Direction = InputCommandModel.DirectionStateEnum.Down },
                new InputItemViewModel() { Direction = InputCommandModel.DirectionStateEnum.DownForward, Medium_Punch = true }
            });
            tmpHitList = new BindableCollection<HitViewModel>();
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 80, 0, 150, 0, 20, new[] { HitViewModel.CancelAbilityEnum.Super }, 3, 2, 0, 0, 0, "1~5f Invincible, 6~16f lower body invincibility, 5f~ airborne, knock down, "));
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 50, 0, 50, 0, 20, new HitViewModel.CancelAbilityEnum[] { }, 0, 12, 43, -34, 0, "[2nd hit] can juggle"));

            moveList.Add(new MoveViewModel("Medium Shoryuken", MoveViewModel.MoveTypeEnum.Special, tmpHitList, tmpCommand));

            // Hard Shoryuken
            tmpCommand = new CommandViewModel(new BindableCollection<InputItemViewModel>() {  
                new InputItemViewModel() { Direction = InputCommandModel.DirectionStateEnum.Forward },
                new InputItemViewModel() { Direction = InputCommandModel.DirectionStateEnum.Down },
                new InputItemViewModel() { Direction = InputCommandModel.DirectionStateEnum.DownForward, Hard_Punch = true }
            });
            tmpHitList = new BindableCollection<HitViewModel>();
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 160, 60, 200, 50, 20, new HitViewModel.CancelAbilityEnum[] { }, 3, 14, 46, -37, 0, "1~4f Invincible, 3~4f unthrowable, 5~16f lower body invincibility, 3f~ airborne, knock down, [] refers to active frames 3~14f"));

            moveList.Add(new MoveViewModel("Hard Shoryuken", MoveViewModel.MoveTypeEnum.Special, tmpHitList, tmpCommand));

            // EX Shoryuken
            tmpCommand = new CommandViewModel(new BindableCollection<InputItemViewModel>() { 
                new InputItemViewModel() { Direction = InputCommandModel.DirectionStateEnum.Forward },
                new InputItemViewModel() { Direction = InputCommandModel.DirectionStateEnum.Down },
                new InputItemViewModel() { Direction = InputCommandModel.DirectionStateEnum.DownForward,  Light_Punch = true, Medium_Punch = true }
            });
            tmpHitList = new BindableCollection<HitViewModel>();
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 50, 0, 50, 0, -250, new[] { HitViewModel.CancelAbilityEnum.Super }, 3, 2, 45, 0, 0, "1~16f Invincible, 6f~ airborne, knock down, "));
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 50, 0, 50, 0, 0, new[] { HitViewModel.CancelAbilityEnum.Super }, 0, 12, 48, -39, 0, "[2nd hit] can juggle"));

            moveList.Add(new MoveViewModel("EX Shoryuken", MoveViewModel.MoveTypeEnum.ExtraSpecial, tmpHitList, tmpCommand));

            #endregion

            #region Tatsumaki Senpukyakus

            // Light Tatsumaki Senpukyaku
            tmpCommand = new CommandViewModel(new BindableCollection<InputItemViewModel>() { 
                new InputItemViewModel() { Direction = InputCommandModel.DirectionStateEnum.Down },
                new InputItemViewModel() { Direction = InputCommandModel.DirectionStateEnum.DownBack },
                new InputItemViewModel() { Direction = InputCommandModel.DirectionStateEnum.Back,  Light_Kick = true }
            });
            tmpHitList = new BindableCollection<HitViewModel>();
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 50, 0, 50, 0, -250, new[] { HitViewModel.CancelAbilityEnum.Super }, 3, 2, 45, 0, 0, "1~16f Invincible, 6f~ airborne, knock down, "));
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 50, 0, 50, 0, 0, new[] { HitViewModel.CancelAbilityEnum.Super }, 0, 12, 48, -39, 0, "[2nd hit] can juggle"));

            moveList.Add(new MoveViewModel("Light Tatsumaki Senpukyaku", MoveViewModel.MoveTypeEnum.Special, tmpHitList, tmpCommand));

            #endregion

            // Initialise Ryu:
            FighterViewModel ryuFighter = new FighterViewModel("Ryu", FighterViewModel.FighterTypeEnum.Shoto, 1000, 1000, 0.045f, 0.030f, moveList);
            return ryuFighter;
        }

        public static FighterViewModel Ken()
        {
            BindableCollection<HitViewModel> tmpHitList; ;
            CommandViewModel tmpCommand;

            BindableCollection<MoveViewModel> moveList = new BindableCollection<MoveViewModel>();

            // Close Jab
            tmpCommand = new CommandViewModel(new BindableCollection<InputItemViewModel>() {
                new InputItemViewModel() { Light_Punch = true } 
            });
            tmpHitList = new BindableCollection<HitViewModel>();
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 30, 0, 50, 0, 20, new[] { HitViewModel.CancelAbilityEnum.Chain, HitViewModel.CancelAbilityEnum.Special, HitViewModel.CancelAbilityEnum.Super }, 3, 3, 6, 2, 5, ""));

            moveList.Add(new MoveViewModel("Close Jab", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

            // Close Strong
            tmpCommand = new CommandViewModel(new BindableCollection<InputItemViewModel>() { 
                new InputItemViewModel() { Medium_Punch = true }
            });
            tmpHitList = new BindableCollection<HitViewModel>();
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 70, 0, 100, 0, 40, new[] { HitViewModel.CancelAbilityEnum.Special, HitViewModel.CancelAbilityEnum.Super }, 3, 3, 21, -3, 3, ""));

            moveList.Add(new MoveViewModel("Close Strong", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

            // Close Fierce
            tmpCommand = new CommandViewModel(new BindableCollection<InputItemViewModel>() {
                //new InputItemViewModel() { Direction = InputCommandModel.DirectionStateEnum.Down } ,
                //new InputItemViewModel() { Direction = InputCommandModel.DirectionStateEnum.DownForward } ,
                //new InputItemViewModel() { Direction = InputCommandModel.DirectionStateEnum.Forward } ,
                new InputItemViewModel() { Hard_Punch = true } 
            });
            tmpHitList = new BindableCollection<HitViewModel>();
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 100, 80, 200, 150, 60, new[] { HitViewModel.CancelAbilityEnum.Special, HitViewModel.CancelAbilityEnum.Super }, 5, 7, 26, -15, -10, "Forces stand, less damage and stun on frames 3~5"));

            moveList.Add(new MoveViewModel("Close Fierce", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

            // Close Short
            tmpCommand = new CommandViewModel(new BindableCollection<InputItemViewModel>() { 
                new InputItemViewModel() { Light_Kick = true }
            });
            tmpHitList = new BindableCollection<HitViewModel>();
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 30, 0, 50, 0, 20, new HitViewModel.CancelAbilityEnum[] { }, 5, 5, 7, -1, 2, ""));

            moveList.Add(new MoveViewModel("Close Short", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

            // Close Long
            tmpCommand = new CommandViewModel(new BindableCollection<InputItemViewModel>() { 
                new InputItemViewModel() { Medium_Kick = true }
            });
            tmpHitList = new BindableCollection<HitViewModel>();
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 80, 0, 100, 0, 40, new[] { HitViewModel.CancelAbilityEnum.Special, HitViewModel.CancelAbilityEnum.Super }, 3, 5, 16, -7, -2, ""));

            moveList.Add(new MoveViewModel("Close Long", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

            // Close Roundhouse
            tmpCommand = new CommandViewModel(new BindableCollection<InputItemViewModel>() { 
                new InputItemViewModel() { Hard_Kick = true }
            });
            tmpHitList = new BindableCollection<HitViewModel>();
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 40, 0, 125, 0, 60, new[] { HitViewModel.CancelAbilityEnum.Super }, 8, 8, 0, 0, 0, ""));
            tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 70, 0, 75, 0, 20, new HitViewModel.CancelAbilityEnum[] { }, 2, 4, 15, -1, 4, ""));

            moveList.Add(new MoveViewModel("Close Roundhouse", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

            FighterViewModel kenFighter = new FighterViewModel("Ken", FighterViewModel.FighterTypeEnum.Shoto, 1000, 1000, 0.045f, 0.030f, moveList);
            return kenFighter;
        }

        public static FighterViewModel EHonda()
        {
            BindableCollection<HitViewModel> tmpHitList; ;
            CommandViewModel tmpCommand;

            BindableCollection<MoveViewModel> moveList = new BindableCollection<MoveViewModel>();
            FighterViewModel fighter = new FighterViewModel("E. Honda", FighterViewModel.FighterTypeEnum.Shoto, 1000, 1000, 0.045f, 0.030f, moveList);
            return fighter;
        }

        public static FighterViewModel Ibuki()
        {
            BindableCollection<HitViewModel> tmpHitList; ;
            CommandViewModel tmpCommand;

            BindableCollection<MoveViewModel> moveList = new BindableCollection<MoveViewModel>();
            FighterViewModel fighter = new FighterViewModel("Ibuki", FighterViewModel.FighterTypeEnum.Shoto, 1000, 1000, 0.045f, 0.030f, moveList);
            return fighter;
        }

        public static FighterViewModel Makoto()
        {
            BindableCollection<HitViewModel> tmpHitList; ;
            CommandViewModel tmpCommand;

            BindableCollection<MoveViewModel> moveList = new BindableCollection<MoveViewModel>();
            FighterViewModel fighter = new FighterViewModel("Makoto", FighterViewModel.FighterTypeEnum.Shoto, 1000, 1000, 0.045f, 0.030f, moveList);
            return fighter;
        }

        public static FighterViewModel Dudley()
        {
            BindableCollection<HitViewModel> tmpHitList; ;
            CommandViewModel tmpCommand;

            BindableCollection<MoveViewModel> moveList = new BindableCollection<MoveViewModel>();
            FighterViewModel fighter = new FighterViewModel("Dudley", FighterViewModel.FighterTypeEnum.Shoto, 1000, 1000, 0.045f, 0.030f, moveList);
            return fighter;
        }

        public static FighterViewModel Seth()
        {
            BindableCollection<HitViewModel> tmpHitList; ;
            CommandViewModel tmpCommand;

            BindableCollection<MoveViewModel> moveList = new BindableCollection<MoveViewModel>();
            FighterViewModel fighter = new FighterViewModel("Seth", FighterViewModel.FighterTypeEnum.Shoto, 1000, 1000, 0.045f, 0.030f, moveList);
            return fighter;
        }

        public static FighterViewModel Gouken()
        {
            BindableCollection<HitViewModel> tmpHitList; ;
            CommandViewModel tmpCommand;

            BindableCollection<MoveViewModel> moveList = new BindableCollection<MoveViewModel>();
            FighterViewModel fighter = new FighterViewModel("Gouken", FighterViewModel.FighterTypeEnum.Shoto, 1000, 1000, 0.045f, 0.030f, moveList);
            return fighter;
        }

        public static FighterViewModel Akuma()
        {
            BindableCollection<HitViewModel> tmpHitList; ;
            CommandViewModel tmpCommand;

            BindableCollection<MoveViewModel> moveList = new BindableCollection<MoveViewModel>();
            FighterViewModel fighter = new FighterViewModel("Akuma", FighterViewModel.FighterTypeEnum.Shoto, 1000, 1000, 0.045f, 0.030f, moveList);
            return fighter;
        }

        public static FighterViewModel Gen()
        {
            BindableCollection<HitViewModel> tmpHitList; ;
            CommandViewModel tmpCommand;

            BindableCollection<MoveViewModel> moveList = new BindableCollection<MoveViewModel>();
            FighterViewModel fighter = new FighterViewModel("Gen", FighterViewModel.FighterTypeEnum.Shoto, 1000, 1000, 0.045f, 0.030f, moveList);
            return fighter;
        }

        public static FighterViewModel Dan()
        {
            BindableCollection<HitViewModel> tmpHitList; ;
            CommandViewModel tmpCommand;

            BindableCollection<MoveViewModel> moveList = new BindableCollection<MoveViewModel>();
            FighterViewModel fighter = new FighterViewModel("Dan", FighterViewModel.FighterTypeEnum.Shoto, 1000, 1000, 0.045f, 0.030f, moveList);
            return fighter;
        }

        public static FighterViewModel Sakura()
        {
            BindableCollection<HitViewModel> tmpHitList; ;
            CommandViewModel tmpCommand;

            BindableCollection<MoveViewModel> moveList = new BindableCollection<MoveViewModel>();
            FighterViewModel fighter = new FighterViewModel("Sakura", FighterViewModel.FighterTypeEnum.Shoto, 1000, 1000, 0.045f, 0.030f, moveList);
            return fighter;
        }

        public static FighterViewModel Oni()
        {
            BindableCollection<HitViewModel> tmpHitList; ;
            CommandViewModel tmpCommand;

            BindableCollection<MoveViewModel> moveList = new BindableCollection<MoveViewModel>();
            FighterViewModel fighter = new FighterViewModel("Oni", FighterViewModel.FighterTypeEnum.Shoto, 1000, 1000, 0.045f, 0.030f, moveList);
            return fighter;
        }

        public static FighterViewModel Yun()
        {
            BindableCollection<HitViewModel> tmpHitList; ;
            CommandViewModel tmpCommand;

            BindableCollection<MoveViewModel> moveList = new BindableCollection<MoveViewModel>();
            FighterViewModel fighter = new FighterViewModel("Yun", FighterViewModel.FighterTypeEnum.Shoto, 1000, 1000, 0.045f, 0.030f, moveList);
            return fighter;
        }

        public static FighterViewModel Juri()
        {
            BindableCollection<HitViewModel> tmpHitList; ;
            CommandViewModel tmpCommand;

            BindableCollection<MoveViewModel> moveList = new BindableCollection<MoveViewModel>();
            FighterViewModel fighter = new FighterViewModel("Juri", FighterViewModel.FighterTypeEnum.Shoto, 1000, 1000, 0.045f, 0.030f, moveList);
            return fighter;
        }

        public static FighterViewModel ChunLi()
        {
            BindableCollection<HitViewModel> tmpHitList; ;
            CommandViewModel tmpCommand;

            BindableCollection<MoveViewModel> moveList = new BindableCollection<MoveViewModel>();
            FighterViewModel fighter = new FighterViewModel("Chun-Li", FighterViewModel.FighterTypeEnum.Shoto, 1000, 1000, 0.045f, 0.030f, moveList);
            return fighter;
        }

        public static FighterViewModel Dhalsim()
        {
            BindableCollection<HitViewModel> tmpHitList; ;
            CommandViewModel tmpCommand;

            BindableCollection<MoveViewModel> moveList = new BindableCollection<MoveViewModel>();
            FighterViewModel fighter = new FighterViewModel("Dhalsim", FighterViewModel.FighterTypeEnum.Shoto, 1000, 1000, 0.045f, 0.030f, moveList);
            return fighter;
        }

        public static FighterViewModel Abel()
        {
            BindableCollection<HitViewModel> tmpHitList; ;
            CommandViewModel tmpCommand;

            BindableCollection<MoveViewModel> moveList = new BindableCollection<MoveViewModel>();
            FighterViewModel fighter = new FighterViewModel("Abel", FighterViewModel.FighterTypeEnum.Shoto, 1000, 1000, 0.045f, 0.030f, moveList);
            return fighter;
        }

        public static FighterViewModel CViper()
        {
            BindableCollection<HitViewModel> tmpHitList; ;
            CommandViewModel tmpCommand;

            BindableCollection<MoveViewModel> moveList = new BindableCollection<MoveViewModel>();
            FighterViewModel fighter = new FighterViewModel("C. Viper", FighterViewModel.FighterTypeEnum.Shoto, 1000, 1000, 0.045f, 0.030f, moveList);
            return fighter;
        }

        public static FighterViewModel MBison()
        {
            BindableCollection<HitViewModel> tmpHitList; ;
            CommandViewModel tmpCommand;

            BindableCollection<MoveViewModel> moveList = new BindableCollection<MoveViewModel>();
            FighterViewModel fighter = new FighterViewModel("M. Bison", FighterViewModel.FighterTypeEnum.Shoto, 1000, 1000, 0.045f, 0.030f, moveList);
            return fighter;
        }

        public static FighterViewModel Sagat()
        {
            BindableCollection<HitViewModel> tmpHitList; ;
            CommandViewModel tmpCommand;

            BindableCollection<MoveViewModel> moveList = new BindableCollection<MoveViewModel>();
            FighterViewModel fighter = new FighterViewModel("Sagat", FighterViewModel.FighterTypeEnum.Shoto, 1000, 1000, 0.045f, 0.030f, moveList);
            return fighter;
        }

        public static FighterViewModel Cammy()
        {
            BindableCollection<HitViewModel> tmpHitList; ;
            CommandViewModel tmpCommand;

            BindableCollection<MoveViewModel> moveList = new BindableCollection<MoveViewModel>();
            FighterViewModel fighter = new FighterViewModel("Cammy", FighterViewModel.FighterTypeEnum.Shoto, 1000, 1000, 0.045f, 0.030f, moveList);
            return fighter;
        }

        public static FighterViewModel DeeJay()
        {
            BindableCollection<HitViewModel> tmpHitList; ;
            CommandViewModel tmpCommand;

            BindableCollection<MoveViewModel> moveList = new BindableCollection<MoveViewModel>();
            FighterViewModel fighter = new FighterViewModel("Dee Jay", FighterViewModel.FighterTypeEnum.Shoto, 1000, 1000, 0.045f, 0.030f, moveList);
            return fighter;
        }

        public static FighterViewModel Cody()
        {
            BindableCollection<HitViewModel> tmpHitList; ;
            CommandViewModel tmpCommand;

            BindableCollection<MoveViewModel> moveList = new BindableCollection<MoveViewModel>();
            FighterViewModel fighter = new FighterViewModel("Cody", FighterViewModel.FighterTypeEnum.Shoto, 1000, 1000, 0.045f, 0.030f, moveList);
            return fighter;
        }

        public static FighterViewModel Guy()
        {
            BindableCollection<HitViewModel> tmpHitList; ;
            CommandViewModel tmpCommand;

            BindableCollection<MoveViewModel> moveList = new BindableCollection<MoveViewModel>();
            FighterViewModel fighter = new FighterViewModel("Guy", FighterViewModel.FighterTypeEnum.Shoto, 1000, 1000, 0.045f, 0.030f, moveList);
            return fighter;
        }

        public static FighterViewModel Hakan()
        {
            BindableCollection<HitViewModel> tmpHitList; ;
            CommandViewModel tmpCommand;

            BindableCollection<MoveViewModel> moveList = new BindableCollection<MoveViewModel>();
            FighterViewModel fighter = new FighterViewModel("Hakan", FighterViewModel.FighterTypeEnum.Shoto, 1000, 1000, 0.045f, 0.030f, moveList);
            return fighter;
        }

        public static FighterViewModel Yang()
        {
            BindableCollection<HitViewModel> tmpHitList; ;
            CommandViewModel tmpCommand;

            BindableCollection<MoveViewModel> moveList = new BindableCollection<MoveViewModel>();
            FighterViewModel fighter = new FighterViewModel("Yang", FighterViewModel.FighterTypeEnum.Shoto, 1000, 1000, 0.045f, 0.030f, moveList);
            return fighter;
        }

        public static FighterViewModel EvilRyu()
        {
            BindableCollection<HitViewModel> tmpHitList; ;
            CommandViewModel tmpCommand;

            BindableCollection<MoveViewModel> moveList = new BindableCollection<MoveViewModel>();
            FighterViewModel fighter = new FighterViewModel("Evil Ryu", FighterViewModel.FighterTypeEnum.Shoto, 1000, 1000, 0.045f, 0.030f, moveList);
            return fighter;
        }

        public static FighterViewModel Guile()
        {
            BindableCollection<HitViewModel> tmpHitList; ;
            CommandViewModel tmpCommand;

            BindableCollection<MoveViewModel> moveList = new BindableCollection<MoveViewModel>();
            FighterViewModel fighter = new FighterViewModel("Guile", FighterViewModel.FighterTypeEnum.Shoto, 1000, 1000, 0.045f, 0.030f, moveList);
            return fighter;
        }

        public static FighterViewModel Blanka()
        {
            BindableCollection<HitViewModel> tmpHitList; ;
            CommandViewModel tmpCommand;

            BindableCollection<MoveViewModel> moveList = new BindableCollection<MoveViewModel>();
            FighterViewModel fighter = new FighterViewModel("Blanka", FighterViewModel.FighterTypeEnum.Shoto, 1000, 1000, 0.045f, 0.030f, moveList);
            return fighter;
        }

        public static FighterViewModel Zangief()
        {
            BindableCollection<HitViewModel> tmpHitList; ;
            CommandViewModel tmpCommand;

            BindableCollection<MoveViewModel> moveList = new BindableCollection<MoveViewModel>();
            FighterViewModel fighter = new FighterViewModel("Zangief", FighterViewModel.FighterTypeEnum.Shoto, 1000, 1000, 0.045f, 0.030f, moveList);
            return fighter;
        }

        public static FighterViewModel Rufus()
        {
            BindableCollection<HitViewModel> tmpHitList; ;
            CommandViewModel tmpCommand;

            BindableCollection<MoveViewModel> moveList = new BindableCollection<MoveViewModel>();
            FighterViewModel fighter = new FighterViewModel("Rufus", FighterViewModel.FighterTypeEnum.Shoto, 1000, 1000, 0.045f, 0.030f, moveList);
            return fighter;
        }

        public static FighterViewModel ElFuerte()
        {
            BindableCollection<HitViewModel> tmpHitList; ;
            CommandViewModel tmpCommand;

            BindableCollection<MoveViewModel> moveList = new BindableCollection<MoveViewModel>();
            FighterViewModel fighter = new FighterViewModel("El Fuerte", FighterViewModel.FighterTypeEnum.Shoto, 1000, 1000, 0.045f, 0.030f, moveList);
            return fighter;
        }

        public static FighterViewModel Vega()
        {
            BindableCollection<HitViewModel> tmpHitList; ;
            CommandViewModel tmpCommand;

            BindableCollection<MoveViewModel> moveList = new BindableCollection<MoveViewModel>();
            FighterViewModel fighter = new FighterViewModel("Vega", FighterViewModel.FighterTypeEnum.Shoto, 1000, 1000, 0.045f, 0.030f, moveList);
            return fighter;
        }

        public static FighterViewModel Balrog()
        {
            BindableCollection<HitViewModel> tmpHitList; ;
            CommandViewModel tmpCommand;

            BindableCollection<MoveViewModel> moveList = new BindableCollection<MoveViewModel>();
            FighterViewModel fighter = new FighterViewModel("Balrog", FighterViewModel.FighterTypeEnum.Shoto, 1000, 1000, 0.045f, 0.030f, moveList);
            return fighter;
        }

        public static FighterViewModel FeiLong()
        {
            BindableCollection<HitViewModel> tmpHitList; ;
            CommandViewModel tmpCommand;

            BindableCollection<MoveViewModel> moveList = new BindableCollection<MoveViewModel>();
            FighterViewModel fighter = new FighterViewModel("Fei Long", FighterViewModel.FighterTypeEnum.Shoto, 1000, 1000, 0.045f, 0.030f, moveList);
            return fighter;
        }

        public static FighterViewModel THawk()
        {
            BindableCollection<HitViewModel> tmpHitList; ;
            CommandViewModel tmpCommand;

            BindableCollection<MoveViewModel> moveList = new BindableCollection<MoveViewModel>();
            FighterViewModel fighter = new FighterViewModel("T. Hawk", FighterViewModel.FighterTypeEnum.Shoto, 1000, 1000, 0.045f, 0.030f, moveList);
            return fighter;
        }

        public static FighterViewModel Adon()
        {
            BindableCollection<HitViewModel> tmpHitList; ;
            CommandViewModel tmpCommand;

            BindableCollection<MoveViewModel> moveList = new BindableCollection<MoveViewModel>();
            FighterViewModel fighter = new FighterViewModel("Adon", FighterViewModel.FighterTypeEnum.Shoto, 1000, 1000, 0.045f, 0.030f, moveList);
            return fighter;
        }

        public static FighterViewModel Rose()
        {
            BindableCollection<HitViewModel> tmpHitList; ;
            CommandViewModel tmpCommand;

            BindableCollection<MoveViewModel> moveList = new BindableCollection<MoveViewModel>();
            FighterViewModel fighter = new FighterViewModel("Rose", FighterViewModel.FighterTypeEnum.Shoto, 1000, 1000, 0.045f, 0.030f, moveList);
            return fighter;
        }
       
        //public static FighterViewModel Test2Data()
        //{

        //    BindableCollection<HitViewModel> tmpHitList; ;
        //    CommandViewModel tmpCommand;

        //    BindableCollection<MoveViewModel> moveList = new BindableCollection<MoveViewModel>();

        //    tmpCommand = new CommandViewModel(new BindableCollection<InputItemViewModel>() {
        //        new InputItemViewModel() { Light_Punch = true } 
        //    });
        //    tmpHitList = new BindableCollection<HitViewModel>();
        //    tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 30, 0, 50, 0, 20, new[] { HitViewModel.CancelAbilityEnum.Chain, HitViewModel.CancelAbilityEnum.Special, HitViewModel.CancelAbilityEnum.Super }, 3, 3, 6, 2, 5, ""));
        //    moveList.Add(new MoveViewModel("Close", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

        //    tmpHitList = new BindableCollection<HitViewModel>();
        //    tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 70, 0, 100, 0, 40, new[] { HitViewModel.CancelAbilityEnum.Special, HitViewModel.CancelAbilityEnum.Super }, 3, 3, 21, -3, 3, ""));
        //    moveList.Add(new MoveViewModel("Close", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

        //    tmpHitList = new BindableCollection<HitViewModel>();
        //    tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 100, 80, 200, 150, 60, new[] { HitViewModel.CancelAbilityEnum.Special, HitViewModel.CancelAbilityEnum.Super }, 5, 7, 26, -15, -10, "Forces stand, [] refers to active frames 3~5f"));
        //    moveList.Add(new MoveViewModel("Close", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

        //    tmpHitList = new BindableCollection<HitViewModel>();
        //    tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 30, 0, 50, 0, 20, new HitViewModel.CancelAbilityEnum[] { }, 5, 5, 7, -1, 2, ""));
        //    moveList.Add(new MoveViewModel("Close", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

        //    tmpHitList = new BindableCollection<HitViewModel>();
        //    tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 80, 0, 100, 0, 40, new[] { HitViewModel.CancelAbilityEnum.Special, HitViewModel.CancelAbilityEnum.Super }, 3, 5, 16, -7, -2, ""));
        //    moveList.Add(new MoveViewModel("Close", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

        //    tmpHitList = new BindableCollection<HitViewModel>();
        //    tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 40 * 70, 0, 125 * 75, 0, 60 * 20, new[] { HitViewModel.CancelAbilityEnum.Super }, 8, 8, 0, 0, 0, ""));
        //    tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 40 * 70, 0, 125 * 75, 0, 60 * 20, new HitViewModel.CancelAbilityEnum[] { }, 2, 4, 15, -1, 4, ""));
        //    moveList.Add(new MoveViewModel("Close", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

        //    tmpHitList = new BindableCollection<HitViewModel>();
        //    tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 30, 0, 50, 0, 20, new[] { HitViewModel.CancelAbilityEnum.Chain, HitViewModel.CancelAbilityEnum.Special, HitViewModel.CancelAbilityEnum.Super }, 4, 3, 6, 2, 5, ""));
        //    moveList.Add(new MoveViewModel("Far", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

        //    tmpHitList = new BindableCollection<HitViewModel>();
        //    tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 80, 0, 100, 0, 40, new[] { HitViewModel.CancelAbilityEnum.Special, HitViewModel.CancelAbilityEnum.Super }, 5, 4, 14, -4, -1, ""));
        //    moveList.Add(new MoveViewModel("Far", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

        //    tmpHitList = new BindableCollection<HitViewModel>();
        //    tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 120, 0, 200, 0, 60, new HitViewModel.CancelAbilityEnum[] { }, 8, 3, 15, 0, 4, ""));
        //    moveList.Add(new MoveViewModel("Far", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

        //    tmpHitList = new BindableCollection<HitViewModel>();
        //    tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 40, 0, 50, 0, 20, new HitViewModel.CancelAbilityEnum[] { }, 5, 6, 6, -1, 2, ""));
        //    moveList.Add(new MoveViewModel("Far", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

        //    tmpHitList = new BindableCollection<HitViewModel>();
        //    tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 80, 0, 100, 0, 40, new HitViewModel.CancelAbilityEnum[] { }, 8, 2, 17, -5, -2, ""));
        //    moveList.Add(new MoveViewModel("Far", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

        //    tmpHitList = new BindableCollection<HitViewModel>();
        //    tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 110, 0, 200, 0, 60, new HitViewModel.CancelAbilityEnum[] { }, 9, 4, 20, -6, -2, ""));
        //    moveList.Add(new MoveViewModel("Far", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

        //    tmpHitList = new BindableCollection<HitViewModel>();
        //    tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 30, 0, 50, 0, 20, new[] { HitViewModel.CancelAbilityEnum.Chain, HitViewModel.CancelAbilityEnum.Special, HitViewModel.CancelAbilityEnum.Super }, 3, 2, 7, 2, 5, ""));
        //    moveList.Add(new MoveViewModel("crouch", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

        //    tmpHitList = new BindableCollection<HitViewModel>();
        //    tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 60, 0, 100, 0, 40, new[] { HitViewModel.CancelAbilityEnum.Special, HitViewModel.CancelAbilityEnum.Super }, 4, 4, 8, 2, 5, ""));
        //    moveList.Add(new MoveViewModel("crouch", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

        //    tmpHitList = new BindableCollection<HitViewModel>();
        //    tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 90, 0, 200, 0, 60, new[] { HitViewModel.CancelAbilityEnum.Special, HitViewModel.CancelAbilityEnum.Super }, 4, 8, 28, -18, -13, "Forces stand"));
        //    moveList.Add(new MoveViewModel("crouch", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

        //    tmpHitList = new BindableCollection<HitViewModel>();
        //    tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Low, 20, 0, 50, 0, 20, new[] { HitViewModel.CancelAbilityEnum.Chain, HitViewModel.CancelAbilityEnum.Special, HitViewModel.CancelAbilityEnum.Super }, 4, 3, 9, -1, 2, ""));
        //    moveList.Add(new MoveViewModel("crouch", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

        //    tmpHitList = new BindableCollection<HitViewModel>();
        //    tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Low, 60, 0, 100, 0, 40, new[] { HitViewModel.CancelAbilityEnum.Special, HitViewModel.CancelAbilityEnum.Super }, 5, 5, 12, -3, 0, ""));
        //    moveList.Add(new MoveViewModel("crouch", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

        //    tmpHitList = new BindableCollection<HitViewModel>();
        //    tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Low, 90, 0, 100, 0, 60, new HitViewModel.CancelAbilityEnum[] { }, 5, 4, 28, -14, 0, "Untechable knockdown"));
        //    moveList.Add(new MoveViewModel("crouch", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

        //    tmpHitList = new BindableCollection<HitViewModel>();
        //    tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.High, 50, 0, 50, 0, 20, new HitViewModel.CancelAbilityEnum[] { }, 10, 7, 0, 0, 0, "Legs projectile invincible until end of startup frames"));
        //    moveList.Add(new MoveViewModel("Jump up", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

        //    tmpHitList = new BindableCollection<HitViewModel>();
        //    tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.High, 80, 0, 100, 0, 40, new HitViewModel.CancelAbilityEnum[] { }, 5, 5, 0, 0, 0, "Legs projectile invincible until end of active frames"));
        //    moveList.Add(new MoveViewModel("Jump up", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

        //    tmpHitList = new BindableCollection<HitViewModel>();
        //    tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.High, 100, 0, 200, 0, 60, new HitViewModel.CancelAbilityEnum[] { }, 6, 5, 0, 0, 0, "Legs projectile invincible until end of startup frames"));
        //    moveList.Add(new MoveViewModel("Jump up", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

        //    tmpHitList = new BindableCollection<HitViewModel>();
        //    tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.High, 40, 0, 50, 0, 20, new HitViewModel.CancelAbilityEnum[] { }, 5, 9, 0, 0, 0, "Legs projectile invincible until end of startup frames"));
        //    moveList.Add(new MoveViewModel("Jump up", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

        //    tmpHitList = new BindableCollection<HitViewModel>();
        //    tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.High, 80, 0, 100, 0, 40, new HitViewModel.CancelAbilityEnum[] { }, 6, 10, 0, 0, 0, "Legs projectile invincible until end of startup frames"));
        //    moveList.Add(new MoveViewModel("Jump up", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

        //    tmpHitList = new BindableCollection<HitViewModel>();
        //    tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.High, 100, 0, 200, 0, 60, new HitViewModel.CancelAbilityEnum[] { }, 4, 4, 0, 0, 0, "Legs projectile invincible until end of startup frames"));
        //    moveList.Add(new MoveViewModel("Jump up", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

        //    tmpHitList = new BindableCollection<HitViewModel>();
        //    tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.High, 50, 0, 50, 0, 20, new HitViewModel.CancelAbilityEnum[] { }, 4, 7, 0, 0, 0, "Legs projectile invincible until end of startup frames"));
        //    moveList.Add(new MoveViewModel("Jump forward", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

        //    tmpHitList = new BindableCollection<HitViewModel>();
        //    tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.High, 50 * 30, 0, 50 * 50, 0, 40 * 20, new HitViewModel.CancelAbilityEnum[] { }, 7, 3 * 4, 0, 0, 0, "Legs projectile invincible until end of startup frames, [1st air hit] floats opponent, [2nd air hit] knock down and can juggle"));
        //    moveList.Add(new MoveViewModel("Jump forward", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

        //    tmpHitList = new BindableCollection<HitViewModel>();
        //    tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.High, 100, 0, 200, 0, 60, new HitViewModel.CancelAbilityEnum[] { }, 6, 5, 0, 0, 0, "Legs projectile invincible until end of startup frames"));
        //    moveList.Add(new MoveViewModel("Jump forward", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

        //    tmpHitList = new BindableCollection<HitViewModel>();
        //    tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.High, 40, 0, 50, 0, 20, new HitViewModel.CancelAbilityEnum[] { }, 4, 8, 0, 0, 0, "Legs projectile invincible until end of startup frames"));
        //    moveList.Add(new MoveViewModel("Jump forward", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

        //    tmpHitList = new BindableCollection<HitViewModel>();
        //    tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.High, 70, 0, 100, 0, 40, new HitViewModel.CancelAbilityEnum[] { }, 6, 6, 0, 0, 0, "Legs projectile invincible until end of startup frames"));
        //    moveList.Add(new MoveViewModel("Jump forward", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

        //    tmpHitList = new BindableCollection<HitViewModel>();
        //    tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.High, 100, 0, 200, 0, 60, new HitViewModel.CancelAbilityEnum[] { }, 7, 7, 0, 0, 0, "Legs projectile invincible until end of startup frames"));
        //    moveList.Add(new MoveViewModel("Jump forward", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

        //    tmpHitList = new BindableCollection<HitViewModel>();
        //    tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.High, 30, 0, 50, 0, 40, new HitViewModel.CancelAbilityEnum[] { }, 17, 1, 0, 0, 0, ""));
        //    tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.High, 50, 0, 50, 0, 20, new HitViewModel.CancelAbilityEnum[] { }, 1, 2, 14, -2, 3, "Only +1 hit advantage on crouching opponents"));
        //    moveList.Add(new MoveViewModel("Collarbone Breaker", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

        //    tmpHitList = new BindableCollection<HitViewModel>();
        //    tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 40, 0, 50, 0, 60, new HitViewModel.CancelAbilityEnum[] { }, 17, 2, 0, 0, 0, ""));
        //    tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 60, 0, 50, 0, 20, new[] { HitViewModel.CancelAbilityEnum.Special, HitViewModel.CancelAbilityEnum.Super }, 0, 2, 18, 0, 4, "Can only cancel in last 3 recovery frames"));
        //    moveList.Add(new MoveViewModel("Solarplexus Strike", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

        //    tmpHitList = new BindableCollection<HitViewModel>();
        //    tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 60, 0, 100, 0, 20, new HitViewModel.CancelAbilityEnum[] { }, 10 + 11, 2, 35, -21, -21, ""));
        //    moveList.Add(new MoveViewModel("Focus Attack LVL 1", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

        //    tmpHitList = new BindableCollection<HitViewModel>();
        //    tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 80, 0, 150, 0, 40, new HitViewModel.CancelAbilityEnum[] { }, 18 + 11, 2, 35, -15, 0, ""));
        //    moveList.Add(new MoveViewModel("Focus Attack LVL 2", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));


        //    tmpHitList = new BindableCollection<HitViewModel>();
        //    tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 140, 0, 200, 0, 60, new HitViewModel.CancelAbilityEnum[] { }, 65, 2, 35, 0, 0, ""));
        //    moveList.Add(new MoveViewModel("Focus Attack LVL 3", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));


        //    tmpHitList = new BindableCollection<HitViewModel>();
        //    tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Techable, 130, 0, 140, 0, 40, new HitViewModel.CancelAbilityEnum[] { }, 3, 2, 20, 0, 0, "Untechable knockdown"));
        //    moveList.Add(new MoveViewModel("Forward Throw", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

        //    tmpHitList = new BindableCollection<HitViewModel>();
        //    tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Techable, 130, 0, 120, 0, 40, new HitViewModel.CancelAbilityEnum[] { }, 3, 2, 20, 0, 0, "Untechable knockdown"));
        //    moveList.Add(new MoveViewModel("Back Throw", MoveViewModel.MoveTypeEnum.Normal, tmpHitList, tmpCommand));

        //    tmpHitList = new BindableCollection<HitViewModel>();
        //    tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 70, 0, 100, 0, 10 / 20, new[] { HitViewModel.CancelAbilityEnum.Super }, 13, 0, 45, -6, -2, "[air hit] knock down, 16~17f focus cancellable"));
        //    moveList.Add(new MoveViewModel("Hadoken", MoveViewModel.MoveTypeEnum.Special, tmpHitList, tmpCommand));

        //    tmpHitList = new BindableCollection<HitViewModel>();
        //    tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 50, 0, 50, 0, -250, new[] { HitViewModel.CancelAbilityEnum.Super }, 12, 0, 40, 1, 0, "knock down, can juggle, [counterhit] floats opponent, 15~16f focus cancellable"));
        //    tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid, 50, 0, 50, 0, 0, new[] { HitViewModel.CancelAbilityEnum.Super }, 12, 0, 40, 1, 0, ""));
        //    moveList.Add(new MoveViewModel("Hadoken", MoveViewModel.MoveTypeEnum.ExtraSpecial, tmpHitList, tmpCommand));

        //    //tmpHitList= new BindableCollection<HitViewModel>(); 
        //    //   tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid,100,70,200,100,30 ,new[] {HitViewModel.CancelAbilityEnum.Super},3,14,24,-17,0,"1~2f Invincible, 3~4f unthrowable, 3~16f lower body invincibility, 4f~ airborne, knock down, [] refers to active frames 3~14f"));
        //    //        moveList.Add(new MoveViewModel("Shoryuken", MoveViewModel.MoveTypeEnum.Special, tmpHitList, tmpCommand));

        //    //tmpHitList= new BindableCollection<HitViewModel>(); 
        //    //   tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid,80,0,150,0,20,new[] {HitViewModel.CancelAbilityEnum.Super},3,2,0,0,0,"1~5f Invincible, 6~16f lower body invincibility, 5f~ airborne, knock down, "));
        //    //   tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid,50,0,50,0,20,new HitViewModel.CancelAbilityEnum[]{},0,12,43,-34,0,"[2nd hit] can juggle"));
        //    //        moveList.Add(new MoveViewModel("Shoryuken", MoveViewModel.MoveTypeEnum.Special, tmpHitList, tmpCommand));

        //    //tmpHitList= new BindableCollection<HitViewModel>(); 
        //    //   tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid,160,60,200,50,20/40[20], new HitViewModel.CancelAbilityEnum[] { } ,3,14,46,-37,0,"1~4f Invincible, 3~4f unthrowable, 5~16f lower body invincibility, 3f~ airborne, knock down, [] refers to active frames 3~14f"));
        //    //        moveList.Add(new MoveViewModel("Shoryuken", MoveViewModel.MoveTypeEnum.Special, tmpHitList, tmpCommand));

        //    //tmpHitList= new BindableCollection<HitViewModel>(); 
        //    //   tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid,80*60,0,100*100,0,-250/0,new[] {HitViewModel.CancelAbilityEnum.Super},3,2*12,30 + After landing 18,-39,0,"1~16f Invincible, 6f~ airborne, knock down, [2nd hit] can juggle"));
        //    //        moveList.Add(new MoveViewModel("Shoryuken", MoveViewModel.MoveTypeEnum.ExtraSpecial, tmpHitList, tmpCommand));

        //    //tmpHitList= new BindableCollection<HitViewModel>(); 
        //    //   tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid,100,0,200,0,30/30, new HitViewModel.CancelAbilityEnum[] { } ,11,2(6)2,12 + After landing 5,-6,0,"7~20f lower body immune to projectiles, 7f~ airborne, knock down, armor break, cannot hit crouching opponents, [2nd hit] aimed backwards"));
        //    //        moveList.Add(new MoveViewModel("Hurricane Kick", MoveViewModel.MoveTypeEnum.Special, tmpHitList, tmpCommand));

        //    //tmpHitList= new BindableCollection<HitViewModel>(); 
        //    //   tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid,110,0,200,0,30/30, new HitViewModel.CancelAbilityEnum[] { } ,12,2(6)2(6)2(6)2(6)2,18 + After landing 3,-2,0,"7~45f lower body immune to projectiles, 7f~ airborne, knock down, armor break, cannot hit crouching opponents, [2nd hit, 4th hit] aimed backwards"));
        //    //        moveList.Add(new MoveViewModel("Hurricane Kick", MoveViewModel.MoveTypeEnum.Special, tmpHitList, tmpCommand));

        //    //tmpHitList= new BindableCollection<HitViewModel>(); 
        //    //   tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid,120,0,200,0,30/30, new HitViewModel.CancelAbilityEnum[] { } ,12,2(6)2(6)2(6)2(6)2,18 + After landing 3,-2,0,"7~45f lower body immune to projectiles, 7f~ airborne, knock down, armor break, cannot hit crouching opponents, [2nd hit, 4th hit] aimed backwards"));
        //    //        moveList.Add(new MoveViewModel("Hurricane Kick", MoveViewModel.MoveTypeEnum.Special, tmpHitList, tmpCommand));

        //    //tmpHitList= new BindableCollection<HitViewModel>(); 
        //    //   tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid,30x4*40,0,40x5,0,-250/0, new HitViewModel.CancelAbilityEnum[] { } ,11,1(3)1(3)1(3)1(3)1,18 + After landing 3,-1,0,"6~27f lower body immune to projectiles, 6f~ airborne, [1st-4th hit] forces stand, [air hit, 5th hit] knock down, armor break, can juggle, [2nd, 4th hit] aimed backwards"));
        //    //        moveList.Add(new MoveViewModel("Hurricane Kick", MoveViewModel.MoveTypeEnum.ExtraSpecialSpecial, tmpHitList, tmpCommand));

        //    //tmpHitList= new BindableCollection<HitViewModel>(); 
        //    //   tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid,70,0,100,0,10/40, new HitViewModel.CancelAbilityEnum[] { } ,9,2(6)2(6)2,After landing 10,0,0,"knock down, [2nd, 4th hit] aimed backwards"));
        //    //        moveList.Add(new MoveViewModel("Hurricane Kick  (air)", MoveViewModel.MoveTypeEnum.Special, tmpHitList, tmpCommand));

        //    //tmpHitList= new BindableCollection<HitViewModel>(); 
        //    //   tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid,80,0,100,0,10/40, new HitViewModel.CancelAbilityEnum[] { } ,9,2(6)2(6)2,After landing 10,0,0,"knock down, [2nd, 4th hit] aimed backwards"));
        //    //        moveList.Add(new MoveViewModel("Hurricane Kick  (air)", MoveViewModel.MoveTypeEnum.Special, tmpHitList, tmpCommand));

        //    //tmpHitList= new BindableCollection<HitViewModel>(); 
        //    //   tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid,90,0,100,0,10/40, new HitViewModel.CancelAbilityEnum[] { } ,9,2(6)2(6)2,After landing 10,0,0,"knock down, [2nd, 4th hit] aimed backwards"));
        //    //        moveList.Add(new MoveViewModel("Hurricane Kick  (air)", MoveViewModel.MoveTypeEnum.Special, tmpHitList, tmpCommand));

        //    //tmpHitList= new BindableCollection<HitViewModel>(); 
        //    //   tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid,40x5,0,50x5,0,-250/0, new HitViewModel.CancelAbilityEnum[] { } ,7,1(3)1(3)1(3)1(3)1,After landing 4,0,0,"knock down, can juggle, [2nd, 4th hit] aimed backwards"));
        //    //        moveList.Add(new MoveViewModel("Hurricane Kick  (air)", MoveViewModel.MoveTypeEnum.ExtraSpecial, tmpHitList, tmpCommand));

        //    //tmpHitList= new BindableCollection<HitViewModel>(); 
        //    //   tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid,50x4*100,0,0,0,-1000/0, new HitViewModel.CancelAbilityEnum[] { } ,1+2,0,Total 52,11,0,"1f Invincible, [1st-4th air hit] untechable knockdown, [5th hit] untechable knockdown, can juggle"));
        //    //        moveList.Add(new MoveViewModel("Super Combo", MoveViewModel.MoveTypeEnum.Super, tmpHitList, tmpCommand));

        //    //tmpHitList= new BindableCollection<HitViewModel>(); 
        //    //   tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid,42x7*75,0,0,0,0/0, new HitViewModel.CancelAbilityEnum[] { } ,0+11,0,Total 120,-25,0,"1~9f Invincible, [1st-7th air hit] or [8th hit] untechable knockdown, can juggle"));
        //    //        moveList.Add(new MoveViewModel("Ultra Combo 1", MoveViewModel.MoveTypeEnum.Ultra, tmpHitList, tmpCommand));

        //    //tmpHitList= new BindableCollection<HitViewModel>(); 
        //    //   tmpHitList.Add(new HitViewModel(HitViewModel.BlockTypeEnum.Mid,270*38x4*50x3,270*233,0,0,0/0, new HitViewModel.CancelAbilityEnum[] { } ,0+8,3*3x7,43+ After landing 41,-84,0,"1~10f Invincible, 11~31f lower body invincibility, 11f~ airborne, untechable knockdown, [2nd hit] (translate) can juggle, armor break, 1st hit goes into animation, [] refers to animation, guard advantage assumes 2nd hit"));
        //    //        moveList.Add(new MoveViewModel("Ultra Combo 2", MoveViewModel.MoveTypeEnum.Ultra, tmpHitList, tmpCommand));

        //    FighterViewModel fighter = new FighterViewModel(events, "Ryu", FighterViewModel.FighterTypeEnum.Shoto, 1000, 1000, 0.045f, 0.030f, moveList);
        //    return fighter;
        //}
    }


}

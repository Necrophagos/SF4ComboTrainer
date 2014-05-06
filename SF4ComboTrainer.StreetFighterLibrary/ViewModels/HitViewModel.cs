namespace SF4ComboTrainer.StreetFighterLibrary.ViewModels
{
    using System.Collections.Generic;

    public class HitViewModel
    {
        public enum BlockTypeEnum
        {
            High,
            Mid,
            Low
        }

        public enum CancelAbilityEnum
        {
            Chain,
            Special,
            Super,
            Ultra
        }

        public BlockTypeEnum BlockType { get; set; }
        public int Damage { get; set; }
        public int LateDamage { get; set; }
        public int Stun { get; set; }
        public int LateStun { get; set; }
        public int MeterGain { get; set; }
        public List<CancelAbilityEnum> CancelAbility { get; set; }
        public int Startup { get; set; }
        public int Active { get; set; }
        public int Recovery { get; set; }
        public int OnBlockAdvantage { get; set; }
        public int OnHitAdvantage { get; set; }
        public string Notes { get; set; }

        public HitViewModel(BlockTypeEnum blockType,
            int damage,
            int lateDamage,
            int stun,
            int lateStun,
            int meterGain,
            CancelAbilityEnum[] cancelAbility,
            int startup,
            int active,
            int recovery,
            int onBlockAdvantage,
            int onHitAdvantage,
            string notes)
        {
            BlockType = blockType;
            Damage = damage;
            LateDamage = lateDamage;
            Stun = stun;
            LateStun = lateStun;
            MeterGain = meterGain;
            CancelAbility = new List<CancelAbilityEnum>();
            CancelAbility.AddRange(cancelAbility);
            Startup = startup;
            Active = active;
            Recovery = recovery;
            OnBlockAdvantage = onBlockAdvantage;
            OnHitAdvantage = onHitAdvantage;
            Notes = notes;
        }
    }
}

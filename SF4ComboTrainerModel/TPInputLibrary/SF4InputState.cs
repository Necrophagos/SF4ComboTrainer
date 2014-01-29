using SF4ComboTrainerModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace TPInputLibrary
{
    public class SF4InputState
    {
        //Options
        public bool Back;
        public bool Start;

        //Direction
        public bool Up;
        public bool Down;
        public bool Left;
        public bool Right;

        public bool Forward;
        public bool Backward;

        //Punch
        public bool LightPunch;
        public bool MediumPunch;
        public bool HardPunch;

        //Kick
        public bool LightKick;
        public bool MediumKick;
        public bool HardKick;



        public bool NonePressed
        {
            get
            {
                return

                    Back
                    && Start
                    && Up
                    && Down
                    && Left
                    && Right
                    && Forward
                    && Backward
                    && LightPunch
                    && MediumPunch
                    && HardPunch
                    && LightKick
                    && MediumKick
                    && HardKick
                    ;
            }
        }

        public Input[] ToInputsArray()
        {
            List<Input> tmp = new List<Input>();

            if (Up) tmp.Add(Input.P1_UP);
            if (Down) tmp.Add(Input.P1_DN);
            if (Left) tmp.Add(Input.P1_LE);
            if (Right) tmp.Add(Input.P1_RI);
            if (Forward) tmp.Add(Input.P1_FW);
            if (Backward) tmp.Add(Input.P1_BK);
            if (LightPunch) tmp.Add(Input.P1_LP);
            if (MediumPunch) tmp.Add(Input.P1_MP);
            if (HardPunch) tmp.Add(Input.P1_HP);
            if (LightKick) tmp.Add(Input.P1_LK);
            if (MediumKick) tmp.Add(Input.P1_MK);
            if (HardKick) tmp.Add(Input.P1_HK);

            return tmp.ToArray();
        }

        public bool Equals(SF4InputState other)
        {
            if (object.ReferenceEquals(other, null)) return false;

            bool result = true;
            result &= Back == other.Back;
            result &= Start == other.Start;
            result &= Up == other.Up;
            result &= Down == other.Down;
            result &= Left == other.Left;
            result &= Right == other.Right;
            result &= Forward == other.Forward;
            result &= Backward == other.Backward;
            result &= LightPunch == other.LightPunch;
            result &= MediumPunch == other.MediumPunch;
            result &= HardPunch == other.HardPunch;
            result &= LightKick == other.LightKick;
            result &= MediumKick == other.MediumKick;
            result &= HardKick == other.HardKick;

            return result;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as SF4InputState);
        }

        public static bool operator ==(SF4InputState lhs, SF4InputState rhs)
        {
            return
                object.ReferenceEquals(lhs, rhs) ||
                !object.ReferenceEquals(lhs, null) && lhs.Equals(rhs);
        }

        public static bool operator !=(SF4InputState lhs, SF4InputState rhs)
        {
            return !(lhs == rhs);
        }

        public override int GetHashCode()
        {
            int hash = 13;
            hash = (hash * 7) + Back.GetHashCode();
            hash = (hash * 7) + Start.GetHashCode();
            hash = (hash * 7) + Up.GetHashCode();
            hash = (hash * 7) + Down.GetHashCode();
            hash = (hash * 7) + Left.GetHashCode();
            hash = (hash * 7) + Right.GetHashCode();
            hash = (hash * 7) + Forward.GetHashCode();
            hash = (hash * 7) + Backward.GetHashCode();
            hash = (hash * 7) + LightPunch.GetHashCode();
            hash = (hash * 7) + MediumPunch.GetHashCode();
            hash = (hash * 7) + HardPunch.GetHashCode();
            hash = (hash * 7) + LightKick.GetHashCode();
            hash = (hash * 7) + MediumKick.GetHashCode();
            hash = (hash * 7) + HardKick.GetHashCode();
            return hash;
        }

    }
}

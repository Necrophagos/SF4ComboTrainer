using SF4ComboTrainerModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace TPInputLibrary
{
    public class SF4InputState
    {
        public struct Option
        {
            public bool Back;
            public bool Start;

        }

        public struct Direction
        {
            public bool Up;
            public bool Down;
            public bool Left;
            public bool Right;

            public bool Forward;
            public bool Backward;


            public bool NonePressed { get { return !Up && !Down && !Left && !Right; } }
        }

        public struct Punch
        {
            public bool Light;
            public bool Medium;
            public bool Hard;

            public bool NonePressed { get { return !Light && !Medium && !Hard; } }
        }

        public struct Kick
        {
            public bool Light;
            public bool Medium;
            public bool Hard;

            public bool NonePressed { get { return !Light && !Medium && !Hard; } }
        }

        public Option Options;
        public Direction Directions;
        public Punch Punches;
        public Kick Kicks;

        public bool NonePressed { get { return Directions.NonePressed && Punches.NonePressed && Kicks.NonePressed; } }

        public Input[] ToInputsArray()
        {
            List<Input> tmp = new List<Input>();

            if (Directions.Up) tmp.Add(Input.P1_UP);
            if (Directions.Down) tmp.Add(Input.P1_DN);
            if (Directions.Left) tmp.Add(Input.P1_LE);
            if (Directions.Right) tmp.Add(Input.P1_RI);
            if (Directions.Forward) tmp.Add(Input.P1_FW);
            if (Directions.Backward) tmp.Add(Input.P1_BK);
            if (Punches.Light) tmp.Add(Input.P1_LP);
            if (Punches.Medium) tmp.Add(Input.P1_MP);
            if (Punches.Hard) tmp.Add(Input.P1_HP);
            if (Kicks.Light) tmp.Add(Input.P1_LK);
            if (Kicks.Medium) tmp.Add(Input.P1_MK);
            if (Kicks.Hard) tmp.Add(Input.P1_HK);

            return tmp.ToArray();
        }

        public bool Equals(SF4InputState other)
        {
            if (object.ReferenceEquals(other, null)) return false;

            bool result = true;
            result &= Options.Back == other.Options.Back;
            result &= Options.Start == other.Options.Start;
            result &= Directions.Up == other.Directions.Up;
            result &= Directions.Down == other.Directions.Down;
            result &= Directions.Left == other.Directions.Left;
            result &= Directions.Right == other.Directions.Right;
            result &= Directions.Forward == other.Directions.Forward;
            result &= Directions.Backward == other.Directions.Backward;
            result &= Punches.Light == other.Punches.Light;
            result &= Punches.Medium == other.Punches.Medium;
            result &= Punches.Hard == other.Punches.Hard;
            result &= Kicks.Light == other.Kicks.Light;
            result &= Kicks.Medium == other.Kicks.Medium;
            result &= Kicks.Hard == other.Kicks.Hard;

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
            hash = (hash * 7) + Options.Back.GetHashCode();
            hash = (hash * 7) + Options.Start.GetHashCode();
            hash = (hash * 7) + Directions.Up.GetHashCode();
            hash = (hash * 7) + Directions.Down.GetHashCode();
            hash = (hash * 7) + Directions.Left.GetHashCode();
            hash = (hash * 7) + Directions.Right.GetHashCode();
            hash = (hash * 7) + Directions.Forward.GetHashCode();
            hash = (hash * 7) + Directions.Backward.GetHashCode();
            hash = (hash * 7) + Punches.Light.GetHashCode();
            hash = (hash * 7) + Punches.Medium.GetHashCode();
            hash = (hash * 7) + Punches.Hard.GetHashCode();
            hash = (hash * 7) + Kicks.Light.GetHashCode();
            hash = (hash * 7) + Kicks.Medium.GetHashCode();
            hash = (hash * 7) + Kicks.Hard.GetHashCode();
            return hash;
        }

    }
}

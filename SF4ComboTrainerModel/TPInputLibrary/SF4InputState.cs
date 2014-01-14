using SF4ComboTrainerModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace TPInputLibrary
{
    public class SF4InputState
    {
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
        
    }
}

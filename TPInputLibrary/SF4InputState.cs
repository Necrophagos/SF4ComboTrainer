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
    }
}

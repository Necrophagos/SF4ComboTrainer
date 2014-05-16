
namespace FrameTrapped.Input.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    public enum Input
    {
        P1_LE,
        P1_RI,
        P1_BK,
        P1_FW,
        P1_DN,
        P1_UP,
        P1_LP,
        P1_MP,
        P1_HP,
        P1_LK,
        P1_MK,
        P1_HK
    }

    public class InputCommandModel : ISerializable
    {
        public enum DirectionStateEnum
        {
            UpBack,
            Up,
            UpForward,

            Back,
            Neutral,
            Forward,

            DownBack,
            Down,
            DownForward
        }

        public enum ButtonStateEnum
        {
            Pressed,
            Released
        }


        public DirectionStateEnum DirectionState;

        public ButtonStateEnum LightPunch;
        public ButtonStateEnum MediumPunch;
        public ButtonStateEnum HardPunch;

        public ButtonStateEnum LightKick;
        public ButtonStateEnum MediumKick;
        public ButtonStateEnum HardKick;

        public bool NonePressed
        {
            get
            {
                return
                    DirectionState == DirectionStateEnum.Neutral &&
                    LightPunch == ButtonStateEnum.Released &&
                    MediumPunch == ButtonStateEnum.Released &&
                    HardPunch == ButtonStateEnum.Released &&
                    LightKick == ButtonStateEnum.Released &&
                    MediumKick == ButtonStateEnum.Released &&
                    HardKick == ButtonStateEnum.Released;
            }
        }

        /// <summary>
        /// Converts the current SF4InputState into an InputsArray.
        /// </summary>
        /// <returns><see cref="Input"/> array.</returns>
        public Input[] ToInputsArray()
        {
            List<Input> inputsArray = new List<Input>();
            switch (DirectionState)
            {
                case DirectionStateEnum.UpBack:
                    inputsArray.Add(Input.P1_UP);
                    inputsArray.Add(Input.P1_BK);
                    break;
                case DirectionStateEnum.Up:
                    inputsArray.Add(Input.P1_UP);
                    break;
                case DirectionStateEnum.UpForward:
                    inputsArray.Add(Input.P1_UP);
                    inputsArray.Add(Input.P1_FW);
                    break;
                case DirectionStateEnum.Back:
                    inputsArray.Add(Input.P1_BK);
                    break;
                case DirectionStateEnum.Neutral:
                    // Do nothing - Placeholder for later.
                    break;
                case DirectionStateEnum.Forward:
                    inputsArray.Add(Input.P1_FW);
                    break;
                case DirectionStateEnum.DownBack:
                    inputsArray.Add(Input.P1_DN);
                    inputsArray.Add(Input.P1_BK);
                    break;
                case DirectionStateEnum.Down:
                    inputsArray.Add(Input.P1_DN);
                    break;
                case DirectionStateEnum.DownForward:
                    inputsArray.Add(Input.P1_DN);
                    inputsArray.Add(Input.P1_FW);
                    break;
            }

            if (LightPunch == ButtonStateEnum.Pressed) inputsArray.Add(Input.P1_LP);
            if (MediumPunch == ButtonStateEnum.Pressed) inputsArray.Add(Input.P1_MP);
            if (HardPunch == ButtonStateEnum.Pressed) inputsArray.Add(Input.P1_HP);
            if (LightKick == ButtonStateEnum.Pressed) inputsArray.Add(Input.P1_LK);
            if (MediumKick == ButtonStateEnum.Pressed) inputsArray.Add(Input.P1_MK);
            if (HardKick == ButtonStateEnum.Pressed) inputsArray.Add(Input.P1_HK);

            return inputsArray.ToArray();
        }


        /// <summary>
        /// Converts the current SF4InputState into an InputsArray.
        /// </summary>
        /// <returns><see cref="Input"/> array.</returns>
        public Input[] ToInputsPressedArray()
        {
            List<Input> inputsArray = new List<Input>();
            switch (DirectionState)
            {
                case DirectionStateEnum.UpBack:
                    inputsArray.Add(Input.P1_UP);
                    inputsArray.Add(Input.P1_BK);
                    break;
                case DirectionStateEnum.Up:
                    inputsArray.Add(Input.P1_UP);
                    break;
                case DirectionStateEnum.UpForward:
                    inputsArray.Add(Input.P1_UP);
                    inputsArray.Add(Input.P1_FW);
                    break;
                case DirectionStateEnum.Back:
                    inputsArray.Add(Input.P1_BK);
                    break;
                case DirectionStateEnum.Neutral:
                    // Do nothing - Placeholder for later.
                    break;
                case DirectionStateEnum.Forward:
                    inputsArray.Add(Input.P1_FW);
                    break;
                case DirectionStateEnum.DownBack:
                    inputsArray.Add(Input.P1_DN);
                    inputsArray.Add(Input.P1_BK);
                    break;
                case DirectionStateEnum.Down:
                    inputsArray.Add(Input.P1_DN);
                    break;
                case DirectionStateEnum.DownForward:
                    inputsArray.Add(Input.P1_DN);
                    inputsArray.Add(Input.P1_FW);
                    break;
            }

            if (LightPunch == ButtonStateEnum.Pressed) inputsArray.Add(Input.P1_LP);
            if (MediumPunch == ButtonStateEnum.Pressed) inputsArray.Add(Input.P1_MP);
            if (HardPunch == ButtonStateEnum.Pressed) inputsArray.Add(Input.P1_HP);
            if (LightKick == ButtonStateEnum.Pressed) inputsArray.Add(Input.P1_LK);
            if (MediumKick == ButtonStateEnum.Pressed) inputsArray.Add(Input.P1_MK);
            if (HardKick == ButtonStateEnum.Pressed) inputsArray.Add(Input.P1_HK);

            return inputsArray.ToArray();
        }


        /// <summary>
        /// Converts the current SF4InputState into an InputsArray.
        /// </summary>
        /// <returns><see cref="Input"/> array.</returns>
        public Input[] ToReleasedArray()
        {
            List<Input> inputsArray = new List<Input>();
            inputsArray.Add(Input.P1_UP);
            inputsArray.Add(Input.P1_DN);
            inputsArray.Add(Input.P1_FW);
            inputsArray.Add(Input.P1_BK);

            switch (DirectionState)
            {
                case DirectionStateEnum.UpBack:
                    inputsArray.Remove(Input.P1_UP);
                    inputsArray.Remove(Input.P1_BK);
                    break;
                case DirectionStateEnum.Up:
                    inputsArray.Remove(Input.P1_UP);
                    break;
                case DirectionStateEnum.UpForward:
                    inputsArray.Remove(Input.P1_UP);
                    inputsArray.Remove(Input.P1_FW);
                    break;
                case DirectionStateEnum.Back:
                    inputsArray.Remove(Input.P1_BK);
                    break;
                case DirectionStateEnum.Neutral:
                    // Do nothing - Placeholder for later.
                    break;
                case DirectionStateEnum.Forward:
                    inputsArray.Remove(Input.P1_FW);
                    break;
                case DirectionStateEnum.DownBack:
                    inputsArray.Remove(Input.P1_DN);
                    inputsArray.Remove(Input.P1_BK);
                    break;
                case DirectionStateEnum.Down:
                    inputsArray.Remove(Input.P1_DN);
                    break;
                case DirectionStateEnum.DownForward:
                    inputsArray.Remove(Input.P1_DN);
                    inputsArray.Remove(Input.P1_FW);
                    break;
            }

            if (LightPunch == ButtonStateEnum.Released) inputsArray.Add(Input.P1_LP);
            if (MediumPunch == ButtonStateEnum.Released) inputsArray.Add(Input.P1_MP);
            if (HardPunch == ButtonStateEnum.Released) inputsArray.Add(Input.P1_HP);
            if (LightKick == ButtonStateEnum.Released) inputsArray.Add(Input.P1_LK);
            if (MediumKick == ButtonStateEnum.Released) inputsArray.Add(Input.P1_MK);
            if (HardKick == ButtonStateEnum.Released) inputsArray.Add(Input.P1_HK);

            return inputsArray.ToArray();
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new System.NotImplementedException();
        }

        public InputCommandModel()
        {
            LightPunch = ButtonStateEnum.Released;
            MediumPunch = ButtonStateEnum.Released;
            HardPunch = ButtonStateEnum.Released;

            LightKick = ButtonStateEnum.Released;
            MediumKick = ButtonStateEnum.Released;
            HardKick = ButtonStateEnum.Released;

            DirectionState = DirectionStateEnum.Neutral;
        }
    }
}

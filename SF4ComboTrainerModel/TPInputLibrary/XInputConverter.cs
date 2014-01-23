using System;
using XInputDotNetPure;

namespace TPInputLibrary
{
    public class XInputConverter : SF4InputConverter
    {

        bool playerIndexSet = false;
        PlayerIndex playerIndex;
        GamePadState gamePadState;
        GamePadState prevState;

        public XInputConverter(int playerSlot)
        {
            VerifyControllerConnected(playerSlot);

        }

        private void VerifyControllerConnected(int playerSlot, bool required = false)
        {
            // Find a PlayerIndex, for a single player game
            if (!playerIndexSet || !prevState.IsConnected)
            {
                PlayerIndex testPlayerIndex = (PlayerIndex)playerSlot - 1;
                GamePadState testState = GamePad.GetState(testPlayerIndex);
                if (testState.IsConnected)
                {
                    //Debug.Log (string.Format ("GamePad found {0}", testPlayerIndex));
                    playerIndex = testPlayerIndex;
                    playerIndexSet = true;
                }
                else
                {
                    if (required)
                    {
                        throw new Exception(string.Format("GamePad {0} has been unplugged or is not connecting properly", testPlayerIndex));
                    }
                }
            }
        }

        public override SF4InputState Convert()
        {
            SF4InputState outputState = new SF4InputState();

            gamePadState = GamePad.GetState(playerIndex);

            //Options
            outputState.Back = gamePadState.Buttons.Back == ButtonState.Pressed;
            outputState.Start = gamePadState.Buttons.Start == ButtonState.Pressed;

            //Punches 
            outputState.LightPunch = gamePadState.Buttons.X == ButtonState.Pressed;
            outputState.MediumPunch = gamePadState.Buttons.Y == ButtonState.Pressed;
            outputState.HardPunch = gamePadState.Buttons.RightShoulder == ButtonState.Pressed;

            //Kicks
            outputState.LightKick = gamePadState.Buttons.A == ButtonState.Pressed;
            outputState.MediumKick = gamePadState.Buttons.B == ButtonState.Pressed;
            outputState.HardKick = gamePadState.Triggers.Right > 0.25f;

            //Determine if Dpad has any input
            outputState.Right = (gamePadState.DPad.Right == ButtonState.Pressed || gamePadState.ThumbSticks.Left.X > 0.25f);

            outputState.Left = (gamePadState.DPad.Left == ButtonState.Pressed || -gamePadState.ThumbSticks.Left.X > 0.25f);

            outputState.Up = (gamePadState.DPad.Up == ButtonState.Pressed || gamePadState.ThumbSticks.Left.Y > 0.25f);

            outputState.Down = (gamePadState.DPad.Down == ButtonState.Pressed || -gamePadState.ThumbSticks.Left.Y > 0.25f);

            return outputState;
        }
    }
}



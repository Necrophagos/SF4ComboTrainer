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

            //Punches 
            outputState.Punches.Light = gamePadState.Buttons.X == ButtonState.Pressed;
            outputState.Punches.Medium = gamePadState.Buttons.Y == ButtonState.Pressed;
            outputState.Punches.Hard = gamePadState.Buttons.RightShoulder == ButtonState.Pressed;

            //Kicks
            outputState.Kicks.Light = gamePadState.Buttons.A == ButtonState.Pressed;
            outputState.Kicks.Medium = gamePadState.Buttons.B == ButtonState.Pressed;
            outputState.Kicks.Hard = gamePadState.Triggers.Right > 0.25f;

            //Determine if Dpad has any input
            outputState.Directions.Right = (gamePadState.DPad.Right == ButtonState.Pressed || gamePadState.ThumbSticks.Left.X > 0.25f);

            outputState.Directions.Left = (gamePadState.DPad.Left == ButtonState.Pressed || -gamePadState.ThumbSticks.Left.X > 0.25f);

            outputState.Directions.Up = (gamePadState.DPad.Up == ButtonState.Pressed || gamePadState.ThumbSticks.Left.Y > 0.25f);

            outputState.Directions.Down = (gamePadState.DPad.Down == ButtonState.Pressed || -gamePadState.ThumbSticks.Left.Y > 0.25f);

            return outputState;
        }
    }
}



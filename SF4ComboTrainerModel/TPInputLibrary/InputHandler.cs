using System;

#if UNITY_EDITOR
using UnityEngine;
#endif


namespace TPInputLibrary
{
    public class SF4InputHandler
    {
        //Controller handlers and properties
        private int playerNumber;

        public enum InputType
        {
            None = 0,
            KeyboardMouse,
            XBoxController,
            PCGamePad
        }

        public InputType SelectedInputType = InputType.None;
        public SF4InputState CurrentState;

        //Ambiguous Abstract input converter allows us to assign Xbox or keyboard as input
        private SF4InputConverter converter;

        public SF4InputHandler(int _playerNumber, InputType inputType)
        {
            SelectedInputType = inputType;
            playerNumber = _playerNumber;
            if (playerNumber > 4 || playerNumber < 1)
            {
                throw new Exception("Player must be set to 1, 2, 3 or 4");
            }

            if (SelectedInputType == InputType.XBoxController)
            {
                converter = new XInputConverter(playerNumber);

            } else if (SelectedInputType == InputType.KeyboardMouse)
            {
                //Old converter from Unity engine, not applicable.
               // converter = new UnityKeyboardInputConverter();
            }
        }

        // Update is called once per frame
        public void InputUpdate()
        {
            if (converter != null)
            {
                CurrentState = converter.Convert();
            }

            #if UNITY_EDITOR
                Debug.Log(CommandState.ToString());
            #endif
        }
    }
}


namespace FrameTrapped.Input.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using WindowsInput;

    using FrameTrapped.Input.Models; 

    /**
 * this class translates our custom Input enum to actual keyboard codes that are used by the input simulator.
 * the main reason for this class is the resolving of back and forward since the Directions change when a player crosses up.
 * it also reads the keyboard config file sf4keyboard.cfg
 */
    public class InputResolver
    {
        private SF4Memory sf4m;

        public Dictionary<Input, WindowsInput.VirtualKeyCode> InputMap = new Dictionary<Input, VirtualKeyCode>();

        public InputResolver(SF4Memory sf4memory)
        {
            this.sf4m = sf4memory;

            readInputConfig();
        }

        private void readInputConfig()
        {

            string filename = System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName) + @"\sf4keyboard.cfg";

            string[] lines = System.IO.File.ReadAllLines(filename);

            foreach (String line in lines)
            {
                if (!(line.StartsWith(";")) && line.Contains('='))
                {
                    string[] tokens = line.Split('=');
                    Input input = (Input)Enum.Parse(typeof(Input), tokens[0]);
                    VirtualKeyCode key = (VirtualKeyCode)Enum.Parse(typeof(VirtualKeyCode), tokens[1]);
                    InputMap.Add(input, key);
                }
            }
        }

        public VirtualKeyCode Get(Input input)
        {
            if (input == Input.P1_BK)
            {
                return getP1_BK();
            }
            else if (input == Input.P1_FW)
            {
                return getP1_FW();
            }
            else if (InputMap.ContainsKey(input))
            {
                return InputMap[input];
            }
            else
            {
                throw new KeyNotFoundException("Cannot find input key for " + input);
            }
        }

        public bool IsPlayerOnLeft()
        {
            return (sf4m.GetP1PosX() < sf4m.GetP2PosX());
        }

        private VirtualKeyCode getP1_BK()
        {
            return (sf4m.GetP1PosX() < sf4m.GetP2PosX()) ? Get(Input.P1_LE) : Get(Input.P1_RI);

        }

        private VirtualKeyCode getP1_FW()
        {
            return (sf4m.GetP1PosX() > sf4m.GetP2PosX()) ? Get(Input.P1_LE) : Get(Input.P1_RI);
        }
    }
}

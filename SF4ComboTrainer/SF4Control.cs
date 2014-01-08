using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsInput;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Form;

namespace SF4ComboTrainer
{
    /**
     * this class is the is the interface to streetfighter. it used the sf4memory to read data from sf4 and it uses the 
     * inputsimulator to send keyboad strokes.
     */
    class SF4Control
    {
        private SF4Memory sf4memory;

        private InputResolver inputResolver;        

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("USER32.DLL")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public bool switchToSF4()
        {
            Process[] processes = Process.GetProcessesByName("SSFIV");            
            if (processes.Count() > 0)
            {
                SetForegroundWindow(processes[0].MainWindowHandle);
                ShowWindow(processes[0].MainWindowHandle, 1);
                return true;                
            }
            return false;
            
        }

        public SF4Control(SF4Memory sf4memory)
        {
            this.sf4memory = sf4memory;
            this.inputResolver = new InputResolver(sf4memory);
        }

        public void waitFrames(int frames)
        {
            int currentFrame = sf4memory.getFrameCount();
            int endFrame = currentFrame + frames;
            while (currentFrame < endFrame)
            {
                currentFrame = sf4memory.getFrameCount();
                Thread.Sleep(1);
            }
        }

        
        public void press(params Input[] inputs)
        {
            foreach (Input input in inputs)
            {
                InputSimulator.SimulateKeyDown(inputResolver.get(input));
            }
            waitFrames(1);
            foreach (Input input in inputs)
            {
                InputSimulator.SimulateKeyUp(inputResolver.get(input));
            }
        }

        public void hold(params Input[] inputs)
        {
            foreach (Input input in inputs)
            {
                InputSimulator.SimulateKeyDown(inputResolver.get(input));
            }
        }

        public void release(params Input[] inputs)
        {
            foreach (Input input in inputs)
            {
                InputSimulator.SimulateKeyUp(inputResolver.get(input));
            }
        }

        public void releaseALL()
        {
            foreach (VirtualKeyCode key in inputResolver.inputMap.Values)
            {
                InputSimulator.SimulateKeyUp(key);
            }
        }

    }

    /**
     * this class translates our custom Input enum to actual keyboard codes that are used by the input simulator.
     * the main reason for this class is the resolving of back and forward since the directions change when a player crosses up.
     * it also reads the keyboard config file sf4keyboard.cfg
     */
    class InputResolver
    {
        private SF4Memory sf4m;

        public Dictionary<Input, WindowsInput.VirtualKeyCode> inputMap = new Dictionary<Input, VirtualKeyCode>();

        public InputResolver(SF4Memory sf4memory)
        {
            this.sf4m = sf4memory;

            readInputConfig();
        }

        private void readInputConfig(){

            string filename = System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName) + @"\sf4keyboard.cfg";

            string[] lines = System.IO.File.ReadAllLines(filename);

            foreach (String line in lines)
            {
               if(!(line.StartsWith(";")) && line.Contains('=')){
                   string[] tokens = line.Split('=');
                   Input input = (Input)Enum.Parse(typeof(Input), tokens[0]);
                   VirtualKeyCode key = (VirtualKeyCode)Enum.Parse(typeof(VirtualKeyCode), tokens[1]);
                   inputMap.Add(input, key);
               }
            }
        }

        public VirtualKeyCode get(Input input)
        {
            if (input == Input.P1_BK)
            {
                return getP1_BK();
            }
            else if (input == Input.P1_FW)
            {
                return getP1_FW();
            }
            else if (inputMap.ContainsKey(input))
            {
                return inputMap[input];
            }
            else
            {
                throw new KeyNotFoundException("Cannot find input key for " + input);
            }
        }

        private VirtualKeyCode getP1_BK()
        {
            return (sf4m.getP1PosX() < sf4m.getP2PosX()) ? get(Input.P1_LE) : get(Input.P1_RI);

        }

        private VirtualKeyCode getP1_FW()
        {
            return (sf4m.getP1PosX() > sf4m.getP2PosX()) ? get(Input.P1_LE) : get(Input.P1_RI);
        }
    }
}

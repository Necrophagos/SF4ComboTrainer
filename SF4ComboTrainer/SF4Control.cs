using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsInput;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace SF4ComboTrainer
{
    /**
     * this class is the is the interface to streetfighter. it used the sf4memory to read data from sf4 and it uses the 
     * inputsimulator to send keyboad strokes.
     */
    class SF4Control
    {
        protected SF4Memory sf4memory;

        protected InputResolver inputResolver;

        // To keep the last frame.
        protected int lastFrame;

        // To tell if the game is paused.
        protected Stopwatch frameTimer = new Stopwatch();

        //min time in between frames is set to 3 seconds just so to prevent lockups when game is actually paused
        //switch to fullscreen sf4 actually takes very long.
        protected int MIN_TIME_BETWEEN_FRAMES = 3000;

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        // to see if in a match.
        public volatile bool InMatch;
        
        public bool SwitchToSF4()
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

        public bool SF4isForegroundWindow()
        {
            Process[] processes = Process.GetProcessesByName("SSFIV");
            if (processes.Count() > 0)
            {
                return processes[0].MainWindowHandle == GetForegroundWindow();                
            }
            return false;         
        }

        public SF4Control(SF4Memory sf4memory)
        {
            this.sf4memory = sf4memory;
            this.inputResolver = new InputResolver(sf4memory);
        }

        public void WaitFrames(int frames)
        {
            int currentFrame = sf4memory.GetFrameCount();
            int endFrame = currentFrame + frames;
            long lastFrameTime = frameTimer.ElapsedMilliseconds;

            while (currentFrame < endFrame && (frameTimer.ElapsedMilliseconds-lastFrameTime) < MIN_TIME_BETWEEN_FRAMES)
            {
                // Set lastFrame then the new current frame
                lastFrame = currentFrame;
                currentFrame = sf4memory.GetFrameCount();

                if (currentFrame != lastFrame)
                {
                    lastFrameTime = frameTimer.ElapsedMilliseconds;

                    // Since we currentFrame != lastFrame we are in a match.
                    // (frames on menu screen or pause menu are constant).
                    InMatch = true;
                }
                else
                    InMatch = false;
                    
                Thread.Sleep(1);
            }
        }

        public void ResetLockupTimer()
        {
            if (frameTimer.IsRunning)
            {
                frameTimer.Stop();
            }
            frameTimer.Reset();
            frameTimer.Start();
        }

        
        public void Press(params Input[] inputs)
        {
            if (!SF4isForegroundWindow()) { return; }

            foreach (Input input in inputs)
            {
                InputSimulator.SimulateKeyDown(inputResolver.Get(input));
            }
            WaitFrames(1);
            foreach (Input input in inputs)
            {
                InputSimulator.SimulateKeyUp(inputResolver.Get(input));
            }
        }

        public void Hold(params Input[] inputs)
        {
            if (!SF4isForegroundWindow()) { return; }

            foreach (Input input in inputs)
            {
                InputSimulator.SimulateKeyDown(inputResolver.Get(input));
            }
        }

        public void Release(params Input[] inputs)
        {
            if (!SF4isForegroundWindow()) { return; }

            foreach (Input input in inputs)
            {
                InputSimulator.SimulateKeyUp(inputResolver.Get(input));
            }
        }

        public void ReleaseALL()
        {
            foreach (VirtualKeyCode key in inputResolver.InputMap.Values)
            {
                InputSimulator.SimulateKeyUp(key);
            }
        }

    }

    /**
     * this class translates our custom Input enum to actual keyboard codes that are used by the input simulator.
     * the main reason for this class is the resolving of back and forward since the Directions change when a player crosses up.
     * it also reads the keyboard config file sf4keyboard.cfg
     */
    class InputResolver
    {
        private SF4Memory sf4m;

        public Dictionary<Input, WindowsInput.VirtualKeyCode> InputMap = new Dictionary<Input, VirtualKeyCode>();

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

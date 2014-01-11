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
        private SF4Memory sf4memory;

        private InputResolver inputResolver;

        // To keep the last frame.
        private int lastFrame;

        // To tell if the game is paused.
        private Stopwatch frameTimer = new Stopwatch();

        // This is 15 FPS, needed to find a default value because timing will vary on every CPU.
        // Only thing i could think of was time between frames and let 15 FPS be too low to use this. (This can be changed to lower FPS)
        private int MIN_TIME_BETWEEN_FRAMES = 66;

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        // to see if in a match.
        public volatile bool inMatch;
        
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

        public void waitFrames(int frames)
        {
            // Reset / start the frameTimer which is used to get time between frames.
            frameTimer.Reset();
            frameTimer.Start();

            int currentFrame = sf4memory.getFrameCount();
            int endFrame = currentFrame + frames;

            while (currentFrame < endFrame && frameTimer.ElapsedMilliseconds < MIN_TIME_BETWEEN_FRAMES)
            {
                // Set lastFrame then the new current frame
                lastFrame = currentFrame;
                currentFrame = sf4memory.getFrameCount();

                if (currentFrame != lastFrame)
                {
                    // Stop the frame timer since the frame has changed.
                    frameTimer.Stop();

                    frameTimer.Reset();
                    frameTimer.Start();

                    // Since we currentFrame != lastFrame we are in a match.
                    // (frames on menu screen or pause menu are constant).
                    inMatch = true;
                }
                else
                    inMatch = false;
                    
                Thread.Sleep(1);
            }
        }

        
        public void press(params Input[] inputs)
        {
            if (!SF4isForegroundWindow()) { return; }

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
            if (!SF4isForegroundWindow()) { return; }

            foreach (Input input in inputs)
            {
                InputSimulator.SimulateKeyDown(inputResolver.get(input));
            }
        }

        public void release(params Input[] inputs)
        {
            if (!SF4isForegroundWindow()) { return; }

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

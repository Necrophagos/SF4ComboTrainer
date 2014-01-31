using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsInput;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace SF4ComboTrainerModel
{
    /**
     * this class is the is the interface to streetfighter. it used the sf4memory to read data from sf4 and it uses the 
     * inputsimulator to send keyboad strokes.
     */
    public class SF4Control
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

            //TODO: To unify a press and the wait that follows - Add a WaitFrames(framesToWait - 1);

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
}

namespace FrameTrapped.Input.Utilities
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using WindowsInput;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Threading;

    using FrameTrapped.Input;
    using FrameTrapped.Input.Models;
    using FrameTrapped.Input.Utilities.MemoryEditor;

    /**
     * this class is the is the interface to streetfighter. it used the sf4memory to read data from sf4 and it uses the 
     * inputsimulator to send keyboad strokes.
     */
    public class SF4Control
    {

        #region API calls
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();
        #endregion

        #region Fields
        protected SF4Memory sf4memory;

        public InputResolver inputResolver;

        // To keep the last frame.
        protected int lastFrame;

        // To tell if the game is paused.
        protected Stopwatch frameTimer = new Stopwatch();

        //min time in between frames is set to 3 seconds just so to prevent lockups when game is actually paused
        //switch to fullscreen sf4 actually takes very long.
        protected int MIN_TIME_BETWEEN_FRAMES = 3000;

        // to see if in a match.
        public volatile bool InMatch;
        #endregion

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

        public bool SwitchToSF4(Process process)
        {
            SetForegroundWindow(process.MainWindowHandle);
            ShowWindow(process.MainWindowHandle, 1);
            return true;
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
            frameTimer.Stop();
            while (currentFrame < endFrame
                && (frameTimer.ElapsedMilliseconds - lastFrameTime) < MIN_TIME_BETWEEN_FRAMES)
            {
                // Set lastFrame then the new current frame
                lastFrame = currentFrame;
                int escape = 1000;
                while (currentFrame == lastFrame && escape > 0)
                {
                    Thread.Sleep(2);
                    currentFrame = sf4memory.GetFrameCount();
                    escape--;
                }

                if (currentFrame != lastFrame)
                {
                    lastFrameTime = frameTimer.ElapsedMilliseconds;

                    // Since we currentFrame != lastFrame we are in a match.
                    // (frames on menu screen or pause menu are constant).
                    InMatch = true;
                }
                else
                {
                    InMatch = false;
                    break;
                }

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

        public void Press(InputCommandModel inputCommandModel)
        {
            if (!SF4isForegroundWindow()) { SwitchToSF4(); }

            foreach (Input input in inputCommandModel.ToInputsArray())
            {
                InputSimulator.SimulateKeyDown(inputResolver.Get(input));
            }
            WaitFrames(1);
            foreach (Input input in inputCommandModel.ToInputsArray())
            {
                InputSimulator.SimulateKeyUp(inputResolver.Get(input));
            }

            //TODO: To unify a press and the wait that follows - Add a WaitFrames(framesToWait - 1);

        }

        public void Hold(InputCommandModel inputCommandModel)
        {
            if (!SF4isForegroundWindow()) { return; }

            foreach (Input input in inputCommandModel.ToInputsArray())
            {
                InputSimulator.SimulateKeyDown(inputResolver.Get(input));
            }
        }

        public void Release(InputCommandModel inputCommandModel)
        {
            if (!SF4isForegroundWindow()) { return; }

            foreach (Input input in inputCommandModel.ToInputsArray())
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsInput;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using TPInputLibrary;

namespace SF4ComboTrainer
{
    class SF4Record : SF4Control
    {
  

        private int frameStart;

        SF4InputHandler inputHandler;

        List<SF4InputState> inputsList;

        public SF4Record(SF4Memory sf4memory): base( sf4memory)
        {
            inputHandler = new SF4InputHandler(1, SF4InputHandler.InputType.XBoxController);
            inputsList = new List<SF4InputState>();
        }

        //Recording section
        private System.Threading.Thread recordThread = null;
        private volatile bool _recordStop;
        public void startRecording()
        {

            //prevent multiple threads
            if (null != recordThread) { return; }
            _recordStop = false;
            recordThread = new System.Threading.Thread(recordForFrames);
            recordThread.Start(100000);
        }

        public void stopRecording()
        {
            _recordStop = true;

        }
        public void recordForFrames(object maxFrames)
        {

          

            int currentFrame = sf4memory.getFrameCount();
            int endFrame = currentFrame + (int)maxFrames;

            inputsList.Clear();
  // Reset / start the frameTimer which is used to get time between frames.
            frameTimer.Reset();

            Debug.WriteLine(currentFrame < endFrame);
            Debug.WriteLine(frameTimer.ElapsedMilliseconds < MIN_TIME_BETWEEN_FRAMES);
            Debug.WriteLine(!_recordStop);

            frameTimer.Start();
            while (currentFrame < endFrame && frameTimer.ElapsedMilliseconds < MIN_TIME_BETWEEN_FRAMES && !_recordStop)
            {
                // Set lastFrame then the new current frame
                lastFrame = currentFrame;
                currentFrame = sf4memory.getFrameCount();

                if (currentFrame != lastFrame)
                {
                    // Stop the frame timer since the frame has changed.
                    frameTimer.Stop();

                    //Time to check inputs
                    inputHandler.InputUpdate();
                    if (inputHandler.CurrentState.NonePressed == false)
                    {
                        inputsList.Add(inputHandler.CurrentState);
                    
                        Debug.WriteLine("INPUT");
                    }
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

        public void Record()
        {
            inputHandler.InputUpdate();

            SF4InputState state = inputHandler.CurrentState;


        }

    }
}

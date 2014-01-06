using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF4ComboTrainer
{
    //this class calculates the games fps if you continously call the getfps method
    class FPS
    {
        private long lastTime;
        private int lastFrameCount;
        private float fps;
        private System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
        public float getFPS(int frameCount, int frameCheckInterval)
        {
            if (!stopwatch.IsRunning)
            {
                stopwatch.Start();
                lastTime = stopwatch.ElapsedMilliseconds;
                lastFrameCount = frameCount;
                fps = 0;
            }

            if ((frameCount - lastFrameCount) >= frameCheckInterval)
            {

                long elapsedTimeMs = stopwatch.ElapsedMilliseconds - lastTime;
                int elapsedFrames = frameCount - lastFrameCount;
                fps = (float)(1000 * elapsedFrames) / (float)elapsedTimeMs;
                lastTime = stopwatch.ElapsedMilliseconds;
                lastFrameCount = frameCount;
                return fps;


            }
            else
            {
                return fps;
            }

        }
    }
}

namespace FrameTrapped.Common.Utilities
{
    using System;
    using System.Threading;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Text;

    /**
     * This class helps with sound (hence roadie). its has several jobs. 
     * first and foremost it runs a producer-consumer threading system so the timeline can call playsound asynchronously with out
     * having to wait for the playsound method to return. second it provides a single thread from which mcisoundplayback is called
     * since the mcisendstring api demands to be called from only one thread.
     */
    public class Roadie : IDisposable
    {
        [DllImport("winmm.dll")]
        private static extern Int32 mciSendString(string command, StringBuilder buffer, int bufferSize, IntPtr hwndCallback);

        private static Roadie instance;

        private static String PRESS_BUTTON = "open \"" + getSoundDir() + "press_button.wav\" type waveaudio alias s_pre_but";
        private static String PRESS_DIRECTION = "open \"" + getSoundDir() + "press_direction.wav\" type waveaudio alias s_pre_dir";
        private static String HOLD_BUTTON = "open \"" + getSoundDir() + "hold_button.wav\" type waveaudio alias s_hol_but";
        private static String HOLD_DIRECTION = "open \"" + getSoundDir() + "hold_direction.wav\" type waveaudio alias s_hol_dir";
        private static String RELEASE_BUTTON = "open \"" + getSoundDir() + "release_button.wav\" type waveaudio alias s_rel_but";
        private static String RELEASE_DIRECTION = "open \"" + getSoundDir() + "release_direction.wav\" type waveaudio alias s_rel_dir";
        private static String WAIT = "open \"" + getSoundDir() + "wait.wav\" type waveaudio alias s_wait";

        public static String PRESS_BUTTON_SOUND = "play s_pre_but from 0";
        public static String PRESS_DIRECTION_SOUND = "play s_pre_dir from 0";
        public static String HOLD_BUTTON_SOUND = "play s_hol_but from 0";
        public static String HOLD_DIRECTION_SOUND = "play s_hol_dir from 0";
        public static String RELEASE_BUTTON_SOUND = "play s_rel_but from 0";
        public static String RELEASE_DIRECTION_SOUND = "play s_rel_dir from 0";
        public static String WAIT_SOUND = "play s_wait from 0";

        private EventWaitHandle wh = new AutoResetEvent(false);
        private Thread worker;
        private readonly object locker = new object();
        private Queue<string> tasks = new Queue<string>();

        private static String getSoundDir()
        {
            return System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName) + @"\sounds\";
        }

        public void PlaySound(string sound)
        {
            lock (locker) tasks.Enqueue(sound);
            wh.Set();
        }


        private void Work()
        {
            mciSendString(PRESS_BUTTON, null, 0, IntPtr.Zero);
            mciSendString(PRESS_DIRECTION, null, 0, IntPtr.Zero);
            mciSendString(HOLD_BUTTON, null, 0, IntPtr.Zero);
            mciSendString(HOLD_DIRECTION, null, 0, IntPtr.Zero);
            mciSendString(RELEASE_BUTTON, null, 0, IntPtr.Zero);
            mciSendString(RELEASE_DIRECTION, null, 0, IntPtr.Zero);
            mciSendString(WAIT, null, 0, IntPtr.Zero);

            while (true)
            {
                string task = null;
                lock (locker)
                    if (tasks.Count > 0)
                    {
                        task = tasks.Dequeue();
                        if (task == null)
                        {
                            return;
                        }
                    }
                if (task != null)
                {
                    mciSendString(task, null, 0, IntPtr.Zero);
                }
                else
                {
                    wh.WaitOne();         // No more tasks - wait for a signal
                }
            }
        }

        public static Roadie Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Roadie();
                }
                return instance;
            }
        }

        public void Dispose()
        {
            PlaySound(null);    // Signal the consumer to exit.
            worker.Join();      // Wait for the consumer's thread to finish.
            wh.Close();         // Release any OS resources.
        }

        private Roadie()
        {
            worker = new Thread(Work);
            worker.Start();
        }
    }
}
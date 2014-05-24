namespace FrameTrapped.Common.Utilities
{
    using System;
    using System.Threading;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Text;

    /// <summary>
    /// The Roadie class for audio handling in the time line.
    /// </summary>
    public class Roadie : IDisposable
    {

        [DllImport("winmm.dll")]
        private static extern Int32 mciSendString(string command, StringBuilder buffer, int bufferSize, IntPtr hwndCallback);

        /// <summary>
        /// The static singletone instance of <see cref="Roadie"/>.
        /// </summary>
        private static Roadie instance;

        /// <summary>
        /// The PRESS_BUTTON sound location.
        /// </summary>
        private static String PRESS_BUTTON = "open \"" + GetSoundDir() + "press_button.wav\" type waveaudio alias s_pre_but";

        /// <summary>
        /// The PRESS_DIRECTION sound location.
        /// </summary>
        private static String PRESS_DIRECTION = "open \"" + GetSoundDir() + "press_direction.wav\" type waveaudio alias s_pre_dir";

        /// <summary>
        /// The HOLD_BUTTON sound location.
        /// </summary>
        private static String HOLD_BUTTON = "open \"" + GetSoundDir() + "hold_button.wav\" type waveaudio alias s_hol_but";

        /// <summary>
        /// The HOLD_DIRECTION sound location.
        /// </summary>
        private static String HOLD_DIRECTION = "open \"" + GetSoundDir() + "hold_direction.wav\" type waveaudio alias s_hol_dir";

        /// <summary>
        /// The RELEASE_BUTTON sound location.
        /// </summary>
        private static String RELEASE_BUTTON = "open \"" + GetSoundDir() + "release_button.wav\" type waveaudio alias s_rel_but";

        /// <summary>
        /// The RELEASE_DIRECTION sound location.
        /// </summary>
        private static String RELEASE_DIRECTION = "open \"" + GetSoundDir() + "release_direction.wav\" type waveaudio alias s_rel_dir";

        /// <summary>
        /// The WAIT sound location.
        /// </summary>
        private static String WAIT = "open \"" + GetSoundDir() + "wait.wav\" type waveaudio alias s_wait";

        /// <summary>
        /// The PRESS_BUTTON_SOUND sound command string.
        /// </summary>
        public static String PRESS_BUTTON_SOUND = "play s_pre_but from 0";

        /// <summary>
        /// The PRESS_DIRECTION_SOUND sound command string.
        /// </summary>
        public static String PRESS_DIRECTION_SOUND = "play s_pre_dir from 0";

        /// <summary>
        /// The HOLD_BUTTON_SOUND sound command string.
        /// </summary>
        public static String HOLD_BUTTON_SOUND = "play s_hol_but from 0";

        /// <summary>
        /// The HOLD_DIRECTION_SOUND sound command string.
        /// </summary>
        public static String HOLD_DIRECTION_SOUND = "play s_hol_dir from 0";

        /// <summary>
        /// The RELEASE_BUTTON_SOUND sound command string.
        /// </summary>
        public static String RELEASE_BUTTON_SOUND = "play s_rel_but from 0";

        /// <summary>
        /// The RELEASE_DIRECTION_SOUND sound command string.
        /// </summary>
        public static String RELEASE_DIRECTION_SOUND = "play s_rel_dir from 0";

        /// <summary>
        /// The WAIT sound command string.
        /// </summary>
        public static String WAIT_SOUND = "play s_wait from 0";

        /// <summary>
        /// The event wait handler.
        /// </summary>
        private EventWaitHandle _eventWaitHandler = new AutoResetEvent(false);

        /// <summary>
        /// The worker.
        /// </summary>
        private Thread _worker;

        /// <summary>
        /// The worker thread _locker.
        /// </summary>
        private readonly object _locker = new object();

        /// <summary>
        /// The sound _tasks queue.
        /// </summary>
        private Queue<string> _tasks = new Queue<string>();

        /// <summary>
        /// Gets the sound directory
        /// </summary>
        /// <returns></returns>
        private static String GetSoundDir
        {
            get
            {
                return System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName) + @"\Resources\Sounds\";
            }
        }

        /// <summary>
        /// Play sound function.
        /// </summary>
        /// <param name="sound">The sound to play.</param>
        public void PlaySound(string sound)
        {
            lock (_locker) _tasks.Enqueue(sound);
            _eventWaitHandler.Set();
        }

        /// <summary>
        /// The worker thread function.
        /// </summary>
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
                lock (_locker)
                    if (_tasks.Count > 0)
                    {
                        task = _tasks.Dequeue();
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
                    _eventWaitHandler.WaitOne();         // No more _tasks - wait for a signal
                }
            }
        }

        /// <summary>
        /// Gets the static accessor for making a <see cref="Roadie" /> instance.
        /// </summary>
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

        /// <summary>
        /// The dispose function.
        /// </summary>
        public void Dispose()
        {
            PlaySound(null);    // Signal the consumer to exit.
            _worker.Join();      // Wait for the consumer's thread to finish.
            _eventWaitHandler.Close();         // Release any OS resources.
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Roadie"/> class.
        /// </summary>
        private Roadie()
        {
            _worker = new Thread(Work);
            _worker.Start();
        }
    }
}
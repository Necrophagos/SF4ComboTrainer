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
class Roadie : IDisposable
{
    EventWaitHandle _wh = new AutoResetEvent(false);
    Thread _worker;
    readonly object _locker = new object();
    Queue<string> _tasks = new Queue<string>();

    private static String getSoundDir()
    {
        return System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName) + @"\sounds\";

    }
    private static String PRESS_BUTTON_PATH = getSoundDir() + "press_button.wav";
    private static String PRESS_DIRECTION_PATH = getSoundDir() + "press_direction.wav";
    private static String HOLD_BUTTON_PATH = getSoundDir() + "hold_button.wav";
    private static String HOLD_DIRECTION_PATH = getSoundDir() + "hold_direction.wav";
    private static String RELEASE_BUTTON_PATH = getSoundDir() + "release_button.wav";
    private static String RELEASE_DIRECTION_PATH = getSoundDir() + "release_direction.wav";
    private static String WAIT_PATH = getSoundDir() + "wait.wav";

    public static String PRESS_BUTTON_SOUND = "s_pre_but";
    public static String PRESS_DIRECTION_SOUND = "s_pre_dir";
    public static String HOLD_BUTTON_SOUND = "s_hol_but";
    public static String HOLD_DIRECTION_SOUND = "s_hol_dir";
    public static String RELEASE_BUTTON_SOUND = "s_rel_but";
    public static String RELEASE_DIRECTION_SOUND = "s_rel_dir";
    public static String WAIT_SOUND = "s_wait";

    [DllImport("winmm.dll")]
    static extern Int32 mciSendString(string command, StringBuilder buffer, int bufferSize, IntPtr hwndCallback);

    public Roadie()
    {
        _worker = new Thread(Work);
        _worker.Start();
    }

    public void playSound(string sound)
    {
        lock (_locker) _tasks.Enqueue(sound);
        _wh.Set();
    }

    public void Dispose()
    {
        playSound(null);     // Signal the consumer to exit.
        _worker.Join();         // Wait for the consumer's thread to finish.
        _wh.Close();            // Release any OS resources.
    }

    void Work()
    {
        mciSendString("open \"" + PRESS_BUTTON_PATH + "\" type waveaudio alias " + PRESS_BUTTON_SOUND, null, 0, IntPtr.Zero);
        mciSendString("open \"" + PRESS_DIRECTION_PATH + "\" type waveaudio alias " + PRESS_DIRECTION_SOUND, null, 0, IntPtr.Zero);
        mciSendString("open \"" + HOLD_BUTTON_PATH + "\" type waveaudio alias " + HOLD_BUTTON_SOUND, null, 0, IntPtr.Zero);
        mciSendString("open \"" + HOLD_DIRECTION_PATH + "\" type waveaudio alias " + HOLD_DIRECTION_SOUND, null, 0, IntPtr.Zero);
        mciSendString("open \"" + RELEASE_BUTTON_PATH + "\" type waveaudio alias " + RELEASE_BUTTON_SOUND, null, 0, IntPtr.Zero);
        mciSendString("open \"" + RELEASE_DIRECTION_PATH + "\" type waveaudio alias " + RELEASE_DIRECTION_SOUND, null, 0, IntPtr.Zero);
        mciSendString("open \"" + WAIT_PATH + "\" type waveaudio alias " + WAIT_SOUND, null, 0, IntPtr.Zero);

        while (true)
        {
            string task = null;
            lock (_locker)
                if (_tasks.Count > 0)
                {
                    task = _tasks.Dequeue();
                    if (task == null) return;
                }
            if (task != null)
            {
                mciSendString(@"play " + task + " from 0", null, 0, IntPtr.Zero);
            }
            else
                _wh.WaitOne();         // No more tasks - wait for a signal
        }
    }
}
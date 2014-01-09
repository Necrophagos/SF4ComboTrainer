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
                    if (task == null) return;
                }
            if (task != null)
            {
                mciSendString(task, null, 0, IntPtr.Zero);
            }
            else
                _wh.WaitOne();         // No more tasks - wait for a signal
        }
    }
}
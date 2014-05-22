namespace FrameTrapped.ComboTrainer.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Forms;
    using System.Windows.Forms.Integration;

    using Caliburn.Micro;
    using WindowsInput;

    using FrameTrapped.ComboTrainer.Messages;
    using FrameTrapped.ComboTrainer.Views;
    using FrameTrapped.Common.Properties;
    using FrameTrapped.Common.Utilities;
    using FrameTrapped.Input.Models;
    using FrameTrapped.Input.Utilities;

    /// <summary>
    /// Game View Model.
    /// </summary>
    public class GameViewModel : Caliburn.Micro.Screen, IHandle<FocusStreetFighterMessage>, IHandle<PlayTimeLineMessage>
    {
        /// <summary>
        /// The event aggregator.
        /// </summary>
        private readonly IEventAggregator _events;

        /// <summary>
        /// The path to the game file (should be an executable).
        /// </summary>
        private string _gameExecuteablePath;

        /// <summary>
        /// The game process itself.
        /// </summary>
        private Process _gameProcess;

        /// <summary>
        /// The game process handle for its main window.
        /// </summary>
        private IntPtr _gameProcessMainWindowHandle;

        /// <summary>
        /// The input resolver.
        /// </summary>
        public InputResolver _inputResolver;

        /// <summary>
        /// Indicates if the main window is active.
        /// </summary>
        private bool _isMainWindowEnabled;

        /// <summary>
        /// Indicates if the the game loading.
        /// </summary>      
        private bool _isLoading;

        /// <summary>
        /// The panel hosting the game.
        /// </summary>
        private System.Windows.Forms.Panel _panel;

        /// <summary>
        /// The SF4 Memory handler.
        /// </summary>
        private SF4Memory _sf4Memory;

        /// <summary>
        /// Array that defines directional inputs.
        /// </summary>
        private static Input[] Directions = new Input[] { Input.P1_UP, Input.P1_DN, Input.P1_LE, Input.P1_RI, Input.P1_BK, Input.P1_FW };

        /// <summary>
        /// Array that defines button inputs.
        /// </summary>
        private static Input[] Buttons = new Input[] { Input.P1_LP, Input.P1_MP, Input.P1_HP, Input.P1_LK, Input.P1_MK, Input.P1_HK };

        /// <summary>
        /// The last frame.
        /// </summary>
        private int lastFrame;

        /// <summary>
        /// The offset frame.
        /// </summary>
        private int _offsetFrame;

        /// <summary>
        /// Flag to show if the game is in a match.
        /// </summary>
        private volatile bool _inMatch;

        /// <summary>
        /// Gets or sets a value indicating whether the application is busy.
        /// </summary>
        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }

            set
            {
                _isLoading = value;
                NotifyOfPropertyChange(() => IsLoading);
            }
        }

        /// <summary>
        /// Gets a value indicating whether the application is active.
        /// </summary>
        public bool IsStopped
        {
            get
            {
                return _gameProcessMainWindowHandle == IntPtr.Zero;
            }
        }

        /// <summary>
        /// Gets or sets the current frame of the time line queue (not the current match frame).
        /// </summary>
        public int OffsetFrame
        {
            get
            {
                return _offsetFrame;
            }
            set
            {
                _offsetFrame = value;
                NotifyOfPropertyChange(() => OffsetFrame);
            }
        }

        /// <summary>
        /// Performs all presses and releases for a time line item.
        /// </summary>
        /// <param name="timeLineItem"></param>
        /// <param name="sendInputs"></param>
        private void Action(TimeLineItemViewModel timeLineItem, bool sendInputs)
        {
            if (sendInputs)
            {
                InputCommandModel icm = timeLineItem.InputItemViewModel.InputItem.InputCommandState;
                foreach (Input input in icm.ToInputsReleasedArray())
                {
                    InputSimulator.SimulateKeyUp(_inputResolver.Get(input));
                }
                foreach (Input input in icm.ToInputsPressedArray())
                {
                    InputSimulator.SimulateKeyDown(_inputResolver.Get(input));
                }
                WaitForFrames(1);
            }
            else
            {
                //press event waits 1 frame, if send inputs is disabled wait frame is maintained
                WaitForFrames(1);
            }

            if (timeLineItem.InputItemViewModel.PlaySound)
            {
                Input[] inputs = timeLineItem.InputItemViewModel.InputItem.Inputs;
                if (inputs.Intersect(Directions).Count() > 0 && inputs.Intersect(Buttons).Count() > 0)
                {
                    Roadie.Instance.PlaySound(Roadie.WAIT_SOUND);
                }
                else
                {
                    if (inputs.Intersect(Directions).Count() > 0)
                        Roadie.Instance.PlaySound(Roadie.PRESS_DIRECTION_SOUND);
                    if (inputs.Intersect(Buttons).Count() > 0)
                        Roadie.Instance.PlaySound(Roadie.PRESS_BUTTON_SOUND);
                }
            }

            //After sound has played we wait the remainder of the frame duration
            if (timeLineItem.WaitFrames > 1)
            {
                WaitForFrames(timeLineItem.WaitFrames - 1);
            }
        }

        /// <summary>
        /// Creates child process.
        /// </summary>
        /// <param name="panelHandle">The panel handle.</param>
        private void CreateGameProcess(IntPtr panelHandle)
        {
            IsLoading = true;

            Task.Factory.StartNew(
                () =>
                {

                    // Get all instances of SSFIV.exe running on the local 
                    // computer.
                    Process[] sfivInstances = Process.GetProcessesByName("SSFIV");

                    if (sfivInstances.Length > 0)
                    {
                        sfivInstances[0].Kill();
                    }

                    _gameProcess = new Process
                    {
                        StartInfo =
                        {
                            FileName = _gameExecuteablePath,
                            WindowStyle = ProcessWindowStyle.Minimized,
                            RedirectStandardInput = true,
                            ErrorDialog = false,
                            UseShellExecute = false,
                        }
                    };
                    
                    _gameProcess.EnableRaisingEvents = true;
                    _gameProcess.Exited += GameProcessExited;

                    lock (this)
                    {
                        uint _oldErrorMode = NativeModel.SetErrorMode(NativeModel.SEM_FAILCRITICALERRORS
                            | NativeModel.SEM_NOGPFAULTERRORBOX);

                        try
                        {
                            _gameProcess.Start();
                        }
                        catch (InvalidOperationException invEx)
                        {
                            // Expected, handled
                            Debug.WriteLine(invEx.Message);
                        }
                        catch (Exception ex)
                        {
                            Execute.OnUIThread(() =>
                                System.Windows.MessageBox.Show(
                                System.Windows.Application.Current.MainWindow,
                                string.Format("The game coulnd't start: {0} !", ex.Message),
                                "Error",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error));
                        }

                        _gameProcess.WaitForInputIdle();

                        // For correct responding, it's important to let sleep our thread for a while.
                        System.Threading.Thread.Sleep(1000);


                        while (_gameProcessMainWindowHandle == IntPtr.Zero)
                        {
                            Thread.Sleep(100);
                            _gameProcessMainWindowHandle = _gameProcess.MainWindowHandle;
                            _gameProcess.Refresh();
                        }

                        int dwStyle = NativeModel.GetWindowLong(_gameProcessMainWindowHandle, NativeModel.GWL_STYLE);
                        NativeModel.SetWindowLong(_gameProcessMainWindowHandle, NativeModel.GWL_STYLE,
                            new IntPtr(dwStyle & ~NativeModel.WS_CAPTION & ~NativeModel.WS_THICKFRAME));

                        NativeModel.SetWindowPos(_gameProcessMainWindowHandle, IntPtr.Zero, 0, 0,
                        Convert.ToInt32(Math.Floor((double)_panel.Width)),
                        Convert.ToInt32(Math.Floor((double)_panel.Height)), NativeModel.SWP_ASYNCWINDOWPOS);

                        _panel.Invoke(new MethodInvoker(delegate { NativeModel.SetParent(_gameProcessMainWindowHandle, _panel.Handle); }));
                    }

                    Execute.OnUIThread(() =>
                    {
                        NotifyOfPropertyChange(() => IsStopped);
                        EnableWindow();
                    });

                    PanelResize(this, null);

                }).ContinueWith(
                        (t) =>
                        {
                            Execute.OnUIThread(() =>
                            {
                                IsLoading = false;
                            });
                        }
                );
        }

        /// <summary>
        /// Enables the SF4 Window bringing it to the foreground.
        /// </summary>
        public void EnableWindow()
        {
            NativeModel.SetForegroundWindow(_gameProcessMainWindowHandle);
            NativeModel.ShowWindow(_gameProcessMainWindowHandle, 1);
        }

        /// <summary>
        /// The game was exited via the in game menu, check stuff.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event arguments.</param>
        private void GameProcessExited(object sender, EventArgs e)
        {
            if (!_isMainWindowEnabled)
            {
                EnableWindow();
            }

            if (_gameProcess.ExitCode != 0)
            {
                Execute.OnUIThread(
                    () =>
                        System.Windows.MessageBox.Show(
                            System.Windows.Application.Current.MainWindow,
                            string.Format("The game crashed with exit code {0} !", _gameProcess.ExitCode.ToString()),
                             "Error",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error));
            }

            NotifyOfPropertyChange(() => IsStopped);
            TryClose();

        }

        /// <summary>
        /// Panel resize handles the host panel resizing in FrameTrapped.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PanelResize(object sender, EventArgs e)
        {
            NativeModel.SetWindowPos(_gameProcessMainWindowHandle, Process.GetCurrentProcess().MainWindowHandle,
                0, 0, _panel.Width, _panel.Height,
                NativeModel.SWP_NOZORDER | NativeModel.SWP_NOACTIVATE);
        }

        /// <summary>
        /// In the OnLoaded event, set up the game in the WindowsFormsHost.
        /// </summary>
        /// <param name="view">The view framework element.</param>
        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);

            FrameworkElement frameworkElement = view as FrameworkElement;

            if (frameworkElement == null)
            {
                return;
            }

            WindowsFormsHost windowsFormsHost = (WindowsFormsHost)frameworkElement.FindName("GameHost");

            _panel.Dock = System.Windows.Forms.DockStyle.Fill;
            windowsFormsHost.Child = _panel;
            _panel.Resize += PanelResize;
        }
        /// <summary>
        /// Setup to play the time line.
        /// </summary>
        /// <param name="timeLineItems"></param>
        public void PlayTimeLine(IEnumerable<TimeLineItemViewModel> timeLineItems)
        {
            Execute.OnUIThread(() => OffsetFrame = 0);

            //Wait 2 seconds to give time to start
            WaitForFrames(120);

            for (int x = 0; x < timeLineItems.Count(); x++)
            {
                //highlighting of current item
                if (timeLineItems.ElementAtOrDefault(x - 1) != null)
                {
                    Execute.OnUIThread(() => timeLineItems.ElementAtOrDefault(x - 1).DeHighlight());
                }
                Execute.OnUIThread(() => timeLineItems.ElementAtOrDefault(x).Highlight());

                // if we aren't in a match (defined by being on a menu or pause is selected) the play timeline stops.
                if (_inMatch)
                {
                    Action(timeLineItems.ElementAtOrDefault(x), true);
                }
                else
                {
                    string message = "The combo trainer has detected that SF4 didn't produce any new frames in the last 3 seconds. Make sure that\n\na) Street Fighter 4 is running and inside a match or training mode\nb) Street Fighter is not paused\nc) You are running the latest version of Street Fighter 4 AEv2012\nd) Stage Quality in your SF4 graphic settings is set to HIGH";
                    System.Windows.MessageBox.Show(message);
                    break;
                }
            }

            ReleaseAll();
        }

        /// <summary>
        /// Releases all the buttons.
        /// </summary>
        public void ReleaseAll()
        {
            foreach (VirtualKeyCode key in _inputResolver.InputMap.Values)
            {
                InputSimulator.SimulateKeyUp(key);
            }
        }

        /// <summary>
        /// Waits for the given number of frames to pass in game.
        /// </summary>
        /// <param name="frames"></param>
        public void WaitForFrames(int frames)
        {
            int currentFrame = _sf4Memory.GetFrameCount();
            int endFrame = currentFrame + frames;

            while (currentFrame < endFrame)
            {
                // Set lastFrame then the new current frame
                lastFrame = currentFrame;
                int escape = 1000;
                while (currentFrame == lastFrame && escape > 0)
                {
                    Thread.Sleep(2);
                    currentFrame = _sf4Memory.GetFrameCount();
                    escape--;
                }

                // This small wait is just to give the game a little
                // grace time to catch up after it has incremented frames
                Thread.Sleep(2);

                if (currentFrame != lastFrame)
                {
                    // Since we currentFrame != lastFrame we are in a match.
                    // (frames on menu screen or pause menu are constant).
                    _inMatch = true;

                    Execute.OnUIThread(() => OffsetFrame++);
                }
                else
                {
                    _inMatch = false;
                    break;
                }
            }

        }

        /// <summary>
        /// The focus street fighter message handler.
        /// </summary>
        /// <param name="message"></param>
        public void Handle(FocusStreetFighterMessage message)
        {
            Process[] processes = Process.GetProcessesByName("SSFIV");
            if (processes.Length > 0)
            {
                NativeModel.SetForegroundWindow(_gameProcessMainWindowHandle);
                NativeModel.ShowWindow(_gameProcessMainWindowHandle, 1);
            }
        }

        /// <summary>
        /// The play time line message handler.
        /// </summary>
        /// <param name="message"></param>
        public void Handle(PlayTimeLineMessage message)
        {
            PlayTimeLine(message.TimeLineItemViewModels);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameViewModel"/> class.
        /// </summary>
        /// <param name="events">The events aggregator.</param>
        /// <param name="gameExecuteablePath">The game executable path.</param>
        public GameViewModel(IEventAggregator events, string gameExecuteablePath)
        {
            _events = events;
            _events.Subscribe(this);

            _gameExecuteablePath = Settings.Default.Properties["SSFIVLocation"].ToString();
            _isMainWindowEnabled = true;

            _sf4Memory = new SF4Memory(true);
            _inputResolver = new InputResolver(_sf4Memory);

            Execute.OnUIThread(
                () =>
                {
                    _panel = new System.Windows.Forms.Panel();
                    CreateGameProcess(_panel.Handle);
                });
        }
    }
}

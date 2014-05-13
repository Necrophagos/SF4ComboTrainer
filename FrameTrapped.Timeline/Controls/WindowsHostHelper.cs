
namespace FrameTrapped.ComboTrainer.Controls
{
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Windows.Controls;
    using System.Windows.Forms;
    using System.Windows.Forms.Integration;
    
    public class WindowsHostHelper : ContentControl
    {
        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll")]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        //Recalculate the size and position of the windows client area.
        const UInt32 SWP_FRAMECHANGED = 0x0020;  /* The frame changed: send WM_NCCALCSIZE */

        //set a new Window Style (Border, has horizontal/vertical scrollbar, please see MSDN)
        static readonly int GWL_STYLE = (-16);

        //the specified window has a title bar
        public const uint WS_CAPTION = 0x00C00000;

        //Creates a window with a resizable frame.
        public const uint WS_THICKFRAME = 0x00040000;

        //If the parent window is redrawn,the area which is covered by the "child" windows will be excluded.
        public const uint WS_CLIPCHILDREN = 0x02000000;

        //Create a new overlapped window,take care that it has a titlebar and border per default.
        public const uint WS_OVERLAPPED = 0x00000000;

        //WindowsFormsHost Class is able to _host WindowsForms Control in WPF
        private WindowsFormsHost _host = new WindowsFormsHost();

        private System.Windows.Forms.Panel _panel = new System.Windows.Forms.Panel();

        private IntPtr _windowHandle;

        public void SetProcess(Process PR)
        {
            try
            {
                //For correct responding, it's important to let sleep our thread for a while.
                System.Threading.Thread.Sleep(1000);
                _windowHandle = PR.MainWindowHandle;

                int dwStyle = GetWindowLong(_windowHandle, GWL_STYLE);
                SetWindowLong(_windowHandle, GWL_STYLE, new IntPtr(dwStyle &
                ~WS_CAPTION & ~WS_THICKFRAME));

                SetWindowPos(_windowHandle, IntPtr.Zero, 0, 0,
                Convert.ToInt32(Math.Floor(ActualWidth)),
                Convert.ToInt32(Math.Floor(ActualHeight)), SWP_FRAMECHANGED);
                _panel.Invoke(new MethodInvoker(delegate{SetParent(_windowHandle,_panel.Handle);}));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        protected override System.Windows.Size ArrangeOverride(System.Windows.Size arrangeBounds)
        {
            base.ArrangeOverride(arrangeBounds);

            return arrangeBounds;
        }

        protected override void OnContentChanged(object oldContent, object newContent)
        {
            this.Content = this._host;
        }

        public WindowsHostHelper()
        {
            Height = 1280;
            Width = 720;
            
            Content = _host;
            _panel.CreateControl();
            
            _host.Child = _panel;
            _panel.Left = 0;
            _panel.Top= 0;
        }

    }
}

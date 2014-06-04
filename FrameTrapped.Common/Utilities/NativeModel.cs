using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FrameTrapped.Common.Utilities
{
    public static class NativeModel
    {
        public enum WindowShowStyle : uint
        {
            Hide = 0,
            ShowNormal = 1,
            ShowMinimized = 2,
            ShowMaximized = 3,
            Maximize = 3,
            ShowNormalNoActivate = 4,
            Show = 5,
            Minimize = 6,
            ShowMinNoActivate = 7,
            ShowNoActivate = 8,
            Restore = 9,
            ShowDefault = 10,
            ForceMinimized = 11
        }

        [DllImport("user32.dll")]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string lclassName, string windowTitle);

        [DllImport("kernel32.dll")]
        public static extern uint SetErrorMode(uint uMode);

        [DllImport("user32.dll")]
        public static extern bool EnableWindow(IntPtr hwnd, bool enable);

        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("kernel32.dll")]
        public static extern int GetCurrentThreadId();

        [DllImport("user32.dll")]
        public static extern IntPtr AttachThreadInput(IntPtr idAttach, IntPtr idAtttachTo, int fAttach);

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, out IntPtr ProcessId);

        [DllImport("user32.dll")]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, uint nCmdShow);

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        //set a new Window Style (Border, has horizontal/vertical scrollbar, please see MSDN)
        public const int GWL_STYLE = (-16);

        /// <summary>
        /// Don't display critical errors. 
        /// </summary>
        public const uint SEM_FAILCRITICALERRORS = 0x0001;

        /// <summary>
        /// Don't display Windows Error-Reporting message box.
        /// </summary>
        public const uint SEM_NOGPFAULTERRORBOX = 0x0002;

        //Recalculate the size and position of the windows client area.
        public const uint SWP_FRAMECHANGED = 0x0020;  /* The frame changed: send WM_NCCALCSIZE */

        public const uint SWP_ASYNCWINDOWPOS = 0x4000;

        public const uint SWP_NOZORDER = 0x0004;

        // Do not activate the window upon reattaching the process.
        public const uint SWP_NOACTIVATE = 0x0010;

        // The specified window has a title bar
        public const uint WS_CAPTION = 0x00C00000;

        //Creates a window with a resizable frame.
        public const uint WS_THICKFRAME = 0x00040000;

    }
}

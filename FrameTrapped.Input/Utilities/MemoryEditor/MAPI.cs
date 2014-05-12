namespace FrameTrapped.Input.Utilities.MemoryEditor
{
    using System;
    using System.Runtime.InteropServices;

    internal class MAPI
    {
        [DllImport("kernel32.dll")]
        public static extern int ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [In, Out] byte[] bBuffer, uint size, out IntPtr lpNumberOfBytesRead);
        [DllImport("kernel32.dll")]
        public static extern int WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [In, Out] byte[] bBuffer, uint size, out IntPtr lpNumberOfBytesWritten);
    }
}


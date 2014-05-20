namespace FrameTrapped.Input.Utilities.MemoryEditor
{
    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.Text;
    using System.Text.RegularExpressions;

    public class MemoryReader
    {
        private IntPtr hReadProcess = IntPtr.Zero;
        private Process mReadProcess;

        public int BaseAddress()
        {
            return this.mReadProcess.MainModule.BaseAddress.ToInt32();
        }

        public int BaseAddress(string sModuleName)
        {
            return this.FindModule(sModuleName).BaseAddress.ToInt32();
        }

        public bool BytesEqual(byte[] bBytes_1, byte[] bBytes_2)
        {
            return (BitConverter.ToString(bBytes_1) == BitConverter.ToString(bBytes_2));
        }

        private int CalculatePointer(int iMemoryAddress, int[] iOffsets)
        {
            int num = iOffsets.Length - 1;
            byte[] bBuffer = new byte[4];
            int num2 = 0;
            if (num == 0)
            {
                num2 = iMemoryAddress;
            }
            for (int i = 0; i <= num; i++)
            {
                IntPtr ptr;
                if (i == num)
                {
                    MAPI.ReadProcessMemory(this.hReadProcess, (IntPtr) num2, bBuffer, 4, out ptr);
                    return (this.Dec(this.CreateAddress(bBuffer)) + iOffsets[i]);
                }
                if (i == 0)
                {
                    MAPI.ReadProcessMemory(this.hReadProcess, (IntPtr) iMemoryAddress, bBuffer, 4, out ptr);
                    num2 = this.Dec(this.CreateAddress(bBuffer)) + iOffsets[0];
                }
                else
                {
                    MAPI.ReadProcessMemory(this.hReadProcess, (IntPtr) num2, bBuffer, 4, out ptr);
                    num2 = this.Dec(this.CreateAddress(bBuffer)) + iOffsets[i];
                }
            }
            return 0;
        }

        public int CalculateStaticAddress(int iStaticOffset)
        {
            return (this.BaseAddress() + iStaticOffset);
        }

        public int CalculateStaticAddress(string sStaticOffset)
        {
            return (this.BaseAddress() + this.Dec(sStaticOffset));
        }

        public int CalculateStaticAddress(int iStaticOffset, string sModuleName)
        {
            return (this.BaseAddress(sModuleName) + iStaticOffset);
        }

        public int CalculateStaticAddress(string sStaticOffset, string sModuleName)
        {
            return (this.BaseAddress(sModuleName) + this.Dec(sStaticOffset));
        }

        private string CreateAddress(byte[] bBytes)
        {
            string str = "";
            for (int i = 0; i < bBytes.Length; i++)
            {
                if (Convert.ToInt16(bBytes[i]) < 0x10)
                {
                    str = "0" + bBytes[i].ToString("X") + str;
                }
                else
                {
                    str = bBytes[i].ToString("X") + str;
                }
            }
            return str;
        }

        private byte[] CreateAOBString(string sBytes)
        {
            return BitConverter.GetBytes(this.Dec(sBytes));
        }

        private byte[] CreateAOBText(string sBytes)
        {
            return Encoding.ASCII.GetBytes(sBytes);
        }

        public int Dec(int iHex)
        {
            return int.Parse(iHex.ToString(), NumberStyles.HexNumber);
        }

        public int Dec(string sHex)
        {
            return int.Parse(sHex, NumberStyles.HexNumber);
        }

        public int EntryPoint()
        {
            return this.mReadProcess.MainModule.EntryPointAddress.ToInt32();
        }

        public int EntryPoint(string sModuleName)
        {
            return this.FindModule(sModuleName).EntryPointAddress.ToInt32();
        }

        public string FileVersion()
        {
            return this.mReadProcess.MainModule.FileVersionInfo.FileVersion;
        }

        private ProcessModule FindModule(string sModuleName)
        {
            for (int i = 0; i < this.mReadProcess.Modules.Count; i++)
            {
                if (this.mReadProcess.Modules[i].ModuleName == sModuleName)
                {
                    return this.mReadProcess.Modules[i];
                }
            }
            return null;
        }

        public ProcessModuleCollection GetModules()
        {
            return this.mReadProcess.Modules;
        }

        public string Hex(int iDec)
        {
            return iDec.ToString("X");
        }

        public string Hex(string sDec)
        {
            if (this.IsNumeric(sDec))
            {
                return int.Parse(sDec).ToString("X");
            }
            return "0";
        }

        public bool IsNumeric(string sNumber)
        {
            return new Regex(@"^\d+$").IsMatch(sNumber);
        }

        public int MemorySize()
        {
            return this.mReadProcess.MainModule.ModuleMemorySize;
        }

        public int MemorySize(string sModuleName)
        {
            return this.FindModule(sModuleName).ModuleMemorySize;
        }

        public string Name()
        {
            return this.mReadProcess.ProcessName;
        }

        public bool NOP(int iMemoryAddress, int iLength)
        {
            IntPtr ptr;
            byte[] bBuffer = new byte[iLength];
            for (int i = 0; i < iLength; i++)
            {
                bBuffer[i] = 0x90;
            }
            MAPI.WriteProcessMemory(this.hReadProcess, (IntPtr) iMemoryAddress, bBuffer, (uint) iLength, out ptr);
            return (ptr.ToInt32() == iLength);
        }

        public bool NOP(int iMemoryAddress, int[] iOffsets, int iLength)
        {
            IntPtr ptr;
            int num = this.CalculatePointer(iMemoryAddress, iOffsets);
            byte[] bBuffer = new byte[iLength];
            for (int i = 0; i < iLength; i++)
            {
                bBuffer[i] = 0x90;
            }
            MAPI.WriteProcessMemory(this.hReadProcess, (IntPtr) num, bBuffer, (uint) iLength, out ptr);
            return (ptr.ToInt32() == bBuffer.Length);
        }

        public bool OpenProcess()
        {
            this.mReadProcess = Process.GetCurrentProcess();
            if (this.mReadProcess.Handle != IntPtr.Zero)
            {
                this.hReadProcess = this.mReadProcess.Handle;
                return true;
            }
            return false;
        }

        public bool OpenProcess(int iProcessID)
        {
            this.mReadProcess = Process.GetProcessById(iProcessID);
            if (this.mReadProcess.Handle != IntPtr.Zero)
            {
                this.hReadProcess = this.mReadProcess.Handle;
                return true;
            }
            return false;
        }

        public bool OpenProcess(string sProcessName)
        {
            Process[] processesByName = Process.GetProcessesByName(sProcessName);
            if (processesByName.Length > 0)
            {
                this.mReadProcess = processesByName[0];
                if (this.mReadProcess.Handle != IntPtr.Zero)
                {
                    this.hReadProcess = this.mReadProcess.Handle;
                    return true;
                }
            }
            return false;
        }

        public int PID()
        {
            return this.mReadProcess.Id;
        }

        public byte[] ReadAOB(int iMemoryAddress, uint iBytesToRead)
        {
            IntPtr ptr;
            byte[] bBuffer = new byte[iBytesToRead];
            MAPI.ReadProcessMemory(this.hReadProcess, (IntPtr) iMemoryAddress, bBuffer, iBytesToRead, out ptr);
            return bBuffer;
        }

        public byte[] ReadAOB(int iMemoryAddress, int[] iOffsets, uint iBytesToRead)
        {
            IntPtr ptr;
            int num = this.CalculatePointer(iMemoryAddress, iOffsets);
            byte[] bBuffer = new byte[1];
            MAPI.ReadProcessMemory(this.hReadProcess, (IntPtr) num, bBuffer, iBytesToRead, out ptr);
            return bBuffer;
        }

        public byte ReadByte(int iMemoryAddress)
        {
            IntPtr ptr;
            byte[] bBuffer = new byte[1];
            if (MAPI.ReadProcessMemory(this.hReadProcess, (IntPtr) iMemoryAddress, bBuffer, 1, out ptr) == 0)
            {
                return 0;
            }
            return bBuffer[0];
        }

        public byte ReadByte(int iMemoryAddress, int[] iOffsets)
        {
            IntPtr ptr;
            int num = this.CalculatePointer(iMemoryAddress, iOffsets);
            byte[] bBuffer = new byte[1];
            MAPI.ReadProcessMemory(this.hReadProcess, (IntPtr) num, bBuffer, 1, out ptr);
            return bBuffer[0];
        }

        public double ReadDouble(int iMemoryAddress)
        {
            IntPtr ptr;
            byte[] bBuffer = new byte[8];
            if (MAPI.ReadProcessMemory(this.hReadProcess, (IntPtr) iMemoryAddress, bBuffer, 8, out ptr) == 0)
            {
                return 0.0;
            }
            return BitConverter.ToDouble(bBuffer, 0);
        }

        public double ReadDouble(int iMemoryAddress, int[] iOffsets)
        {
            IntPtr ptr;
            int num = this.CalculatePointer(iMemoryAddress, iOffsets);
            byte[] bBuffer = new byte[8];
            MAPI.ReadProcessMemory(this.hReadProcess, (IntPtr) num, bBuffer, 8, out ptr);
            return BitConverter.ToDouble(bBuffer, 0);
        }

        public float ReadFloat(int iMemoryAddress)
        {
            IntPtr ptr;
            byte[] bBuffer = new byte[4];
            if (MAPI.ReadProcessMemory(this.hReadProcess, (IntPtr) iMemoryAddress, bBuffer, 4, out ptr) == 0)
            {
                return 0f;
            }
            return BitConverter.ToSingle(bBuffer, 0);
        }

        public float ReadFloat(int iMemoryAddress, int[] iOffsets)
        {
            IntPtr ptr;
            int num = this.CalculatePointer(iMemoryAddress, iOffsets);
            byte[] bBuffer = new byte[4];
            MAPI.ReadProcessMemory(this.hReadProcess, (IntPtr) num, bBuffer, 4, out ptr);
            return BitConverter.ToSingle(bBuffer, 0);
        }

        public uint ReadInt(int iMemoryAddress)
        {
            IntPtr ptr;
            byte[] bBuffer = new byte[4];
            if (MAPI.ReadProcessMemory(this.hReadProcess, (IntPtr) iMemoryAddress, bBuffer, 4, out ptr) == 0)
            {
                return 0;
            }
            return BitConverter.ToUInt32(bBuffer, 0);
        }

        public uint ReadInt(int iMemoryAddress, int[] iOffsets)
        {
            IntPtr ptr;
            int num = this.CalculatePointer(iMemoryAddress, iOffsets);
            byte[] bBuffer = new byte[4];
            MAPI.ReadProcessMemory(this.hReadProcess, (IntPtr) num, bBuffer, 4, out ptr); 
            return BitConverter.ToUInt32(bBuffer, 0);
        }

        public long ReadLong(int iMemoryAddress)
        {
            IntPtr ptr;
            byte[] bBuffer = new byte[8];
            if (MAPI.ReadProcessMemory(this.hReadProcess, (IntPtr) iMemoryAddress, bBuffer, 8, out ptr) == 0)
            {
                return 0L;
            }
            return BitConverter.ToInt64(bBuffer, 0);
        }

        public long ReadLong(int iMemoryAddress, int[] iOffsets)
        {
            IntPtr ptr;
            int num = this.CalculatePointer(iMemoryAddress, iOffsets);
            byte[] bBuffer = new byte[8];
            MAPI.ReadProcessMemory(this.hReadProcess, (IntPtr) num, bBuffer, 8, out ptr);
            return BitConverter.ToInt64(bBuffer, 0);
        }

        public ushort ReadShort(int iMemoryAddress)
        {
            IntPtr ptr;
            byte[] bBuffer = new byte[2];
            if (MAPI.ReadProcessMemory(this.hReadProcess, (IntPtr) iMemoryAddress, bBuffer, 2, out ptr) == 0)
            {
                return 0;
            }
            return BitConverter.ToUInt16(bBuffer, 0);
        }

        public ushort ReadShort(int iMemoryAddress, int[] iOffsets)
        {
            IntPtr ptr;
            int num = this.CalculatePointer(iMemoryAddress, iOffsets);
            byte[] bBuffer = new byte[2];
            MAPI.ReadProcessMemory(this.hReadProcess, (IntPtr) num, bBuffer, 2, out ptr);
            return BitConverter.ToUInt16(bBuffer, 0);
        }

        public string ReadString(int iMemoryAddress, uint iTextLength, int iMode = 0)
        {
            IntPtr ptr;
            byte[] bBuffer = new byte[iTextLength];
            MAPI.ReadProcessMemory(this.hReadProcess, (IntPtr) iMemoryAddress, bBuffer, iTextLength, out ptr);
            if (iMode == 0)
            {
                return Encoding.UTF8.GetString(bBuffer);
            }
            if (iMode == 1)
            {
                return BitConverter.ToString(bBuffer).Replace("-", "");
            }
            return "";
        }

        public string ReadText(int iMemoryAddress, int[] iOffsets, uint iStringLength, int iMode = 0)
        {
            IntPtr ptr;
            int num = this.CalculatePointer(iMemoryAddress, iOffsets);
            byte[] bBuffer = new byte[1];
            MAPI.ReadProcessMemory(this.hReadProcess, (IntPtr) num, bBuffer, iStringLength, out ptr);
            if (iMode == 0)
            {
                return Encoding.UTF8.GetString(bBuffer);
            }
            if (iMode == 1)
            {
                return BitConverter.ToString(bBuffer).Replace("-", "");
            }
            return "";
        }

        public byte[] ReverseBytes(byte[] bOriginalBytes)
        {
            int length = bOriginalBytes.Length;
            byte[] buffer = new byte[length];
            for (int i = 0; i < length; i++)
            {
                buffer[(length - i) - 1] = bOriginalBytes[i];
            }
            return buffer;
        }

        public int SID()
        {
            return this.mReadProcess.SessionId;
        }

        public string StartTime()
        {
            return this.mReadProcess.StartTime.ToString();
        }

        public bool Write(int iMemoryAddress, byte bByteToWrite)
        {
            IntPtr ptr;
            byte[] bBuffer = new byte[] { bByteToWrite };
            MAPI.WriteProcessMemory(this.hReadProcess, (IntPtr) iMemoryAddress, bBuffer, 1, out ptr);
            return (ptr.ToInt32() == 1);
        }

        public bool Write(int iMemoryAddress, double iDoubleToWrite)
        {
            IntPtr ptr;
            byte[] bytes = BitConverter.GetBytes(iDoubleToWrite);
            MAPI.WriteProcessMemory(this.hReadProcess, (IntPtr) iMemoryAddress, bytes, 8, out ptr);
            return (ptr.ToInt32() == 8);
        }

        public bool Write(int iMemoryAddress, short iShortToWrite)
        {
            IntPtr ptr;
            byte[] bytes = BitConverter.GetBytes(iShortToWrite);
            MAPI.WriteProcessMemory(this.hReadProcess, (IntPtr) iMemoryAddress, bytes, 2, out ptr);
            return (ptr.ToInt32() == 2);
        }

        public bool Write(int iMemoryAddress, int iIntToWrite)
        {
            IntPtr ptr;
            byte[] bytes = BitConverter.GetBytes(iIntToWrite);
            MAPI.WriteProcessMemory(this.hReadProcess, (IntPtr) iMemoryAddress, bytes, 4, out ptr);
            return (ptr.ToInt32() == 4);
        }

        public bool Write(int iMemoryAddress, long iLongToWrite)
        {
            IntPtr ptr;
            byte[] bytes = BitConverter.GetBytes(iLongToWrite);
            MAPI.WriteProcessMemory(this.hReadProcess, (IntPtr) iMemoryAddress, bytes, 8, out ptr);
            return (ptr.ToInt32() == 8);
        }

        public bool Write(int iMemoryAddress, float iFloatToWrite)
        {
            IntPtr ptr;
            byte[] bytes = BitConverter.GetBytes(iFloatToWrite);
            MAPI.WriteProcessMemory(this.hReadProcess, (IntPtr) iMemoryAddress, bytes, 4, out ptr);
            return (ptr.ToInt32() == 4);
        }

        public bool Write(int iMemoryAddress, byte[] bBytesToWrite)
        {
            IntPtr ptr;
            MAPI.WriteProcessMemory(this.hReadProcess, (IntPtr) iMemoryAddress, bBytesToWrite, (uint) bBytesToWrite.Length, out ptr);
            return (ptr.ToInt32() == bBytesToWrite.Length);
        }

        public bool Write(int iMemoryAddress, int[] iOffsets, byte bByteToWrite)
        {
            IntPtr ptr;
            int num = this.CalculatePointer(iMemoryAddress, iOffsets);
            byte[] bBuffer = new byte[] { bByteToWrite };
            MAPI.WriteProcessMemory(this.hReadProcess, (IntPtr) num, bBuffer, 1, out ptr);
            return (ptr.ToInt32() == 1);
        }

        public bool Write(int iMemoryAddress, int[] iOffsets, double iDoubleToWrite)
        {
            IntPtr ptr;
            int num = this.CalculatePointer(iMemoryAddress, iOffsets);
            byte[] bytes = BitConverter.GetBytes(iDoubleToWrite);
            MAPI.WriteProcessMemory(this.hReadProcess, (IntPtr) num, bytes, 8, out ptr);
            return (ptr.ToInt32() == 8);
        }

        public bool Write(int iMemoryAddress, int[] iOffsets, short iShortToWrite)
        {
            IntPtr ptr;
            int num = this.CalculatePointer(iMemoryAddress, iOffsets);
            byte[] bytes = BitConverter.GetBytes(iShortToWrite);
            MAPI.WriteProcessMemory(this.hReadProcess, (IntPtr) num, bytes, 2, out ptr);
            return (ptr.ToInt32() == 2);
        }

        public bool Write(int iMemoryAddress, string sStringToWrite, int iMode = 0)
        {
            IntPtr ptr;
            byte[] bBuffer = new byte[1];
            if (iMode == 0)
            {
                bBuffer = this.CreateAOBText(sStringToWrite);
            }
            else if (iMode == 1)
            {
                bBuffer = this.ReverseBytes(this.CreateAOBString(sStringToWrite));
            }
            MAPI.WriteProcessMemory(this.hReadProcess, (IntPtr) iMemoryAddress, bBuffer, (uint) bBuffer.Length, out ptr);
            return (ptr.ToInt32() == bBuffer.Length);
        }

        public bool Write(int iMemoryAddress, int[] iOffsets, int iIntToWrite)
        {
            IntPtr ptr;
            int num = this.CalculatePointer(iMemoryAddress, iOffsets);
            byte[] bytes = BitConverter.GetBytes(iIntToWrite);
            MAPI.WriteProcessMemory(this.hReadProcess, (IntPtr) num, bytes, 4, out ptr);
            return (ptr.ToInt32() == 4);
        }

        public bool Write(int iMemoryAddress, int[] iOffsets, long iLongToWrite)
        {
            IntPtr ptr;
            int num = this.CalculatePointer(iMemoryAddress, iOffsets);
            byte[] bytes = BitConverter.GetBytes(iLongToWrite);
            MAPI.WriteProcessMemory(this.hReadProcess, (IntPtr) num, bytes, 8, out ptr);
            return (ptr.ToInt32() == 8);
        }

        public bool Write(int iMemoryAddress, int[] iOffsets, float iFloatToWrite)
        {
            IntPtr ptr;
            int num = this.CalculatePointer(iMemoryAddress, iOffsets);
            byte[] bytes = BitConverter.GetBytes(iFloatToWrite);
            MAPI.WriteProcessMemory(this.hReadProcess, (IntPtr) num, bytes, 4, out ptr);
            return (ptr.ToInt32() == 4);
        }

        public bool Write(int iMemoryAddress, int[] iOffsets, byte[] bBytesToWrite)
        {
            IntPtr ptr;
            int num = this.CalculatePointer(iMemoryAddress, iOffsets);
            MAPI.WriteProcessMemory(this.hReadProcess, (IntPtr) num, bBytesToWrite, (uint) bBytesToWrite.Length, out ptr);
            return (ptr.ToInt32() == bBytesToWrite.Length);
        }

        public bool Write(int iMemoryAddress, int[] iOffsets, string sStringToWrite, int iMode = 0)
        {
            IntPtr ptr;
            int num = this.CalculatePointer(iMemoryAddress, iOffsets);
            byte[] bBuffer = new byte[1];
            if (iMode == 0)
            {
                bBuffer = this.CreateAOBText(sStringToWrite);
            }
            else if (iMode == 1)
            {
                bBuffer = this.ReverseBytes(this.CreateAOBString(sStringToWrite));
            }
            MAPI.WriteProcessMemory(this.hReadProcess, (IntPtr) num, bBuffer, (uint) sStringToWrite.Length, out ptr);
            return (ptr.ToInt32() == sStringToWrite.Length);
        }
    }
}


using System;
using System.Runtime.InteropServices;

namespace Nodule_wCI.Worker.Helpers
{
    class Win32
    {

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool DeleteFile(string lpFileName);


    }
}

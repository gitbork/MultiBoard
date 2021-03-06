﻿using System;
using System.Threading;
using System.Windows.Forms;

namespace MultiBoard
{
    static class Program
    {
        static Mutex mutex = new Mutex(true, "{8c14eced-65ff-49d3-9077-a8c95aa2a054}");
        [STAThread]
        static void Main()
        {
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MultiBoard());
                mutex.ReleaseMutex();
            }
            else
            {
                // send our Win32 message to make the currently running instance
                // jump on top of all the other windows
                NativeMethods.PostMessage(
                    (IntPtr)NativeMethods.HwndBroadcast,
                    NativeMethods.WmShowme,
                    IntPtr.Zero,
                    IntPtr.Zero);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KeyPress
{
    class PressKey1
    {
        const UInt32 WM_KEYDOWN = 0x0100;
        const int VK_F5 = 0x74;

        [DllImport("user32.dll")]
        static extern bool PostMessage(IntPtr hWnd, UInt32 Msg, int wParam, int lParam);

        // This method that will be called when the thread is started
        public void Press()
        {
            while (true)
            {
                Process[] processes = Process.GetProcessesByName("chrome");

                foreach (Process proc in processes)
                    PostMessage(proc.MainWindowHandle, WM_KEYDOWN, VK_F5, 0);

                Thread.Sleep(30000);
            }
        }
    }
}

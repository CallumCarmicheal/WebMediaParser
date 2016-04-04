using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Management;

namespace YoutubeMusicParser.Util {
    class Processes {

        public static List<ProcessListing> lstTitlesProc = new List<ProcessListing>();
        public static List<string> lstTitles = new List<string>();

        const int MAXTITLE = 255;

        private delegate bool EnumDelegate(IntPtr hWnd, int lParam);

        [DllImport("user32.dll", EntryPoint = "EnumDesktopWindows",
        ExactSpelling = false, CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool EnumDesktopWindows(IntPtr hDesktop,
        EnumDelegate lpEnumCallbackFunction, IntPtr lParam);

        [DllImport("user32.dll", EntryPoint = "GetWindowText",
        ExactSpelling = false, CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int _GetWindowText(IntPtr hWnd,
        StringBuilder lpWindowText, int nMaxCount);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint processId);

        private static bool EnumWindowsProc(IntPtr hWnd, int lParam) {
            string strTitle = GetWindowText(hWnd); uint pid;
            if (strTitle != "" & IsWindowVisible(hWnd)) {
                GetWindowThreadProcessId(hWnd, out pid);
                lstTitles.Add("PID:   " + pid + "    HID:  " + hWnd + "  Text: " + strTitle);
            } return true;
        }

        private static bool EnumWindowsProc_(IntPtr hWnd, int lParam) {
            string strTitle = GetWindowText(hWnd);
            if (strTitle != "" & IsWindowVisible(hWnd)) {
                uint pid; GetWindowThreadProcessId(hWnd, out pid);

                ProcessListing pl = new ProcessListing() {
                    ProcessID = pid,
                    WindowHandle = hWnd,
                    WindowText = strTitle
                }; lstTitlesProc.Add(pl);
            } return true;
        }

        /// <summary>
        /// Return the window title of handle
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        public static string GetWindowText(IntPtr hWnd) {
            StringBuilder strbTitle = new StringBuilder(MAXTITLE);
            int nLength = _GetWindowText(hWnd, strbTitle, strbTitle.Capacity + 1);
            strbTitle.Length = nLength;
            return strbTitle.ToString();
        }

        /// <summary>
        /// Return titles of all visible windows on desktop
        /// </summary>
        /// <returns>List of titles in type of string</returns>
        public static string[] GetDesktopWindowsTitles() {
            var lstTitles = new List<string>();
            EnumDelegate delEnumfunc = new EnumDelegate(EnumWindowsProc);
            bool bSuccessful = EnumDesktopWindows(IntPtr.Zero, delEnumfunc, IntPtr.Zero); //for current desktop

            if (bSuccessful) {
                return lstTitles.ToArray();
            } else {
                MessageBox.Show("Could not iterate the open windows");
                /*int nErrorCode = Marshal.GetLastWin32Error();
                string strErrMsg = String.Format("EnumDesktopWindows failed with code {0}.", nErrorCode);
                throw new Exception(strErrMsg);*/ // IGNORE IT!
                return default(string[]);
            }
        }

        public static ProcessListing[] GetDesktopWindowsTitles_OBJ() {
            lstTitlesProc = new List<ProcessListing>();
            EnumDelegate delEnumfunc = new EnumDelegate(EnumWindowsProc_);
            bool bSuccessful = EnumDesktopWindows(IntPtr.Zero, delEnumfunc, IntPtr.Zero); // For current desktop

            if (bSuccessful) {
                return lstTitlesProc.ToArray();
            } else {
                MessageBox.Show("Could not iterate the open windows");
                /*int nErrorCode = Marshal.GetLastWin32Error();
                string strErrMsg = String.Format("EnumDesktopWindows failed with code {0}.", nErrorCode);
                throw new Exception(strErrMsg);*/
                // IGNORE IT!
                return default(ProcessListing[]);
            }
        }

        public static void ConsoleOnlyTest() {
            string[] strWindowsTitles = GetDesktopWindowsTitles();
            foreach (string strTitle in strWindowsTitles) {
                Console.WriteLine(strTitle);
            }
            Console.ReadLine();
        }

        public static List<Process> GetChildProcesses(Process process) {
            List<Process> children = new List<Process>();
            ManagementObjectSearcher mos = new ManagementObjectSearcher(String.Format("Select * From Win32_Process Where ParentProcessID={0}", process.Id));

            foreach (ManagementObject mo in mos.Get()) 
                children.Add(Process.GetProcessById(Convert.ToInt32(mo["ProcessID"])));
            return children;
        }



        /*public static ProcessListing[] GetProcesses() {
            var pl = new List<ProcessListing>();

            Process[] procList = Process.GetProcesses();
            foreach (Process proc in procList) {
                if(!IsInteractionWindow(proc)) continue;
                System.Diagnostics.Debugger.Log(0, "", "GetChildProcesses: PROCESS ID " + proc.Id + ", WINDOW TITLE " + proc.MainWindowTitle + "\n");
                pl.AddRange(EnumerateProcess(proc));
            } return pl.ToArray();
        }

        public static bool IsInteractionWindow(Process c) {
            string windowTitle = c.MainWindowTitle;
            return !(string.IsNullOrWhiteSpace(windowTitle));
        }

        public static ProcessListing[] EnumerateProcess(Process p) {
            var pl = new List<ProcessListing>();
            var children = GetChildProcesses(p);

            foreach (Process c in children) {
                if (!IsInteractionWindow(c)) continue;
                System.Diagnostics.Debugger.Log(0, "", "EnumerateProcess: PROCESS ID " + c.Id + ", WINDOW TITLE " + c.MainWindowTitle + "\n");

                ProcessListing plObj = new ProcessListing() {
                    ProcessID = c.Id,
                    WindowText = c.MainWindowTitle
                }; pl.Add(plObj);
            }

            return pl.ToArray();
        }*/


        public static bool WindowHandleIsValid(IntPtr hWnd) {
            uint output = 0; GetWindowThreadProcessId(
                hWnd, out output);
            return (output != 0);
        }

        public static ProcessListing getListingfromWHandle(IntPtr hWnd) {
            if (!WindowHandleIsValid(hWnd))
                return null;

            ProcessListing pl = new ProcessListing();

            uint pid = 0;
            GetWindowThreadProcessId(hWnd, out pid);

            pl.ProcessID        = pid;
            pl.WindowText       = GetWindowText(hWnd);
            pl.WindowHandle     = hWnd;

            return pl;
        }

    }

    class ProcessListing {
        public uint ProcessID;
        public IntPtr WindowHandle;
        public string WindowText;
    }
}

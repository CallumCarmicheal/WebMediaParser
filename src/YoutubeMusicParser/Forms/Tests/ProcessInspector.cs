using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace YoutubeMusicParser {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void RefreshWindows(object sender, EventArgs e) {
            ProcessList.Text = "";

            Process[] procList = Process.GetProcesses();

            foreach (Process proc in procList) {
                string windowTitle = proc.MainWindowTitle;

                bool isValid = !(string.IsNullOrWhiteSpace(windowTitle));
                if (!isValid) continue;

                ProcessList.AppendText("Process ID: " + proc.Id);           ProcessList.AppendText("\r\n");
                ProcessList.AppendText("    Window Title: " + windowTitle); ProcessList.AppendText("\r\n");
            }
        }
    }
}

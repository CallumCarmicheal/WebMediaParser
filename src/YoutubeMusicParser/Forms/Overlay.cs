using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Runtime.InteropServices;

namespace YoutubeMusicParser.Forms {
    public partial class Overlay : Form {
        public Overlay() {
            InitializeComponent();
        }

        public enum GWL {
            ExStyle = -20
        }

        public enum WS_EX {
            Transparent = 0x20,
            Layered = 0x80000
        }

        public enum LWA {
            ColorKey = 0x1,
            Alpha = 0x2
        }

        [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
        public static extern int GetWindowLong(IntPtr hWnd, GWL nIndex);

        [DllImport("user32.dll", EntryPoint = "SetWindowLong")]
        public static extern int SetWindowLong(IntPtr hWnd, GWL nIndex, int dwNewLong);

        [DllImport("user32.dll", EntryPoint = "SetLayeredWindowAttributes")]
        public static extern bool SetLayeredWindowAttributes(IntPtr hWnd, int crKey, byte alpha, LWA dwFlags);

        protected override void OnShown(EventArgs e) {
            base.OnShown(e);
            //int wl = GetWindowLong(this.Handle, GWL.ExStyle);
            //wl = wl | 0x80000 | 0x20;
            //SetWindowLong(this.Handle, GWL.ExStyle, wl);
            //SetLayeredWindowAttributes(this.Handle, System.Drawing.Color.Gainsboro.ToArgb(), 155, LWA.ColorKey);
        }

        private void fixLocation() {
            // Move to top right incl padding of 5 pixels


            //int screenWidth     = Screen.PrimaryScreen.WorkingArea.Width;
            //int screenHeight    = Screen.PrimaryScreen.WorkingArea.Height;
            int screenWidth     = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight    = 0;
            
            int newWidth        = screenWidth  - this.Width - 5;
            int newHeight       = screenHeight - 5;
            this.Location       = new Point(newWidth, screenHeight);

            MessageBox.Show(newWidth + "x" + newHeight);
        }

        private void fixWidth() {
            // Label's width + padding * 2
            this.Width = label1.Width - (label1.Width / 3);
        }

        private void Overlay_Shown(object sender, EventArgs e) {
            // Set our width
            fixWidth();
            fixLocation();
        }

        public void SetMusicText(string str) {
            label1.Text = str;
            fixWidth();
            fixLocation();
        }
    }
}

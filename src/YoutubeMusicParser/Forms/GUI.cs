using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YoutubeMusicParser.Forms {
    public partial class GUI : Form {
        public GUI() {
            InitializeComponent();
        }

        string lastTitle = "";
        bool newProc = false;
        Overlay musicOverlay = new Overlay();
        Util.ProcessListing selectedProcess = null;
        Util.ProcessListing[] listings = null;


        private void comboBox1_DropDown(object sender, EventArgs e) {
            ProcessList.Items.Clear();
            var tmp = Util.Processes.GetDesktopWindowsTitles_OBJ();
            List<Util.ProcessListing> list = new List<Util.ProcessListing>();

            foreach (Util.ProcessListing pl in tmp) {
                if (Util.MediaServices.isPlayingAMediaService(pl.WindowText)) {
                    ProcessList.Items.Add(pl.WindowText);
                    list.Add(pl);
                }
            }

            listings = list.ToArray();
        }

        private void ProcessList_SelectedIndexChanged(object sender, EventArgs e) {
            newProc = true;
            selectedProcess = listings[ProcessList.SelectedIndex];

            label7.Text = "" + selectedProcess.ProcessID;
            label6.Text = "" + selectedProcess.WindowHandle;
            label5.Text = "" + selectedProcess.WindowText;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) {
            if (((CheckBox)sender).Checked)
                ChangesChecker.Start();
            else
                ChangesChecker.Stop();
        }

        private void ChangesChecker_Tick(object sender, EventArgs e) {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            path += "/CurrentYoutubeSong.txt";

            if (selectedProcess == null) {
                ((Timer)sender).Enabled = false;
                checkBox1.Checked = false;

                if (saveFileToPath.Checked)
                    System.IO.File.WriteAllText(path, "No process selected");

                MessageBox.Show("No process selected");
                return;
            }

            if (!Util.Processes.WindowHandleIsValid(selectedProcess.WindowHandle)) {
                ((Timer)sender).Enabled = false;
                checkBox1.Checked = false;

                MessageBox.Show(
                    "Process for (" + Util.MediaServices.GetSongTitleFromText(selectedProcess.WindowText) + ") has been Closed\n" +
                    "Stopped listening for changes");

                selectedProcess     = null;
                ProcessList.Text    = "";
                OutputText.Text       = "No song playing";
                return;
            }

            

            // Left most column
            var newProcess  = Util.Processes.getListingfromWHandle(selectedProcess.WindowHandle);
            if (!newProc && selectedProcess.WindowText == newProcess.WindowText)
                return;

            // Check if youtube is the current tab
            if (!Util.MediaServices.isPlayingAMediaService(newProcess.WindowText))
                return;

            newProc         = false;
            selectedProcess = newProcess;
            label5.Text     = "" + selectedProcess.WindowText;

            var videoText   = Util.MediaServices.GetVideoFromProc(selectedProcess);
            OutputText.Text   = videoText;

            if (checkBox3.Checked)
                musicOverlay.SetMusicText(videoText);

            if (saveFileToPath.Checked)
                System.IO.File.WriteAllText(path, videoText);
            
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e) {
            if (checkBox3.Checked)
                musicOverlay.Show();
            else
                musicOverlay.Hide();
        }
    }
}

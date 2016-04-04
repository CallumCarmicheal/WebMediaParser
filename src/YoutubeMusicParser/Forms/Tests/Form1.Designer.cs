namespace YoutubeMusicParser
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnWriteToFile = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGetProcesses = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ProcessList = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnWriteToFile
            // 
            this.btnWriteToFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWriteToFile.Location = new System.Drawing.Point(12, 373);
            this.btnWriteToFile.Name = "btnWriteToFile";
            this.btnWriteToFile.Size = new System.Drawing.Size(626, 23);
            this.btnWriteToFile.TabIndex = 1;
            this.btnWriteToFile.Text = "Display Information";
            this.btnWriteToFile.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Location = new System.Drawing.Point(465, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(173, 216);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Process Information";
            // 
            // btnGetProcesses
            // 
            this.btnGetProcesses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetProcesses.Location = new System.Drawing.Point(12, 344);
            this.btnGetProcesses.Name = "btnGetProcesses";
            this.btnGetProcesses.Size = new System.Drawing.Size(626, 23);
            this.btnGetProcesses.TabIndex = 3;
            this.btnGetProcesses.Text = "Refresh Windows";
            this.btnGetProcesses.UseVisualStyleBackColor = true;
            this.btnGetProcesses.Click += new System.EventHandler(this.RefreshWindows);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Location = new System.Drawing.Point(13, 227);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(625, 111);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Music Information";
            // 
            // ProcessList
            // 
            this.ProcessList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ProcessList.BackColor = System.Drawing.SystemColors.Control;
            this.ProcessList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ProcessList.Location = new System.Drawing.Point(13, 12);
            this.ProcessList.Name = "ProcessList";
            this.ProcessList.Size = new System.Drawing.Size(446, 209);
            this.ProcessList.TabIndex = 4;
            this.ProcessList.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 408);
            this.Controls.Add(this.ProcessList);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnGetProcesses);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnWriteToFile);
            this.Name = "Form1";
            this.Text = "TestForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnWriteToFile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnGetProcesses;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox ProcessList;
    }
}


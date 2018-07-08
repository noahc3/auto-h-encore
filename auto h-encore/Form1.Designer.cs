namespace auto_h_encore {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.barProgress = new System.Windows.Forms.ProgressBar();
            this.lblVersion = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.cbxDelete = new System.Windows.Forms.CheckBox();
            this.cbxTrim = new System.Windows.Forms.CheckBox();
            this.lblIssueTracker = new System.Windows.Forms.LinkLabel();
            this.lblWifiProblem = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Location = new System.Drawing.Point(12, 339);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(569, 223);
            this.txtLog.TabIndex = 2;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(12, 310);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(569, 23);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfo.Location = new System.Drawing.Point(12, 9);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(569, 148);
            this.lblInfo.TabIndex = 8;
            // 
            // barProgress
            // 
            this.barProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.barProgress.Location = new System.Drawing.Point(12, 281);
            this.barProgress.Maximum = 17;
            this.barProgress.Name = "barProgress";
            this.barProgress.Size = new System.Drawing.Size(569, 23);
            this.barProgress.TabIndex = 9;
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVersion.Location = new System.Drawing.Point(326, 567);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(255, 13);
            this.lblVersion.TabIndex = 10;
            this.lblVersion.Text = "auto h-encore version x";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.Location = new System.Drawing.Point(12, 206);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(569, 23);
            this.btnImport.TabIndex = 11;
            this.btnImport.Text = "I\'ve already download some or all of the files and would like to use them rather " +
    "than redownload them";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // cbxDelete
            // 
            this.cbxDelete.AutoSize = true;
            this.cbxDelete.Location = new System.Drawing.Point(15, 258);
            this.cbxDelete.Name = "cbxDelete";
            this.cbxDelete.Size = new System.Drawing.Size(306, 17);
            this.cbxDelete.TabIndex = 12;
            this.cbxDelete.Text = "Delete existing files (do this if something went wrong before)";
            this.cbxDelete.UseVisualStyleBackColor = true;
            // 
            // cbxTrim
            // 
            this.cbxTrim.AutoSize = true;
            this.cbxTrim.Checked = true;
            this.cbxTrim.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxTrim.Location = new System.Drawing.Point(15, 235);
            this.cbxTrim.Name = "cbxTrim";
            this.cbxTrim.Size = new System.Drawing.Size(476, 17);
            this.cbxTrim.TabIndex = 13;
            this.cbxTrim.Text = "Trim excess content from bitter smile demo (reduces h-encore app size from ~240MB" +
    " to ~13MB)";
            this.cbxTrim.UseVisualStyleBackColor = true;
            // 
            // lblIssueTracker
            // 
            this.lblIssueTracker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblIssueTracker.AutoSize = true;
            this.lblIssueTracker.Location = new System.Drawing.Point(12, 567);
            this.lblIssueTracker.Name = "lblIssueTracker";
            this.lblIssueTracker.Size = new System.Drawing.Size(72, 13);
            this.lblIssueTracker.TabIndex = 14;
            this.lblIssueTracker.TabStop = true;
            this.lblIssueTracker.Text = "Issue Tracker";
            this.lblIssueTracker.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblIssueTracker_LinkClicked);
            // 
            // lblWifiProblem
            // 
            this.lblWifiProblem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWifiProblem.Location = new System.Drawing.Point(12, 157);
            this.lblWifiProblem.Name = "lblWifiProblem";
            this.lblWifiProblem.Size = new System.Drawing.Size(569, 46);
            this.lblWifiProblem.TabIndex = 15;
            this.lblWifiProblem.Text = "WIFI PROBLEMS";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 587);
            this.Controls.Add(this.lblWifiProblem);
            this.Controls.Add(this.lblIssueTracker);
            this.Controls.Add(this.cbxTrim);
            this.Controls.Add(this.cbxDelete);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.barProgress);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtLog);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "auto h-encore";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.ProgressBar barProgress;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.CheckBox cbxDelete;
        private System.Windows.Forms.CheckBox cbxTrim;
        private System.Windows.Forms.LinkLabel lblIssueTracker;
        private System.Windows.Forms.Label lblWifiProblem;
    }
}


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
            this.txtAID = new System.Windows.Forms.TextBox();
            this.lblAID = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblHowToAID = new System.Windows.Forms.LinkLabel();
            this.lblQCMA = new System.Windows.Forms.Label();
            this.txtQCMA = new System.Windows.Forms.TextBox();
            this.btnBrowseQCMA = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.barProgress = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // txtAID
            // 
            this.txtAID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAID.Location = new System.Drawing.Point(12, 28);
            this.txtAID.Name = "txtAID";
            this.txtAID.Size = new System.Drawing.Size(569, 20);
            this.txtAID.TabIndex = 0;
            this.txtAID.TextChanged += new System.EventHandler(this.txtAID_TextChanged);
            // 
            // lblAID
            // 
            this.lblAID.AutoSize = true;
            this.lblAID.Location = new System.Drawing.Point(9, 12);
            this.lblAID.Name = "lblAID";
            this.lblAID.Size = new System.Drawing.Size(88, 13);
            this.lblAID.TabIndex = 1;
            this.lblAID.Text = "Account ID (AID)";
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Location = new System.Drawing.Point(12, 310);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(569, 299);
            this.txtLog.TabIndex = 2;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Enabled = false;
            this.btnStart.Location = new System.Drawing.Point(12, 281);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(569, 23);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblHowToAID
            // 
            this.lblHowToAID.AutoSize = true;
            this.lblHowToAID.Location = new System.Drawing.Point(9, 93);
            this.lblHowToAID.Name = "lblHowToAID";
            this.lblHowToAID.Size = new System.Drawing.Size(147, 13);
            this.lblHowToAID.TabIndex = 4;
            this.lblHowToAID.TabStop = true;
            this.lblHowToAID.Text = "How do I get this information?";
            this.lblHowToAID.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblHowToAID_LinkClicked);
            // 
            // lblQCMA
            // 
            this.lblQCMA.AutoSize = true;
            this.lblQCMA.Location = new System.Drawing.Point(9, 54);
            this.lblQCMA.Name = "lblQCMA";
            this.lblQCMA.Size = new System.Drawing.Size(119, 13);
            this.lblQCMA.TabIndex = 6;
            this.lblQCMA.Text = "QCMA PS Vita directory";
            // 
            // txtQCMA
            // 
            this.txtQCMA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQCMA.Location = new System.Drawing.Point(12, 70);
            this.txtQCMA.Name = "txtQCMA";
            this.txtQCMA.Size = new System.Drawing.Size(488, 20);
            this.txtQCMA.TabIndex = 5;
            this.txtQCMA.TextChanged += new System.EventHandler(this.txtQCMA_TextChanged);
            // 
            // btnBrowseQCMA
            // 
            this.btnBrowseQCMA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseQCMA.Location = new System.Drawing.Point(506, 68);
            this.btnBrowseQCMA.Name = "btnBrowseQCMA";
            this.btnBrowseQCMA.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseQCMA.TabIndex = 7;
            this.btnBrowseQCMA.Text = "Browse";
            this.btnBrowseQCMA.UseVisualStyleBackColor = true;
            this.btnBrowseQCMA.Click += new System.EventHandler(this.btnBrowseQCMA_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfo.Location = new System.Drawing.Point(12, 121);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(569, 128);
            this.lblInfo.TabIndex = 8;
            // 
            // barProgress
            // 
            this.barProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.barProgress.Location = new System.Drawing.Point(15, 252);
            this.barProgress.Maximum = 18;
            this.barProgress.Name = "barProgress";
            this.barProgress.Size = new System.Drawing.Size(566, 23);
            this.barProgress.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 621);
            this.Controls.Add(this.barProgress);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnBrowseQCMA);
            this.Controls.Add(this.lblQCMA);
            this.Controls.Add(this.txtQCMA);
            this.Controls.Add(this.lblHowToAID);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.lblAID);
            this.Controls.Add(this.txtAID);
            this.Name = "Form1";
            this.Text = "auto h-encore";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAID;
        private System.Windows.Forms.Label lblAID;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.LinkLabel lblHowToAID;
        private System.Windows.Forms.Label lblQCMA;
        private System.Windows.Forms.TextBox txtQCMA;
        private System.Windows.Forms.Button btnBrowseQCMA;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.ProgressBar barProgress;
    }
}


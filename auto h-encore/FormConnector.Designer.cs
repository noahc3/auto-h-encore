namespace auto_h_encore {
    partial class FormConnector {
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
            this.btnUSB = new System.Windows.Forms.Button();
            this.lblInstructions = new System.Windows.Forms.Label();
            this.btnWifi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnUSB
            // 
            this.btnUSB.Location = new System.Drawing.Point(12, 175);
            this.btnUSB.Name = "btnUSB";
            this.btnUSB.Size = new System.Drawing.Size(239, 23);
            this.btnUSB.TabIndex = 0;
            this.btnUSB.Text = "USB";
            this.btnUSB.UseVisualStyleBackColor = true;
            this.btnUSB.Click += new System.EventHandler(this.btnUSB_Click);
            // 
            // lblInstructions
            // 
            this.lblInstructions.Location = new System.Drawing.Point(12, 9);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(484, 163);
            this.lblInstructions.TabIndex = 1;
            this.lblInstructions.Text = "label1";
            // 
            // btnWifi
            // 
            this.btnWifi.Location = new System.Drawing.Point(257, 175);
            this.btnWifi.Name = "btnWifi";
            this.btnWifi.Size = new System.Drawing.Size(239, 23);
            this.btnWifi.TabIndex = 2;
            this.btnWifi.Text = "WIFI";
            this.btnWifi.UseVisualStyleBackColor = true;
            this.btnWifi.Click += new System.EventHandler(this.btnWifi_Click);
            // 
            // FormConnector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 203);
            this.Controls.Add(this.btnWifi);
            this.Controls.Add(this.lblInstructions);
            this.Controls.Add(this.btnUSB);
            this.Name = "FormConnector";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormConnector_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUSB;
        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.Button btnWifi;
    }
}
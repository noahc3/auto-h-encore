using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace auto_h_encore {
    public partial class FormAID : Form {
        public FormAID() {
            InitializeComponent();

            lblGuide.Text = "Before running: \r\n1. Install QCMA\r\n2. Open QCMA\r\n3. Connect your Vita to your PC using USB and launch Content Manager\r\n4. Select Copy Content to connect your Vita to your PC\r\n   If your Vita says you need to update, turn off Wifi and restart the console\r\n5. Right click QCMA in task tray, select settings\r\n6.Copy the directory named Applications / Backups into this application as the PS Vita directory \r\n7. Navigate to the directory you just copied and go into the APP folder\r\n8. Your AID is the name of the folder inside this directory (it should be 16 characters)";
        }

        private void btnOpenGuide_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("https://github.com/TheOfficialFloW/h-encore/blob/master/README.md");
        }

        private void btnClose_Click(object sender, EventArgs e) {
            Close();
        }
    }
}

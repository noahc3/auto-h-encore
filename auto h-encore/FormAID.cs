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

            btnClose.Text = Language.MountedLanguage["btn_Close"];
            lblGuide.Text = Language.MountedLanguage["txtblock_HowToInfo"];
        }

        private void btnOpenGuide_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("https://github.com/TheOfficialFloW/h-encore/blob/master/README.md");
        }

        private void btnClose_Click(object sender, EventArgs e) {
            Close();
        }
    }
}

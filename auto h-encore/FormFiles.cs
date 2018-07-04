using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using Microsoft.VisualBasic.FileIO;
using System.IO;
using System.Threading;

namespace auto_h_encore {
    public partial class FormFiles : Form {

        static bool HashState = false;

        private bool UserChecked = false;

        private bool[] calculating = new bool[4];
        private bool[] okFiles = new bool[4];

        private static string[] fileStatusMessages = new string[] {
            Language.MountedLanguage["status_NoFile"],
            Language.MountedLanguage["status_Invalid"],
            Language.MountedLanguage["status_Valid"],
            Language.MountedLanguage["status_BadHash"],
            Language.MountedLanguage["status_Override"],
            Language.MountedLanguage["status_Calculating"],
        };

        public FormFiles() {
            InitializeComponent();

            lblBittersmileStatus.Text = fileStatusMessages[0];
            lblHencoreStatus.Text = fileStatusMessages[0];
            lblPkg2zipStatus.Text = fileStatusMessages[0];
            lblPsvimgtoolsStatus.Text = fileStatusMessages[0];

            this.Text = Language.MountedLanguage["title_Import"];
            btnBrowseBittersmile.Text = Language.MountedLanguage["btn_Browse"];
            btnBrowseHencore.Text = Language.MountedLanguage["btn_Browse"];
            btnBrowsePkg2zip.Text = Language.MountedLanguage["btn_Browse"];
            btnBrowsePsvimgtools.Text = Language.MountedLanguage["btn_Browse"];
            btnOk.Text = Language.MountedLanguage["btn_Done"];
            cbxIgnoreHashes.Text = Language.MountedLanguage["cbx_OverrideHashes"];
            lblInfo.Text = Language.MountedLanguage["txtblock_Import"];
        }

        private void LockControls(int id, Button btn, TextBox txt) {
            btnOk.Enabled = false;

            btn.Enabled = false;
            txt.Enabled = false;
            calculating[id] = true;
        }

        private void TryUnlockControls(int id, Button btn, TextBox txt) {

            btn.Enabled = true;
            txt.Enabled = true;
            calculating[id] = false;

            bool canUnlock = true;
            foreach(bool k in calculating) {
                if (k == true) {
                    canUnlock = false;
                    break;
                }
            }

            if (canUnlock) {
                btnOk.Enabled = true;
            }
        }

        private void CheckStatus(int id, Button btnBrowse, Label lblStatus, TextBox txtFile) {
            lblStatus.ForeColor = SystemColors.ControlText;
            lblStatus.Text = fileStatusMessages[5];
            if (txtFile.Text == "") {
                //if nothing is specified, default message
                lblStatus.ForeColor = SystemColors.ControlText;
                lblStatus.Text = fileStatusMessages[0];
                okFiles[id] = false;
            } else if (FileSystem.FileExists(txtFile.Text)) {
                //if the file is specified and exists, lock the textbox and start doing an MD5 verification
                LockControls(id, btnBrowse, txtFile);
                Task.Factory.StartNew(new Action(() => {
                    bool fileValid = false;
                    string hash = Utility.MD5Checksum(txtFile.Text);
                    foreach (string k in Reference.hashes[id]) {
                        if (k == hash) fileValid = true;
                    }
                    if (fileValid) {
                        Invoke(new Action(() => {
                            lblStatus.ForeColor = Color.Green;
                            lblStatus.Text = fileStatusMessages[2];
                            okFiles[id] = true;
                        }));
                    } else {
                        if (cbxIgnoreHashes.Checked) {
                            Invoke(new Action(() => {
                                lblStatus.ForeColor = Color.Orange;
                                lblStatus.Text = fileStatusMessages[4];
                                okFiles[id] = true;
                            }));
                        } else {
                            Invoke(new Action(() => {
                                lblStatus.ForeColor = Color.Red;
                                lblStatus.Text = fileStatusMessages[3];
                                okFiles[id] = false;
                            }));
                        }
                    }
                    Invoke(new Action(() => TryUnlockControls(id, btnBrowse, txtFile)));
                }));
            } else {
                //if something is specified but the file doesnt exist, tell the user
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = fileStatusMessages[1];
                okFiles[id] = false;
            }
        }

        private void txtHencore_TextChanged(object sender, EventArgs e) {
            CheckStatus(0, btnBrowseHencore, lblHencoreStatus, txtHencore);

        }

        private void txtPkg2zip_TextChanged(object sender, EventArgs e) {
            CheckStatus(1, btnBrowsePkg2zip, lblPkg2zipStatus, txtPkg2zip);
        }

        private void txtPsvimgtools_TextChanged(object sender, EventArgs e) {
            CheckStatus(2, btnBrowsePsvimgtools, lblPsvimgtoolsStatus, txtPsvimgtools);
        }

        private void txtBittersmile_TextChanged(object sender, EventArgs e) {
            CheckStatus(3, btnBrowseBittersmile, lblBittersmileStatus, txtBittersmile);
        }

        private void btnOk_Click(object sender, EventArgs e) {

            if (okFiles[0] == true) Global.fileOverrides[0] = txtHencore.Text;
            if (okFiles[1] == true) Global.fileOverrides[1] = txtPkg2zip.Text;
            if (okFiles[2] == true) Global.fileOverrides[2] = txtPsvimgtools.Text;
            if (okFiles[3] == true) Global.fileOverrides[3] = txtBittersmile.Text;

            Close();
        }

        private void btnBrowseHencore_Click(object sender, EventArgs e) {
            txtHencore.Text = Utility.BrowseFile(Language.MountedLanguage["browse_Generic"] + "h-encore.zip v1.0", ".zip", "Zip files (*.zip)|*.zip");
        }

        private void btnBrowsePkg2zip_Click(object sender, EventArgs e) {
            txtPkg2zip.Text = Utility.BrowseFile(Language.MountedLanguage["browse_Generic"] + "pkg2zip_32bit.zip or pkg2zip_64bit.zip v1.8", ".zip", "Zip files (*.zip)|*.zip");
        }

        private void btnBrowsePsvimgtools_Click(object sender, EventArgs e) {
            txtPsvimgtools.Text = Utility.BrowseFile(Language.MountedLanguage["browse_Generic"] + "psvimgtools -0.1-win32.zip or psvimgtools-0.1-win64.zip v0.1", ".zip", "Zip files (*.zip)|*.zip");
        }

        private void btnBrowseBittersmile_Click(object sender, EventArgs e) {
            txtBittersmile.Text = Utility.BrowseFile(Language.MountedLanguage["browse_Generic"] + "BitterSmile demo pkg", ".pkg", "All files (*)|*");
        }

        private void cbxIgnoreHashes_CheckedChanged(object sender, EventArgs e) {
            if (!UserChecked) {
                if (cbxIgnoreHashes.Checked) {
                    UserChecked = true;
                    if (MessageBox.Show(Language.MountedLanguage["warn_HashCompat"], Language.MountedLanguage["title_Warning"] , MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
                        cbxIgnoreHashes.BackColor = Color.Red;
                        UserChecked = false;

                        if (lblHencoreStatus.Text == fileStatusMessages[3]) {
                            lblHencoreStatus.ForeColor = Color.Orange;
                            lblHencoreStatus.Text = fileStatusMessages[4];
                            okFiles[0] = true;
                        }

                        if (lblPkg2zipStatus.Text == fileStatusMessages[3]) {
                            lblPkg2zipStatus.ForeColor = Color.Orange;
                            lblPkg2zipStatus.Text = fileStatusMessages[4];
                            okFiles[1] = true;
                        }

                        if (lblPsvimgtoolsStatus.Text == fileStatusMessages[3]) {
                            lblPsvimgtoolsStatus.ForeColor = Color.Orange;
                            lblPsvimgtoolsStatus.Text = fileStatusMessages[4];
                            okFiles[2] = true;
                        }

                        if (lblBittersmileStatus.Text == fileStatusMessages[3]) {
                            lblBittersmileStatus.ForeColor = Color.Orange;
                            lblBittersmileStatus.Text = fileStatusMessages[4];
                            okFiles[3] = true;
                        }
                    } else {
                        cbxIgnoreHashes.Checked = false;
                    }
                } else {
                    cbxIgnoreHashes.BackColor = SystemColors.Control;

                    if (lblHencoreStatus.Text == fileStatusMessages[4]) {
                        lblHencoreStatus.ForeColor = Color.Red;
                        lblHencoreStatus.Text = fileStatusMessages[3];
                        okFiles[0] = false;
                    }

                    if (lblPkg2zipStatus.Text == fileStatusMessages[4]) {
                        lblPkg2zipStatus.ForeColor = Color.Red;
                        lblPkg2zipStatus.Text = fileStatusMessages[3];
                        okFiles[1] = false;
                    }

                    if (lblPsvimgtoolsStatus.Text == fileStatusMessages[4]) {
                        lblPsvimgtoolsStatus.ForeColor = Color.Red;
                        lblPsvimgtoolsStatus.Text = fileStatusMessages[3];
                        okFiles[2] = false;
                    }

                    if (lblBittersmileStatus.Text == fileStatusMessages[4]) {
                        lblBittersmileStatus.ForeColor = Color.Red;
                        lblBittersmileStatus.Text = fileStatusMessages[3];
                        okFiles[3] = false;
                    }
                }
            } else {
                UserChecked = false;
            }

            HashState = cbxIgnoreHashes.Checked;
        }

        private void FormFiles_Load(object sender, EventArgs e) {

            ControlBox = false;

            UserChecked = true;
            cbxIgnoreHashes.Checked = HashState;
            if (HashState) cbxIgnoreHashes.BackColor = Color.Red;

            txtHencore.Text = Global.fileOverrides[0];
            txtPkg2zip.Text = Global.fileOverrides[1];
            txtPsvimgtools.Text = Global.fileOverrides[2];
            txtBittersmile.Text = Global.fileOverrides[3];

            UserChecked = false;
        }
    }
}

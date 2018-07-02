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

        private static MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

        private bool[] calculating = new bool[4];

        private static string[] fileStatusMessages = new string[] {
            "No file selected, will download.",
            "File path is invalid",
            "File selected and hash matches, will import.",
            "File selected but hash does not match, will download",
            "File selected but hash does not match. Hash override enabled, will import",
            "Calculating checksum..."
        };

        public static string[] result;

        public FormFiles() {
            InitializeComponent();
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
            LockControls(id, btnBrowse, txtHencore);
            Task.Factory.StartNew(new Action(() => {
                if (txtFile.Text == "") {
                    Invoke(new Action(() => {
                        lblStatus.ForeColor = SystemColors.ControlText;
                        lblStatus.Text = fileStatusMessages[0];
                    }));
                } else if (FileSystem.FileExists(txtFile.Text)) {
                    if (md5.ComputeHash(File.OpenRead(txtFile.Text)).ToString() == Reference.hash_hencore) {
                        Invoke(new Action(() => {
                            lblStatus.ForeColor = Color.Green;
                            lblStatus.Text = fileStatusMessages[2];
                        }));
                    } else {
                        if (cbxIgnoreHashes.Checked) {
                            Invoke(new Action(() => {
                                lblStatus.ForeColor = Color.Yellow;
                                lblStatus.Text = fileStatusMessages[4];
                            }));
                        } else {
                            Invoke(new Action(() => {
                                lblStatus.ForeColor = Color.Red;
                                lblStatus.Text = fileStatusMessages[3];
                            }));
                        }
                    }
                } else {
                    lblHencoreName.ForeColor = Color.Red;
                    lblHencoreName.Text = fileStatusMessages[1];
                }

                TryUnlockControls(id, btnBrowse, txtFile);
            }));
        }

        private void txtHencore_TextChanged(object sender, EventArgs e) {
            CheckStatus(0, btnBrowseHencore, lblHencoreStatus, txtHencore);

        }

        private void txtPkg2zip_TextChanged(object sender, EventArgs e) {
            CheckStatus(1, btnPkg2zipBrowse, lblPkg2zipStatus, txtPkg2zip);
        }

        private void txtPsvimgtools_TextChanged(object sender, EventArgs e) {
            CheckStatus(2, btnPsvimgtoolsBrowse, lblPsvimgtoolsStatus, txtPsvimgtools);
        }

        private void txtBittersmile_TextChanged(object sender, EventArgs e) {
            CheckStatus(3, btnBittersmileBrowse, lblBittersmileStatus, txtBittersmile);
        }

        private void btnOk_Click(object sender, EventArgs e) {
            result = new string[] {
                txtHencore.Text, txtPkg2zip.Text, txtPsvimgtools.Text, txtBittersmile.Text
            };

            Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.IO.Compression;
using System.Net.Http;
using Microsoft.VisualBasic.FileIO;
using System.Diagnostics;
using System.Security.Cryptography;
using Microsoft.Win32;

namespace auto_h_encore {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            this.Text = Language.MountedLanguage["title_Main"];
            lblVersion.Text = Language.MountedLanguage["lbl_VersionText"] + Reference.version;
            lblInfo.Text = Language.MountedLanguage["txtblock_BeforeRunning"];
            //lblAID.Text = Language.MountedLanguage["lbl_AID"];
            //lblHowToAID.Text = Language.MountedLanguage["lbl_HowToAID"];
            lblIssueTracker.Text = Language.MountedLanguage["lbl_Issues"];
            lblWifiProblem.Text = Language.MountedLanguage["lbl_WifiProblems"];
            //lblQCMA.Text = Language.MountedLanguage["lbl_QCMADir"];
            btnImport.Text = Language.MountedLanguage["btn_Import"];
            btnStart.Text = Language.MountedLanguage["btn_Start"];
            //btnBrowseQCMA.Text = Language.MountedLanguage["btn_Browse"];
            cbxDelete.Text = Language.MountedLanguage["cbx_DeleteExisting"];
            cbxTrim.Text = Language.MountedLanguage["cbx_Trim"];
        }

        private void generateDirectories() {
            if (cbxDelete.Checked) {
                try {
                    if (Global.path_QCMA != "") {
                        Global.fileOverrides[4] = "SKIP";
                    }
                    info(Language.MountedLanguage["log_WipeFiles"]);
                    if (Directory.Exists(Reference.path_data)) Directory.Delete(Reference.path_data, true);
                    for (int i = 0; i < 4; i++) {
                        if (!FileSystem.FileExists(Global.fileOverrides[i])) Global.fileOverrides[i] = "";
                    }
                } catch (Exception ex) {
                    ErrorHandling.HandleException("0200", ex);
                }
            } else {

                string path = "";
                string cleanName;
                string md5;

                for (int id = 0; id < 5; id++) {

                    switch (id) {
                        case 0:
                            path = Reference.path_downloads + "hencore.zip";
                            break;
                        case 1:
                            path = Reference.path_downloads + "pkg2zip.zip";
                            break;
                        case 2:
                            path = Reference.path_downloads + "psvimgtools.zip";
                            break;
                        case 3:
                            path = Reference.path_downloads + "bittersmile.pkg";
                            break;
                        case 4:
                            path = Reference.path_downloads + "qcma.zip";
                            break;
                    }

                    cleanName = path.Replace('/', '\\').Split('\\').Last();

                    if (id == 4 && Global.path_QCMA != "") {
                        Global.fileOverrides[4] = "SKIP";
                        continue;
                    }

                    if (Global.fileOverrides[id] != null && Global.fileOverrides[id] != "") {
                        info(string.Format(Language.MountedLanguage["log_Import"], cleanName));
                        continue;
                    }

                    if (FileSystem.FileExists(path)) {
                        bool fileValid = false;
                        md5 = Utility.MD5Checksum(path);
                        foreach (string k in Reference.hashes[id]) {
                            if (k == md5) fileValid = true;
                        }
                        if (fileValid) {
                            info(string.Format(Language.MountedLanguage["log_DownloadValid"], cleanName));
                            Global.fileOverrides[id] = path;
                        } else {
                            info(string.Format(Language.MountedLanguage["log_DownloadInvalid"], cleanName));
                        }
                    } else {
                        info(string.Format(Language.MountedLanguage["log_NotDownloaded"], cleanName));
                    }
                }

                if (Directory.Exists(Reference.path_qcma)) FileSystem.DeleteDirectory(Reference.path_qcma, DeleteDirectoryOption.DeleteAllContents);
                if (Directory.Exists(Reference.path_hencore)) FileSystem.DeleteDirectory(Reference.path_hencore, DeleteDirectoryOption.DeleteAllContents);
                if (Directory.Exists(Reference.path_psvimgtools)) FileSystem.DeleteDirectory(Reference.path_psvimgtools, DeleteDirectoryOption.DeleteAllContents);
            }

            try {
                info(Language.MountedLanguage["log_WorkingDirs"]);
                if (FileSystem.FileExists(Reference.fpath_pkg2zip)) FileSystem.DeleteFile(Reference.fpath_pkg2zip);
                if (FileSystem.DirectoryExists(Reference.path_downloads + "app\\PCSG90096\\")) FileSystem.DeleteDirectory(Reference.path_downloads + "app\\PCSG90096\\", DeleteDirectoryOption.DeleteAllContents);
                Directory.CreateDirectory(Reference.path_data);
                Directory.CreateDirectory(Reference.path_hencore);
                Directory.CreateDirectory(Reference.path_psvimgtools);
                Directory.CreateDirectory(Reference.path_qcma);
                Directory.CreateDirectory(Reference.path_downloads);
            } catch (Exception ex) {
                ErrorHandling.HandleException("0201", ex);
            }

            incrementProgress();
        }

        private void downloadFiles() {

            for (int id = 0; id < 5; id++) {
                if (Global.fileOverrides[id] != "SKIP") {
                    string cleanName = Reference.raws[id].Replace('/', '\\').Split('\\').Last();
                    if (Global.fileOverrides[id] != null && Global.fileOverrides[id] != "") {
                        if (Global.fileOverrides[id] == Reference.raws[id]) info(string.Format(Language.MountedLanguage["log_CorrectLocation"], cleanName));
                        else {
                            try {
                                info(string.Format(Language.MountedLanguage["log_Importing"], cleanName));
                                FileSystem.CopyFile(Global.fileOverrides[id], Reference.raws[id], true);
                                info(Language.MountedLanguage["log_Done"]);
                            } catch (Exception ex) {
                                ErrorHandling.HandleException("0202", ex);
                            }

                        }
                    } else {
                        Utility.DownloadFile(this, Reference.downloads[id], Reference.raws[id]);

                    }
                    incrementProgress();

                    if (id == 3) {

                    } else {
                        Utility.ExtractFile(this, true, Reference.raws[id], Reference.paths[id]);
                    }
                }
            }
        }

        private void PackageHencore(string encKey) {
            Utility.PackageFiles(this, true, Reference.path_hencore + "h-encore\\", encKey, "app");
            Utility.PackageFiles(this, true, Reference.path_hencore + "h-encore\\", encKey, "appmeta");
            Utility.PackageFiles(this, true, Reference.path_hencore + "h-encore\\", encKey, "license");
            Utility.PackageFiles(this, true, Reference.path_hencore + "h-encore\\", encKey, "savedata");
        }


        private void toggleControls(bool state) {
            if (InvokeRequired) {
                Invoke(new Action(() => {
                    btnStart.Enabled = state;
                    btnImport.Enabled = state;
                    cbxDelete.Enabled = state;
                    cbxTrim.Enabled = state;
                    barProgress.Value = 0;
                }));
            } else {
                btnStart.Enabled = state;
                btnImport.Enabled = state;
                cbxDelete.Enabled = state;
                cbxTrim.Enabled = state;
                barProgress.Value = 0;
            }
        }
        private void txtAID_TextChanged(object sender, EventArgs e) {
            
        }

        private void btnStart_Click(object sender, EventArgs e) {
            
                toggleControls(false);

                //run code on new thread to keep UI responsive
                Task.Factory.StartNew(new Action(() => {
                    try {
                        try {
                            Global.path_QCMA = Utility.FindQCMA(this);
                            Utility.KillQCMA(this);
                        } catch (Exception ex) {
                            ErrorHandling.HandleException("020B", ex);
                        }

                        try {
                            generateDirectories();
                            downloadFiles();
                        } catch (Exception ex) {
                            ErrorHandling.HandleException("020C", ex);
                        }

                        try {
                            Utility.ImportRegistry(this);
                        } catch (Exception ex) {
                            ErrorHandling.HandleException("020D", ex);
                        }

                        if (Global.path_QCMA == "") Global.path_QCMA = Reference.path_qcma + "qcma.exe";

                        info(Language.MountedLanguage["log_Prompt"]);
                        FormConnector frm = new FormConnector();
                        frm.ShowDialog();
                        info(Language.MountedLanguage["log_Done"]);

                        if (Directory.Exists(Global.QCMAAPPS + "\\APP\\" + Global.AID + "\\PCSG90096\\")) {
                            if (MessageBox.Show(Language.MountedLanguage["warn_DeleteExistingBittersmile"], Language.MountedLanguage["title_Warning"], MessageBoxButtons.YesNo) == DialogResult.Yes) {
                                FileSystem.DeleteDirectory(Global.QCMAAPPS + "\\APP\\" + Global.AID + "\\PCSG90096\\", DeleteDirectoryOption.DeleteAllContents);
                            } else {
                                throw new IOException("Directory Already Exists");
                            }
                        }

                        try {
                            info(Language.MountedLanguage["log_ExtractingPKG"]);
                            ProcessStartInfo psi = new ProcessStartInfo();
                            psi.WorkingDirectory = Reference.path_downloads;
                            psi.Arguments = "-x bittersmile.pkg";
                            psi.FileName = Reference.fpath_pkg2zip;
                            Process process = Process.Start(psi);
                            process.WaitForExit();
                            info(Language.MountedLanguage["log_Done"]);
                            incrementProgress();
                        } catch (Exception ex) {
                            ErrorHandling.HandleException("0203", ex);
                        }


                        if (cbxTrim.Checked) {
                            try {
                                info(Language.MountedLanguage["log_Trimming"]);
                                string path = Reference.path_downloads + "app\\PCSG90096\\resource\\";
                                foreach (string k in Reference.trims) {
                                    FileSystem.DeleteDirectory(path + k, DeleteDirectoryOption.DeleteAllContents);
                                }
                                info(Language.MountedLanguage["log_Done"]);
                            } catch (Exception ex) {
                                ErrorHandling.HandleException("0204", ex);
                            }
                        }

                        try {
                            foreach (string k in FileSystem.GetFiles(Reference.path_downloads + "app\\PCSG90096\\")) {
                                info(string.Format(Language.MountedLanguage["log_MoveToHencore"], k.Split('\\').Last()));
                                FileSystem.MoveFile(k, Reference.path_hencore + "\\h-encore\\app\\ux0_temp_game_PCSG90096_app_PCSG90096\\" + k.Split('\\').Last());
                            }
                        } catch (Exception ex) {
                            ErrorHandling.HandleException("0205", ex);
                        }

                        try {
                            foreach (string k in FileSystem.GetDirectories(Reference.path_downloads + "app\\PCSG90096\\")) {
                                info(string.Format(Language.MountedLanguage["log_MoveToHencore"], k.Split('\\').Last()));
                                FileSystem.MoveDirectory(k, Reference.path_hencore + "\\h-encore\\app\\ux0_temp_game_PCSG90096_app_PCSG90096\\" + k.Split('\\').Last());
                            }
                        } catch (Exception ex) {
                            ErrorHandling.HandleException("0206", ex);
                        }

                        incrementProgress();

                        try {
                            info(Language.MountedLanguage["log_MoveLicense"]);
                            FileSystem.MoveFile(Reference.path_hencore + "\\h-encore\\app\\ux0_temp_game_PCSG90096_app_PCSG90096\\sce_sys\\package\\temp.bin", Reference.path_hencore + "\\h-encore\\license\\ux0_temp_game_PCSG90096_license_app_PCSG90096\\6488b73b912a753a492e2714e9b38bc7.rif");
                            info(Language.MountedLanguage["log_Done"]);
                            incrementProgress();
                        } catch (Exception ex) {
                            ErrorHandling.HandleException("0207", ex);
                        }

                        string encKey = "";

                        try {
                            info(string.Format(Language.MountedLanguage["log_GetCMA"], Global.AID));
                            encKey = Utility.GetEncKey(Global.AID);
                            if (encKey.Length != 64) return;
                            info(string.Format(Language.MountedLanguage["log_GotCMA"], encKey));
                            incrementProgress();
                        } catch (Exception ex) {
                            ErrorHandling.HandleException("0208", ex);
                        }

                        try {
                            PackageHencore(encKey);
                        } catch (Exception ex) {
                            ErrorHandling.HandleException("0209", ex);
                        }

                        try {
                            info(Language.MountedLanguage["log_MoveToQCMA"]);
                            FileSystem.MoveDirectory(Reference.path_hencore + "h-encore\\PCSG90096\\", Global.QCMAAPPS + "\\APP\\" + Global.AID + "\\PCSG90096\\");
                            incrementProgress();
                            info(Language.MountedLanguage["log_Finished"]);
                        } catch (Exception ex) {
                            ErrorHandling.HandleException("020A", ex);
                        }

                        Invoke(new Action(() => MessageBox.Show(Language.MountedLanguage["info_Finish"])));

                        toggleControls(true);
                    } catch (KeyNotFoundException ex) {
                        ErrorHandling.ShowError("AAAA020B", "An error occurred with language substitution: \r\n" + ex.Message + "\r\nThis is a bug! Please report this on the issue tracker with the message provided above!");
                        toggleControls(true);
                        return;
                    } catch (Exception) {
                        toggleControls(true);
                        return;
                    }
                }));
            
        }

        public void incrementProgress() {
            if (barProgress.Value < barProgress.Maximum) {
                if (InvokeRequired) Invoke(new Action(() => barProgress.Value++));
                else barProgress.Value++;
            }
        }

        public void info(string message) {
            if (InvokeRequired) Invoke(new Action(() => txtLog.AppendText("[" + DateTime.Now.ToLongTimeString() + "] " + message + "\r\n")));
            else txtLog.AppendText("[" + DateTime.Now.ToLongTimeString() + "] " + message + "\r\n");

        }

        private void btnBrowseQCMA_Click(object sender, EventArgs e) {
        }

        private void txtQCMA_TextChanged(object sender, EventArgs e) {
        }

        private void btnImport_Click(object sender, EventArgs e) {
            FormFiles frm = new FormFiles();
            frm.ShowDialog();
        }

        private void lblIssueTracker_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start(Reference.url_issues);
            
        }

        private void Form1_Load(object sender, EventArgs e) {

            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            Application.Exit();
        }
    }
}

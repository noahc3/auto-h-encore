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

namespace auto_h_encore {
    public partial class Form1 : Form {


        public Form1() {
            InitializeComponent();

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            lblVersion.Text = "auto h-encore version " + Reference.version;
            lblInfo.Text = "Before running: \r\n1. Install QCMA\r\n2. Open QCMA\r\n3. Connect your Vita to your PC using USB and launch Content Manager\r\n4. Select Copy Content to connect your Vita to your PC\r\n   If your Vita says you need to update, turn off Wifi and restart the console\r\n\r\nEverything is now ready. Enter the above information correctly to enable the start button\r\n\r\nIf the start button does not enable, make sure your AID is 16 characters long and that you've selected the correct PS Vita folder (it should have an APP directory in it).";
        }

        private void VerifyUserInfo() {
            if (txtAID.Text.Length == 16 && Directory.Exists(txtQCMA.Text + "\\APP\\")) btnStart.Enabled = true;
            else btnStart.Enabled = false;
        }

        private void generateDirectories(string AID) {
            //TODO: Needs code cleanup pretty bad...
            if (cbxDelete.Checked) {
                info("Deleting old files...");
                if (Directory.Exists(Reference.path_data)) Directory.Delete(Reference.path_data, true);
                for (int i = 0; i < 4; i++) {
                    if (!FileSystem.FileExists(Global.fileOverrides[i])) Global.fileOverrides[i] = "";
                }
                
            } else {

                string path = "";
                string cleanName;
                string md5;

                for (int id = 0; id < 4; id++) {

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
                    }

                    cleanName = path.Replace('/', '\\').Split('\\').Last();

                    if (Global.fileOverrides[id] != null && Global.fileOverrides[id] != "") {
                        info("File import for file " + cleanName + " valid.");
                        continue;
                    }

                    if (FileSystem.FileExists(path)) {
                        md5 = Utility.MD5Checksum(path);
                        if (Reference.hashes[id] == md5) {
                            info("File " + cleanName + " already downloaded and valid, won't redownload");
                            Global.fileOverrides[id] = path;
                        } else {
                            info("File " + cleanName + " already downloaded but hash doesn't match, will redownload.");
                        }
                    } else {
                        info("File " + cleanName + " not downloaded or imported, will download.");
                    }
                }

                if (Directory.Exists(Reference.path_hencore)) Directory.Delete(Reference.path_hencore, true);
                if (Directory.Exists(Reference.path_psvimgtools)) Directory.Delete(Reference.path_psvimgtools, true);
            }

            if (Directory.Exists(txtQCMA.Text + "\\APP\\" + AID + "\\PCSG90096\\")) {
                if (MessageBox.Show("You must remove the existing bittersmile backup from your QCMA directory. If you want to keep it, move it now. Delete?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    FileSystem.DeleteDirectory(txtQCMA.Text + "\\APP\\" + txtAID.Text + "\\PCSG90096\\", DeleteDirectoryOption.DeleteAllContents);
                } else {
                    throw new IOException("Directory Already Exists");
                }
            }

            info("Generating working directories...");
            if (FileSystem.FileExists(Reference.fpath_pkg2zip)) FileSystem.DeleteFile(Reference.fpath_pkg2zip);
            Directory.CreateDirectory(Reference.path_data);
            Directory.CreateDirectory(Reference.path_hencore);
            Directory.CreateDirectory(Reference.path_psvimgtools);
            Directory.CreateDirectory(Reference.path_downloads);
            incrementProgress();
        }

        private void downloadFiles() {

            for (int id = 0; id < 4; id++) {
                string cleanName = Reference.raws[id].Replace('/', '\\').Split('\\').Last();
                if (Global.fileOverrides[id] != null && Global.fileOverrides[id] != "") {
                    if (Global.fileOverrides[id] == Reference.raws[id]) info("File " + cleanName + " in correct location, skipping");
                    else {
                        info("Importing " + cleanName);
                        FileSystem.CopyFile(Global.fileOverrides[id], Reference.raws[id], true);
                        info("      Done!");
                    }
                } else {
                    Utility.DownloadFile(this, Reference.downloads[id], Reference.raws[id]);
                }
                incrementProgress();

                if (id != 3) Utility.ExtractFile(this, true, Reference.raws[id], Reference.paths[id]);
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
                    txtAID.Enabled = state;
                    txtQCMA.Enabled = state;
                    btnBrowseQCMA.Enabled = state;
                    barProgress.Value = 0;
                }));
            } else {
                btnStart.Enabled = state;
                txtAID.Enabled = state;
                txtQCMA.Enabled = state;
                btnBrowseQCMA.Enabled = state;
                barProgress.Value = 0;
            }
        }
        

        private void lblHowToAID_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            FormAID frmAid = new FormAID();
            frmAid.ShowDialog();
        }

        private void txtAID_TextChanged(object sender, EventArgs e) {
            VerifyUserInfo();
        }

        private void btnStart_Click(object sender, EventArgs e) {
            toggleControls(false);

            //run code on new thread to keep UI responsive
            Task.Factory.StartNew(new Action(() => {
                
                try {
                    generateDirectories(txtAID.Text);
                    downloadFiles();
                } catch (Exception ex) {
                    //MessageBox.Show(ex.Message);
                    toggleControls(true);
                    return;
                }
                

                try {
                    info("Extracting bittersmile demo with pkg2zip...");
                    ProcessStartInfo psi = new ProcessStartInfo();
                    psi.WorkingDirectory = Reference.path_downloads;
                    psi.Arguments = "-x bittersmile.pkg";
                    psi.FileName = Reference.fpath_pkg2zip;
                    Process process = Process.Start(psi);
                    process.WaitForExit();
                    info("      Done!");
                    incrementProgress();
                } catch (FileNotFoundException) {
                    MessageBox.Show("Files that were downloaded seem to have disappeared. Please relaunch the application and avoid touching the application directory.");
                    toggleControls(true);
                    return;
                }

                if (cbxTrim.Checked) {
                    info("Trimming excess content from bitter smile demo...");
                    string path = Reference.path_downloads + "app\\PCSG90096\\";
                    FileSystem.DeleteFile(path + "resource\\movie\\Opening.mp4");
                    foreach (string k in FileSystem.GetFiles(path + "resource\\sound\\bgm\\")) FileSystem.DeleteFile(k);
                    FileSystem.DeleteDirectory(path + "resource\\sound\\voice\\01\\", DeleteDirectoryOption.DeleteAllContents);
                    FileSystem.DeleteDirectory(path + "resource\\sound\\se\\", DeleteDirectoryOption.DeleteAllContents);
                    FileSystem.DeleteDirectory(path + "resource\\image\\bg\\", DeleteDirectoryOption.DeleteAllContents);
                    FileSystem.DeleteDirectory(path + "resource\\image\\tachie\\", DeleteDirectoryOption.DeleteAllContents);
                    info("      Done!");
                }

                try {
                    foreach (string k in FileSystem.GetFiles(Reference.path_downloads + "app\\PCSG90096\\")) {
                        info("Moving " + k.Split('\\').Last() + " to h-encore working directory...");
                        FileSystem.MoveFile(k, Reference.path_hencore + "\\h-encore\\app\\ux0_temp_game_PCSG90096_app_PCSG90096\\" + k.Split('\\').Last());
                    }
                } catch (DirectoryNotFoundException ex) {
                    MessageBox.Show("Directories that were created seem to have disappeared. Please relaunch the application and avoid touching the application directory.");
                    toggleControls(true);
                    return;
                } catch (UnauthorizedAccessException ex) {
                    MessageBox.Show("The application doesn't have write access to the directory it was installed in. Please move it to a directory you are own of, or rerun the application as Administrator.");
                    toggleControls(true);
                    return;
                } catch (IOException ex) {
                    MessageBox.Show("Something went wrong:\r\n\r\n" + ex.Message);
                    toggleControls(true);
                    return;
                }

                try {
                    foreach (string k in FileSystem.GetDirectories(Reference.path_downloads + "app\\PCSG90096\\")) {
                        info("Moving " + k.Split('\\').Last() + " to h-encore working directory...");
                        FileSystem.MoveDirectory(k, Reference.path_hencore + "\\h-encore\\app\\ux0_temp_game_PCSG90096_app_PCSG90096\\" + k.Split('\\').Last());
                    }
                } catch (DirectoryNotFoundException ex) {
                    MessageBox.Show("Directories that were created seem to have disappeared. Please relaunch the application and avoid touching the application directory.");
                    toggleControls(true);
                    return;
                } catch (UnauthorizedAccessException ex) {
                    MessageBox.Show("The application doesn't have write access to the directory it was installed in. Please move it to a directory you are own of, or rerun the application as Administrator.");
                    toggleControls(true);
                    return;
                } catch (IOException ex) {
                    MessageBox.Show("Something went wrong:\r\n\r\n" + ex.Message);
                    toggleControls(true);
                    return;
                }

                incrementProgress();

                try {
                    info("Moving license file...");
                    FileSystem.MoveFile(Reference.path_hencore + "\\h-encore\\app\\ux0_temp_game_PCSG90096_app_PCSG90096\\sce_sys\\package\\temp.bin", Reference.path_hencore + "\\h-encore\\license\\ux0_temp_game_PCSG90096_license_app_PCSG90096\\6488b73b912a753a492e2714e9b38bc7.rif");
                    info("      Done!");
                    incrementProgress();
                } catch (DirectoryNotFoundException ex) {
                    MessageBox.Show("Directories that were created seem to have disappeared. Please relaunch the application and avoid touching the application directory.");
                    toggleControls(true);
                    return;
                } catch (UnauthorizedAccessException ex) {
                    MessageBox.Show("The application doesn't have write access to the directory it was installed in. Please move it to a directory you are own of, or rerun the application as Administrator.");
                    toggleControls(true);
                    return;
                } catch (IOException ex) {
                    MessageBox.Show("Something went wrong:\r\n\r\n" + ex.Message);
                    toggleControls(true);
                    return;
                }

                string encKey;

                try {
                    info("Getting CMA encryption key using AID " + txtAID.Text);
                    encKey = Utility.GetEncKey(txtAID.Text);
                    if (encKey.Length != 64) return;
                    info("Got CMA encryption key " + encKey);
                    incrementProgress();
                } catch (Exception) {
                    toggleControls(true);
                    return;
                }
                
                try {
                    PackageHencore(encKey);
                } catch (Exception) {
                    toggleControls(true);
                    return;
                }

                try {
                    info("Moving h-encore files to QCMA APP directory...\r\n");
                    FileSystem.MoveDirectory(Reference.path_hencore + "h-encore\\PCSG90096\\", txtQCMA.Text + "\\APP\\" + txtAID.Text + "\\PCSG90096\\");
                    incrementProgress();
                    info("auto h-encore Done!!");
                } catch (DirectoryNotFoundException ex) {
                    MessageBox.Show("Your QCMA directory disappeared! Make sure you specified the correct directory and that it wasn't changed or deleted!");
                    toggleControls(true);
                    return;
                } catch (UnauthorizedAccessException ex) {
                    MessageBox.Show("The application doesn't have write access to your specified QCMA directory. Change it in QCMA settings to a directory you own, run this application as administrator, or disable read-only mode on the QCMA directory.");
                    toggleControls(true);
                    return;
                } catch (IOException ex) {
                    MessageBox.Show("Something went wrong:\r\n\r\n" + ex.Message);
                    toggleControls(true);
                    return;
                }

                Invoke(new Action(() => MessageBox.Show("To finish your h-encore installation:\r\n"
                    + "1. Right click the QCMA icon in task tray and select refresh database\r\n"
                    + "2. Connect your PS Vita to your PC using USB\r\n"
                    + "3. Open Content Manager on your PS Vita and select Copy Content\r\n"
                    + "     If it says you need to update your firmware, turn off Wifi on your Vita and restart the Vita\r\n"
                    + "4. In Content Manager, choose PC -> PS Vita System\r\n"
                    + "5. Select Applications\r\n"
                    + "6. Select PS Vita\r\n"
                    + "7. Select h-encore and hit Copy\r\n"
                    + "8. Run the h-encore app from the Live Area\r\n"
                    + "     If it crashes the first time, try restarting your Vita and launching the bubble again\r\n\r\n"
                    + "Done!")));

                toggleControls(true);
            }));
            
        }

        public void incrementProgress() {
            if (InvokeRequired) Invoke(new Action(() => barProgress.Value++));
            else barProgress.Value++;
        }

        public void info(string message) {
            if (InvokeRequired) Invoke(new Action(() => txtLog.AppendText("[" + DateTime.Now.ToLongTimeString() + "] " + message + "\r\n")));
            else txtLog.AppendText("[" + DateTime.Now.ToLongTimeString() + "] " + message + "\r\n");

        }

        private void btnBrowseQCMA_Click(object sender, EventArgs e) {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "Locate your PS Vita/APP folder (find it in QCMA settings)";
            dialog.ShowDialog();
            txtQCMA.Text = dialog.SelectedPath;
        }

        private void txtQCMA_TextChanged(object sender, EventArgs e) {
            VerifyUserInfo();
        }

        private void btnImport_Click(object sender, EventArgs e) {
            FormFiles frm = new FormFiles();
            frm.ShowDialog();
        }
    }
}

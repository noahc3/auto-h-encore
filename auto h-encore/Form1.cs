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

        private static string[] imports = new string[4];
        private static bool[] existingFiles = new bool[4];


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
                
            } else {
                using (MD5 md5 = MD5.Create()) {
                    if (FileSystem.FileExists(Reference.path_pkg2zip + "bittersmile.pkg")) {
                        if (imports[3] != null && imports[3] != "") {
                            info("Deleting existing bittersmile since an import is selected...");
                            FileSystem.DeleteFile(Reference.path_pkg2zip + "bittersmile.pkg");
                        } else {
                            using (FileStream stream = File.OpenRead(Reference.path_pkg2zip + "bittersmile.pkg")) {
                                if (BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToLower() == Reference.hash_bittersmile) {
                                    info("Bittersmile already downloaded and checksum OK");
                                    stream.Close();
                                    FileSystem.MoveFile(Reference.path_pkg2zip + "bittersmile.pkg", Reference.path_downloads + "bittersmile.pkg");
                                    existingFiles[3] = true;
                                } else {
                                    info("Existing bittersmile pkg hash mismatch, deleting...");
                                    stream.Close();
                                    FileSystem.DeleteFile(Reference.path_pkg2zip + "bittersmile.pkg");
                                }
                            }
                        }
                    }
                    if (FileSystem.FileExists(Reference.path_downloads + "hencore.zip")) {
                        if (imports[0] != null && imports[0] != "") {
                            info("Deleting existing h-encore since an import is selected...");
                            FileSystem.DeleteFile(Reference.path_downloads + "hencore.zip");
                        } else {
                            using (FileStream stream = File.OpenRead(Reference.path_downloads + "hencore.zip")) {
                                if (BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToLower() == Reference.hash_hencore) {
                                    info("h-encore already downloaded and checksum OK");
                                    existingFiles[0] = true;
                                } else {
                                    info("Existing h-encore.zip hash mismatch, deleting...");
                                    stream.Close();
                                    FileSystem.DeleteFile(Reference.path_downloads + "hencore.zip");
                                }
                            }
                        }
                    }
                    if (FileSystem.FileExists(Reference.path_downloads + "pkg2zip.zip")) {
                        if (imports[1] != null && imports[1] != "") {
                            info("Deleting existing pkg2zip since an import is selected...");
                            FileSystem.DeleteFile(Reference.path_downloads + "pkg2zip.zip");
                        } else {
                            using (FileStream stream = File.OpenRead(Reference.path_downloads + "pkg2zip.zip")) {
                                if (BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToLower() == Reference.hash_pkg2zip) {
                                    info("pkg2zip already downloaded and checksum OK");
                                    existingFiles[1] = true;
                                } else {
                                    info("Existing pkg2zip.zip hash mismatch, deleting...");
                                    stream.Close();
                                    FileSystem.DeleteFile(Reference.path_downloads + "pkg2zip.zip");
                                }
                            }
                        }
                    }
                    if (FileSystem.FileExists(Reference.path_downloads + "psvimgtools.zip")) {
                        if (imports[2] != null && imports[2] != "") {
                            info("Deleting existing psvimgtools since an import is selected...");
                            FileSystem.DeleteFile(Reference.path_downloads + "psvimgtools.zip");
                        } else {
                            using (FileStream stream = File.OpenRead(Reference.path_downloads + "psvimgtools.zip")) {
                                if (BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToLower() == Reference.hash_psvimgtools) {
                                    info("psvimgtools already downloaded and checksum OK");
                                    existingFiles[2] = true;
                                } else {
                                    info("Existing psvimgtools.zip hash mismatch, deleting...");
                                    stream.Close();
                                    FileSystem.DeleteFile(Reference.path_downloads + "psvimgtools.zip");
                                }
                            }
                        }
                    }
                    
                }

                if (Directory.Exists(Reference.path_hencore)) Directory.Delete(Reference.path_hencore, true);
                if (Directory.Exists(Reference.path_pkg2zip)) Directory.Delete(Reference.path_pkg2zip, true);
                if (Directory.Exists(Reference.path_psvimgtools)) Directory.Delete(Reference.path_psvimgtools, true);
            }

            if (Directory.Exists(txtQCMA.Text + "\\APP\\" + AID + "\\PCSG90096\\")) {
                if (MessageBox.Show("You must remove the existing bittersmile backup from your QCMA directory. Delete?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    Directory.Delete(txtQCMA.Text + "\\APP\\" + txtAID.Text + "\\PCSG90096\\", true);
                } else {
                    throw new IOException("Directory Already Exists");
                }
            }

            info("Generating working directories...");
            Directory.CreateDirectory(Reference.path_data);
            Directory.CreateDirectory(Reference.path_hencore);
            Directory.CreateDirectory(Reference.path_psvimgtools);
            Directory.CreateDirectory(Reference.path_pkg2zip);
            Directory.CreateDirectory(Reference.path_downloads);
            incrementProgress();
        }

        private void downloadFiles() {
            if (!existingFiles[0]) {
                if (imports[0] != null && imports[0] != "") {
                    Utility.ImportFile(this, imports[0], Reference.path_downloads + "hencore.zip");
                } else {
                    Utility.DownloadFile(this, Reference.url_hencore, Reference.path_downloads + "hencore.zip");
                }
            }
            incrementProgress();
            Utility.ExtractFile(this, true, Reference.path_downloads + "hencore.zip", Reference.path_hencore);

            if (!existingFiles[1]) {
                if (imports[1] != null && imports[1] != "") {
                    Utility.ImportFile(this, imports[1], Reference.path_downloads + "pkg2zip.zip");
                } else {
                    Utility.DownloadFile(this, Reference.url_pkg2zip, Reference.path_downloads + "pkg2zip.zip");
                }
            }
            incrementProgress();
            Utility.ExtractFile(this, true, Reference.path_downloads + "pkg2zip.zip", Reference.path_pkg2zip);

            if (!existingFiles[2]) {
                if (imports[2] != null && imports[2] != "") {
                    Utility.ImportFile(this, imports[2], Reference.path_downloads + "psvimgtools.zip");
                } else {
                    Utility.DownloadFile(this, Reference.url_psvimgtools, Reference.path_downloads + "psvimgtools.zip");
                }
            }
            incrementProgress();
            Utility.ExtractFile(this, true, Reference.path_downloads + "psvimgtools.zip", Reference.path_psvimgtools);

            if (!existingFiles[3]) {
                if (imports[3] != null && imports[3] != "") {
                    Utility.ImportFile(this, imports[3], Reference.path_downloads + "bittersmile.pkg");
                } else {
                    Utility.DownloadFile(this, Reference.url_bittersmile, Reference.path_downloads + "bittersmile.pkg");
                }
            }
            incrementProgress();

            existingFiles = new bool[4];
            
            
           
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
                    //move the bittersmile pkg to pkg2zip working directory because pkg2zip doesnt support special characters
                    info("Extracting bittersmile demo with pkg2zip...");
                    FileSystem.MoveFile(Reference.path_downloads + "bittersmile.pkg", Reference.path_pkg2zip + "bittersmile.pkg");
                    ProcessStartInfo psi = new ProcessStartInfo();
                    psi.WorkingDirectory = Reference.path_pkg2zip;
                    psi.Arguments = "-x bittersmile.pkg";
                    psi.FileName = Reference.path_pkg2zip + "pkg2zip.exe";
                    Process process = Process.Start(psi);
                    process.WaitForExit();
                    info("      Done!");
                    incrementProgress();
                } catch (FileNotFoundException) {
                    MessageBox.Show("Files that were downloaded seem to have disappeared. Please relaunch the application and avoid touching the application directory.");
                    toggleControls(true);
                    return;
                }

                try {
                    foreach (string k in FileSystem.GetFiles(Reference.path_pkg2zip + "app\\PCSG90096\\")) {
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
                    foreach (string k in FileSystem.GetDirectories(Reference.path_pkg2zip + "app\\PCSG90096\\")) {
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
                    + "    If it says you need to update your firmware, turn off Wifi on your Vita and restart the Vita\r\n"
                    + "4. In Content Manager, choose PC -> PS Vita System\r\n"
                    + "5. Select Applications\r\n"
                    + "6. Select PS Vita\r\n"
                    + "7. Select h-encore and hit Copy\r\n"
                    + "8. Run the h-encore app from the Live Area\r\n"
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
            FormFiles frm = new FormFiles(imports);
            frm.ShowDialog();
            if (frm.result != null) {
                imports = frm.result;
            }
        }
    }
}

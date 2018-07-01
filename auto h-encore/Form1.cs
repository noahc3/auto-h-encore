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
using System.Diagnostics;

namespace auto_h_encore {
    public partial class Form1 : Form {

        WebClient web = new WebClient();
        HttpClient http = new HttpClient();

        public Form1() {
            InitializeComponent();

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            lblInfo.Text = "Before running: \r\n1. Install QCMA\r\n2. Open QCMA\r\n3. Connect your Vita to your PC using USB and launch Content Manager\r\n4. Select Copy Content to connect your Vita to your PC\r\n   If your Vita says you need to update, turn off Wifi and restart the console\r\n\r\nEverything is now ready. Enter the above information correctly to enable the start button\r\n\r\nIf the button does not enable, make sure your AID is 16 characters long and that you've selected the correct PS Vita folder (it should have an APP directory in it)";
        }

        private void VerifyUserInfo() {
            if (txtAID.Text.Length == 16 && Directory.Exists(txtQCMA.Text + "\\APP\\")) btnStart.Enabled = true;
            else btnStart.Enabled = false;
        }

        private void generateDirectories() {
            info("Generating working directories...");
            Directory.CreateDirectory(Reference.path_data);
            Directory.CreateDirectory(Reference.path_hencore);
            Directory.CreateDirectory(Reference.path_psvimgtools);
            Directory.CreateDirectory(Reference.path_pkg2zip);
            Directory.CreateDirectory(Reference.path_downloads);
            incrementProgress();
        }

        private void downloadFiles() {
            info("Downloading h-encore...");
            web.DownloadFile(Reference.url_hencore, Reference.path_downloads + "hencore.zip");
            info("      Done!");
            incrementProgress();
            info("Extracting h-encore...");
            ZipFile.ExtractToDirectory(Reference.path_downloads + "hencore.zip", Reference.path_hencore);
            info("      Done!");
            incrementProgress();

            info("Downloading psvimgtools...");
            web.DownloadFile(Reference.url_psvimgtools, Reference.path_downloads + "psvimgtools.zip");
            info("  Done!");
            incrementProgress();
            info("Extracting psvimgtools...");
            ZipFile.ExtractToDirectory(Reference.path_downloads + "psvimgtools.zip", Reference.path_psvimgtools);
            info("      Done!");
            incrementProgress();

            info("Downloading pkg2zip...");
            web.DownloadFile(Reference.url_pkg2zip, Reference.path_downloads + "pkg2zip.zip");
            info("      Done!");
            incrementProgress();
            info("Extracting pkg2zip...");
            ZipFile.ExtractToDirectory(Reference.path_downloads + "pkg2zip.zip", Reference.path_pkg2zip);
            info("      Done!");
            incrementProgress();

            info("Downloading bittersmile demo (this might take a while)...");
            web.DownloadFile(Reference.url_bittersmile, Reference.path_downloads + "bittersmile.pkg");
            info("      Done!");
            incrementProgress();
        }

        private void PackageHencore(string encKey) {

            ProcessStartInfo psi = new ProcessStartInfo();
            psi.WorkingDirectory = Reference.path_hencore + "h-encore\\";
            psi.FileName = Reference.path_psvimgtools + "psvimg-create.exe";

            info("Packaging h-encore app using psvimgtools...");
            psi.Arguments = "-n app -K " + encKey + " app PCSG90096/app";
            Process process = Process.Start(psi);
            process.WaitForExit();
            info("      Done!");
            incrementProgress();

            info("Packaging h-encore appmeta using psvimgtools...");
            psi.Arguments = "-n appmeta -K " + encKey + " appmeta PCSG90096/appmeta";
            process = Process.Start(psi);
            process.WaitForExit();
            info("      Done!");
            incrementProgress();

            info("Packaging h-encore license using psvimgtools...");
            psi.Arguments = "-n license -K " + encKey + " license PCSG90096/license";
            process = Process.Start(psi);
            process.WaitForExit();
            info("      Done!");
            incrementProgress();

            info("Packaging h-encore savedata using psvimgtools...");
            psi.Arguments = "-n savedata -K " + encKey + " savedata PCSG90096/savedata";
            process = Process.Start(psi);
            process.WaitForExit();
            info("      Done!");
            incrementProgress();
        }

        private string GetEncKey(string aid) {
            string page = http.GetStringAsync(Reference.url_cma + aid).Result;
            return page.Substring(page.Length - 65, 64);
        }

        private void lblHowToAID_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            FormAID frmAid = new FormAID();
            frmAid.ShowDialog();
        }

        private void txtAID_TextChanged(object sender, EventArgs e) {
            VerifyUserInfo();
        }

        private void btnStart_Click(object sender, EventArgs e) {
            btnStart.Enabled = false;
            txtAID.Enabled = false;
            txtQCMA.Enabled = false;

            //run code on new thread to keep UI responsive
            Task.Factory.StartNew(new Action(() => {

                
                generateDirectories();
                downloadFiles();
                
                info("Extracting bittersmile demo with pkg2zip...");
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.WorkingDirectory = Reference.path_pkg2zip;
                psi.Arguments = "-x \"" + Reference.path_downloads + "bittersmile.pkg\"";
                psi.FileName = Reference.path_pkg2zip + "pkg2zip.exe";
                Process process = Process.Start(psi);
                process.WaitForExit();
                info("      Done!");
                incrementProgress();

                foreach (string k in Directory.EnumerateFiles(Reference.path_pkg2zip + "app\\PCSG90096\\")) {
                    info("Moving " + k.Split('\\').Last() + " to h-encore working directory...");
                    File.Move(k, Reference.path_hencore + "\\h-encore\\app\\ux0_temp_game_PCSG90096_app_PCSG90096\\" + k.Split('\\').Last());
                }

                foreach(string k in Directory.EnumerateDirectories(Reference.path_pkg2zip + "app\\PCSG90096\\")) {
                    info("Moving " + k.Split('\\').Last() + " to h-encore working directory...");
                    Directory.Move(k, Reference.path_hencore + "\\h-encore\\app\\ux0_temp_game_PCSG90096_app_PCSG90096\\" + k.Split('\\').Last());
                }

                incrementProgress();

                info("Moving license file...");
                File.Move(Reference.path_hencore + "\\h-encore\\app\\ux0_temp_game_PCSG90096_app_PCSG90096\\sce_sys\\package\\temp.bin", Reference.path_hencore + "\\h-encore\\license\\ux0_temp_game_PCSG90096_license_app_PCSG90096\\6488b73b912a753a492e2714e9b38bc7.rif");
                info("      Done!");
                incrementProgress();

                info("Getting CMA encryption key using AID " + txtAID.Text);
                string encKey = GetEncKey(txtAID.Text);
                info("Got CMA key " + encKey);
                incrementProgress();

                PackageHencore(encKey);

                info("Moving h-encore files to QCMA APP directory...\r\n");
                Directory.Move(Reference.path_hencore + "h-encore\\PCSG90096\\", txtQCMA.Text + "\\APP\\" + txtAID.Text + "\\PCSG90096\\");
                incrementProgress();
                info("auto h-encore Done!!");

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
            }));
            
        }

        private void incrementProgress() {
            if (InvokeRequired) Invoke(new Action(() => barProgress.Value++));
            else barProgress.Value++;
        }

        private void info(string message) {
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
    }
}

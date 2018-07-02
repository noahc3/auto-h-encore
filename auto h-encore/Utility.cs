using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.VisualBasic.FileIO;

namespace auto_h_encore {
    public static class Utility {
        private static WebClient web = new WebClient();
        private static HttpClient http = new HttpClient();

        public static string GetEncKey(string aid) {
            try {
                string page = http.GetStringAsync(Reference.url_cma + aid).Result;
                return page.Substring(page.Length - 65, 64);
            } catch (Exception) {
                MessageBox.Show("Failed to get the CMA encryption key");
                return "";
            }
        }

        public static void DownloadFile(Form1 form, bool incrementProgress, string url, string output) {
            while (true)
                try {
                    form.info("Downloading " + output.Replace('/', '\\').Split('\\').Last());
                    web.DownloadFile(url, output);
                    form.info("      Done!");
                    if (incrementProgress) form.incrementProgress();
                    return;
                } catch (WebException ex) {
                    if (MessageBox.Show("Failed to download file " + url + "\r\n\r\nMake sure your internet is connected and/or retry. If it still doesn't work, create an issue on the Github issue tracker.", "Error", MessageBoxButtons.RetryCancel) == DialogResult.Cancel)
                        throw ex;
                }
        }

        public static void ExtractFile(Form1 form, bool incrementProgress, string filePath, string outputDirectory) {
            try {
                form.info("Extracting " + filePath.Replace('/', '\\').Split('\\').Last());
                ZipFile.ExtractToDirectory(filePath, outputDirectory);
                form.info("      Done!");
                if (incrementProgress) form.incrementProgress();
                return;
            } catch (DirectoryNotFoundException ex) {
                MessageBox.Show("Directories that were created seem to have disappeared. Please relaunch the application and avoid touching the application directory.");
                throw ex;
            } catch (UnauthorizedAccessException ex) {
                MessageBox.Show("The application doesn't have write access to the directory it was installed in. Please move it to a directory you are own of, or rerun the application as Administrator.");
                throw ex;
            } catch (FileNotFoundException ex) {
                MessageBox.Show("Files that were downloaded seem to have disappeared. Please relaunch the application and avoid touching the application directory.");
                throw ex;
            } catch (IOException ex) {
                MessageBox.Show("Something went wrong:\r\n\r\n" + ex.Message);
                throw ex;
            } catch (InvalidDataException ex) {
                MessageBox.Show("A download was corrupt, please rerun the application and make sure your network is stable.");
                throw ex;
            }

        }

        public static void PackageFiles(Form1 form, bool incrementProgress, string workingDirectory, string encryptionKey, string type) {
            try {
                form.info("Packaging h-encore " + type + " using psvimgtools...");
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.WorkingDirectory = workingDirectory;
                psi.FileName = Reference.path_psvimgtools + "psvimg-create.exe";
                psi.Arguments = "-n " + type + " -K " + encryptionKey + " " + type + " PCSG90096/" + type;
                Process process = Process.Start(psi);
                process.WaitForExit();
                form.info("      Done!");
                if (incrementProgress) form.incrementProgress();
                return;
            } catch (FileNotFoundException ex) {
                MessageBox.Show("Files that were downloaded seem to have disappeared. Please relaunch the application and avoid touching the application directory.");
                throw ex;
            }
        }

        public static void ImportFile(Form1 form, bool incrementProgress, string source, string dest) {
            try {
                form.info("Importing file " + source.Replace('/', '\\').Split('\\').Last());
                FileSystem.CopyFile(source, dest);
                form.info("        Done!");
                if (incrementProgress) form.incrementProgress();
            } catch (DirectoryNotFoundException ex) {
                MessageBox.Show("Directories that were created seem to have disappeared. Please relaunch the application and avoid touching the application directory.");
                return;
            } catch (UnauthorizedAccessException ex) {
                MessageBox.Show("The application doesn't have write access to the directory it was installed in. Please move it to a directory you are own of, or rerun the application as Administrator.");
                return;
            } catch (IOException ex) {
                MessageBox.Show("Something went wrong:\r\n\r\n" + ex.Message);
                return;
            }

        }

        public static string BrowseFile(string title, string extension, string restrictions) {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = restrictions;
            dialog.CheckFileExists = true;
            dialog.CheckPathExists = true;
            dialog.DefaultExt = extension;
            dialog.Multiselect = false;
            dialog.Title = title;
            dialog.ShowDialog();
            return dialog.FileName;
        }
    }
}

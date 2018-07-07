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
using System.Security.Cryptography;

namespace auto_h_encore {
    public static class Utility {
        private static WebClient web = new WebClient();
        private static HttpClient http = new HttpClient();

        public static string GetEncKey(string aid) {
            try {
                string page = http.GetStringAsync(Reference.url_cma + aid).Result;
                return page.Substring(page.Length - 65, 64);
            } catch (Exception ex) {
                ErrorHandling.HandleException("0106", ex);
            }
            return "";
        }

        public static void DownloadFile(Form1 form, string url, string output) {
            while (true)
                try {
                    form.info(string.Format(Language.MountedLanguage["log_Downloading"], output.Replace('/', '\\').Split('\\').Last()));
                    web.DownloadFile(url, output);
                    form.info(Language.MountedLanguage["log_Done"]);
                    return;
                } catch (WebException ex) {
                    //gets special handling to allow retry without reset
                    if (MessageBox.Show(string.Format(Language.MountedLanguage["error_Redownload"], url), Language.MountedLanguage["title_Error"], MessageBoxButtons.RetryCancel) == DialogResult.Cancel)
                        throw ex;
                } catch (Exception ex) {
                    ErrorHandling.HandleException("0104", ex);
                }
        }

        public static void ExtractFile(Form1 form, bool incrementProgress, string filePath, string outputDirectory) {
            try {
                form.info(string.Format(Language.MountedLanguage["log_Extracting"], filePath.Replace('/', '\\').Split('\\').Last()));
                ZipFile.ExtractToDirectory(filePath, outputDirectory);
                form.info(Language.MountedLanguage["log_Done"]);
                if (incrementProgress) form.incrementProgress();
                return;
            } catch (Exception ex) {
                ErrorHandling.HandleException("0103", ex);
            }

        }

        public static void PackageFiles(Form1 form, bool incrementProgress, string workingDirectory, string encryptionKey, string type) {
            try {
                form.info(string.Format(Language.MountedLanguage["log_Packaging"], type));
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.WorkingDirectory = workingDirectory;
                psi.FileName = Reference.path_psvimgtools + "psvimg-create.exe";
                psi.Arguments = "-n " + type + " -K " + encryptionKey + " " + type + " PCSG90096/" + type;
                Process process = Process.Start(psi);
                process.WaitForExit();
                form.info(Language.MountedLanguage["log_Done"]);
                form.incrementProgress();
                return;
            } catch (Exception ex) {
                ErrorHandling.HandleException("0102", ex);
            }
        }

        public static string BrowseFile(string title, string extension, string restrictions) {
            try {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = restrictions;
                dialog.CheckFileExists = true;
                dialog.CheckPathExists = true;
                dialog.DefaultExt = extension;
                dialog.Multiselect = false;
                dialog.Title = title;
                dialog.ShowDialog();
                return dialog.FileName;
            } catch (Exception ex) {
                ErrorHandling.HandleException("0101", ex);
            }

            return "";
        }

        public static string MD5Checksum(string path) {
            try {
                using (MD5 md5 = MD5.Create()) {
                    using (FileStream stream = File.OpenRead(path)) {
                        return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToLower();
                    }
                }
            } catch (Exception ex) {
                ErrorHandling.HandleException("0100", ex);
            }

            return "";

        }

        public static string FindQCMA(Form1 form) {
            form.info("Searching for QCMA...");
            //if (FileSystem.FileExists("C:\\Program Files\\Qcma\\qcma.exe")) {
            //    form.info("Found QCMA");
            //    return "C:\\Program Files\\Qcma\\qcma.exe";
            //}
            //if (FileSystem.FileExists("C:\\Program Files (x86)\\Qcma\\qcma.exe")) {
            //    form.info("Found QCMA");
            //    return "C:\\Program Files (x86)\\Qcma\\qcma.exe";
            //}
            form.info("QCMA not found, will download.");
            return "";
        }
    }
}

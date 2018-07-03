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
            } catch (Exception) {
                //10020100
                ErrorHandling.ShowError("10020100", "Failed to get the CMA encryption key. Make sure your internet is connected and/or retry.");
                return "";
            }
        }

        public static void DownloadFile(Form1 form, string url, string output) {
            while (true)
                try {
                    form.info("Downloading " + output.Replace('/', '\\').Split('\\').Last());
                    web.DownloadFile(url, output);
                    form.info("      Done!");
                    return;
                } catch (WebException ex) {
                    //01010100
                    if (MessageBox.Show("Error 10010101\r\n\r\nFailed to download file " + url + "\r\n\r\nMake sure your internet is connected and/or retry. If it still doesn't work, create an issue on the Github issue tracker.", "Error", MessageBoxButtons.RetryCancel) == DialogResult.Cancel)
                        throw ex;
                } catch (Exception ex) {
                    //FFFF0108
                    ErrorHandling.ShowError("FFFF0108", "Unexpected Exception: " + ex.Message);
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
                //20010102
                ErrorHandling.ShowError("20010102", "Directories that were created seem to have disappeared. Please retry and avoid touching the application directory.");
                throw ex;
            } catch (UnauthorizedAccessException ex) {
                //20020103
                ErrorHandling.ShowError("20020103", "The application doesn't have write access to the directory it was installed in. Try rerunning the application as administrator.");
                throw ex;
            } catch (FileNotFoundException ex) {
                //20030104
                ErrorHandling.ShowError("20030104", "Files that were created seem to have disappeared. Please retry and avoid touching the application directory.");
                throw ex;
            } catch (InvalidDataException ex) {
                //20040105
                ErrorHandling.ShowError("20040105", "A download is corrupt. Make sure your network is stable, then retry.");
                throw ex;
            } catch (IOException ex) {
                //20FF0106
                ErrorHandling.ShowError("20FF0106", "Unexpected Exception: " + ex.Message);
                throw ex;
            } catch (Exception ex) {
                //FFFF0107
                ErrorHandling.ShowError("FFFF0107", "Unexpected Exception: " + ex.Message);
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
                form.incrementProgress();
                return;
            } catch (FileNotFoundException ex) {
                //20030109
                ErrorHandling.ShowError("20030109", "Files that were created seem to have disappeared. Please retry and avoid touching the application directory.");
                throw ex;
            } catch (Exception ex) {
                //FFFF010A
                ErrorHandling.ShowError("FFFF010A", "Unexpected Exception: " + ex.Message);
                throw ex;
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
                //FFFF010B
                ErrorHandling.ShowError("FFFF010B", "Unexpected Exception: " + ex.Message);
                throw ex;
            }            
        }

        public static string MD5Checksum(string path) {
            try {
                using (MD5 md5 = MD5.Create()) {
                    using (FileStream stream = File.OpenRead(path)) {
                        return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToLower();
                    }
                }
            } catch (System.Reflection.TargetInvocationException ex) {
                //3001010C
                ErrorHandling.ShowError("3001010C", "Failed to create MD5 calculator. Please retry.");
                throw ex;
            } catch (DirectoryNotFoundException ex) {
                //2001010D
                ErrorHandling.ShowError("2001010D", "Directories that were created seem to have disappeared. Please retry and avoid touching the application directory.");
                throw ex;
            } catch (UnauthorizedAccessException ex) {
                //2002010E
                ErrorHandling.ShowError("2002010E", "The application doesn't have write access to the directory it was installed in. Try rerunning the application as administrator.");
                throw ex;
            } catch (FileNotFoundException ex) {
                //2003010F
                ErrorHandling.ShowError("2003010F", "Files that were created seem to have disappeared. Please retry and avoid touching the application directory.");
                throw ex;
            } catch (Exception ex) {
                //FFFF0110
                ErrorHandling.ShowError("FFFF0110", "Unexpected Exception: " + ex.Message);
                throw ex;
            }

        }
    }
}

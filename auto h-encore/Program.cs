using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace auto_h_encore {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            if (Language.Languages.Count > 1) {
                if (FileSystem.FileExists(Reference.config_language)) {
                    string[] conf = File.ReadAllLines(Reference.config_language);
                    if (conf.Any() && conf[0].StartsWith("language=")) {
                        int id;
                        if (int.TryParse(conf[0].Replace("language=", ""), out id)) {
                            if (id < Language.Languages.Count) {
                                Language.MountedLanguage = Language.Languages.ElementAt(id).Value;
                                Application.Run(new Form1());
                            } else {
                                Application.Run(new FormLanguage(0));
                            }
                        } else {
                            FileSystem.DeleteFile(Reference.config_language);
                            Application.Run(new FormLanguage(0));
                        }
                    } else {
                        FileSystem.DeleteFile(Reference.config_language);
                        Application.Run(new FormLanguage(0));
                    }
                } else Application.Run(new FormLanguage(0));
            } else {
                Application.Run(new Form1());
            }
        }
    }
}

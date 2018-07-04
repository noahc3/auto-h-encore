using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auto_h_encore {
    public static class Language {

        public static Dictionary<string, Dictionary<string, string>> Languages = new Dictionary<string, Dictionary<string, string>> {
            { "English",  new Dictionary<string, string> {
                { "lbl_ChooseLanguage", "Choose Language:" },
                { "lbl_AID", "Account ID (AID)" },
                { "lbl_QCMADir", "QCMA PS Vita directory" },
                { "lbl_HowToAID", "How do I get this information?" },
                { "lbl_VersionText", "auto h-encore version " },
                { "lbl_Issues", "Issue Tracker" },

                { "status_NoFile", "No file selected, will download." },
                { "status_Invalid", "File path is invalid." },
                { "status_Valid", "File selected and hash matches, will import." },
                { "status_BadHash", "File selected but hash does not match, will download." },
                { "status_Override", "File selected but hash does not match. Hash override enabled, will import." },
                { "status_Calculating", "Calculating file hash..." },

                { "txtblock_BeforeRunning", "Before running: \r\n1. Install QCMA\r\n2. Open QCMA\r\n3. Connect your Vita to your PC using USB and launch Content Manager\r\n4. Select Copy Content to connect your Vita to your PC\r\n   If your Vita says you need to update, turn off Wifi and restart the console\r\n\r\nEverything is now ready. Enter the above information correctly to enable the start button\r\n\r\nIf the start button does not enable, make sure your AID is 16 characters long and that you've selected the correct PS Vita folder (it should have an APP directory in it)."},
                { "txtblock_Import", "If you've already downloaded some or all of the necessary files, and don't want the application to redownload them, you can select the files here for the program to import." },
                { "txtblock_HowToInfo",  "The program should have tried to get this info automatically. If it didn't or you want to verify that it is correct: \r\n\r\n1. Install QCMA\r\n2. Open QCMA\r\n3. Connect your Vita to your PC using USB and launch Content Manager\r\n4. Select Copy Content to connect your Vita to your PC\r\n   If your Vita says you need to update, turn off Wifi and restart the console\r\n5. Right click QCMA in task tray, select settings\r\n6.Copy the directory named Applications / Backups into this application as the PS Vita directory \r\n7. Navigate to the directory you just copied and go into the APP folder\r\n8. Your AID is the name of the folder inside this directory (it should be 16 characters)"},

                { "btn_Import", "I've already downloaded some or all of the files and would like to use them rather than redownload them" },
                { "btn_Ok", "OK" },
                { "btn_Close", "Close" },
                { "btn_Start", "Start" },
                { "btn_Done", "Done" },
                { "btn_Browse", "Browse" },

                { "cbx_Trim", "Trim excess content from bitter smile demo (reduces h-encore app size from ~240MB to ~13MB)" },
                { "cbx_DeleteExisting", "Delete existing files (do this if something went wrong before)" },
                { "cbx_OverrideHashes", "Ignore Mismatch File Hashes" },

                { "browse_QCMA", "Locate your QCMA PS Vita directory (find it in QCMA settings under Applications / Backups)" },
                { "browse_Generic", "Browse for " },

                { "info_Finish",  "To finish your h-encore installation:\r\n"
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
                        + "Done!"},

                { "warn_HashCompat", "Compatibility is not guranteed when using versions of files this application was not designed for. Continue anyways?" },
                { "warn_DeleteExistingBittersmile", "You must remove the existing bittersmile backup from your QCMA directory. If you want to keep it, move it now. Delete?" },

                { "error_WebException", "Failed to download file. Please check your internet connection." },
                { "error_Unknown", "Something went wrong: {0}" },
                { "error_DirectoryNotFoundException", "A directory that was created seem to have disappeared (did they get deleted?) OR a directory failed to extract earlier OR you are using an unsupported file import." },
                { "error_UnauthorizedAccessException", "The application doesn't have write access to the directory it was installed in. Try rerunning the application as administrator." },
                { "error_FileNotFoundException",  "A file that was created seem to have disappeared (did they get deleted?) OR a file failed to extract earlier OR you are using an unsupported file import."},
                { "error_InvalidOperationException",  "A download is corrupt. Make sure your network is stable."},
                { "error_TargetInvocationException", "Failed to create MD5 calculator." },
                { "error_Template", "Error {0} occurred.\r\n\r\n{1}\r\n\r\nPlease retry the process. If you can't solve the issue, please create an issue on the issue tracker with this error code." },
                { "error_Redownload",  "Error 1001-0105\r\n\r\nFailed to download file {0}\r\n\r\nMake sure your internet is connected and/or retry. If it still doesn't work, create an issue on the Github issue tracker."},

                { "log_Done", "        Done!" },
                { "log_WipeFiles", "Deleting old files..." },
                { "log_Import", "File import for file {0} valid." },
                { "log_DownloadValid", "File {0} already downloaded and valid, won't redownload." },
                { "log_DownloadInvalid", "File {0} already downloaded but hash doesn't match, will redownload." },
                { "log_NotDownloaded", "File {0} not downloaded or imported, will download." },
                { "log_WorkingDirs", "Generating working directories..." },
                { "log_CorrectLocation", "File {0} in correct location, skipping." },
                { "log_Importing", "Importing {0}" },
                { "log_Downloading", "Downloading {0}" },
                { "log_Extracting", "Extracting {0}" },
                { "log_ExtractingPKG", "Extracting bittersmile demo with pkg2zip..." },
                { "log_Trimming", "Trimming excess content from bittersmile demo..." },
                { "log_MoveToHencore", "Moving {0} to h-encore working directory..." },
                { "log_MoveLicense", "Moving license file..." },
                { "log_GetCMA", "Getting CMA encryption key using AID {0}" },
                { "log_GotCMA", "Got CMA encryption key {0}" },
                { "log_Packaging", "Packaging h-encore {0} using psvimgtools..." },
                { "log_MoveToQCMA", "Moving h-encore files to QCMA APP directory...\r\n" },
                { "log_Finished", "auto h-encore Finished!!\r\n" },

                { "title_Main", "auto h-encore" },
                { "title_Import", "Import Existing Files" },
                { "title_Warning", "Warning" },
                { "title_Error", "Error" }
            } }
        };

        public static Dictionary<string, string> MountedLanguage = Languages["English"];
    }
}

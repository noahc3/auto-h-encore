using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using System.Net;
using System.Net.Http;
using System.Reflection;

namespace auto_h_encore {
    public static class ErrorHandling {

        /*
            Error code information:

            format: aabbccdd

            where:
                aa is the type (ie. FileSystem)
                bb is the type of exception (ie. UnauthorizedException)
                cc is the file that it occurred in (ie. Utility.cs)
                dd is the location the error occurred in code (what block of code it happened in) makes ctrl+f easy

            10: Network
                01: WebException
                    A file download was interrupted
                02: Ambiguous HTTP Exception
                    An HTTP request likely timed out
            20: FileSystem/IO
                01: DirectoryNotFoundException
                    Directory failed to get created earlier without raising errors (maybe missing from a ZIP file) or it was deleting during runtime
                02: UnauthorizedAccessException
                    The file or directory being written to is readonly or the user doesn't own it.
                03: FileNotFoundException
                    A file failed to get moved/extracted earlier or was deleted during runtime
                04: InvalidDataException
                    A file is probably corrupt
                FF: IOException
                    Generic exception, reason needs investigating
            30: Reflection
                01: TargetInvocationException
                    MD5 calculator failed to generate
            FF: Unknown
                FF: Generic Exception
                    An unexpected exception occurred




            cc:
                01: Utility.cs
                02: Form1.cs
        */

        public static void HandleException(string errorSuffix, Exception ex) {
            //ha ha ha this doesnt seem like good practice
            try {
                throw ex;
            } catch (WebException) {
                ShowError("1001-" + errorSuffix, Language.MountedLanguage["error_WebException"]);
            } catch (HttpRequestException) {
                ShowError("10FF-" + errorSuffix, string.Format(Language.MountedLanguage["error_Unknown"], ex.Message));
            } catch (DirectoryNotFoundException) {
                ShowError("2001-" + errorSuffix, Language.MountedLanguage["error_DirectoryNotFoundException"]);
            } catch (UnauthorizedAccessException) {
                ShowError("2002-" + errorSuffix, Language.MountedLanguage["error_UnauthorizedAccessException"]);
            } catch (FileNotFoundException) {
                ShowError("2003-" + errorSuffix, Language.MountedLanguage["error_FileNotFoundException"]);
            } catch (InvalidDataException) {
                ShowError("2004-" + errorSuffix, Language.MountedLanguage["error_InvalidOperationException"]);
            } catch (IOException) {
                ShowError("20FF-" + errorSuffix, string.Format(Language.MountedLanguage["error_Unknown"], ex.Message));
            } catch (TargetInvocationException) {
                ShowError("3001-" + errorSuffix, Language.MountedLanguage["error_TargetInvocationException"]);
            } catch (Exception) {
                ShowError("FFFF-" + errorSuffix, string.Format(Language.MountedLanguage["error_Unknown"], ex.Message));
            } finally {
                throw ex;
            }
        }

        public static void ShowError(string code, string message) {
            MessageBox.Show(string.Format(Language.MountedLanguage["error_Template"], code, message), Language.MountedLanguage["title_Error"], MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public static void ShowError(string code, string message) {
            MessageBox.Show(
                "Error " + code + " occurred.\r\n\r\n"
                + message + "\r\n\r\n"
                + "If you can't solve the issue, please create an issue on the issue tracker with this error code."
                , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

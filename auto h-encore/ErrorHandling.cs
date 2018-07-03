using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace auto_h_encore {
    public static class ErrorHandling {
        public static void ShowError(string code, string message) {
            MessageBox.Show(
                "Error " + code + " occurred.\r\n\r\n"
                + message + "\r\n\r\n"
                + "If you can't solve the issue, please create an issue on the issue tracker with this error code."
                , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

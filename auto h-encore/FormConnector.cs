using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;
using System.Threading;

namespace auto_h_encore {
    public partial class FormConnector : Form {
        public FormConnector() {
            InitializeComponent();
            lblInstructions.Text = "How do you plan to connect your vita to your PC?";
        }

        private void btnUSB_Click(object sender, EventArgs e) {
            if (btnUSB.Width != 484) {
                btnUSB.Width = 484;
                btnWifi.Visible = false;
                btnUSB.Text = "Next";
                lblInstructions.Text = "Unplug your Vita if it is plugged in and click Next.";
            } else {
                btnUSB.Visible = false;
                if (!Global.QCMA_Installed) {
                    lblInstructions.Text = "Installing USB Driver, please wait...";
                    Task.Factory.StartNew(new Action(() => {
                        Process process = Process.Start(Reference.path_qcma + "driver\\dpscat.exe");
                        process.WaitForExit();
                        ProcessStartInfo psi = new ProcessStartInfo();
                        if (Environment.Is64BitOperatingSystem) psi.FileName = Reference.path_qcma + "driver\\dpinst64.exe";
                        else psi.FileName = Reference.path_qcma + "driver\\dpinst32.exe";
                        psi.Arguments = "/S /SE /SW";
                        process = Process.Start(psi);
                        process.WaitForExit();
                        AfterUSB();
                    }));
                } else AfterUSB();
                
            }
        }

        private void AfterUSB() {

            Process.Start(Global.path_QCMA);

            Action action = new Action(() => {
                lblInstructions.Text = "Connect your PS Vita now.\r\n\r\nIf nothing happens:\r\n1. Launch Content Manager on your PS Vita\r\n2. Select Copy Content\r\n3. If prompted: Select PC and USB\r\n\r\nIf it still doesn't work, try restarting your computer and PS Vita and retry (including the steps above).";
                Task.Factory.StartNew(new Action(() => {
                    string old = (string)Registry.GetValue("HKEY_CURRENT_USER\\Software\\codestation\\qcma", "lastAccountId", "");

                    while ((string)Registry.GetValue("HKEY_CURRENT_USER\\Software\\codestation\\qcma", "lastAccountId", "") == old) {
                        Thread.Sleep(500);
                    }
                    
                    Global.AID = (string)Registry.GetValue("HKEY_CURRENT_USER\\Software\\codestation\\qcma", "lastAccountId", null);
                    Global.QCMAAPPS = (string)Registry.GetValue("HKEY_CURRENT_USER\\Software\\codestation\\qcma", "appsPath", null);

                    Invoke(new Action(() => { Close(); }));
                }));
            });

            if (InvokeRequired) Invoke(action);
            else action.Invoke();
        }

        private void AfterWifi() {

            Process.Start(Global.path_QCMA);

            btnWifi.Visible = false;
            btnUSB.Visible = false;
            Action action = new Action(() => {
                lblInstructions.Text = "On your PS Vita:\r\n1. Launch Content Manager\r\n2. Select Copy Content\r\n3. Choose PC\r\n4. Choose Wifi\r\n5. Select Register\r\n6.Select the name of your PC\r\n7. Enter the code that appears on your PC\r\n\r\nIf it doesn't work, make sure your Vita and PC are on the same network, or rerun this application and try USB.";
                Task.Factory.StartNew(new Action(() => {
                    string old = (string)Registry.GetValue("HKEY_CURRENT_USER\\Software\\codestation\\qcma", "lastAccountId", "xxxxxxxxxxxxxxxx");

                    while ((string)Registry.GetValue("HKEY_CURRENT_USER\\Software\\codestation\\qcma", "lastAccountId", "xxxxxxxxxxxxxxxx") == old) {
                        Thread.Sleep(500);
                    }

                    Global.AID = (string)Registry.GetValue("HKEY_CURRENT_USER\\Software\\codestation\\qcma", "lastAccountId", null);
                    Global.QCMAAPPS = (string)Registry.GetValue("HKEY_CURRENT_USER\\Software\\codestation\\qcma", "appsPath", null);

                    Invoke(new Action(() => { Close(); }));
                }));
            });

            if (InvokeRequired) Invoke(action);
            else action.Invoke();
        }

        private void btnWifi_Click(object sender, EventArgs e) {
            AfterWifi();
        }
    }
}

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
using System.Timers;

namespace auto_h_encore {
    public partial class FormConnector : Form {

        System.Timers.Timer QCMAtimer = new System.Timers.Timer();

        public FormConnector() {
            InitializeComponent();
            ControlBox = false;
            lblInstructions.Text = Language.MountedLanguage["lbl_ConnectionMethod"];
            btnUSB.Text = Language.MountedLanguage["btn_USB"];
            btnWifi.Text = Language.MountedLanguage["btn_Wifi"];
        }

        private void btnUSB_Click(object sender, EventArgs e) {
            if (btnUSB.Width != 484) {
                btnUSB.Width = 484;
                btnWifi.Visible = false;
                btnUSB.Text = Language.MountedLanguage["btn_Next"];
                lblInstructions.Text = Language.MountedLanguage["lbl_UnplugVita"];
            } else {
                btnUSB.Visible = false;
                if (!Global.QCMA_Installed) {
                    lblInstructions.Text = Language.MountedLanguage["lbl_InstallingUSB"];
                    Task.Factory.StartNew(new Action(() => {
                        ProcessStartInfo psi = new ProcessStartInfo();
                        psi.WorkingDirectory = Reference.path_qcma + "driver\\";
                        psi.FileName = Reference.path_qcma + "driver\\dpscat.exe";
                        Process process = Process.Start(psi);
                        process.WaitForExit();
                        if (Environment.Is64BitOperatingSystem) psi.FileName = Reference.path_qcma + "driver\\dpinst64.exe";
                        else psi.FileName = Reference.path_qcma + "driver\\dpinst32.exe";
                        psi.Arguments = "/SE /SW";
                        process = Process.Start(psi);
                        process.WaitForExit();
                        AfterUSB();
                    }));
                } else AfterUSB();
                
            }
        }

        private void AfterUSB() {

            Process.Start(Global.path_QCMA);
            QCMAtimer.Interval = 15000;
            QCMAtimer.Elapsed += ResetQCMA;
            QCMAtimer.Start();

            Action action = new Action(() => {
                lblInstructions.Text = Language.MountedLanguage["txtblock_USBInstructions"];
                Task.Factory.StartNew(new Action(() => {
                    string old = (string)Registry.GetValue("HKEY_CURRENT_USER\\Software\\codestation\\qcma", "lastAccountId", "");

                    while (true)
                    {
                        string value = (string)Registry.GetValue("HKEY_CURRENT_USER\\Software\\codestation\\qcma", "lastAccountId", "");
                        if (value != old)
                        {
                            if (value.Length == 16) break;
                            else old = value;
                        }
                    }

                    QCMAtimer.Stop();
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
                lblInstructions.Text = Language.MountedLanguage["txtblock_WifiInstructions"];
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

        private void ResetQCMA(object sender, EventArgs e) {
            Utility.KillQCMA();
            Thread.Sleep(500);
            Process.Start(Global.path_QCMA);
        }

        private void FormConnector_FormClosing(object sender, FormClosingEventArgs e)
        {
            QCMAtimer.Stop();
        }
    }
}

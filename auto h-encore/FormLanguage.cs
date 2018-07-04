using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace auto_h_encore {
    public partial class FormLanguage : Form {

        public FormLanguage(int id) {
            InitializeComponent();
            foreach (string k in Language.Languages.Keys) {
                ddlLanguage.Items.Add(k);
            }
            if (id < Language.Languages.Count) ddlLanguage.SelectedIndex = id;
            else ddlLanguage.SelectedIndex = 0;
        }

        private void launch() {
            File.WriteAllLines(Reference.config_language, new string[] { "language=" + ddlLanguage.SelectedIndex });
            Visible = false;
            Form1 frm = new Form1();
            frm.Show();
        }

        private void FormLanguage_Load(object sender, EventArgs e) {
            
        }

        private void btnOK_Click(object sender, EventArgs e) {
            launch();
        }

        private void ddlLanguage_SelectedIndexChanged(object sender, EventArgs e) {
            Language.MountedLanguage = Language.Languages.ElementAt(ddlLanguage.SelectedIndex).Value;
            lblLanguage.Text = Language.MountedLanguage["lbl_ChooseLanguage"];
            btnOK.Text = Language.MountedLanguage["btn_Ok"];
        }
    }
}

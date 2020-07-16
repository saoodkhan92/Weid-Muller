using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WeiderMuller_Test_Utility
{
    public partial class ErrorMsg : Form
    {
        public ErrorMsg()
        {
            InitializeComponent();
        }
        bool blclose = true;
        bool blFormClosing = false;

        private void ErrorMsg_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Bitmap.FromHicon(SystemIcons.Warning.Handle);
            blFormClosing = false;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            blclose = true;
            if (blclose == true)
            {
                blclose = true;
                blFormClosing = true;
                this.Close();
            }
            else
                blclose = false;
            ((System.Windows.Forms.Form)((System.Windows.Forms.ButtonBase)sender).Parent).DialogResult = DialogResult.OK;

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            //this.Close();
            ((System.Windows.Forms.Form)((System.Windows.Forms.ButtonBase)sender).Parent).DialogResult = DialogResult.Cancel;
            //Application.Exit();
        }

        private void ErrorMsg_FormClosing(object sender, FormClosingEventArgs e)
        {
            blclose = false;
            //if (blclose == false)
            //   blFormClosing = true;

            if (blFormClosing == false)
            {
                ((System.Windows.Forms.Form)sender).DialogResult = DialogResult.Cancel;

            }

        }
    }
}
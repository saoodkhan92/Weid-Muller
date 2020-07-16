using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WeiderMuller_Test_Utility
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void btn_About_OK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void About_Load(object sender, EventArgs e)
        {

        }
    }
}
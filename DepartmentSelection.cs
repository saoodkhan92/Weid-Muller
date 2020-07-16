using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WeiderMuller_Test_Utility
{
    public partial class DepartmentSelection : Form
    {       
        public DepartmentSelection()
        {
            InitializeComponent();           
        }        

        private void rdBtnProduction_CheckedChanged(object sender, EventArgs e)
        {
            SetValues.IsProductionCheck = rdBtnProduction.Checked;
        }

        private void rdBtnQualityCheck_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Hide();
            ConfigurationSettings _config = new ConfigurationSettings();
                _config.ShowDialog();
            
            this.Close();
            this.Dispose();
            Application.Exit();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
            Application.Exit();            
        }
    }
}
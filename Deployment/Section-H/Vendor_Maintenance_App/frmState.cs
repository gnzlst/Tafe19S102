using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VendorMaintenance
{
    public partial class frmState : Form
    {
        public frmState()
        {
            InitializeComponent();
        }

        State selectedState;

        // Form load 
        private void frmState_Load(object sender, EventArgs e)
        {
        }

        // Clear data on screen
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCode.Text = "";
            txtName.Text = "";
            txtFirstZip.Text = "";
            txtLastZip.Text = "";
            btnModify.Enabled = false;
        }

        // Codes for the add button which is to display the frmAddModifyGLAccount form
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Generater a new form instance
            frmAddModifyState f;
            f = new frmAddModifyState();

            // assignment the addGLAccount global boolean to be true
            f.addState = true;

            DialogResult result = f.ShowDialog();
            if (result == DialogResult.OK)
            {
                selectedState = f.state;
                txtCode.Text = selectedState.StateCode.ToString();
                this.DisplayState();
            }
        }


        // Codes for the modify button which is to display the frmAddModifyGLAccount form
        private void btnModify_Click(object sender, EventArgs e)
        {
            // Generater a new form instance
            frmAddModifyState f;
            f = new frmAddModifyState();

            f.addState = false;

            f.state = selectedState;

            DialogResult result = f.ShowDialog();
            if (result == DialogResult.OK || result == DialogResult.Retry)
            {
                selectedState = f.state;
                this.DisplayState();
            }
            else if (result == DialogResult.Abort)
            {
                txtCode.Text = "";
                this.ClearControls();
            }
        }

        // Get GLAccount from table
        private void btnGetState_Click(object sender, EventArgs e)
        {
            try
            {
                selectedState =
                    (from state in DataContext.payables.States
                     where state.StateCode == txtCode.Text
                     select state).Single();
                this.DisplayState();
                btnModify.Enabled = true;
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("No State found with this No. " +
                    "Please try again.", "this State Not Found");
                this.ClearControls();
                txtCode.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }


        // Display GLAccount method
        private void DisplayState()
        {
            txtCode.Text = selectedState.StateCode.ToString();
            txtName.Text = selectedState.StateName.ToString();
            txtFirstZip.Text = selectedState.FirstZipCode.ToString();
            txtLastZip.Text = selectedState.LastZipCode.ToString();
            //cmdModify.Enabled = true;
            //cmdDelete.Enabled = true;
        }

        // Clear screen control method
        private void ClearControls()
        {
            txtCode.Text = "";
            txtName.Text = "";
            txtFirstZip.Text = "";
            txtLastZip.Text = "";
            //cmdModify.Enabled = false;
            //cmdDelete.Enabled = false;
        }

       


    }
}

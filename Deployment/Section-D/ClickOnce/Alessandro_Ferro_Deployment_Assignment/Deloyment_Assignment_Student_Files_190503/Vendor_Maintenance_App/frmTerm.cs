using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VendorMaintenance
{
    public partial class frmTerm : Form
    {
        public frmTerm()
        {
            InitializeComponent();
        }

        public Term selectedTerm;

        private void btnGetTerm_Click(object sender, EventArgs e)
        {
            try
            {
                selectedTerm =
                    (from Terms in DataContext.payables.Terms
                    where Terms.TermsID == Convert.ToInt32(txtTermID.Text)
                    select Terms).Single();
                this.DisplayTerm();
                btnModify.Enabled = true;
                btnDelete.Enabled = true;
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("No Term found with this ID. " +
                    "Please re-enter the ID.", "this Term Not Found");
                this.ClearControls();
                txtTermID.Focus();
            }
            catch (Exception playBall)
            {
                MessageBox.Show(playBall.Message, playBall.GetType().ToString());
            }
        }

        private void ClearControls()
        {
            txtTermID.Text = "";
            txtTermDesc.Text = "";
            txtDueDays.Text = "";
            btnModify.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void DisplayTerm()
        {
            txtTermID.Text = selectedTerm.TermsID.ToString();
            txtTermDesc.Text = selectedTerm.Description.ToString();
            txtDueDays.Text = selectedTerm.DueDays.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearControls();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddModifyTerm f;
            f = new frmAddModifyTerm();

            f.addTerm = true;

            DialogResult result = f.ShowDialog();
            if (result == DialogResult.OK)
            {
                selectedTerm = f.term;
                txtTermID.Text= selectedTerm.TermsID.ToString();
                this.DisplayTerm();
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            frmAddModifyTerm f;
            f = new frmAddModifyTerm();

            f.addTerm = false;

            f.term = selectedTerm;

            DialogResult result = f.ShowDialog();
            if (result == DialogResult.OK || result == DialogResult.Retry)
            {
                selectedTerm = f.term;
                this.DisplayTerm();
            }
            else if (result == DialogResult.Abort)
            {
                txtTermID.Text="";
                this.ClearControls();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmVendorMaintenance f = new frmVendorMaintenance();
            this.Hide();
            f.ShowDialog();
            
        }

        /*private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result =
                MessageBox.Show("Delete " + selectedTerm.TermsID + "?", 
                "ConfirmDelete", MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question);
            if(result==DialogResult.Yes)
            {
                try
                {
                    DataContext.payables.Terms.DeleteOnSubmit(selectedTerm);
                    DataContext.payables.SubmitChanges();
                    txtTermID.Text = "";
                    this.ClearControls();
                }
                catch(ChangeConflictException)
                {
                    DataContext.GetCurrentValues();
                    MessageBox.Show("Another user has updated that vendor.", 
                        "Database Error");
                    this.DisplayTerm();
                }
        }*/


    }
}

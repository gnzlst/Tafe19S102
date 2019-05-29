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
    public partial class frmAddModifyTerm : Form
    {
        public frmAddModifyTerm()
        {
            InitializeComponent();
        }

        public Term term;
        public bool addTerm;

        private void frmAddModifyTerm_load(object sender, EventArgs e)
        {
            if (addTerm != true)
            {
                this.DisplayTermData();
            }
        }

        private void DisplayTermData()
        {
            txtTID.Text = term.TermsID.ToString();
            txtTDesc.Text = term.Description.ToString();
            txtTDays.Text = term.DueDays.ToString();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (addTerm)
            {
                term = new Term();
                this.PutTermData(term);
                DataContext.payables.Terms.InsertOnSubmit(term);

                try
                {
                    DataContext.payables.SubmitChanges();
                    this.DialogResult = DialogResult.OK;
                    MessageBox.Show("Term " + Convert.ToString(term.TermsID) + " has been added to the Terms Table");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }
            }
            else
            {
                this.PutTermData(term);
                try
                {
                    DataContext.payables.SubmitChanges();
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }
            }
        }

        private void PutTermData(Term term)
        {
            term.TermsID = Int32.Parse(txtTID.Text);
            term.Description = txtTDesc.Text;
            term.DueDays = short.Parse(txtTDays.Text);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTID.Text = "";
            txtTDesc.Text = "";
            txtTDays.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

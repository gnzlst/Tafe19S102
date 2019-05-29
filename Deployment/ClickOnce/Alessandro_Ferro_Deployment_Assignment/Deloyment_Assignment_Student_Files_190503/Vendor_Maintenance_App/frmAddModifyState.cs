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
    public partial class frmAddModifyState : Form
    {
        public frmAddModifyState()
        {
            InitializeComponent();
        }
        public bool addState;
        public State state;


        // Check whether the user want to add or modify function, the corresponding add/modify action to the database is carried out
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (addState)
            {
                state = new State();
                this.PutStateData(state);
                DataContext.payables.States.InsertOnSubmit(state);

                try
                {
                    DataContext.payables.SubmitChanges();
                    this.DialogResult = DialogResult.OK;
                    MessageBox.Show("State Code " + Convert.ToString(state.StateCode) + " has been added to the State table");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }

            }
            else
            {
                this.PutStateData(state);
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


        // assign GLAccount properties through this method
        private void PutStateData(State state)
        {
            state.StateCode = txtCode.Text;
            state.StateName = txtName.Text;
            state.FirstZipCode = Int32.Parse(txtFirstZip.Text);
            state.LastZipCode = Int32.Parse(txtLastZip.Text);


        }

        // if not adding a GLAccount display the GLAccount data to screen
        private void frmAddModifyState_Load(object sender, EventArgs e)
        {

            if (addState != true)
            {
                this.DisplayStateData();
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void DisplayStateData()
        {
            txtCode.Text = state.StateCode.ToString();
            txtName.Text = state.StateName;
            txtFirstZip.Text = state.FirstZipCode.ToString();
            txtLastZip.Text = state.LastZipCode.ToString();
        }

    }
}

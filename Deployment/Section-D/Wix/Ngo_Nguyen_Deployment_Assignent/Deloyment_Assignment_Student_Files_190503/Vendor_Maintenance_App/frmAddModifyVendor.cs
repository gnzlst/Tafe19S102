using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Linq;

namespace VendorMaintenance
{
    public partial class frmAddModifyVendor : Form
    {
        public frmAddModifyVendor()
        {
            InitializeComponent();
        }

        public bool addVendor;
        public Vendor vendor;
        
        private void frmAddModifyVendor_Load(object sender, EventArgs e)
        {
            this.LoadComboBoxes();
            if (addVendor)
            {
                this.Text = "Add Vendor";
                cboStates.SelectedIndex = -1;
                cboTerms.SelectedIndex = -1;
                cboAccounts.SelectedIndex = -1;
            }
            else
            {
                this.Text = "Modify Vendor";
                this.DisplayVendorData();
            }
        }

        private void LoadComboBoxes()
        {
            try
            {
                var states = from state in DataContext.payables.States
                             orderby state.StateName
                             select new { state.StateCode, state.StateName };
                cboStates.DataSource = states;
                cboStates.DisplayMember = "StateName";
                cboStates.ValueMember = "StateCode";

                var terms = from term in DataContext.payables.Terms
                            orderby term.Description
                            select new { term.TermsID, term.Description };
                cboTerms.DataSource = terms;
                cboTerms.DisplayMember = "Description";
                cboTerms.ValueMember = "TermsID";

                var accounts = from account in DataContext.payables.GLAccounts
                               orderby account.Description
                               select account;
                cboAccounts.DataSource = accounts;
                cboAccounts.DisplayMember = "Description";
                cboAccounts.ValueMember = "AccountNo";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void DisplayVendorData()
        {
            txtName.Text = vendor.Name;
            txtAddress1.Text = vendor.Address1;
            txtAddress2.Text = vendor.Address2;
            txtCity.Text = vendor.City;
            cboStates.SelectedValue = vendor.State;
            txtZipCode.Text = vendor.ZipCode;
            cboTerms.SelectedValue = vendor.DefaultTermsID;
            cboAccounts.SelectedValue = vendor.DefaultAccountNo;
            if (vendor.Phone == "")
                txtPhone.Text = "";
            else
                txtPhone.Text = FormattedPhoneNumber(vendor.Phone);
            txtFirstName.Text = vendor.ContactFName;
            txtLastName.Text = vendor.ContactLName;
        }

        private string FormattedPhoneNumber(string phone)
        {
            return phone.Substring(0, 3) + "." +
                phone.Substring(3, 3) + "." +
                phone.Substring(6, 4);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                if (addVendor)
                {
                    vendor = new Vendor();
                    this.PutVendorData(vendor);
                    DataContext.payables.Vendors.InsertOnSubmit(vendor);
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
                else
                {
                    this.PutVendorData(vendor);
                    try
                    {
                        DataContext.payables.SubmitChanges();
                        this.DialogResult = DialogResult.OK;
                    }
                    catch (ChangeConflictException)
                    {
                        DataContext.GetCurrentValues();
                        if (DataContext.vendorDeleted)
                        {
                            MessageBox.Show("Another user has deleted " +
                                "that vendor.", "Database Error");
                            this.DialogResult = DialogResult.Abort;
                        }
                        else
                        {
                            MessageBox.Show("Another user has updated " +
                                "that vendor.", "Database Error");
                            this.DialogResult = DialogResult.Retry;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, ex.GetType().ToString());
                    }
                }
            }
        }

        private bool IsValidData()
        {
            if (Validator.IsPresent(txtName) &&
                Validator.IsPresent(txtAddress1) &&
                Validator.IsPresent(txtCity) &&
                Validator.IsPresent(cboStates) &&
                Validator.IsPresent(txtZipCode) &&
                Validator.IsInt32(txtZipCode) &&
                Validator.IsPresent(cboTerms) &&
                Validator.IsPresent(cboAccounts))
            {
                string state = cboStates.SelectedValue.ToString();
                var zipRange = (from s in DataContext.payables.States
                                where s.StateCode == state
                                select new { s.FirstZipCode, s.LastZipCode })
                                .Single();
                if (Validator.IsStateZipCode(txtZipCode, zipRange.FirstZipCode,
                    zipRange.LastZipCode))
                {
                    if (txtPhone.Text != "")
                    {
                        if (Validator.IsPhoneNumber(txtPhone))
                            return true;
                        else
                            return false;
                    }
                    else
                        return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        private void PutVendorData(Vendor vendor)
        {
            vendor.Name = txtName.Text;
            vendor.Address1 = txtAddress1.Text;
            vendor.Address2 = txtAddress2.Text;
            vendor.City = txtCity.Text;
            vendor.State = cboStates.SelectedValue.ToString();
            vendor.ZipCode = txtZipCode.Text;
            vendor.DefaultTermsID = (int)cboTerms.SelectedValue;
            vendor.DefaultAccountNo = (int)cboAccounts.SelectedValue;
            vendor.Phone = txtPhone.Text.Replace(".", "");
            vendor.ContactFName = txtFirstName.Text;
            vendor.ContactLName = txtLastName.Text;
        }
    }
}

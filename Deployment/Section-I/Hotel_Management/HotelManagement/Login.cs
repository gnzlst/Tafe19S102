using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroFramework.Forms;
using MetroFramework.Controls;
using MetroFramework.Drawing;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Hotel_Manager
{
    public partial class Login : MetroForm
    {

        SqlConnection conn;
        SqlDataReader dr;
        SqlCommand cmd;


        public Login()
        {
            InitializeComponent();
            CenterToScreen();
        }
        private void signinButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (verifier("frontend".Trim(), usernameTextBox.Text.Trim(), passwordTextBox.Text.Trim()))
                {
                    this.Hide();
                    Frontend hotel_management = new Frontend();
                    hotel_management.Show();
                }
                else if (verifier("kitchen".Trim(), usernameTextBox.Text.Trim(), passwordTextBox.Text.Trim()))
                {
                    this.Hide();
                    Kitchen kitchen_management = new Kitchen();
                    kitchen_management.Show();
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "Username or Password is wrong, try again", "Login Failed", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.ToString(), "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        private void usernameTextBox_Click(object sender, EventArgs e)
        {

            if (usernameTextBox.Text == string.Empty)
            {
                usernameLabel.Visible = true;
            }
            if (usernameTextBox.Text != "Username" && usernameTextBox.Text != string.Empty)
            {
                usernameLabel.Visible = false;
            }
        }
        private void passwordTextBox_Click(object sender, EventArgs e)
        {

            if (passwordTextBox.Text == string.Empty)
            {
                passwordLabel.Visible = true;
            }
            if (passwordTextBox.Text != "Password" && passwordTextBox.Text != string.Empty)
            {
                passwordLabel.Visible = false;
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (!usernameLabel.Bounds.Contains(e.Location) && usernameTextBox.Text == string.Empty)
            {
                usernameLabel.Visible = false;
            }
            if (!passwordLabel.Bounds.Contains(e.Location) && passwordTextBox.Text == string.Empty)
            {
                passwordLabel.Visible = false;
            }

        }

        public bool verifier(string tableName, string username, string password)
        {
            bool success = false;
            ConnectionStringSettings connSettings = ConfigurationManager.ConnectionStrings["DBConnectApp"];
            string connectionString = connSettings.ConnectionString;
            string sql = "SELECT * FROM " + tableName + " WHERE user_name=@userName AND pass_word=@password";
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                cmd = new SqlCommand(sql, conn);
                cmd.CommandText = sql;
                SqlParameter UsernameParametar = new SqlParameter("@username", SqlDbType.VarChar);
                SqlParameter PassParametar = new SqlParameter("@password", SqlDbType.VarChar);
                cmd.Parameters.Add(UsernameParametar);
                cmd.Parameters.Add(PassParametar);
                UsernameParametar.Value = username;
                PassParametar.Value = password;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                    success = true;
                conn.Close();
            }
            catch (Exception e)
            {
                MetroFramework.MetroMessageBox.Show(this, e.ToString(), "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
           
            return success;
        }

        private void login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void LicenseCallButton_Click(object sender, EventArgs e)
        {
            License open_license = new License();
            open_license.ShowDialog();
        }
    }
}

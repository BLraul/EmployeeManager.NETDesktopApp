using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace EmployeeManager
{
    public partial class SignUp : Form
    {
        DBConnections dbConnect = new DBConnections();

        string emailpattern = "[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
        //string passwordpattern = @"^.*(?=.{8,})(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$";
        public SignUp()
        {
            InitializeComponent();
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text) == true)
            {
                txtName.Focus();
                errorProvider1.SetError(this.txtName, "Please Fill Name");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {

            if (comboBox1.SelectedItem == null)
            {
                comboBox1.Focus();
                errorProvider2.SetError(this.comboBox1, "Please Select a role");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (Regex.IsMatch(txtEmail.Text, emailpattern) == false)
            {
                txtEmail.Focus();
                errorProvider3.SetError(this.txtEmail, "Please Enter Valid Email");

            }
            else
            {
                errorProvider3.Clear();
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text) == true)
            {
                txtPassword.Focus();
                errorProvider4.SetError(this.txtPassword, "Please Fill Password");

            }
            else
            {
                errorProvider4.Clear();
            }
        }

        private void txtConfPassword_Leave(object sender, EventArgs e)
        {
            if (txtConfPassword.Text != txtPassword.Text)
            {
                txtConfPassword.Focus();
                errorProvider5.SetError(this.txtConfPassword, "Password Mismatch");

            }
            else
            {
                errorProvider5.Clear();
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            string userName = txtName.Text;
            string userEmail = txtEmail.Text;
            string userPassword = txtPassword.Text;
            string userConfPassword = txtConfPassword.Text;
            string userType = comboBox1.Text;
            int roleUserId = 0;

            switch (userType)
            {
                case "Owner":
                    roleUserId= 1;
                    break;
                case "Admin":
                    roleUserId= 2;
                    break;
                case "Viewer":
                    roleUserId= 3;
                    break;
            }

            if (userName.Equals(""))
            {
                MessageBox.Show("Please enter your name");
            }
            else if (userEmail.Equals(""))
            {
                MessageBox.Show("Please enter your email");
            }
            else if (userPassword.Equals(""))
            {
                MessageBox.Show("Please enter your password");
            }
            else if (userConfPassword!=userPassword)
            {
                MessageBox.Show("Please re-enter the password");
            }
            else
            {
                SqlCommand insertCommand = new SqlCommand("insert into SignUp(Name, Email, Password, ConfPass, RolUserID) values(@userName, @userEmail, @userPassword, @userConfPassword, @roleUserId)");
                insertCommand.Parameters.AddWithValue("@userName", userName);
                insertCommand.Parameters.AddWithValue("@userEmail", userEmail);
                insertCommand.Parameters.AddWithValue("@userPassword", userPassword);
                insertCommand.Parameters.AddWithValue("@userConfPassword", userConfPassword);
                insertCommand.Parameters.AddWithValue("@roleUserId", roleUserId);

                int row = dbConnect.executeQuery(insertCommand);

                if (row == 1)
                {
                    MessageBox.Show("Account Created Successful!","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    this.Hide();
                    login login = new login();
                    login.Show();
                }
                else
                {
                    MessageBox.Show("Registered Failed","Try Again",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lblLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            login login = new login();
            login.Show();
        }
    }
}

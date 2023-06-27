using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;

namespace EmployeeManager
{
    public partial class login : Form
    {

        public static string id, name, email, password, roleUser;

        DBConnections dbConnection = new DBConnections();

        DataTable dtUsers = new DataTable();
        public login()
        {
            InitializeComponent();
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtPasswordLogin.UseSystemPasswordChar = false;
            }
            else
            {
                txtPasswordLogin.UseSystemPasswordChar = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userEmail = txtEmailLogin.Text;
            string userPassword = txtPasswordLogin.Text;



            if (userEmail != "" && userPassword != "")      
            {
                string query = "Select * From SignUp Where Email= '" + userEmail + "' AND Password= '" + userPassword + "'";

                dbConnection.readDatathroughAdapter(query, dtUsers);

                if (dtUsers.Rows.Count == 1)
                {

                    id = dtUsers.Rows[0]["Id"].ToString();
                    name = dtUsers.Rows[0]["Name"].ToString();
                    email = dtUsers.Rows[0]["Email"].ToString();
                    password = dtUsers.Rows[0]["Password"].ToString();
                    roleUser = dtUsers.Rows[0]["RolUserID"].ToString();
                    
                    if(roleUser == "3")
                    {
                        MessageBox.Show("Congratulations, you have successfully logged in as a Viewer ", "Login Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dbConnection.closeConn();
                        Viewer viewer = new Viewer();
                        viewer.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Login Success", "Congratulations, you are loggin Successfuly", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dbConnection.closeConn();

                        Home home = new Home();
                        home.Show();
                        this.Hide();
                    }

                }
                else
                {
                    MessageBox.Show("Login Failed","Invalid credentials, Provide correct email and password.", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please fill both field", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtEmailLogin_Leave(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtEmailLogin.Text) == true)
            {
                txtEmailLogin.Focus();
                errorProvider1.SetError(this.txtEmailLogin, "Please Fill Email");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtPasswordLogin_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPasswordLogin.Text) == true)
            {
                txtPasswordLogin.Focus();
                errorProvider2.SetError(this.txtPasswordLogin, "Please Fill Password");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void lblCreateAccount_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignUp SignUp = new SignUp();
            SignUp.Show();
        }
    }
}

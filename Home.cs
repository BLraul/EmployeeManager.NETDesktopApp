using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EmployeeManager
{
    public partial class Home : Form
    {

       
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Welcome " + login.name;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            login login = new login();
            login.Show();
            this.Hide();
            
        }
        private void label4_Click(object sender, EventArgs e)
        {
            login login = new login();
            login.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Employee employee= new Employee();
            employee.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            employee.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ViewEmployees viewEmployees= new ViewEmployees();
            viewEmployees.Show();
            this.Hide();
        }
    }
}

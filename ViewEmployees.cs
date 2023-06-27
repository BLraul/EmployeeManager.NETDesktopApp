using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EmployeeManager
{
    public partial class ViewEmployees : Form
    {
        DBConnections dbConnect = new DBConnections();
        public ViewEmployees()
        {
            InitializeComponent();
        }

        private void getDataOfId()
        {
            DataTable dtEmployee = new DataTable();
            string selectCommand = "SELECT * FROM EmployeeTbl WHERE EmpId='" + EditEmpIdSearch.Text + "'";
            dbConnect.readDatathroughAdapter(selectCommand, dtEmployee);
            foreach(DataRow dr in dtEmployee.Rows)
            {
                EditEmpId.Text = dr["EmpId"].ToString();
                EditEmpName.Text = dr["EmpName"].ToString();
                EditEmpAdr.Text = dr["EmpAdr"].ToString();
                EditEmpPos.Text = dr["EmpPos"].ToString();
                EditEmpPhone.Text = dr["EmpPhone"].ToString();
                EditEmpGen.Text = dr["EmpGen"].ToString(); 
                EditEmpId.Visible=true;
                EditEmpName.Visible = true;
                EditEmpAdr.Visible = true;
                EditEmpPos.Visible = true;
                EditEmpPhone.Visible = true;
                EditEmpGen.Visible=true;
            }
            dbConnect.closeConn();
        }
        private void ViewEmployees_Load(object sender, EventArgs e)
        {
       
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            getDataOfId();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            getDataOfId();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace EmployeeManager
{
    public partial class Employee : Form
    {
        DBConnections dbConnect = new DBConnections();
        

        public Employee()
        {
            InitializeComponent();
        }

        private void btnAddEmp_Click(object sender, EventArgs e)
        {
            string EmpName = empName.Text;
            string EmpAdress = empAdr.Text;
            string EmpPos = empPos.Text;
            string EmpDOB = empDob.Text;
            string EmpPhone = empPhone.Text;
            string EmpGen   = empGen.Text;

            if(EmpName =="" || EmpAdress == "" || EmpPos=="" || EmpDOB =="" || EmpPhone == "" || EmpGen =="")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                SqlCommand insertCommand = new SqlCommand("insert into EmployeeTbl(EmpName, EmpAdr, EmpPos, EmpDOB,EmpPhone,EmpGen) values(@EmpName, @EmpAdress, @EmpPos, @EmpDOB, @EmpPhone, @EmpGen)");
                insertCommand.Parameters.AddWithValue("@EmpName", EmpName); 
                insertCommand.Parameters.AddWithValue("@EmpAdress", EmpAdress);
                insertCommand.Parameters.AddWithValue("@EmpPos", EmpPos);
                insertCommand.Parameters.AddWithValue("@EmpDOB", EmpDOB);
                insertCommand.Parameters.AddWithValue("@EmpPhone", EmpPhone);
                insertCommand.Parameters.AddWithValue("@EmpGen", EmpGen);

                int row = dbConnect.executeQuery(insertCommand);

                if (row == 1)
                {
                    //id = dtEmployee.Rows[0]["Id"].ToString();
                    //name = dtUsers.Rows[0]["Name"].ToString();
                    //email = dtUsers.Rows[0]["Email"].ToString();
                    //password = dtUsers.Rows[0]["Password"].ToString();
                    //country = dtUsers.Rows[0]["Country"].ToString();

                    MessageBox.Show("Employee add Succesfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dbConnect.closeConn();
                    getDataFromDB();
                }
                else
                {
                    MessageBox.Show("Add Employee Failed", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void getDataFromDB()
        {
            DataTable dtEmployee = new DataTable();
            string selectCommand = "SELECT * FROM EmployeeTbl";
            dbConnect.readDatathroughAdapter(selectCommand, dtEmployee);
            dataGridViewEmp.DataSource = dtEmployee;
            dbConnect.closeConn();
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            getDataFromDB();
        }

        private void btnDeleteEmp_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Are you sure?", "Delete Employee", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                string query = "DELETE FROM EmployeeTbl WHERE EmpId = '" + empId.Text + "';";

                SqlCommand deleteCommand = new SqlCommand(query);

                int row = dbConnect.executeQuery(deleteCommand);

                if (row == 1)
                {
                    MessageBox.Show("Account Deleted Successfully");
                    dbConnect.closeConn();
                    getDataFromDB();
                }
                else
                {
                    MessageBox.Show("Error Occured. Try Again");
                }
            }
        }

        private void btnUpdateEmp_Click(object sender, EventArgs e)
        {
            string newEmpName = empName.Text;
            string newEmpAdress = empAdr.Text;
            string newEmpPos = empPos.Text;
            string newEmpDOB = empDob.Text;
            string newEmpPhone = empPhone.Text;
            string newEmpGen = empGen.Text;

            if (newEmpName == "" || newEmpAdress == "" || newEmpPos == "" || newEmpDOB == "" || newEmpPhone == "" || newEmpGen == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                SqlCommand updateCommand = new SqlCommand("update EmployeeTbl SET EmpName = '" + @newEmpName + "', EmpAdr = '" + @newEmpAdress + "',EmpPos = '" + @newEmpPos + "', EmpDOB= '" + @newEmpDOB + "', EmpPhone= '" + @newEmpPhone + "', EmpGen= '" + @newEmpGen + "' where EmpId = '" + empId.Text + "';");
                updateCommand.Parameters.AddWithValue("@EmpName", @newEmpName);
                updateCommand.Parameters.AddWithValue("@EmpAdress", @newEmpAdress);
                updateCommand.Parameters.AddWithValue("@EmpPos", @newEmpPos);
                updateCommand.Parameters.AddWithValue("@EmpDOB", @newEmpDOB);
                updateCommand.Parameters.AddWithValue("@EmpPhone", @newEmpPhone);
                updateCommand.Parameters.AddWithValue("@EmpGen", @newEmpGen);

                int row = dbConnect.executeQuery(updateCommand);

                if (row == 1)
                {
                    MessageBox.Show("Employee Updated Succesfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dbConnect.closeConn();
                    getDataFromDB();
                }
                else
                {
                    MessageBox.Show("Update Employee Failed", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void dataGridViewEmp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            
                int i = e.RowIndex;
                DataGridViewRow row = dataGridViewEmp.Rows[i];
            empId.Text = row.Cells[0].Value.ToString();
            empName.Text = row.Cells[1].Value.ToString();
            empAdr.Text = row.Cells[2].Value.ToString();
            empPos.Text = row.Cells[3].Value.ToString();
            empDob.Text = row.Cells[4].Value.ToString();
            empPhone.Text = row.Cells[5].Value.ToString();
            empGen.Text = row.Cells[6].Value.ToString();
            
            //empId.Text = dataGridViewEmp.SelectedRows[0].Cells[0].Value.ToString();
            //empName.Text = dataGridViewEmp.SelectedRows[0].Cells[1].Value;
            //empAdr.Text = dataGridViewEmp.SelectedRows[0].Cells[2].Value;
            //empPos.Text = dataGridViewEmp.SelectedRows[0].Cells[3].Value.ToString();
            //empDob.Text = dataGridViewEmp.SelectedRows[0].Cells[4].Value.ToString();
            //empPhone.Text = dataGridViewEmp.SelectedRows[0].Cells[5].Value.ToString();
            //empGen.Text = dataGridViewEmp.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
        private void label1_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

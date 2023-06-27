using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EmployeeManager
{
    public partial class loadpage : Form
    {
        public loadpage()
        {
            InitializeComponent();
        }

        private void loadpage_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(5);
            label2.Text = progressBar1.Value + "%";
            if(progressBar1.Value == 100)
            {
                timer1.Stop();  

                login login = new login();
                login.Show();
                this.Hide();
            }
        }
    }
}

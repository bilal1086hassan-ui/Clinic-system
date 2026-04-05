using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyClinic1
{
    public partial class maindashboard : Form
    {
        SqlConnection conn;
        public maindashboard()
        {
            InitializeComponent();
            LoginForm f3 = new LoginForm();
            f3.getConnection();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Doctor d = new Doctor();
            d.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            register r1 = new register();
            r1.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Appointments a = new Appointments();
            a.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Reports r = new Reports();
            r.Show();
            this.Hide();
        }
    }
}

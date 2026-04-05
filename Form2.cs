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
    public partial class Registration : Form
    {
        SqlConnection conn;
        
        public Registration()
        {
            InitializeComponent();
            LoginForm f1 = new LoginForm ();
            conn = f1.getConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Please enter username and password");
                return;
            }

            string query = "INSERT INTO login (username, password) VALUES (@user, @pass)";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@user", textBox1.Text);
            cmd.Parameters.AddWithValue("@pass", textBox2.Text);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Registered successfully");

            textBox1.Clear();
            textBox2.Clear();
            LoginForm lf = new LoginForm();
            lf.Show();
            this.Hide();
        }
    }
}

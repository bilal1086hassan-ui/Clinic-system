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
    public partial class register : Form
    {
        SqlConnection conn;
        public register()
        {
            InitializeComponent();
            LoginForm r = new LoginForm();
            conn = r.getConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query1 = "INSERT INTO patient (patientname, patientaddress, patientphone, patientgender, patientnationality, patientdob, registerdate) " +
                    "VALUES (@name, @address, @phone, @gender, @nationality, @DOB, @RegisterDate)";
            SqlCommand cmd = new SqlCommand(query1, conn);
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@phone", textBox2.Text);
            cmd.Parameters.AddWithValue("@nationality", comboBox1.Text);
            cmd.Parameters.AddWithValue("@RegisterDate", textBox3.Text);
            cmd.Parameters.AddWithValue("@address", textBox4.Text);
            cmd.Parameters.AddWithValue("@DOB", textBox5.Text);
            cmd.Parameters.AddWithValue("@gender", comboBox2.Text);
            conn.Open();
            int rowsaffected = cmd.ExecuteNonQuery();
            conn.Close();
            if (rowsaffected > 0)
            {
                MessageBox.Show("Student added successfuly.");
            }
        }
    }
}

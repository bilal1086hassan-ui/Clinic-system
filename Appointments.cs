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
    public partial class Appointments : Form
    {
        SqlConnection conn;
        public Appointments()
        {
            InitializeComponent();
            LoginForm f4 = new LoginForm();
            conn = f4.getConnection();
            loaddoctor();
            loadtime();
        }
        private void loaddoctor()
        {
            string query = "SELECT doctorid, doctorname FROM doctor";
            SqlDataAdapter adapter = new SqlDataAdapter(query,conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "doctorname";
            comboBox1.ValueMember = "doctorid";
        }
        private void loadtime()
        {
            comboBox2.Items.Clear();
            DateTime start = DateTime.Parse("9:00");
            DateTime end = DateTime.Parse("11:00");
            while(start <= end)
            {
                comboBox2.Items.Add(start.ToString("hh:mm"));
                start = start.AddMinutes(10);
            }
        }
        private void Appointments_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO appointment(patientid, doctorid, reservationdate, reservationtime) " +
                "VALUES(@ID, @name, @date, @time) ";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", textBox1.Text);
            cmd.Parameters.AddWithValue("@name", comboBox1.SelectedValue);
            cmd.Parameters.AddWithValue("@date", textBox2.Text);
            cmd.Parameters.AddWithValue("@time", comboBox2.Text);
            conn.Open();
            int rowsaffected = cmd.ExecuteNonQuery();
            conn.Close();
            if (rowsaffected > 0)
            {
                MessageBox.Show("Appointment added successfuly.");
            }
        }
    }
}

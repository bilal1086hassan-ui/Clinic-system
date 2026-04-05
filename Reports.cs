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
    public partial class Reports : Form
    {
        private void LoadDoctors()
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT doctorid, doctorname FROM doctor", conn);

                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "doctorname";
                comboBox1.ValueMember = "doctorid";
            }

        SqlConnection conn;
        public Reports()
        {
            InitializeComponent();
            LoginForm f5 = new LoginForm();
            conn = f5.getConnection();
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            LoadDoctors();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "Select p.patiebtid, d.doctorname, a.reservationdate, a.reservationtime " +
                "FROM appointment a " +
                "JOIN doctor d ON a.doctorid = d.doctorid " +
                "JOIN patient p ON a.patientid = p.patiebtid " +
                "WHERE a.doctorid = @did AND a.reservationdate = @date ";
            SqlDataAdapter ad = new SqlDataAdapter(query, conn);

            ad.SelectCommand.Parameters.AddWithValue("@did", comboBox1.SelectedValue);
            ad.SelectCommand.Parameters.AddWithValue("@date", textBox1.Text);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}

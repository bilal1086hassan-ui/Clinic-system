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
    public partial class Doctor : Form
    {
        SqlConnection conn;
        public Doctor()
        {
            InitializeComponent();
            LoginForm f2 = new LoginForm();
            conn = f2.getConnection();
        }
        private void fillgrid()
        {
            string query = "select * from doctor";
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }
        private void clearform()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void Doctor_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query1 = "INSERT INTO doctor (doctorid, doctorname, doctorspeciality, username, password) " +
                    "VALUES (@doctorid, @doctorname, @doctorspeciality, @username, @password)";
            SqlCommand cmd = new SqlCommand(query1, conn);
            cmd.Parameters.AddWithValue("@doctorid", int.Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("@doctorname", textBox1.Text);
            cmd.Parameters.AddWithValue("@doctorspeciality", textBox2.Text);
            cmd.Parameters.AddWithValue("@username", textBox4.Text);
            cmd.Parameters.AddWithValue("@password", textBox5.Text);
            conn.Open();
            int rowsaffected = cmd.ExecuteNonQuery();
            conn.Close();
            if (rowsaffected > 0)
            {
                MessageBox.Show("Student added successfuly.");
                clearform();
                fillgrid();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            fillgrid();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string query = "select * from doctor where doctorid = @id";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@id", int.Parse(textBox3.Text));
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                textBox1.Text = reader["doctorname"].ToString();
                textBox2.Text = reader["doctorspeciality"].ToString();
                textBox4.Text = reader["username"].ToString();
                textBox5.Text = reader["password"].ToString();
            }
            else
            {
                MessageBox.Show("records not found!");
            }
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = @"UPDATE doctor SET
            doctorname = @name,
            doctorspeciality = @spec,
            username = @user,
            password = @pass
            WHERE doctorid = @id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@spec", textBox2.Text);
            cmd.Parameters.AddWithValue("@user", textBox4.Text);
            cmd.Parameters.AddWithValue("@pass", textBox5.Text);
            cmd.Parameters.AddWithValue("@id",int.Parse(textBox3.Text));
            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            conn.Close();

            if(rows > 0)
            {
                MessageBox.Show("Doctor updated successfuly!");
                fillgrid();
                clearform();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM doctor WHERE doctorid = @id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox3.Text));

            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            conn.Close();

            if (rows > 0)
            {
                MessageBox.Show("Deleted successfully!");
                clearform();
                fillgrid();
            }
            else
            {
                MessageBox.Show("Doctor not found!");
            }
        }
    }
}

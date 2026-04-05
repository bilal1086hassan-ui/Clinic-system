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
    public partial class LoginForm : Form
    {
        private SqlConnection conn;
        public SqlConnection getConnection()
        {
            try
            {
                string connectionString = "Data Source = localhost; Initial Catalog=clinic;User ID=sa;Password=YOUR PASSWORD HERE;";
                conn = new SqlConnection(connectionString);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in database connection");
            }
            return conn;
        }
        public LoginForm()
        {
            InitializeComponent();
            getConnection();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registration f = new Registration();
            f.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "SELECT username , password FROM login WHERE username = @user AND password = @pass";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@user", textBox1.Text);
            cmd.Parameters.AddWithValue("@pass", textBox2.Text);

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                textBox1.Clear();
                textBox2.Clear(); 
                maindashboard d = new maindashboard();
                d.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong username and password");
                textBox1.Clear() ;
                textBox2.Clear() ;
            }
        }
    }
}

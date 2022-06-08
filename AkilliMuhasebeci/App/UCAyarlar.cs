using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace AkilliMuhasebeci.App
{
    public partial class UCAyarlar : UserControl
    {

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;
        SqlDataAdapter adapter;
        DataTable dt = new DataTable();
        DataView dv = new DataView();
        ConnectionDB db = new ConnectionDB();   

        public UCAyarlar()
        {
            InitializeComponent();
            NumberOfUsers();
            NumberOfBranch();
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Users user = new Users();
            user.Show();
           
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
            
        }

        public void NumberOfUsers()
        {
            con = new SqlConnection(db.GetConnection());
            con.Open();
            String countUsers = "Select count(USERNAME) from WorkerLogin";
            cmd = new SqlCommand(countUsers, con);

            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                label10.Text = reader.GetValue(0).ToString();
            }


            con.Close();
        }

        public void NumberOfBranch()
        {
            con = new SqlConnection(db.GetConnection());
            con.Open();
            String countUsers = "Select distinct count(BRANCH) from WorkerLogin";
            cmd = new SqlCommand(countUsers, con);

            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                label11.Text = reader.GetValue(0).ToString();
            }


            con.Close();
        }

        private void save_Click(object sender, EventArgs e)
        {

            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
        }

        private void update_Click(object sender, EventArgs e)
        {
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
        }


    }
}

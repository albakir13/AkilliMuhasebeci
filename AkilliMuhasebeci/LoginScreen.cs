using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AkilliMuhasebeci
{
    public partial class LoginScreen : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter adapter;

        ConnectionDB db = new ConnectionDB();
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Close();
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            passcontrol();
  
            string LoginInfo = "Select * from WorkerLogin where USERNAME='" + USERNAME.Text + 
                           "' and PASSWORD = '" + PASSWORD.Text + 
                           "' and BRANCH = '" + BranchBox.Text + "'" + "Select PERMISSION from WorkerLogin";

            con = new SqlConnection(db.GetConnection());
            cmd = new SqlCommand(LoginInfo, con);
            cmd.Parameters.AddWithValue("@Branch", BranchBox.Text);
            cmd.Parameters.AddWithValue("@USERNAME", USERNAME.Text);
            cmd.Parameters.AddWithValue("@PASSWORD", PASSWORD.Text);

                con.Open();
                dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                dr.Read();

                if (dr[4].ToString() == "Yönetici")
                {
                    ConnectionDB.PERMISSION = "Admin";
                }
                else if (dr[4].ToString() == "Mühasebeci")
                {
                    ConnectionDB.PERMISSION = "Accounter";
                }
                else if (dr[4].ToString() == "Isçi")
                {
                    ConnectionDB.PERMISSION = "Worker";
                }

                MainScreen Dashboard = new MainScreen(USERNAME.Text, BranchBox.Text, permis.Text);
                this.Hide();
                Dashboard.Show();
                
            }
            else
            {
                MessageBox.Show("Kullanıcı adını ve şifrenizi kontrol ediniz.");
            }

            con.Close();
            
        }

        private void passcontrol()
        {
            if (BranchBox.Text == "")
                MessageBox.Show("Şube seçmeniz gerekmektedir");
            else if (USERNAME.Text == "")
                MessageBox.Show("Kullancı adı yazmanız gerekmektedir");
            else if (PASSWORD.Text == "")
                MessageBox.Show("şifre yazmanız gerekmektedir");
        }


        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void BranchBox_Enter(object sender, EventArgs e)
        {

        }

        private void USERNAME_Enter(object sender, EventArgs e)
        {
            if(USERNAME.Text == "Kullancı ad")
            {
                USERNAME.Text = "";
                USERNAME.ForeColor = Color.Black;
            }
        }

        private void USERNAME_Leave(object sender, EventArgs e)
        {

        }

        private void PASSWORD_Enter(object sender, EventArgs e)
        {

        }

        private void PASSWORD_Leave(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        private void BranchBox_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void BranchBox_Leave(object sender, EventArgs e)
        {

        }

        private void BranchBox_Move(object sender, EventArgs e)
        {
            BranchBox.Items.Clear();
        }

        private void BranchBox_Click(object sender, EventArgs e)
        {
            string sorgu = "Select distinct BRANCH from WorkerLogin";
            con = new SqlConnection(db.GetConnection());
            adapter = new SqlDataAdapter("Select distinct BRANCH from WorkerLogin where Branch", con);
            cmd = new SqlCommand(sorgu, con);
            con.Open();
            dr = cmd.ExecuteReader();
            BranchBox.Items.Clear();
            while (dr.Read())
            {
                 BranchBox.Items.Add(dr["Branch"].ToString());
            }
           
            
        }

        private void BranchBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void USERNAME_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}

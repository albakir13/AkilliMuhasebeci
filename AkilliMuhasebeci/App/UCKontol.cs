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

    public partial class UCKontol : UserControl
    {

        ConnectionDB db =new ConnectionDB();
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;

        App.UCMusteriler ucm;

        public UCKontol()
        {
            InitializeComponent();
            sell();
            balance();
            profit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MusteriEkle me = new MusteriEkle(ucm);
            me.Show();  
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CreateInvoice CR = new CreateInvoice();
            CR.Show();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void sell()
        {
            con = new SqlConnection(db.GetConnection());
            con.Open();
            String sellsAmount = "Select sum(Amount) from Faturalar";
            cmd = new SqlCommand(sellsAmount, con);

            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                label9.Text = reader.GetValue(0).ToString();
                
            }


            con.Close();
        }

        private void balance()
        {
            con = new SqlConnection(db.GetConnection());
            con.Open();
            String balance = "Select sum(Balance) from Faturalar";
            cmd = new SqlCommand(balance, con);

            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                label15.Text = reader.GetValue(0).ToString();

            }


            con.Close();
        }

        private void profit()
        {
            con = new SqlConnection(db.GetConnection());
            con.Open();
            String profit = "Select sum(Amount - Balance) from Faturalar";
            cmd = new SqlCommand(profit, con);

            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                label7.Text = reader.GetValue(0).ToString();

            }

            con.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            sell();
            balance();
            profit();
        }
    }
    
}

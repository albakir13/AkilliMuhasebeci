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

namespace AkilliMuhasebeci
{

    public partial class MusteriEkle : Form
    {

        SqlCommand cmd;
        SqlDataReader dr;
        App.UCMusteriler ucm;

        public MusteriEkle(App.UCMusteriler ucm)
        {
            InitializeComponent();
            this.ucm = ucm;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Clear()
        {
            MAd.Clear();
            MSoyad.Clear();
            MTelefon.Clear();
            MEposta.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AkilliMuhasebeci;Integrated Security=True");
            con.Open();
            SqlCommand cmd =new SqlCommand("insert into Musteriler values (@MAdi, @MSoyadi, @MTNumarasi, @MEposta)", con);

            if (MAd.Text.Equals(""))
            {
                MessageBox.Show("Müşteri adını girmelisiniz..!");
                
            }
            else if (MSoyad.Text.Equals(""))
            {
                MessageBox.Show("Müşteri Soyadı girmelisiniz..!");

            }
            else if (MEposta.Text.Equals(""))
            {
                MessageBox.Show("Müşteri E-postasını girmelisiniz..!");

            }
            else if (MTelefon.Text.Equals(""))
            {
                MessageBox.Show("Müşteri Telefon numarasını girmelisiniz..!");

            }
            else
            {
                try
                {
                    cmd.Parameters.AddWithValue("@MAdi", MAd.Text);
                    cmd.Parameters.AddWithValue("@MSoyadi", MSoyad.Text);
                    cmd.Parameters.AddWithValue("@MEposta", MEposta.Text);
                    cmd.Parameters.AddWithValue("@MTNumarasi", MTelefon.Text);
                    cmd.ExecuteNonQuery();
                    //ucm.LoadRecords();
                    con.Close();
                    
                    MessageBox.Show("Müşteri Eklendi");
                    
                    Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
                
           

           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

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

namespace AkilliMuhasebeci
{
    public partial class EditCustomer : Form
    {

        ConnectionDB db =new ConnectionDB();
        SqlConnection con;
        SqlCommand cmd;
        App.UCMusteriler ucm;


        public EditCustomer()
        {
            InitializeComponent();
            this.ucm = ucm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(db.GetConnection());
            con.Open();
            cmd = new SqlCommand("Update Musteriler SET MAdi = @MAdi  ,  MSoyadi = @MSoyadi  ,  MTNumarasi = @MTNumarasi  ,  MEposta = @MEposta WHERE MID = @MID", con);
            cmd.Parameters.AddWithValue("@MID", EID.Text);
            cmd.Parameters.AddWithValue("@MAdi",MAd.Text);
            cmd.Parameters.AddWithValue("@MSoyadi", MSoyad.Text);
            cmd.Parameters.AddWithValue("@MTNumarasi", MTelefon.Text);
            cmd.Parameters.AddWithValue("@MEposta", MEposta.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            //ucm.LoadRecords();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

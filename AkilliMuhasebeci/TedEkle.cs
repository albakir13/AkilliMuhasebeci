using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AkilliMuhasebeci
{
    public partial class TedEkle : Form
    {
        App.UCTedarikciler utd;

        DataSet1TableAdapters.TedarikcilerTableAdapter dt = new DataSet1TableAdapters.TedarikcilerTableAdapter();
        int a;

       

        public TedEkle()
        {
            InitializeComponent();
            button3.Hide();
            Disable();
            textBox2.Text = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss");

        }
        public TedEkle(int a)
        {
            this.utd = utd;
           
            //dt.UpdateQuery(textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, int.Parse(Convert.ToInt32(App.UCTedarikciler.data.CurrentRow.Cells[0].Value.ToString()));
            InitializeComponent();
            Disable();
            button1.Hide();
        }


        

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dt.InsertQuery(textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);
            MessageBox.Show("Tedarikçi Eklendi");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss");
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
        }

        private void TedEkle_Load(object sender, EventArgs e)
        {

        }

        private void Disable()
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
        }
    }
}

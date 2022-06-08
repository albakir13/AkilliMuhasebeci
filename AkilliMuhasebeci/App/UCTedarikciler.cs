using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AkilliMuhasebeci.App
{
    public partial class UCTedarikciler : UserControl
    {
        public UCTedarikciler()
        {
            InitializeComponent();
            dataGridView1.DataSource = dt.GetData();  
        }
        DataSet1TableAdapters.TedarikcilerTableAdapter dt = new DataSet1TableAdapters.TedarikcilerTableAdapter();
        private void label2_Click(object sender, EventArgs e)
        {

        }

        public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TedEkle tedEkle = new TedEkle();
            tedEkle.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dt.GetData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                dt.DeleteQuery(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString())); 
                dataGridView1.DataSource = dt.GetData();
                MessageBox.Show("Tedarikçe silendi");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TedEkle tedEkle = new TedEkle(1);
            tedEkle.ShowDialog();

        }

        public void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FFilter_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dt.GetDataBy3("%" + FFilter.Text + "%");
        }
    }

}

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
    public partial class UCMusteriler : UserControl
    {

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        ConnectionDB db = new ConnectionDB();
        DataTable dt = new DataTable();
        EditCustomer editCustomer;


        public UCMusteriler()
        {
            InitializeComponent();
            con = new SqlConnection(db.GetConnection());
            LoadRecords();
            //fillData();
            //getData();
        }


        private void UCMusteriler_Load(object sender, EventArgs e)
        {
            
           
        }

        private void CustomerPanel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        // ---------------- Methods -----------------
        
        public void LoadRecords()
        {
            
            try
            {
                MDataPanel.Rows.Clear();

                con.Open();
                cmd = new SqlCommand("select * from Musteriler", con); //MID as 'Müşteri No.', MAdi as 'Müşteri Adı', MSoyadi as 'Müşteri Soyadı', MTNumarasi as 'Müşteri Numarası', MEposta as 'Müşteri E-posta'

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    MDataPanel.Rows.Add(dr["MID"].ToString(), dr["MAdi"].ToString(), dr["MSoyadi"].ToString(),
                        dr["MTNumarasi"].ToString(), dr["MEposta"].ToString());
                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);    
            }
            
            
        }
        
        
        /*
        public void fillData()
        {
            MDataPanel.Rows.Clear();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand cmd;

            string sql = "select MID as 'Müşteri No.', MAdi as 'Müşteri Adı', MSoyadi as 'Müşteri Soyadı', MTNumarasi as 'Müşteri Numarası', MEposta as 'Müşteri E-posta' from Musteriler";
            cmd = new SqlCommand(sql, con);
            adapter.SelectCommand = cmd;

            adapter.Fill(dt);

            MDataPanel.DataSource = dt;
        }
        */
        /*
        public void getData()
        {
            try
            {
                con = new SqlConnection(db.GetConnection());
                con.Open();
                cmd = new SqlCommand("select MID as 'Müşteri No.', MAdi as 'Müşteri Adı', MSoyadi as 'Müşteri Soyadı', MTNumarasi as 'Müşteri Numarası', MEposta as 'Müşteri E-posta' from Musteriler", con);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                MDataPanel.Rows.Clear();
                while (dr.Read() == true)
                {
                    MDataPanel.Rows.Add(dr[0], dr[1]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        */

        public void search()
        { 
            con = new SqlConnection(db.GetConnection());
            con.Open();
            cmd = new SqlCommand("Select * From Musteriler Where MTNumarasi like '%" + Mfilter.Text + "%'", con);
            
            if (Mfilter.Text.Length > 0)
            {
                dr = cmd.ExecuteReader();
                dr.Read();
            }
            
            dr.Close();
            con.Close(); 
        }

        //----------------------- Buttons -----------------------


        private void button1_Click(object sender, EventArgs e)
        {
            MusteriEkle ME = new MusteriEkle(this);
            ME.Show();  
        }

        private void button2_Click(object sender, EventArgs e)
        {
          

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            try
            {
                String msg = "Silmek ister misin?";
                String caption = "Müşteri Silmek";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBoxIcon ico = MessageBoxIcon.Question;
                DialogResult result;
                result = MessageBox.Show(this, msg, caption, buttons, ico);
                if (result == DialogResult.Yes)
                {
                    foreach (DataGridViewRow item in this.MDataPanel.SelectedRows)
                    {
                        using (SqlConnection con = new SqlConnection(db.GetConnection()))
                        {
                            SqlCommand cmd = con.CreateCommand();
                            int id = Convert.ToInt32(MDataPanel.SelectedRows[0].Cells[0].Value);
                            cmd.CommandText = "Delete from Musteriler where MID ='" + id + "'";

                            MDataPanel.Rows.RemoveAt(this.MDataPanel.SelectedRows[0].Index);
                            con.Open();
                            cmd.ExecuteNonQuery();

                            
                        }

                    }
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Başarsız silme:" + ex.Message.ToString(), "Sil",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        private void button4_Click(object sender, EventArgs e)
        {
            
            try
            {
                DataView dv = new DataView(dt);
                dv.RowFilter = string.Format("MTNumarasi LIKE '%{0}%'", Mfilter.Text);
                MDataPanel.ClearSelection();
                MDataPanel.DataSource = dv;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            } 
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void MDataPanel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = MDataPanel.Columns[e.ColumnIndex].Name;
            editCustomer = new EditCustomer();
            if (colName == "colEdit")
            {
                editCustomer.EID.Text = MDataPanel.Rows[e.RowIndex].Cells[0].Value.ToString();
                editCustomer.MAd.Text = MDataPanel.Rows[e.RowIndex].Cells[1].Value.ToString();
                editCustomer.MSoyad.Text = MDataPanel.Rows[e.RowIndex].Cells[2].Value.ToString();
                editCustomer.MTelefon.Text = MDataPanel.Rows[e.RowIndex].Cells[3].Value.ToString();
                editCustomer.MEposta.Text = MDataPanel.Rows[e.RowIndex].Cells[4].Value.ToString();
                editCustomer.EID.Enabled = false;
                editCustomer.ShowDialog();

            }




        }

        private void Mfilter_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            LoadRecords();
        }
    }
}

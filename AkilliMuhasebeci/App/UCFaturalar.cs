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
    public partial class UCFaturalar : UserControl
    {

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        ConnectionDB db = new ConnectionDB();
        DataTable dt = new DataTable();
        SqlDataAdapter adapter;
        DataView dv;


        public UCFaturalar()
        {
            InitializeComponent();
            con = new SqlConnection(db.GetConnection());
            con.Open();
            LoadRecords();

        }

        private void UCFaturalar_Load(object sender, EventArgs e)
        {
            
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void fillData()
        {  
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand cmd;

            string sql = "select FaturaID as 'Fatura No',  DateofCreation as 'Oluşturma Tarihi',AccrualDay as 'Tahakkuk Günü',CustomerName as 'Müşteri Adı',Amount as 'Tutar',Balance as 'Bakiye',Status as 'Durumu' from Faturalar";
            cmd = new SqlCommand(sql, con);
            adapter.SelectCommand = cmd;

            adapter.Fill(dt);

            FDataPanel.DataSource = dt;
        }


        public void LoadRecords()
        {
            FDataPanel.Rows.Clear();

            try
            {
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                
                cmd = new SqlCommand("select FaturaID AS 'Fatura No',  DateofCreation AS 'Oluşturma Tarihi',AccrualDay AS 'Tahakkuk Günü',CustomerName AS 'Müşteri Adı',Amount AS 'Tutar',Balance AS 'Bakiye',Status AS 'Durumu' from Faturalar", con); //select FaturaID as 'Fatura No',  DateofCreation as 'Oluşturma Tarihi',AccrualDay as 'Tahakkuk Günü',CustomerName as 'Müşteri Adı',Amount as 'Tutar',Balance as 'Bakiye',Status as 'Durumu' from Faturalar

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    FDataPanel.Rows.Add(dr["Fatura No"].ToString(), dr["Oluşturma Tarihi"].ToString(), dr["Tahakkuk Günü"].ToString(),
                        dr["Müşteri Adı"].ToString(), dr["Tutar"].ToString(), dr["Bakiye"].ToString(), dr["Durumu"].ToString());
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }



        private void button1_Click(object sender, EventArgs e)
        {
            CreateInvoice CR = new CreateInvoice();
            CR.Show();
        }

        private void FFilter_EnabledChanged(object sender, EventArgs e)
        {
            
        }

        private void FFilter_TextChanged(object sender, EventArgs e)
        {

        }

        private void Search() 
        {
            try
            {
                DataView dv = new DataView(dt);
                dv.RowFilter = string.Format("FaturaID LIKE '%{0}%'", FFilter.Text);
                FDataPanel.ClearSelection();
                FDataPanel.DataSource = dv;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void FFilter_Enter(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadRecords();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            try
            {
                String msg = "Silmek ister misin?";
                String caption = "Fatura Silmek";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBoxIcon ico = MessageBoxIcon.Question;
                DialogResult result;
                result = MessageBox.Show(this, msg, caption, buttons, ico);
                if (result == DialogResult.Yes)
                {
                    foreach (DataGridViewRow item in this.FDataPanel.SelectedRows)
                    {
                        using (SqlConnection con = new SqlConnection(db.GetConnection()))
                        {
                            SqlCommand cmd = con.CreateCommand();
                            int id = Convert.ToInt32(FDataPanel.SelectedRows[0].Cells[0].Value);
                            cmd.CommandText = "Delete from Faturalar where FaturaID ='" + id + "'";

                            FDataPanel.Rows.RemoveAt(this.FDataPanel.SelectedRows[0].Index);
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
    }
    
}

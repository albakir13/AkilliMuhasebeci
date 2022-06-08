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

    public partial class CreateInvoice : Form
    {

        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adapter; 
        SqlDataReader reader;
        DataTable dt = new DataTable();
        ConnectionDB db = new ConnectionDB();


        public CreateInvoice()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Clear()
        {
           
            CustomerName.Clear();
            Amount.Clear();
            Balance.Clear();
            Status.Equals("");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(db.GetConnection());
            con.Open();
            cmd = new SqlCommand("INSERT INTO Faturalar values (@DateofCreation,@AccrualDay,@CustomerName,@Amount,@Balance,@Status)", con);

            try
            {
                cmd.Parameters.AddWithValue("@DateofCreation", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@AccrualDay", dateTimePicker2.Value);
                cmd.Parameters.AddWithValue("@CustomerName", CustomerName.Text);
                cmd.Parameters.AddWithValue("@Amount", Amount.Text);
                cmd.Parameters.AddWithValue("@Balance", Balance.Text);
                cmd.Parameters.AddWithValue("@Status", Status.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Fatura Eklendi");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            con.Close();

            Clear();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

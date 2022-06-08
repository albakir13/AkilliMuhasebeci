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
    public partial class Users : Form
    {

        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adapter = new SqlDataAdapter();
        SqlDataReader dr;
        DataTable dt = new DataTable();
        ConnectionDB db = new ConnectionDB();


        public Users()
        {
            InitializeComponent();
            LoadRecords();
            IDNO.Enabled = false;
        }

        private void Users_Load(object sender, EventArgs e)
        {

        }
        public void LoadRecords()
        {

            try
            {
                UsersDataPanel.Rows.Clear();
                con = new SqlConnection(db.GetConnection());
                con.Open();
                cmd = new SqlCommand("Select * from WorkerLogin", con); 

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    UsersDataPanel.Rows.Add(dr["ID"].ToString(), dr["USERNAME"].ToString(), dr["PASSWORD"].ToString(),
                        dr["BRANCH"].ToString(), dr["PERMISSION"].ToString());
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
            con = new SqlConnection(db.GetConnection());
            String usersTable = "Select * from WorkerLogin";
            cmd = new SqlCommand(usersTable,con);
            adapter.SelectCommand = cmd;
            adapter.Fill(dt);  
            UsersDataPanel.DataSource = dt; 
            UsersDataPanel.Refresh();
        }
        */
        /*
        private void updateData()
        {
            UsersDataPanel.Update
            con = new SqlConnection(db.GetConnection());
            String usersTable = "Select * from WorkerLogin";
            cmd = new SqlCommand(usersTable, con);
            adapter.SelectCommand = cmd;
            adapter.Fill(dt);
            UsersDataPanel.DataSource = dt;
        }
        */

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(db.GetConnection());
                con.Open();
                String addUser = "insert into WorkerLogin values (@USERNAME, @PASSWORD, @BRANCH, @PERMISSION)";
                cmd = new SqlCommand(addUser, con);
                cmd.Parameters.AddWithValue("@USERNAME", EUser.Text);
                cmd.Parameters.AddWithValue("@PASSWORD", EPassword.Text);
                cmd.Parameters.AddWithValue("@BRANCH", EBranch.Text);
                cmd.Parameters.AddWithValue("@PERMISSION", EPermission.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                LoadRecords();
                Clear();
                MessageBox.Show("kullanıcı eklendi");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }

        private void Clear()
        {
            IDNO.Clear();
            EUser.Clear();
            EPassword.Clear();
            EBranch.Clear();
            EPermission.Equals("");
        }

        private void UsersDataPanel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                String msg = "Silmek ister misin?";
                String caption = "User Silmek";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBoxIcon ico = MessageBoxIcon.Question;
                DialogResult result;
                result = MessageBox.Show(this, msg, caption, buttons, ico);
                if (result == DialogResult.Yes)
                {
                    foreach (DataGridViewRow item in this.UsersDataPanel.SelectedRows)
                    {
                        using (SqlConnection con = new SqlConnection(db.GetConnection()))
                        {
                            SqlCommand cmd = con.CreateCommand();
                            int id = Convert.ToInt32(UsersDataPanel.SelectedRows[0].Cells[0].Value);
                            cmd.CommandText = "Delete from WorkerLogin where ID ='" + id + "'";

                            UsersDataPanel.Rows.RemoveAt(this.UsersDataPanel.SelectedRows[0].Index);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            Clear();

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
            con = new SqlConnection(db.GetConnection());
            con.Open();
            String updateUser = "Update WorkerLogin set USERNAME = @USERNAME, PASSWORD = @PASSWORD, BRANCH = @BRANCH, PERMISSION = @PERMISSION where ID = @ID";
            cmd = new SqlCommand(updateUser, con);

            cmd.Parameters.AddWithValue("@USERNAME", EUser.Text);
            cmd.Parameters.AddWithValue("@PASSWORD", EPassword.Text);
            cmd.Parameters.AddWithValue("@BRANCH", EBranch.Text);
            cmd.Parameters.AddWithValue("@PERMISSION", EPermission.Text);
            cmd.Parameters.AddWithValue("@ID",IDNO.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            LoadRecords();  
            Clear();
        }

        private void UsersDataPanel_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                int i;

                i = e.RowIndex;
                IDNO.Text = UsersDataPanel.Rows[i].Cells[0].Value.ToString();
                EUser.Text = UsersDataPanel.Rows[i].Cells[1].Value.ToString();
                EPassword.Text = UsersDataPanel.Rows[i].Cells[2].Value.ToString();
                EBranch.Text = UsersDataPanel.Rows[i].Cells[3].Value.ToString();
                EPermission.Text = UsersDataPanel.Rows[i].Cells[4].Value.ToString();
            }
            catch (Exception ex)
            {
                 MessageBox.Show(ex.Message);
            }
           
        }
    }
}

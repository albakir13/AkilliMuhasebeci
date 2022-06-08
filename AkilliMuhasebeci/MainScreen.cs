using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AkilliMuhasebeci.App;
using System.Data.SqlClient;

namespace AkilliMuhasebeci
{
    public partial class MainScreen : Form
    {

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter adapter;
        ConnectionDB db = new ConnectionDB();
        DataTable dt = new DataTable();


        private UCAyarlar uCAyarlar;
        private UCBanka uCBanka;
        private UCFaturalar uCFaturalar;
        private UCKontol uCKontol;
        private UCMagaza uCMagaza;
        private UCMasraflar uCMasraflar;
        private UCMuhasebe uCMuhasebe;
        private UCMusteriler uCMusteriler;
        private UCOdemeler uCOdemeler;
        private UCPazarlama uCPazarlama;
        private UCRaporlar uCRaporlar;
        private UCSiparisB uCSiparisB;
        private UCTedarikciler uCTedarikciler;
        private UCTeklifler uCTeklifler;


        LoginScreen login = new LoginScreen();

        public MainScreen()
        {
            InitializeComponent();
        }

        String Username;
        String Branch;
        String Permission;
        public MainScreen(String s,String b, String per)
        {
            InitializeComponent();
            Username = s;
            Branch = b;
            Permission = per;
            TUsername.Text = Username;
            TBranch.Text = Branch;
            //TPermission.Text = Permission;
            permisson();

        }


        internal void togglePanelMain(string panelName)
        {
            this.panel3.Controls.Clear();
            switch (panelName)
            {
                case "kontrol":
                    if (this.uCKontol == null)
                    {
                        this.uCKontol = new UCKontol();
                        this.panel3.Controls.Add(uCKontol);
                        this.uCKontol.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.uCKontol.Location = new System.Drawing.Point(0, 0);
                        this.uCKontol.Name = "uCKontrol";
                        this.uCKontol.Size = new System.Drawing.Size(250, 766);
                        this.uCKontol.TabIndex = 0;
                    }
                    else
                    {
                        this.panel3.Controls.Add(uCKontol);
                    }
                    break;



                case "musteriler":
                    if (this.uCMusteriler == null)
                    {
                        this.uCMusteriler = new UCMusteriler();
                        this.panel3.Controls.Add(uCMusteriler);
                        this.uCMusteriler.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.uCMusteriler.Location = new System.Drawing.Point(0, 0);
                        this.uCMusteriler.Name = "uCMusteriler";
                        this.uCMusteriler.Size = new System.Drawing.Size(250, 766);
                        this.uCMusteriler.TabIndex = 0;
                    }
                    else
                    {
                        this.panel3.Controls.Add(uCMusteriler);
                    }
                    break;


                case "tedarikciler":
                    if (this.uCTedarikciler == null)
                    {
                        this.uCTedarikciler = new UCTedarikciler();
                        this.panel3.Controls.Add(uCTedarikciler);
                        this.uCTedarikciler.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.uCTedarikciler.Location = new System.Drawing.Point(0, 0);
                        this.uCTedarikciler.Name = "uCTedarikciler";
                        this.uCTedarikciler.Size = new System.Drawing.Size(250, 766);
                        this.uCTedarikciler.TabIndex = 0;
                    }
                    else
                    {
                        this.panel3.Controls.Add(uCTedarikciler);
                    }
                    break;


                case "teklifler":
                    if (this.uCTeklifler == null)
                    {
                        this.uCTeklifler = new UCTeklifler();
                        this.panel3.Controls.Add(uCTeklifler);
                        this.uCTeklifler.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.uCTeklifler.Location = new System.Drawing.Point(0, 0);
                        this.uCTeklifler.Name = "uCTeklifler";
                        this.uCTeklifler.Size = new System.Drawing.Size(250, 766);
                        this.uCTeklifler.TabIndex = 0;
                    }
                    else
                    {
                        this.panel3.Controls.Add(uCTeklifler);
                    }
                    break;


                case "faturalar":
                    if (this.uCFaturalar == null)
                    {
                        this.uCFaturalar = new UCFaturalar();
                        this.panel3.Controls.Add(uCFaturalar);
                        this.uCFaturalar.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.uCFaturalar.Location = new System.Drawing.Point(0, 0);
                        this.uCFaturalar.Name = "uCFaturalar";
                        this.uCFaturalar.Size = new System.Drawing.Size(250, 766);
                        this.uCFaturalar.TabIndex = 0;
                    }
                    else
                    {
                        this.panel3.Controls.Add(uCFaturalar);
                    }
                    break;


                case "siparisBelgesi":
                    if (this.uCSiparisB == null)
                    {
                        this.uCSiparisB = new UCSiparisB();
                        this.panel3.Controls.Add(uCSiparisB);
                        this.uCSiparisB.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.uCSiparisB.Location = new System.Drawing.Point(0, 0);
                        this.uCSiparisB.Name = "uCSiparisB";
                        this.uCSiparisB.Size = new System.Drawing.Size(250, 766);
                        this.uCSiparisB.TabIndex = 0;
                    }
                    else
                    {
                        this.panel3.Controls.Add(uCSiparisB);
                    }
                    break;


                case "odemeler":
                    if (this.uCOdemeler == null)
                    {
                        this.uCOdemeler = new UCOdemeler();
                        this.panel3.Controls.Add(uCOdemeler);
                        this.uCOdemeler.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.uCOdemeler.Location = new System.Drawing.Point(0, 0);
                        this.uCOdemeler.Name = "uCOdemeler";
                        this.uCOdemeler.Size = new System.Drawing.Size(250, 766);
                        this.uCOdemeler.TabIndex = 0;
                    }
                    else
                    {
                        this.panel3.Controls.Add(uCOdemeler);
                    }
                    break;


                case "magaza":
                    if (this.uCMagaza == null)
                    {
                        this.uCMagaza = new UCMagaza();
                        this.panel3.Controls.Add(uCMagaza);
                        this.uCMagaza.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.uCMagaza.Location = new System.Drawing.Point(0, 0);
                        this.uCMagaza.Name = "uCMagaza";
                        this.uCMagaza.Size = new System.Drawing.Size(250, 766);
                        this.uCMagaza.TabIndex = 0;
                    }
                    else
                    {
                        this.panel3.Controls.Add(uCMagaza);
                    }
                    break;


                case "masraflar":
                    if (this.uCMasraflar == null)
                    {
                        this.uCMasraflar = new UCMasraflar();
                        this.panel3.Controls.Add(uCMasraflar);
                        this.uCMasraflar.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.uCMasraflar.Location = new System.Drawing.Point(0, 0);
                        this.uCMasraflar.Name = "uCMasraflar";
                        this.uCMasraflar.Size = new System.Drawing.Size(250, 766);
                        this.uCMasraflar.TabIndex = 0;
                    }
                    else
                    {
                        this.panel3.Controls.Add(uCMasraflar);
                    }
                    break;


                case "banka":
                    if (this.uCBanka == null)
                    {
                        this.uCBanka = new UCBanka();
                        this.panel3.Controls.Add(uCBanka);
                        this.uCBanka.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.uCBanka.Location = new System.Drawing.Point(0, 0);
                        this.uCBanka.Name = "uCBanka";
                        this.uCBanka.Size = new System.Drawing.Size(250, 766);
                        this.uCBanka.TabIndex = 0;
                    }
                    else
                    {
                        this.panel3.Controls.Add(uCBanka);
                    }
                    break;


                case "pazarlama":
                    if (this.uCPazarlama == null)
                    {
                        this.uCPazarlama = new UCPazarlama();
                        this.panel3.Controls.Add(uCPazarlama);
                        this.uCPazarlama.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.uCPazarlama.Location = new System.Drawing.Point(0, 0);
                        this.uCPazarlama.Name = "uCPazarlama";
                        this.uCPazarlama.Size = new System.Drawing.Size(250, 766);
                        this.uCPazarlama.TabIndex = 0;
                    }
                    else
                    {
                        this.panel3.Controls.Add(uCPazarlama);
                    }
                    break;



                case "raporlar":
                    if (this.uCRaporlar == null)
                    {
                        this.uCRaporlar = new UCRaporlar();
                        this.panel3.Controls.Add(uCRaporlar);
                        this.uCRaporlar.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.uCRaporlar.Location = new System.Drawing.Point(0, 0);
                        this.uCRaporlar.Name = "uCRaporlar";
                        this.uCRaporlar.Size = new System.Drawing.Size(250, 766);
                        this.uCRaporlar.TabIndex = 0;
                    }
                    else
                    {
                        this.panel3.Controls.Add(uCRaporlar);
                    }
                    break;


                case "muhasebe":
                    if (this.uCMuhasebe == null)
                    {
                        this.uCMuhasebe = new UCMuhasebe();
                        this.panel3.Controls.Add(uCMuhasebe);
                        this.uCMuhasebe.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.uCMuhasebe.Location = new System.Drawing.Point(0, 0);
                        this.uCMuhasebe.Name = "uCMuhasebe";
                        this.uCMuhasebe.Size = new System.Drawing.Size(250, 766);
                        this.uCMuhasebe.TabIndex = 0;
                    }
                    else
                    {
                        this.panel3.Controls.Add(uCMuhasebe);
                    }
                    break;



                case "ayarlar":
                    if (this.uCAyarlar == null)
                    {
                        this.uCAyarlar = new UCAyarlar();
                        this.panel3.Controls.Add(uCAyarlar);
                        this.uCAyarlar.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.uCAyarlar.Location = new System.Drawing.Point(0, 0);
                        this.uCAyarlar.Name = "uCAyarlar";
                        this.uCAyarlar.Size = new System.Drawing.Size(250, 766);
                        this.uCAyarlar.TabIndex = 0;
                    }
                    else
                    {
                        this.panel3.Controls.Add(uCAyarlar);
                    }
                    break;


                default:
                    break;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginScreen Login_Screen = new LoginScreen();
            this.Hide();
            Login_Screen.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.togglePanelMain("kontrol");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.togglePanelMain("musteriler");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.togglePanelMain("tedarikciler");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.togglePanelMain("teklifler");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.togglePanelMain("faturalar");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.togglePanelMain("siparisBelgesi");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.togglePanelMain("odemeler");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.togglePanelMain("magaza");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.togglePanelMain("masraflar");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.togglePanelMain("banka");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.togglePanelMain("pazarlama");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.togglePanelMain("raporlar");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.togglePanelMain("muhasebe");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            this.togglePanelMain("ayarlar");
        }

        private void panel3_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void panel3_MouseHover(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            login.Show();
            this.Close();
        }

        private void permisson()
        {
            /*
            con = new SqlConnection(db.GetConnection());
            con.Open();
            string permisson = "Select Permission form WorkerLogin";
            adapter = new SqlDataAdapter("Select Permission form WorkerLogin",con);
            cmd = new SqlCommand(permisson, con);
            adapter.SelectCommand = cmd;
            adapter.Fill(dt);
            
            TPermission.Text = dt.ToString();
            */
            
            
            /*
            if (Username != "admin")
            {
                BMasraflar.Hide();
                BPazarlama.Hide();
                BBanka.Hide();
                BRaporlar.Hide();
                BMuhasebe.Hide();
                BAyarlar.Hide();
            }
            */

            if(ConnectionDB.PERMISSION == "Admin")
            {

            }
            else if (ConnectionDB.PERMISSION == "Accounter")
            {
                BRaporlar.Hide();
                BAyarlar.Hide();
            }
            else if (ConnectionDB.PERMISSION == "Worker")
            {
                BMasraflar.Hide();
                BPazarlama.Hide();
                BBanka.Hide();
                BRaporlar.Hide();
                BMuhasebe.Hide();
                BAyarlar.Hide();
            }



        }

        private void TUsername_Click(object sender, EventArgs e)
        {

        }
    }
}

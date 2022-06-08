namespace AkilliMuhasebeci
{
    public partial class SplchScreen : Form
    {
        public SplchScreen()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            panel2.Width += 3;

            if (panel2.Width >= 221)
            {
                timer1.Stop();
                LoginScreen fm2 = new LoginScreen();
                fm2.Show();
                this.Hide();
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            this.BackColor = Color.LightSkyBlue;
            this.TransparencyKey = Color.LightSkyBlue;
        }
    }
}
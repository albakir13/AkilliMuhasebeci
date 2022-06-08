namespace AkilliMuhasebeci
{
    partial class LoginScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginScreen));
            this.label1 = new System.Windows.Forms.Label();
            this.USERNAME = new System.Windows.Forms.TextBox();
            this.PASSWORD = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.BranchBox = new System.Windows.Forms.ComboBox();
            this.permis = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(107, 331);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 15);
            this.label1.TabIndex = 0;
            // 
            // USERNAME
            // 
            this.USERNAME.Location = new System.Drawing.Point(127, 351);
            this.USERNAME.Name = "USERNAME";
            this.USERNAME.Size = new System.Drawing.Size(188, 23);
            this.USERNAME.TabIndex = 1;
            this.USERNAME.TextChanged += new System.EventHandler(this.USERNAME_TextChanged);
            this.USERNAME.Enter += new System.EventHandler(this.USERNAME_Enter);
            // 
            // PASSWORD
            // 
            this.PASSWORD.Location = new System.Drawing.Point(127, 389);
            this.PASSWORD.Name = "PASSWORD";
            this.PASSWORD.Size = new System.Drawing.Size(188, 23);
            this.PASSWORD.TabIndex = 2;
            this.PASSWORD.UseSystemPasswordChar = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(240, 429);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Giriş yap";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(127, 429);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Kapat";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // BranchBox
            // 
            this.BranchBox.FormattingEnabled = true;
            this.BranchBox.Location = new System.Drawing.Point(127, 310);
            this.BranchBox.Name = "BranchBox";
            this.BranchBox.Size = new System.Drawing.Size(188, 23);
            this.BranchBox.TabIndex = 5;
            this.BranchBox.SelectedIndexChanged += new System.EventHandler(this.BranchBox_SelectedIndexChanged);
            this.BranchBox.Click += new System.EventHandler(this.BranchBox_Click);
            // 
            // permis
            // 
            this.permis.AutoSize = true;
            this.permis.BackColor = System.Drawing.Color.Transparent;
            this.permis.ForeColor = System.Drawing.Color.Transparent;
            this.permis.Location = new System.Drawing.Point(0, 489);
            this.permis.Name = "permis";
            this.permis.Size = new System.Drawing.Size(38, 15);
            this.permis.TabIndex = 6;
            this.permis.Text = "label2";
            // 
            // LoginScreen
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(414, 504);
            this.Controls.Add(this.BranchBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.PASSWORD);
            this.Controls.Add(this.USERNAME);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.permis);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox PASSWORD;
        private Button button1;
        private Button button2;
        private ComboBox BranchBox;
        public TextBox USERNAME;
        private Label permis;
    }
}
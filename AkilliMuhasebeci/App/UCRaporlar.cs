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
    public partial class UCRaporlar : UserControl
    {

        public UCRaporlar()
        {
            InitializeComponent();
  
        }

        private void UCRaporlar_Load(object sender, EventArgs e)
        {
            
        }

        private void chBox()
        {
            if (checkBox1.Checked)
            {
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
                checkBox5.Enabled = false;
                checkBox6.Enabled = false;
                checkBox7.Enabled = false;
            }
            else if (checkBox2.Checked)
            {
                checkBox1.Enabled = false;
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
                checkBox5.Enabled = false;
                checkBox6.Enabled = false;
                checkBox7.Enabled = false;
            }
            else if (checkBox3.Checked)
            {
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
                checkBox4.Enabled = false;
                checkBox5.Enabled = false;
                checkBox6.Enabled = false;
                checkBox7.Enabled = false;
            }
            else if (checkBox4.Checked)
            {
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                checkBox5.Enabled = false;
                checkBox6.Enabled = false;
                checkBox7.Enabled = false;
            }
            else if (checkBox5.Checked)
            {
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
                checkBox6.Enabled = false;
                checkBox7.Enabled = false;
            }
            else if (checkBox6.Checked)
            {
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
                checkBox5.Enabled = false;
                checkBox7.Enabled = false;
            }
            else if (checkBox7.Checked)
            {
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
                checkBox5.Enabled = false;
                checkBox6.Enabled = false;
            }
            else
            {
                checkBox1.Enabled = true;
                checkBox2.Enabled = true;
                checkBox3.Enabled = true;
                checkBox4.Enabled = true;
                checkBox5.Enabled = true;
                checkBox6.Enabled = true;
                checkBox7.Enabled = true;
            }
        }


        

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            chBox();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            chBox();

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            chBox();

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            chBox();

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            chBox();

        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            chBox();

        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            chBox();

        }

        private void aramaif()
        {

            if (comboBox1.Equals("Tarih Arası"))
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
            }
            else if(comboBox1.Equals(""))
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
            }
            else
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            aramaif();
        }
    }
}

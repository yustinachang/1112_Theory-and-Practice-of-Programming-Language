using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {

        public Form2 preForm;
        public Form3()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.preForm.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.preForm.preForm.Close();
            this.preForm.Close();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Enabled = checkBox5.Checked;
            if (groupBox2.Enabled == false)
            {
                radioButton1.Checked = false;
                radioButton2.Checked = false;
            }

        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            groupBox3.Enabled = checkBox6.Checked;
            if (groupBox3.Enabled == false)
            {
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                radioButton5.Checked = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked) textBox1.Text = "" + (Convert.ToInt32(textBox1.Text) + 69);
            else textBox1.Text = "" + (Convert.ToInt32(textBox1.Text) - 69);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked) textBox1.Text = "" + (Convert.ToInt32(textBox1.Text) + 49);
            else textBox1.Text = "" + (Convert.ToInt32(textBox1.Text) - 49);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked) textBox1.Text = "" + (Convert.ToInt32(textBox1.Text) + 59);
            else textBox1.Text = "" + (Convert.ToInt32(textBox1.Text) - 59);
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked) textBox1.Text = "" + (Convert.ToInt32(textBox1.Text) + 79);
            else textBox1.Text = "" + (Convert.ToInt32(textBox1.Text) - 79);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked) textBox1.Text = "" + (Convert.ToInt32(textBox1.Text) + 35);
            else textBox1.Text = "" + (Convert.ToInt32(textBox1.Text) - 35);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked) textBox1.Text = "" + (Convert.ToInt32(textBox1.Text) + 25);
                 else textBox1.Text = "" + (Convert.ToInt32(textBox1.Text) - 25);
            }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked) textBox1.Text = "" + (Convert.ToInt32(textBox1.Text) + 35);
                 else textBox1.Text = "" + (Convert.ToInt32(textBox1.Text) - 35);
            }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked) textBox1.Text = "" + (Convert.ToInt32(textBox1.Text) + 25);
                 else textBox1.Text = "" + (Convert.ToInt32(textBox1.Text) - 25);
            }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked) textBox1.Text = "" + (Convert.ToInt32(textBox1.Text) + 45);
                 else textBox1.Text = "" + (Convert.ToInt32(textBox1.Text) - 45);
            }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}

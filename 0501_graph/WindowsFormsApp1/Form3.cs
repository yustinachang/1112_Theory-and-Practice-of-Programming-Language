using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public Form1 preForm; 
        public void getData(out string name, out string picture, out double length, out double width)
        {
            name = textBox1.Text;
            picture = textBox2.Text;
            length = Convert.ToDouble(textBox3.Text);
            width = Convert.ToDouble(textBox4.Text);
        }
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        { 
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}

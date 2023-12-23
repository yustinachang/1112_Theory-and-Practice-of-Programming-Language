using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Excle檔案(*.csv)|*.csv";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName, Encoding.Default);
                string[] input = new string[4];
                string[] name = new string[100];
                int[] num = new int[100];
                double[,] coordinate = new double[100, 2];
                double x = Convert.ToDouble(textBox2.Text);
                double y = Convert.ToDouble(textBox3.Text);
                int i;
                for(i = 0; sr.Peek() >= 0; i++)
                {
                    input = sr.ReadLine().Split(',');
                    name[i] = input[0];
                    num[i] = Convert.ToInt32(input[1]);
                    coordinate[i, 0] = Convert.ToDouble(input[2]);
                    coordinate[i, 1] = Convert.ToDouble(input[3]);
                }
                sr.Close();
                //ShowData()
                int Counter = i;
                double t5 = 0, t6 = 0;
                textBox1.Text = "姓名\t需求量\tX座標\t\tY座標\r\n";
                for (i = 0; i < Counter; i++)
                {
                    textBox1.Text += (name[i] + "\t" + num[i] + "\t" + coordinate[i, 0] + "\t" + coordinate[i, 1] + "\r\n");
                    t5 += num[i];
                    t6 += Math.Sqrt(Math.Pow(coordinate[i, 0] - x, 2) + Math.Pow(coordinate[i, 1] - y, 2));
                }
                textBox4.Text = "" + Counter;
                textBox5.Text = "" + t5;
                textBox6.Text = "" + t6 / Counter;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        TextBox[] arr = new TextBox[15];
        int num = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            arr[0] = textBox3;
            arr[1] = textBox4;
            arr[2] = textBox5;
            arr[3] = textBox6;
            arr[4] = textBox7;
            arr[5] = textBox8;
            arr[6] = textBox9;
            arr[7] = textBox10;
            arr[8] = textBox11;
            arr[9] = textBox12;
            arr[10] = textBox13;
            arr[11] = textBox14;
            arr[12] = textBox15;
            arr[13] = textBox16;
            arr[14] = textBox17;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                textBox2.Text = "";
                if (num == 15) throw new Exception("堆積樹已滿");
                num++;
                arr[num - 1].Text = textBox1.Text;
                if (num > 1)
                {
                    for (int i = num - 1; Convert.ToInt32(arr[i].Text) > Convert.ToInt32(arr[(i - 1) / 2].Text); i = (i - 1) / 2)
                    {
                        string s = arr[i].Text;
                        arr[i].Text = arr[(i - 1) / 2].Text;
                        arr[(i - 1) / 2].Text = s;
                    }
                }
                textBox1.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤訊息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = "";
                textBox2.Text = "";
                if (num == 0) throw new Exception("堆積樹為空");
                textBox2.Text = arr[0].Text;
                arr[0].Text = arr[num - 1].Text;
                arr[num - 1].Text = "";
                num = num - 1;
                int i, t;
                for (i = 0; (i + 1) * 2 <= num; i = t)
                {
                    if (arr[(i + 1) * 2].Text == "")
                        t = (i + 1) * 2 - 1;
                    else
                    {
                        if (Convert.ToInt32(arr[(i + 1) * 2 - 1].Text) < Convert.ToInt32(arr[(i + 1) * 2].Text))
                            t = (i + 1) * 2;
                        else t = (i + 1) * 2 - 1;
                    }
                    if (Convert.ToInt32(arr[i].Text) < Convert.ToInt32(arr[t].Text))
                    {
                        string s = arr[t].Text;
                        arr[t].Text = arr[i].Text;
                        arr[i].Text = s;
                    }
                    else break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤訊息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

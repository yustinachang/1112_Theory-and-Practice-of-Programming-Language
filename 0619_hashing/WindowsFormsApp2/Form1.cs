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

        List<string>[] table = new List<string>[13];
        TextBox[] arr = new TextBox[13];

        private void Form1_Load(object sender, EventArgs e)
        {
            table[0] = new List<string>();
            table[1] = new List<string>();
            table[2] = new List<string>();
            table[3] = new List<string>();
            table[4] = new List<string>();
            table[5] = new List<string>();
            table[6] = new List<string>();
            table[7] = new List<string>();
            table[8] = new List<string>();
            table[9] = new List<string>();
            table[10] = new List<string>();
            table[11] = new List<string>();
            table[12] = new List<string>();
            arr[0] = textBox4;
            arr[1] = textBox5;
            arr[2] = textBox6;
            arr[3] = textBox7;
            arr[4] = textBox8;
            arr[5] = textBox9;
            arr[6] = textBox10;
            arr[7] = textBox11;
            arr[8] = textBox12;
            arr[9] = textBox13;
            arr[10] = textBox14;
            arr[11] = textBox15;
            arr[12] = textBox16;
        }
        public void printHash()
        {
            for (int i = 0; i < 13; i++)
                arr[i].Text = "";
            for (int i = 0; i < 13; i++)
                for (int j = 0; j < table[i].Count; j++)
                    arr[i].Text += " -> " + table[i][j];
        }
        void searchHash(string s, out string fold, out int total, out bool found)
        {
            fold = string.Empty;
            total = 0;
            found = false;

            int size = 3;
            for (int i = 0; i < s.Length; i += size)
            {
                string segment = s.Substring(i, Math.Min(size, s.Length - i));
                if ((i / size) % 2 == 1)
                {
                    char[] segmentChars = segment.ToCharArray();
                    Array.Reverse(segmentChars);
                    segment = new string(segmentChars);
                }
                fold += segment;
                total += Convert.ToInt32(segment);
            }
            if (table[total % 13].Contains(s)) found = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string str = textBox1.Text;
                searchHash(str, out string fold, out int total, out bool found);
                textBox2.Text = fold;
                textBox3.Text = total + " % 13 = " + total % 13;
                if (found) throw new Exception("授權碼" + str + "重複");
                else table[total % 13].Add(str);
                printHash();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "新增失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string str = textBox1.Text;
                searchHash(str, out string fold, out int total, out bool found);
                textBox2.Text = fold;
                textBox3.Text = total + " % 13 = " + total % 13;
                if (found) table[total % 13].Remove(str);
                else throw new Exception("授權碼" + str + "不存在");
                printHash();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "刪除失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string str = textBox1.Text;
                searchHash(str, out string fold, out int total, out bool found);
                textBox2.Text = fold;
                textBox3.Text = total + " % 13 = " + total % 13;
                if (found) throw new Exception("授權碼" + str + "正確");
                else throw new Exception("授權碼" + str + "不存在");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "查詢授權碼", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

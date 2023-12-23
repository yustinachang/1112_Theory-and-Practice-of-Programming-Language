using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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
        TextBox[,] board = new TextBox[10, 10];
        int[,] initial = new int[100, 100];
        int[,] shortest = new int[100, 100];
        private void Form1_Load(object sender, EventArgs e)
        {
            board[0, 0] = textBox1;
            board[0, 1] = textBox2;
            board[0, 2] = textBox3;
            board[0, 3] = textBox4;
            board[0, 4] = textBox5;
            board[0, 5] = textBox6;
            board[0, 6] = textBox7;
            board[0, 7] = textBox8;
            board[0, 8] = textBox9;
            board[0, 9] = textBox10;
            board[1, 0] = textBox11;
            board[1, 1] = textBox12;
            board[1, 2] = textBox13;
            board[1, 3] = textBox14; 
            board[1, 4] = textBox15; 
            board[1, 5] = textBox16;
            board[1, 6] = textBox17; 
            board[1, 7] = textBox18;
            board[1, 8] = textBox19;
            board[1, 9] = textBox20;
            board[2, 0] = textBox21;
            board[2, 1] = textBox22;
            board[2, 2] = textBox23;
            board[2, 3] = textBox24;
            board[2, 4] = textBox25;
            board[2, 5] = textBox26;
            board[2, 6] = textBox27;
            board[2, 7] = textBox28;
            board[2, 8] = textBox29;
            board[2, 9] = textBox30;
            board[3, 0] = textBox31;
            board[3, 1] = textBox32;
            board[3, 2] = textBox33;
            board[3, 3] = textBox34;
            board[3, 4] = textBox35;
            board[3, 5] = textBox36;
            board[3, 6] = textBox37;
            board[3, 7] = textBox38;
            board[3, 8] = textBox39;
            board[3, 9] = textBox40;
            board[4, 0] = textBox41;
            board[4, 1] = textBox42;
            board[4, 2] = textBox43;
            board[4, 3] = textBox44;
            board[4, 4] = textBox45;
            board[4, 5] = textBox46;
            board[4, 6] = textBox47;
            board[4, 7] = textBox48;
            board[4, 8] = textBox49;
            board[4, 9] = textBox50;
            board[5, 0] = textBox51;
            board[5, 1] = textBox52;
            board[5, 2] = textBox53;
            board[5, 3] = textBox54;
            board[5, 4] = textBox55;
            board[5, 5] = textBox56;
            board[5, 6] = textBox57;
            board[5, 7] = textBox58;
            board[5, 8] = textBox59;
            board[5, 9] = textBox60;
            board[6, 0] = textBox61;
            board[6, 1] = textBox62;
            board[6, 2] = textBox63;
            board[6, 3] = textBox64;
            board[6, 4] = textBox65;
            board[6, 5] = textBox66;
            board[6, 6] = textBox67;
            board[6, 7] = textBox68;
            board[6, 8] = textBox69;
            board[6, 9] = textBox70;
            board[7, 0] = textBox71;
            board[7, 1] = textBox72;
            board[7, 2] = textBox73;
            board[7, 3] = textBox74;
            board[7, 4] = textBox75;
            board[7, 5] = textBox76;
            board[7, 6] = textBox77;
            board[7, 7] = textBox78;
            board[7, 8] = textBox79;
            board[7, 9] = textBox80;
            board[8, 0] = textBox81;
            board[8, 1] = textBox82;
            board[8, 2] = textBox83;
            board[8, 3] = textBox84; 
            board[8, 4] = textBox85;
            board[8, 5] = textBox86;
            board[8, 6] = textBox87;
            board[8, 7] = textBox88;
            board[8, 8] = textBox89;
            board[8, 9] = textBox90;
            board[9, 0] = textBox91;
            board[9, 1] = textBox92;
            board[9, 2] = textBox93;
            board[9, 3] = textBox94;
            board[9, 4] = textBox95;
            board[9, 5] = textBox96;
            board[9, 6] = textBox97;
            board[9, 7] = textBox98;
            board[9, 8] = textBox99;
            board[9, 9] = textBox100;
        }

        void PrintRoute(int from, int to)
        {
            if (initial[from, to] == shortest[from, to])
                board[to / 10, to % 10].ForeColor = Color.Red;
            else
                for (int n = 0; n < 100; n++)
                    if (shortest[from, to] == initial[from, n] + shortest[n, to])
                    {
                        board[n / 10, n % 10].ForeColor = Color.Red;
                        PrintRoute(n,to);
                        return;
                    }
        }
        void myPrintRoute(int from, int to)
        {
            board[from / 10, from % 10].ForeColor = Color.Red;
            for (int n = 0; n < 100; n++)
                if (shortest[from, to] == initial[from, n] + shortest[n, to])
                {
                    myPrintRoute(n, to);
                    return;
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i, j, k;
            for (i = 0; i < 100; i++)
                for (j = 0; j < 100; j++)
                    initial[i, j] = 10000000;
            for (i = 0; i < 10; i++)
                for (j = 0; j < 10; j++)
                {
                    if (i < 9) initial[(i + 1) * 10 + j, i * 10 + j] = Convert.ToInt32(board[i, j].Text);
                    if (i > 0) initial[(i - 1) * 10 + j, i * 10 + j] = Convert.ToInt32(board[i, j].Text);
                    if (j < 9) initial[i * 10 + (j + 1), i * 10 + j] = Convert.ToInt32(board[i, j].Text);
                    if (j > 0) initial[i * 10 + (j - 1), i * 10 + j] = Convert.ToInt32(board[i, j].Text);
                }
            for (i = 0; i < 100; i++)
                for (j = 0; j < 100; j++)
                    shortest[i, j] = initial[i, j];
            for (k = 0; k < 100; k++)
                for (i = 0; i < 100; i++)
                    for (j = 0; j < 100; j++)
                        if (shortest[i, j] > shortest[i, k] + shortest[k, j]) shortest[i, j] = shortest[i, k] + shortest[k, j];
            textBox101.Text = Convert.ToString(shortest[0, 99] + Convert.ToInt32(board[0, 0].Text));
            myPrintRoute(0, 99);
            board[9, 9].ForeColor = Color.Red;
            //PrintRoute(0, 99);
            //board[0, 0].ForeColor = Color.Red;
        }

            private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "二元檔案(*.dat)|*.dat";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create);
                BinaryWriter bw = new BinaryWriter(fs);
                for (int i = 0; i < 5; i++)
                    for (int j = 0; j < 5; j++)
                        bw.Write(board[i, j].Text);
                bw.Flush();
                bw.Close();
                fs.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "二元檔案(*.dat)|*.dat";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open);
                BinaryReader br = new BinaryReader(fs);
                for (int i = 0; i < 10; i++)
                    for (int j = 0; j < 10; j++)
                    {
                        board[i, j].Text = br.ReadString();
                        board[i, j].ForeColor = Color.Black;
                    }
                br.Close();
                fs.Close();
            }
        }

    }
}

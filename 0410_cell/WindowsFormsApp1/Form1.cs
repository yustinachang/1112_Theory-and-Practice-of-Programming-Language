using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        CheckBox[,] cell = new CheckBox[5, 5];
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cell[0, 0] = checkBox1;
            cell[0, 1] = checkBox2;
            cell[0, 2] = checkBox3;
            cell[0, 3] = checkBox4;
            cell[0, 4] = checkBox5;
            cell[1, 0] = checkBox6;
            cell[1, 1] = checkBox7;
            cell[1, 2] = checkBox8;
            cell[1, 3] = checkBox9;
            cell[1, 4] = checkBox10;
            cell[2, 0] = checkBox11;
            cell[2, 1] = checkBox12;
            cell[2, 2] = checkBox13;
            cell[2, 3] = checkBox14;
            cell[2, 4] = checkBox15;
            cell[3, 0] = checkBox16;
            cell[3, 1] = checkBox17;
            cell[3, 2] = checkBox18;
            cell[3, 3] = checkBox19;
            cell[3, 4] = checkBox20;
            cell[4, 0] = checkBox21;
            cell[4, 1] = checkBox22;
            cell[4, 2] = checkBox23;
            cell[4, 3] = checkBox24;
            cell[4, 4] = checkBox25;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int[,] state = new int[5, 5];
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    state[i, j] = 0;
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    if (cell[i, j].Checked)
                    {
                        if (i > 0 && j > 0) state[i - 1, j - 1]++;
                        if (i > 0 && j < 4) state[i - 1, j + 1]++;
                        if (i < 4 && j > 0) state[i + 1, j - 1]++;
                        if (i < 4 && j < 4) state[i + 1, j + 1]++;
                        if (i > 0) state[i - 1, j]++;
                        if (i < 4) state[i + 1, j]++;
                        if (j > 0) state[i, j - 1]++;
                        if (j < 4) state[i, j + 1]++;
                    }
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    if (cell[i, j].Checked)
                    {
                        if (state[i, j] <= 1) cell[i, j].Checked = false;
                        if (state[i, j] >= 4) cell[i, j].Checked = false;
                    }
                    else
                    {
                        if (state[i, j] == 3) cell[i, j].Checked = true;
                    }
                }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "二元檔案(*.dat)|*.dat";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open);
                BinaryReader br = new BinaryReader(fs);
                for (int i = 0; br.PeekChar() >= 0; i++)
                    for(int j = 0; j < 5; j++)
                        cell[i, j].Checked = br.ReadBoolean();
                br.Close();
                fs.Close();
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "二元檔案(*.dat)|*.dat";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create);
                BinaryWriter bw = new BinaryWriter(fs);
                for (int i = 0; i < 5; i++)
                    for (int j = 0; j < 5; j++)
                        bw.Write(cell[i, j].Checked);
                bw.Flush();
                bw.Close();
                fs.Close();
            }
        }
    }
}

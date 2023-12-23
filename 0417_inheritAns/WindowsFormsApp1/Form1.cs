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
        string[,] relation = new string[200, 40];
        int recNo, rank, parentNo = -1;
        void find_descendant(string p)
        {
            for (int i = 0; i < recNo; i++)
                if (relation[i, 0] == p)
                {
                    for (int j = 2; relation[i, j] != "end"; j += 2)
                    {
                        if (relation[i, j + 1] != "(MD)" && relation[i, j + 1] != "(FD)" && relation[i, j + 1] != "(MND)" && relation[i, j + 1] != "(FND)")
                            textBox1.Text += (rank++) + ":\t" + relation[i, j] + "\r\n";
                        find_descendant(relation[i, j]);
                    }
                    break;
                }
        }
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "文字檔案(*.txt)|*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                string[] king = sr.ReadLine().Split();
                string[] s = null;
                textBox1.Text = "";
                rank = 1;
                for (recNo = 0; sr.Peek() >= 0; recNo++)
                {
                    s = sr.ReadLine().Split();
                    for (int i = 0; i < s.Length; i++)
                    {
                        relation[recNo, i] = s[i];
                        if (s[i] == king[0] && i != 0)
                            parentNo = recNo;
                        for (int j = i; j >= 5; j -= 2)
                        {
                            if ((relation[recNo, j - 2] == "(F)" || relation[recNo, j - 2] == "(FD)") && (relation[recNo, j] == "(M)" || relation[recNo, j] == "(MD)"))
                            {
                                string temp0 = relation[recNo, j];
                                string temp1 = relation[recNo, j - 1];
                                relation[recNo, j] = relation[recNo, j - 2];
                                relation[recNo, j - 1] = relation[recNo, j - 3];
                                relation[recNo, j - 2] = temp0;
                                relation[recNo, j - 3] = temp1;
                            }
                        }
                    }
                    relation[recNo, s.Length] = "end";
                }
                find_descendant(king[0]);
                if (parentNo != -1)
                {
                    for (int j = 2; relation[parentNo, j] != "end"; j += 2)
                    {
                        if (relation[parentNo, j] != king[0])
                        {
                            if (relation[parentNo, j + 1] != "(MD)" && relation[parentNo, j + 1] != "(FD)" && relation[parentNo, j + 1] != "(MND)" && relation[parentNo, j + 1] != "(FND)")
                                textBox1.Text += (rank++) + ":\t" + relation[parentNo, j] + "\r\n";
                            find_descendant(relation[parentNo, j]);
                        }
                    }
                }
                sr.Close();
            }
        }
    }
}

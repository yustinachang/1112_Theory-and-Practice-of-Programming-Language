using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Schema;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        List<node> tree = new List<node>();
        class node
        {
            char data;
            int freq;
            string code;
            bool leaf;
            bool hasFather;
            node left;
            node right;
            public node(char ch)
            {
                data = ch;
                freq = 1;
                code = "";
                leaf = true;
                hasFather = false;
                left = null;
                right = null;
            }
            public char getData()
            { return data; }
            public int getFreq()
            { return freq; }
            public string getCode()
            { return code; }
            public bool getLeaf()
            { return leaf; }
            public bool getHasfather()
            { return hasFather; }
            public node getLeft()
            { return left; }
            public node getRight()
            { return right; }
            public void setData(char ch)
            { data = ch; }
            public void setFreq(int n)
            { freq = n; }
            public void setCode(string s)
            { code = s; }
            public void setLeaf(bool b)
            { leaf = b; }
            public void setHasfather(bool b)
            { hasFather = b; }
            public void setLeft(node d)
            { left = d; }
            public void setRight(node d)
            { right = d; }
        }
        void findMin(out node min1, out node min2)
        {
            min1 = null; min2 = null;
            int i, n = 0;
            for (i = 0; i < tree.Count; i++)
            {
                if (tree[i].getHasfather() == false)//還未台併
                    if (n == 0)//先取第1個為min1的初始值
                    {
                        min1 = tree[i];
                        n++;
                    }
                    else if (n == 1)//先取第2個為min2的初始
                    {
                        min2 = tree[i];
                        n++;
                        if (min1.getFreq() > min2.getFreq())
                        {
                            min2 = min1;
                            min1 = tree[i];
                        }//min1永遠小於或等於min2
                    }
                    else //第3個節點開始和min2比較
                    {
                        if (tree[i].getFreq() < min2.getFreq())
                        {
                            min2 = tree[i];
                            if (min1.getFreq() > min2.getFreq())
                            {
                                min2 = min1;
                                min1 = tree[i];
                            }
                        }
                    }
            }
        }
        void Encode(node ptr)
        {
            if (ptr != null)
            {
                if (ptr.getLeft() != null)
                    ptr.getLeft().setCode(ptr.getCode() + "0");
                if (ptr.getRight() != null)
                    ptr.getRight().setCode(ptr.getCode() + "1");
                Encode(ptr.getLeft());
                Encode(ptr.getRight());
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text;
            tree.Clear();
            int i, n;
            for (i = 0; i < s.Length; i++)
            {
                for (n = 0; n < tree.Count; n++)
                {
                    if (s[i] == tree[n].getData())
                    {
                        tree[n].setFreq(tree[n].getFreq() + 1);
                        break;
                    }
                }
                if (n==tree.Count)
                {
                    node x = new node(s[i]);
                    tree.Add(x);
                }
            }
            node n1, n2, n3;
            while(true)
            {
                findMin(out n1, out n2);
                if (n2 == null) break;
                else
                {
                    n3 = new node('`');
                    tree.Add(n3);
                    n3.setLeaf(false);
                    n3.setLeft(n1);
                    n3.setRight(n2);
                    n3.setFreq(n1.getFreq() + n2.getFreq());
                    n1.setHasfather(true);
                    n2.setHasfather(true);
                }
            }
            Encode(n1);
            textBox2.Text = "";
            for (n = 0; n < tree.Count; n++)
            {
                if (tree[n].getLeaf())
                {
                    textBox2.Text += tree[n].getData() + "\t" + tree[n].getFreq() + "\t" + tree[n].getCode() + "\r\n";
                }
            }
            textBox3.Text = "";
            for (i = 0; i < s.Length; i++)
            {
                for (n = 0; n < tree.Count; n++)
                {
                    if (s[i] == tree[n].getData())
                    {
                        textBox3.Text += tree[n].getCode();
                        break;
                    }
                }
            }
            textBox4.Text = s.Length * 8 + "bits壓縮成" + textBox3.Text.Length + "bits，壓縮率為" + (s.Length * 8 - textBox3.Text.Length) + "/" + s.Length * 8 + "=" + ((s.Length * 8 - textBox3.Text.Length) * 100 / (s.Length * 8)) + "%";
        }
    }
}

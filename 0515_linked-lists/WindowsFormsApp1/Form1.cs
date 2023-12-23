using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ShowData();
        }
        node head = new node(-1);
        class node
        {
            int data;
            node next;
            public node(int n)
            {
                data = n;
                next = null;
            }
            public int getData()
            {
                return data;
            }
            public node getNext()
            {
                return next;
            }
            public void setData(int n)
            {
                data = n;
            }
            public void setNext(node d)
            {
                next = d;
            }
        }
        void ShowData()
        {
            node ptr = head.getNext();
            textBox2.Text = "head";
            while (ptr != null)
            {
                textBox2.Text += "->" + ptr.getData();
                ptr = ptr.getNext();
            }
            textBox2.Text += "->null";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int n = Convert.ToInt32(textBox1.Text);
                node x = new node(n);
                node ptr1 = head;
                node ptr2 = head.getNext();
                while (ptr2 != null)
                {
                    if (ptr2.getData() == n) throw new Exception("資料" + n + "重複");
                    if (ptr2.getData() > n)
                    {
                        ptr1.setNext(x);
                        x.setNext(ptr2);
                        ShowData();
                        return;
                    }
                    ptr1 = ptr2;
                    ptr2 = ptr2.getNext();
                }
                ptr1.setNext(x);
                ShowData();
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
                int n = Convert.ToInt32(textBox1.Text);
                node ptr1 = head;
                node ptr2 = head.getNext();
                while (ptr2 != null)
                {
                    if (ptr2.getData() == n)
                    {
                        ptr1.setNext(ptr2.getNext());
                        ShowData();
                        return;
                    }
                    if (ptr2.getData() > n) throw new Exception("串列中沒有" + n);
                    ptr1 = ptr2;
                    ptr2 = ptr2.getNext();
                }
                throw new Exception("串列中沒有" + n);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "刪除失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        node root = new node(0);
        class node
        {
            int data;
            node left;
            node right;
            public node(int n)
            {
                data = n;
                left = null;
                right = null;
            }
            public int getData()
            { return data; }
            public node getLeft()
            { return left; }
            public node getRight()
            { return right; }
            public void setData(int n)
            { data = n; }
            public void setLeft(node d)
            { left = d; }
            public void setRight(node d)
            { right = d; }
        }
        void inorder(node ptr)
        {
            if (ptr != null)
            {
                inorder(ptr.getLeft());
                textBox2.Text = textBox2.Text + " " + ptr.getData();
                inorder(ptr.getRight());
            }
        }
        void preorder(node ptr)
        {
            if (ptr != null)
            {
                textBox2.Text = textBox2.Text + " " + ptr.getData();
                preorder(ptr.getLeft());
                preorder(ptr.getRight());
            }
        }
        void postorder(node ptr)
        {
            if (ptr != null)
            {
                postorder(ptr.getLeft());
                postorder(ptr.getRight());
                textBox2.Text = textBox2.Text + " " + ptr.getData();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int n = Convert.ToInt32(textBox1.Text);
                node ptr1 = root;
                node ptr2 = root.getLeft();
                node x = new node(n);
                if (ptr2 == null)
                {
                    root.setLeft(x);
                    textBox2.Text = "";
                    inorder(root.getLeft());
                    return;
                }
                while (ptr2 != null)
                {
                    if (ptr2.getData() == n) throw new Exception("資料" + n + "重複");
                    ptr1 = ptr2;
                    if (n < ptr2.getData())
                        ptr2 = ptr2.getLeft();
                    else
                        ptr2 = ptr2.getRight();
                }
                if (n < ptr1.getData()) ptr1.setLeft(x);
                else ptr1.setRight(x);

                textBox2.Text = "";
                inorder(root.getLeft());
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
                node ptr1 = root;
                node ptr2 = root.getLeft();
                node x = new node(n);
                while (ptr2 != null)
                {
                    if (ptr2.getData() == n) break;
                    ptr1 = ptr2;
                    if (n < ptr2.getData())
                        ptr2 = ptr2.getLeft();
                    else
                        ptr2 = ptr2.getRight();
                }
                if (ptr2 == null) throw new Exception("資料" + n + "不存在");
                else
                {
                    if(ptr2.getRight() == null && ptr2.getLeft() == null)
                    {
                        if (ptr2 == ptr1.getRight()) ptr1.setRight(null);
                        if (ptr2 == ptr1.getLeft()) ptr1.setLeft(null);
                    }
                    else if (ptr2.getRight() != null && ptr2.getLeft() != null)
                    {
                        node ptr3 = ptr2;
                        node ptr4 = ptr2.getLeft();
                        while (ptr4.getRight() != null)
                        {
                            ptr3 = ptr4;
                            ptr4 = ptr4.getRight();
                        }
                        ptr2.setData(ptr4.getData());
                        if (ptr4 == ptr3.getRight()) ptr3.setRight(ptr4.getLeft());
                        if (ptr4 == ptr3.getLeft()) ptr3.setLeft(ptr4.getLeft());
                    }
                    else
                    {
                        if (ptr2.getRight() != null)
                        {
                            if (ptr2 == ptr1.getRight()) ptr1.setRight(ptr2.getRight());
                            if (ptr2 == ptr1.getLeft()) ptr1.setLeft(ptr2.getRight());
                        }
                        if (ptr2.getLeft() != null)
                        {
                            if (ptr2 == ptr1.getRight()) ptr1.setRight(ptr2.getLeft());
                            if (ptr2 == ptr1.getLeft()) ptr1.setLeft(ptr2.getLeft());
                        }
                    }
                    textBox2.Text = "";
                    inorder(root.getLeft());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "刪除失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            preorder(root.getLeft());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            inorder(root.getLeft());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            postorder(root.getLeft());
        }
    }
}

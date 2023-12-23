using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Picture graph = new Picture("Graph");
        List<Picture> allPicture = new List<Picture>();
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "{Picture Graph:}";
            allPicture.Add(graph);
        }
        abstract class Component
        {
            protected string name;
            public abstract double area();
            public abstract string show();
            public string getName()
            {
                return name;
            }
        }
        class Picture : Component
        {
            private List<Component> coms = new List<Component>();
            public Picture(string n)
            {
                name = n;
            }
            public void addComponent(Component c)
            {
                coms.Add(c);
            }
            public override double area()
            {
                double total = 0.0;
                for (int i = 0; i < coms.Count; i++)
                    total = total + coms[i].area();
                return total;
            }
            public override string show()
            {
                string str = "{Picture" + name + ":";
                for (int i = 0; i < coms.Count; i++)
                    str = str + "" + coms[i].show();
                str = str + "}";
                return str;
            }
        }
        abstract class Shape : Component { }
        class Rectangle : Shape
        {
            private double length;
            private double width;
            public Rectangle(string n, double l, double w)
            {
                name = n;
                length = l;
                width = w;
            }
            public override double area()
            {
                return length * width;
            }
            public override string show()
            {
                return "Rectangle: " + name + "(" + length + "," + width + ")";
            }
        }
        class Triangle : Shape
        {
            private double tbase;
            private double height;
            public Triangle(string n, double b, double h)
            {
                name = n;
                tbase = b;
                height = h;
            }
            public override double area()
            {
                return 0.5 * tbase * height; 
            }
            public override string show()
            {
                return "Triangle: " + name + "(" + tbase + "," + height + ")";
            }
        }
        class Circle : Shape
        {
            private double radius;
            public Circle(string n, double r)
            {
                name = n;
                radius = r;
            }
            public override double area()
            {
                return radius * radius * Math.PI;
            }
            public override string show()
            {
                return "Circle: " + name + "(" + radius + ")";
            }
        }
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
            string newName, container;
            int i;
            if (f2.DialogResult == DialogResult.OK)
            {
                f2.getData(out newName, out container);
                for (i = 0; i < allPicture.Count; i++)
                    if (allPicture[i].getName() == container)
                        break;
                if (i == allPicture.Count)
                    MessageBox.Show("不存在的Picture容器:" + container, "錯誤訊息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    Picture x = new Picture(newName);
                    allPicture[i].addComponent(x);
                    allPicture.Add(x);
                    textBox1.Text = graph.show();
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Form3 f3 = new Form3();
                f3.ShowDialog();
                string newName, container;
                double length, width;
                int i;
                if (f3.DialogResult == DialogResult.OK)
                {
                    f3.getData(out newName, out container, out length, out width);
                    for (i = 0; i < allPicture.Count; i++)
                        if (allPicture[i].getName() == container)
                            break;
                    if (i == allPicture.Count)
                        MessageBox.Show("不存在的Picture容器:" + container, "錯誤訊息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        Rectangle x = new Rectangle(newName, length, width);
                        allPicture[i].addComponent(x);
                        textBox1.Text = graph.show();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤訊息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Form4 f4 = new Form4();
                f4.ShowDialog();
                string newName, container;
                double tbase, height;
                int i;
                if (f4.DialogResult == DialogResult.OK)
                {
                    f4.getData(out newName, out container, out tbase, out height);
                    for (i = 0; i < allPicture.Count; i++)
                        if (allPicture[i].getName() == container)
                            break;
                    if (i == allPicture.Count)
                        MessageBox.Show("不存在的Picture容器:" + container, "錯誤訊息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        Triangle x = new Triangle(newName, tbase, height);
                        allPicture[i].addComponent(x);
                        textBox1.Text = graph.show();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤訊息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Form5 f5 = new Form5();
                f5.ShowDialog();
                string newName, container;
                double radius;
                int i;
                if (f5.DialogResult == DialogResult.OK)
                {
                    f5.getData(out newName, out container, out radius);
                    for (i = 0; i < allPicture.Count; i++)
                        if (allPicture[i].getName() == container)
                            break;
                    if (i == allPicture.Count)
                        MessageBox.Show("不存在的Picture容器:" + container, "錯誤訊息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        Circle x = new Circle(newName, radius);
                        allPicture[i].addComponent(x);
                        textBox1.Text = graph.show();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤訊息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            textBox2.Text = " " + graph.area();
        }
    }
}

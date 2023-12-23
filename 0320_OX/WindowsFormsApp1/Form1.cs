using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Button[,] board = new Button[3, 3];
        int[,] state = new int[3, 3];
        bool start = false;     //開始
        bool computer = true;   //輪次:T電腦, F玩家
        int count;              //步數

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            board[0, 0] = button1;
            board[0, 1] = button2;
            board[0, 2] = button3;
            board[1, 0] = button4;
            board[1, 1] = button5;
            board[1, 2] = button6;
            board[2, 0] = button7;
            board[2, 1] = button8;
            board[2, 2] = button9;
        }

        void showBoard()
        {
            int i, j;
            for (i = 0; i < 3; i++)
                for (j = 0; j < 3; j++)
                {
                    if (state[i, j] == 0) board[i, j].Text = "";
                    if (state[i, j] == 1) board[i, j].Text = "O";
                    if (state[i, j] == 10) board[i, j].Text = "X";
                }
            if (computer) textBox1.Text = "電腦";
            else textBox1.Text = "玩家";
            if (state[0, 0] + state[1, 1] + state[2, 2] == 3 || state[0, 2] + state[1, 1] + state[2, 0] == 3)
            {
                MessageBox.Show("電腦獲勝", "遊戲結束", MessageBoxButtons.OK, MessageBoxIcon.Information);
                start = false;
                return;
            }
            for (i = 0; i < 3; i++)
                if (state[i, 0] + state[i, 1] + state[i, 2] == 3 || state[0, i] + state[1, i] + state[2, i] == 3)
                {
                    MessageBox.Show("電腦獲勝", "遊戲結束", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    start = false;
                    return;
                }
            if (state[0, 0] + state[1, 1] + state[2, 2] == 30 || state[0, 2] + state[1, 1] + state[2, 0] == 30)
            {
                MessageBox.Show("玩家獲勝", "遊戲結束", MessageBoxButtons.OK, MessageBoxIcon.Information);
                start = false;
                return;
            }
            for (i = 0; i < 3; i++)
                if (state[i, 0] + state[i, 1] + state[i, 2] == 30 || state[0, i] + state[1, i] + state[2, i] == 30)
                {
                    MessageBox.Show("玩家獲勝", "遊戲結束", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    start = false;
                    return;
                }
            if (count == 9)
            {
                MessageBox.Show("雙方平手", "遊戲結束", MessageBoxButtons.OK, MessageBoxIcon.Information);
                start = false;
                return;
            }
        }

        void play()
        {
            count++;
            int i, j;
            if (start && computer)//step1
            {
                if (state[0, 0] + state[1, 1] + state[2, 2] == 2)
                {
                    state[0, 0] = 1;
                    state[1, 1] = 1;
                    state[2, 2] = 1;
                    computer = false;
                    showBoard();
                    return;
                }
                else if (state[0, 2] + state[1, 1] + state[2, 0] == 2)
                {
                    state[0, 2] = 1;
                    state[1, 1] = 1;
                    state[2, 0] = 1;
                    computer = false;
                    showBoard();
                    return;
                }
                else
                {
                    for (i = 0; i < 3; i++)
                    {
                        if (state[i, 0] + state[i, 1] + state[i, 2] == 2)
                        {
                            state[i, 0] = 1;
                            state[i, 1] = 1;
                            state[i, 2] = 1;
                            computer = false;
                            showBoard();
                            return;
                        }
                        else if (state[0, i] + state[1, i] + state[2, i] == 2)
                        {
                            state[0, i] = 1;
                            state[1, i] = 1;
                            state[2, i] = 1;
                            computer = false;
                            showBoard();
                            return;
                        }
                    }
                }
            }
            if (start && computer)//step2
            {
                if (state[0, 0] + state[1, 1] + state[2, 2] == 20)
                {
                    if (state[0, 0] == 0) state[0, 0] = 1;
                    if (state[1, 1] == 0) state[1, 1] = 1;
                    if (state[2, 2] == 0) state[2, 2] = 1;
                    computer = false;
                    showBoard();
                    return;
                }
                else if (state[0, 2] + state[1, 1] + state[2, 0] == 20)
                {
                    if (state[0, 2] == 0) state[0, 2] = 1;
                    if (state[1, 1] == 0) state[1, 1] = 1;
                    if (state[2, 0] == 0) state[2, 0] = 1;
                    computer = false;
                    showBoard();
                    return;
                }
                else
                {
                    for (i = 0; i < 3; i++)
                    {
                        if (state[i, 0] + state[i, 1] + state[i, 2] == 20)
                        {
                            if (state[i, 0] == 0) state[i, 0] = 1;
                            if (state[i, 1] == 0) state[i, 1] = 1;
                            if (state[i, 2] == 0) state[i, 2] = 1;
                            computer = false;
                            showBoard();
                            return;
                        }
                        else if (state[0, i] + state[1, i] + state[2, i] == 20)
                        {
                            if (state[0, i] == 0) state[0, i] = 1;
                            if (state[1, i] == 0) state[1, i] = 1;
                            if (state[2, i] == 0) state[2, i] = 1;
                            computer = false;
                            showBoard();
                            return;
                        }
                    }
                }
            }
            if (start && computer)//step3
            {
                for (i = 0; i < 3; i++)
                    for (j = 0; j < 3; j++)
                    {
                        int x = 0;
                        if (state[i, j] == 0)
                        {
                            state[i, j] = 1;
                            if (state[i, 0] + state[i, 1] + state[i, 2] == 2) x++;
                            if (state[0, j] + state[1, j] + state[2, j] == 2) x++;
                            if (state[0, 0] + state[1, 1] + state[2, 2] == 2) x++;
                            if (state[0, 2] + state[1, 1] + state[2, 0] == 2) x++;
                            if (x >= 2)
                            {
                                computer = false;
                                showBoard();
                                return;
                            }
                            else state[i, j] = 0;
                        }
                    }
            }
            if (start && computer)//step4
            {   //防止玩家有雙路徑可以使得雙聽
                if((state[0, 0] + state[1, 1] + state[2, 2] == 21 && state[0, 2] + state[1, 1] + state[2, 0] == 1) || (state[0, 0] + state[1, 1] + state[2, 2] == 1 && state[0, 2] + state[1, 1] + state[2, 0] == 21))
                {
                    state[0, 1] = 1;
                    computer = false;
                    showBoard();
                    return;
                }
                for (i = 0; i < 3; i++)
                    for (j = 0; j < 3; j++)
                    {
                        int x = 0;
                        if (state[i, j] == 0)
                        {
                            state[i, j] = 10;
                            if (state[i, 0] + state[i, 1] + state[i, 2] == 20) x++;
                            if (state[0, j] + state[1, j] + state[2, j] == 20) x++;
                            if (state[0, 0] + state[1, 1] + state[2, 2] == 20) x++;
                            if (state[0, 2] + state[1, 1] + state[2, 0] == 20) x++;
                            if (x >= 2)
                            {
                                state[i, j] = 1;
                                computer = false;
                                showBoard();
                                return;
                            }
                            else state[i, j] = 0;
                        }
                    }
            }
            if (start && computer)//step5
            {
                if (state[1, 1] == 0) state[1, 1] = 1;
                else if (state[0, 0] == 0) state[0, 0] = 1;
                else if (state[0, 2] == 0) state[0, 2] = 1;
                else if (state[2, 0] == 0) state[2, 0] = 1;
                else if (state[2, 2] == 0) state[2, 2] = 1;
                else if (state[0, 1] == 0) state[0, 1] = 1;
                else if (state[1, 0] == 0) state[1, 0] = 1;
                else if (state[1, 2] == 0) state[1, 2] = 1;
                else if (state[2, 1] == 0) state[2, 1] = 1;
                computer = false;
                showBoard();
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (start && !computer && state[0, 0] == 0)
            {
                state[0, 0] = 10;
                count++;
                computer = true;
                showBoard();
                play();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (start && !computer && state[0, 1] == 0)
            {
                state[0, 1] = 10;
                count++;
                computer = true;
                showBoard();
                play();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (start && !computer && state[0, 2] == 0)
            {
                state[0, 2] = 10;
                count++;
                computer = true;
                showBoard();
                play();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (start && !computer && state[1, 0] == 0)
            {
                state[1, 0] = 10;
                count++;
                computer = true;
                showBoard();
                play();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (start && !computer && state[1, 1] == 0)
            {
                state[1, 1] = 10;
                count++;
                computer = true;
                showBoard();
                play();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (start && !computer && state[1, 2] == 0)
            {
                state[1, 2] = 10;
                count++;
                computer = true;
                showBoard();
                play();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (start && !computer && state[2, 0] == 0)
            {
                state[2, 0] = 10;
                count++;
                computer = true;
                showBoard();
                play();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (start && !computer && state[2, 1] == 0)
            {
                state[2, 1] = 10;
                count++;
                computer = true;
                showBoard();
                play();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (start && !computer && state[2, 2] == 0)
            {
                state[2, 2] = 10;
                count++;
                computer = true;
                showBoard();
                play();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int i, j;
            for (i = 0; i < 3; i++)
                for (j = 0; j < 3; j++)
                    state[i, j] = 0;
            count = 0;
            showBoard();
            start = true;
            if (radioButton1.Checked)
            {
                computer = true;
                textBox1.Text = "電腦";
                play();
            }
            else
            {
                computer = false;
                textBox1.Text = "玩家";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

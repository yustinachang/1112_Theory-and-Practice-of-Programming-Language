using System.Diagnostics.Eventing.Reader;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        Button[,] board = new Button[3, 3];
        int[,] state = new int[3, 3];
        bool start = false;
        bool computer = true;
        int count;

        void showBoard()
        {
            int i, j;
            for (i = 0; i < 3; i++)
                for (j = 0; j < 3; j++)
                {
                    if (state[i,j] == 0) board[i, j].Text = "";
                    if (state[i, j] == 1) board[i, j].Text = "O";
                    if (state[i, j] == 10) board[i, j].Text = "X";
                }
            if (computer)
                textBox1.Text = "電腦";
            else
                textBox1.Text = "玩家";
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
                MessageBox.Show("恭喜玩家獲勝", "遊戲結束", MessageBoxButtons.OK, MessageBoxIcon.Information);
                start = false;
                return;
            }
            for (i = 0; i < 3; i++)
                if (state[i, 0] + state[i, 1] + state[i, 2] == 30 || state[0, i] + state[1, i] + state[2, i] == 30)
                {
                    MessageBox.Show("恭喜玩家獲勝", "遊戲結束", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    start = false;
                    return;
                }
            if (count == 9)
            {
                MessageBox.Show("雙方平手", "遊戲結束", MessageBoxButtons.OK, MessageBoxIcon.Information);
                start = false;
            }
        }

        void play()
        {
            //#1
            if (state[0, 0] + state[1, 1] + state[2, 2] == 2)
            {
                if (start && computer && state[0, 0] == 0)
                {
                    state[0, 0] = 1;
                    count++;
                    computer = false;
                    showBoard();
                    return;
                }
                else if (start && computer && state[1, 1] == 0)
                {
                    state[1, 1] = 1;
                    count++;
                    computer = false;
                    showBoard();
                    return;
                }
                else if (start && computer && state[2, 2] == 0)
                {
                    state[2, 2] = 1;
                    count++;
                    computer = false;
                    showBoard();
                    return;
                }
            }
            else if (state[0, 2] + state[1, 1] + state[2, 0] == 2)
            {
                if (start && computer && state[0, 2] == 0)
                {
                    state[0, 2] = 1;
                    count++;
                    computer = false;
                    showBoard();
                    return;
                }
                else if (start && computer && state[1, 1] == 0)
                {
                    state[1, 1] = 1;
                    count++;
                    computer = false;
                    showBoard();
                    return;
                }
                else if (start && computer && state[2, 0] == 0)
                {
                    state[2, 0] = 1;
                    count++;
                    computer = false;
                    showBoard();
                    return;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                if (state[i, 0] + state[i, 1] + state[i, 2] == 2)
                {
                    if (start && computer)
                    {
                        if (state[i, 0] == 0)
                        {
                            state[i, 0] = 1;
                            count++;
                            computer = false;
                            showBoard();
                            return;
                        }
                        else if (state[i, 1] == 0)
                        {
                            state[i, 1] = 1;
                            count++;
                            computer = false;
                            showBoard();
                            return;
                        }
                        else if (state[i, 2] == 0)
                        {
                            state[i, 2] = 1;
                            count++;
                            computer = false;
                            showBoard();
                            return;
                        }
                    }
                }
                else if (state[0, i] + state[1, i] + state[2, i] == 2)
                {
                    if (start && computer)
                    {
                        if (state[0, i] == 0)
                        {
                            state[0, i] = 1;
                            count++;
                            computer = false;
                            showBoard();
                            return;
                        }
                        else if (state[1, i] == 0)
                        {
                            state[1, i] = 1;
                            count++;
                            computer = false;
                            showBoard();
                            return;
                        }
                        else if (state[2, i] == 0)
                        {
                            state[2, i] = 1;
                            count++;
                            computer = false;
                            showBoard();
                            return;
                        }
                    }
                }
            }
            //#2
            if (state[0, 0] + state[1, 1] + state[2, 2] == 20)
            {
                if (start && computer && state[0, 0] == 0)
                {
                    state[0, 0] = 1;
                    count++;
                    computer = false;
                    showBoard();
                    return;
                }
                else if (start && computer && state[1, 1] == 0)
                {
                    state[1, 1] = 1;
                    count++;
                    computer = false;
                    showBoard();
                    return;
                }
                else if (start && computer && state[2, 2] == 0)
                {
                    state[2, 2] = 1;
                    count++;
                    computer = false;
                    showBoard();
                    return;
                }
            }
            else if (state[0, 2] + state[1, 1] + state[2, 0] == 20)
            {
                if (start && computer && state[0, 2] == 0)
                {
                    state[0, 2] = 1;
                    count++;
                    computer = false;
                    showBoard();
                    return;
                }
                else if (start && computer && state[1, 1] == 0)
                {
                    state[1, 1] = 1;
                    count++;
                    computer = false;
                    showBoard();
                    return;
                }
                else if (start && computer && state[2, 0] == 0)
                {
                    state[2, 0] = 1;
                    count++;
                    computer = false;
                    showBoard();
                    return;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                if (state[i, 0] + state[i, 1] + state[i, 2] == 20)
                {
                    if (start && computer)
                    {
                        if (state[i, 0] == 0)
                        {
                            state[i, 0] = 1;
                            count++;
                            computer = false;
                            showBoard();
                            return;
                        }
                        else if (state[i, 1] == 0)
                        {
                            state[i, 1] = 1;
                            count++;
                            computer = false;
                            showBoard();
                            return;
                        }
                        else if (state[i, 2] == 0)
                        {
                            state[i, 2] = 1;
                            count++;
                            computer = false;
                            showBoard();
                            return;
                        }
                    }
                }
                else if (state[0, i] + state[1, i] + state[2, i] == 20)
                {
                    if (start && computer)
                    {
                        if (state[0, i] == 0)
                        {
                            state[0, i] = 1;
                            count++;
                            computer = false;
                            showBoard();
                            return;
                        }
                        else if (state[1, i] == 0)
                        {
                            state[1, i] = 1;
                            count++;
                            computer = false;
                            showBoard();
                            return;
                        }
                        else if (state[2, i] == 0)
                        {
                            state[2, i] = 1;
                            count++;
                            computer = false;
                            showBoard();
                            return;
                        }
                    }
                }
            }
            //#3
            if (state[0, 0] + state[1, 1] + state[2, 2] == 1 && state[0, 2] + state[1, 1] + state[2, 0] == 1)
            {
                if (start && computer && state[1,1] == 0)
                {
                    state[1,1] = 1;
                    count++;
                    computer = false;
                    showBoard();
                    return;
                }
            }
            for (int i=0;i<3;i++)
                if (state[0, 0] + state[1, 1] + state[2, 2] == 1 && state[i, 0] + state[i, 1] + state[i, 2] == 1)
                {
                    if (start && computer && state[i, i] == 0)
                    {
                        state[i, i] = 1;
                        count++;
                        computer = false;
                        showBoard();
                        return;
                    }
                }
            for (int j = 0; j < 3; j++)
                if (state[0, 0] + state[1, 1] + state[2, 2] == 1 && state[0, j] + state[1, j] + state[2, j] == 1)
                {
                    if (start && computer && state[j, j] == 0)
                    {
                        state[j, j] = 1;
                        count++;
                        computer = false;
                        showBoard();
                        return;
                    }
                }
            for (int i = 0; i < 3; i++)
                if (state[0, 2] + state[1, 1] + state[2, 0] == 1 && state[i, 0] + state[i, 1] + state[i, 2] == 1)
                {
                    if (i== 0)
                    {
                        if (start && computer && state[0, 2] == 0)
                        {
                            state[0, 2] = 1;
                            count++;
                            computer = false;
                            showBoard();
                            return;
                        }
                    }
                    else if (i== 1)
                    {
                        if (start && computer && state[1, 1] == 0)
                        {
                            state[1, 1] = 1;
                            count++;
                            computer = false;
                            showBoard();
                            return;
                        }
                    }
                    else if (i == 2)
                    {
                        if (start && computer && state[2, 0] == 0)
                        {
                            state[2, 0] = 1;
                            count++;
                            computer = false;
                            showBoard();
                            return;
                        }
                    }

                }
            for (int i = 0;i<3;i++)
                for(int j = 0;j<3;j++)
                {
                    if (state[i, 0] + state[i, 1] + state[i, 2] ==1 && state[0, j] + state[1,j]+ state[2, j]==1)
                    {
                        if (start && computer && state[i, j] ==0)
                        {
                            state[i, j] = 1;
                            count++;
                            computer = false;
                            showBoard();
                            return;
                        }
                    }
                }
            //#4
            if (state[0, 0] + state[1, 1] + state[2, 2] == 21 || state[0, 2] + state[1, 1] + state[2, 0] == 21)
            {
                if (start && computer && state[0, 1] == 0)
                {
                    state[0, 1] = 1;
                    count++;
                    computer = false;
                    showBoard();
                    return;
                }
                else if (start && computer && state[1, 0] == 0)
                {
                    state[1, 0] = 1;
                    count++;
                    computer = false;
                    showBoard();
                    return;
                }
                else if (start && computer && state[1, 2] == 0)
                {
                    state[1, 2] = 1;
                    count++;
                    computer = false;
                    showBoard();
                    return;
                }
                else if (start && computer && state[2, 1] == 0)
                {
                    state[2, 1] = 1;
                    count++;
                    computer = false;
                    showBoard();
                    return;
                }
            }
            if (state[0, 0] + state[1, 1] + state[2, 2] == 10 && state[0, 2] + state[1, 1] + state[2, 0] == 10)
            {
                if (start && computer && state[1, 1] == 0)
                {
                    state[1, 1] = 1;
                    count++;
                    computer = false;
                    showBoard();
                    return;
                }
            }
            for (int i = 0; i < 3; i++)
                if (state[0, 0] + state[1, 1] + state[2, 2] == 10 && state[i, 0] + state[i, 1] + state[i, 2] == 10)
                {
                    if (start && computer && state[i, i] == 0)
                    {
                        state[i, i] = 1;
                        count++;
                        computer = false;
                        showBoard();
                        return;
                    }
                }
            for (int j = 0; j < 3; j++)
                if (state[0, 0] + state[1, 1] + state[2, 2] == 10 && state[0, j] + state[1, j] + state[2, j] == 10)
                {
                    if (start && computer && state[j, j] == 0)
                    {
                        state[j, j] = 1;
                        count++;
                        computer = false;
                        showBoard();
                        return;
                    }
                }
            for (int i = 0; i < 3; i++)
                if (state[0, 2] + state[1, 1] + state[2, 0] == 10 && state[i, 0] + state[i, 1] + state[i, 2] == 10)
                {
                    if (i == 0)
                    {
                        if (start && computer && state[0, 2] == 0)
                        {
                            state[0, 2] = 1;
                            count++;
                            computer = false;
                            showBoard();
                            return;
                        }
                    }
                    else if (i == 1)
                    {
                        if (start && computer && state[1, 1] == 0)
                        {
                            state[1, 1] = 1;
                            count++;
                            computer = false;
                            showBoard();
                            return;
                        }
                    }
                    else if (i == 2)
                    {
                        if (start && computer && state[2, 0] == 0)
                        {
                            state[2, 0] = 1;
                            count++;
                            computer = false;
                            showBoard();
                            return;
                        }
                    }

                }
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    if (state[i, 0] + state[i, 1] + state[i, 2] == 10 && state[0, j] + state[1, j] + state[2, j] == 10)
                    {
                        if (start && computer && state[i, j] == 0)
                        {
                            state[i, j] = 1;
                            count++;
                            computer = false;
                            showBoard();
                            return;
                        }
                    }
                }
            //#5
            if (start && computer && state[1, 1] == 0)
            {
                state[1, 1] = 1;
                count++;
                computer = false;
                showBoard();
                return;
            }
            //#6
            else if (start && computer && state[0, 0] == 0)
            {
                state[0, 0] = 1;
                count++;
                computer = false;
                showBoard();
                return;
            }
            else if (start && computer && state[0, 2] == 0)
            {
                state[0, 2] = 1;
                count++;
                computer = false;
                showBoard();
                return;
            }
            else if (start && computer && state[2, 0] == 0)
            {
                state[2, 0] = 1;
                count++;
                computer = false;
                showBoard();
                return;
            }
            else if (start && computer && state[2, 2] == 0)
            {
                state[2, 2] = 1;
                count++;
                computer = false;
                showBoard();
                return;
            }
            //#7
            else if (start && computer && state[0, 1] == 0)
            {
                state[0, 1] = 1;
                count++;
                computer = false;
                showBoard();
                return;
            }
            else if (start && computer && state[1, 0] == 0)
            {
                state[1, 0] = 1;
                count++;
                computer = false;
                showBoard();
                return;
            }
            else if (start && computer && state[1, 2] == 0)
            {
                state[1, 2] = 1;
                count++;
                computer = false;
                showBoard();
                return;
            }
            else if (start && computer && state[2, 1] == 0)
            {
                state[2, 1] = 1;
                count++;
                computer = false;
                showBoard();
                return;
            }

        }

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int i, j;
            for (i = 0; i < 3; i++)
                for (j = 0; j < 3; j++)
                    state[i, j] = 0;
            count= 0;
            showBoard();
            start = true;
            if (radioButton2.Checked==true)
            {
                computer = false;
                textBox1.Text = "玩家";
            }
            else
            {
                computer= true;
                textBox1.Text = "電腦";
                play();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}
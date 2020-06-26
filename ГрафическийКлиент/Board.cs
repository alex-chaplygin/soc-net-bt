using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace ГрафическийКлиент
{
    public partial class Board : Form
    {
        public static Board board = new Board();
        static System.Timers.Timer timer;
        static bool commFlag = false;
        static Control[] controlGroup;
        public Board()
        {
            InitializeComponent();
        }

        private void buttonGetBoard_Click(object sender, EventArgs e)
        {
            string text;
            int res;
            if (Int32.TryParse(textBox1.Text, out res) == true)
                text = Program.пользователь.ОтправитьПолучить($"Стена {Form1.номерПользователя} {res}");
            else
                text = Program.пользователь.ОтправитьПолучить($"Стена {Form1.номерПользователя} {0}");
            textBoxBoard.Text = text + Environment.NewLine;
        }

        private void Board_Load(object sender, EventArgs e)
        {
            Program.пользователь.ОтправитьПолучить("СписокПользователей");
            string userlist = Program.пользователь.ОтправитьПолучить($"СписокПользователей {Form1.номерПользователя} false");
            foreach (string s in userlist.Split('\n'))
                if (s != "")
                    userList.Items.Add(s);
            controlGroup = new Control[] { labelComms, textBoxComm, textBoxComms, buttonComm };
            foreach (Control c in controlGroup)
                c.Visible = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            userList.Items.Clear();
            string userlist;
            userlist = Program.пользователь.ОтправитьПолучить($"СписокПользователей {Form1.номерПользователя} 0");
            if (checkBox1.Checked == true)
                userlist = Program.пользователь.ОтправитьПолучить($"СписокПользователей {Form1.номерПользователя} 1");
            else
                userlist = Program.пользователь.ОтправитьПолучить($"СписокПользователей {Form1.номерПользователя} 0");
            foreach (string s in userlist.Split('\n'))
                if (s != "")
                    userList.Items.Add(s);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Form1.имяПользователя != Convert.ToString(userList.SelectedItem))
            {
                Program.пользователь.ОтправитьПолучить($"Сообщение {Form1.номерПользователя} {userList.SelectedItem} {textBox2.Text}");
                textBoxMsgs.Text += $"Вы -> {userList.SelectedItem}: {textBox2.Text}{Environment.NewLine}";
            }
            else textBoxMsgs.Text += $"Нельзя отправить сообщение себе{Environment.NewLine}";
            textBox2.Clear();
        }

        private void buttonComms_Click(object sender, EventArgs e)
        {
            if (commFlag == false)
            {
                board.Size = new Size(board.Size.Width + 500, board.Size.Height);
                foreach (Control c in controlGroup)
                    c.Visible = true;
                commFlag = true;
            }
            else
            {
                board.Size = new Size(board.Size.Width - 500, board.Size.Height);
                foreach (Control c in controlGroup)
                    c.Visible = false;
                commFlag = false;
            }
        }

        private void buttonComm_Click(object sender, EventArgs e)
        {
            textBoxComms.Text += Program.пользователь.ОтправитьПолучить(textBoxComm.Text) + Environment.NewLine;
            textBoxComm.Clear();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (userList.SelectedItem == null)
                return;
            textBoxMsgs.Clear();
            string[] text = Program.пользователь.ОтправитьПолучить($"Список {Form1.номерПользователя} {Convert.ToString(userList.SelectedItem)} 0").Split('~');
            foreach (string t in text)
                textBoxMsgs.Text += t + Environment.NewLine;
        }

        private void userList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Program.пользователь.ОтправитьПолучить("Онлайн" + " " + Form1.номерПользователя + " " + textBoxName.Text));
            textBoxName.Text = "";
        }
    }
}

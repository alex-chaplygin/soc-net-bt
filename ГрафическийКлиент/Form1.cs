using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ГрафическийКлиент
{
    public partial class Form1 : Form
    {
        Клиент п;
        public static int номерПользователя;
        public static string имяПользователя;
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            string mess = "Регистрация" + " " + textBox1.Text + " " + textBox2.Text;
            MessageBox.Show(п.ОтправитьПолучить(mess));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mess = "Авторизация" + " " + textBox1.Text + " " + textBox2.Text;
            string returned = п.ОтправитьПолучить(mess);
            MessageBox.Show(returned);
            if (returned != "Неверное имя пользователя или пароль")
            {
                номерПользователя = Convert.ToInt32(returned);
                имяПользователя = textBox2.Text;
                Board.board.Show();
                button3.Visible = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string mess = $"Выход {номерПользователя}";
            MessageBox.Show(п.ОтправитьПолучить(mess));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Program.пользователь = new Клиент(textBox3.Text, Convert.ToInt32(textBox4.Text));
            п = Program.пользователь;
            groupBox1.Visible = false;
        }
    }
}

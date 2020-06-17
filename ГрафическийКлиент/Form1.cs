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
            MessageBox.Show(п.ОтправитьПолучить(mess));
            button3.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string mess = "Выход" + " " + textBox1.Text;
            MessageBox.Show(п.ОтправитьПолучить(mess));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            п = new Клиент(textBox3.Text, Convert.ToInt32(textBox4.Text));
            groupBox1.Visible = false;
        }
    }
}

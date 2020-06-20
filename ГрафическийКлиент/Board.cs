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
    public partial class Board : Form
    {
        public static Board board = new Board();
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
            textBoxBoard.Text = text;
        }
    }
}

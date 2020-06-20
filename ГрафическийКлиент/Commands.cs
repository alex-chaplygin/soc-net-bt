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
    public partial class Commands : Form
    {
        public static Commands c = new Commands();
        public Commands()
        {
            InitializeComponent();
        }

        private void buttonGetComms_Click(object sender, EventArgs e)
        {
            textGetComms.Text += Program.пользователь.ОтправитьПолучить(textBoxComms.Text) + Environment.NewLine;
        }
    }
}

namespace ГрафическийКлиент
{
    partial class Board
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBoxMsgs = new System.Windows.Forms.TextBox();
            this.buttonGetBoard = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.userList = new System.Windows.Forms.ListBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonComms = new System.Windows.Forms.Button();
            this.textBoxComms = new System.Windows.Forms.TextBox();
            this.textBoxComm = new System.Windows.Forms.TextBox();
            this.labelComms = new System.Windows.Forms.Label();
            this.buttonComm = new System.Windows.Forms.Button();
            this.textBoxBoard = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // textBoxMsgs
            // 
            this.textBoxMsgs.Location = new System.Drawing.Point(189, 12);
            this.textBoxMsgs.MaxLength = 327670;
            this.textBoxMsgs.Multiline = true;
            this.textBoxMsgs.Name = "textBoxMsgs";
            this.textBoxMsgs.ReadOnly = true;
            this.textBoxMsgs.Size = new System.Drawing.Size(341, 436);
            this.textBoxMsgs.TabIndex = 0;
            // 
            // buttonGetBoard
            // 
            this.buttonGetBoard.Location = new System.Drawing.Point(797, 451);
            this.buttonGetBoard.Name = "buttonGetBoard";
            this.buttonGetBoard.Size = new System.Drawing.Size(93, 23);
            this.buttonGetBoard.TabIndex = 1;
            this.buttonGetBoard.Text = "Получить стену";
            this.buttonGetBoard.UseVisualStyleBackColor = true;
            this.buttonGetBoard.Click += new System.EventHandler(this.buttonGetBoard_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(534, 458);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Имя:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(572, 453);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(189, 20);
            this.textBoxName.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(767, 453);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(24, 20);
            this.textBox1.TabIndex = 4;
            // 
            // userList
            // 
            this.userList.FormattingEnabled = true;
            this.userList.Location = new System.Drawing.Point(12, 211);
            this.userList.Name = "userList";
            this.userList.Size = new System.Drawing.Size(163, 238);
            this.userList.TabIndex = 5;
            this.userList.SelectedIndexChanged += new System.EventHandler(this.userList_SelectedIndexChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 459);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(102, 17);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "Только онлайн";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(186, 456);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Сообщение:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(260, 453);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(270, 20);
            this.textBox2.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(292, 479);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Отправить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonComms
            // 
            this.buttonComms.Location = new System.Drawing.Point(863, 494);
            this.buttonComms.Name = "buttonComms";
            this.buttonComms.Size = new System.Drawing.Size(43, 23);
            this.buttonComms.TabIndex = 10;
            this.buttonComms.Text = "cmd";
            this.buttonComms.UseVisualStyleBackColor = true;
            this.buttonComms.Click += new System.EventHandler(this.buttonComms_Click);
            // 
            // textBoxComms
            // 
            this.textBoxComms.Location = new System.Drawing.Point(944, 13);
            this.textBoxComms.Multiline = true;
            this.textBoxComms.Name = "textBoxComms";
            this.textBoxComms.ReadOnly = true;
            this.textBoxComms.Size = new System.Drawing.Size(446, 436);
            this.textBoxComms.TabIndex = 11;
            // 
            // textBoxComm
            // 
            this.textBoxComm.Location = new System.Drawing.Point(1002, 455);
            this.textBoxComm.Name = "textBoxComm";
            this.textBoxComm.Size = new System.Drawing.Size(304, 20);
            this.textBoxComm.TabIndex = 12;
            // 
            // labelComms
            // 
            this.labelComms.AutoSize = true;
            this.labelComms.Location = new System.Drawing.Point(941, 458);
            this.labelComms.Name = "labelComms";
            this.labelComms.Size = new System.Drawing.Size(55, 13);
            this.labelComms.TabIndex = 13;
            this.labelComms.Text = "Команда:";
            // 
            // buttonComm
            // 
            this.buttonComm.Location = new System.Drawing.Point(1312, 454);
            this.buttonComm.Name = "buttonComm";
            this.buttonComm.Size = new System.Drawing.Size(78, 22);
            this.buttonComm.TabIndex = 14;
            this.buttonComm.Text = "Отправить";
            this.buttonComm.UseVisualStyleBackColor = true;
            this.buttonComm.Click += new System.EventHandler(this.buttonComm_Click);
            // 
            // textBoxBoard
            // 
            this.textBoxBoard.Location = new System.Drawing.Point(537, 12);
            this.textBoxBoard.Multiline = true;
            this.textBoxBoard.Name = "textBoxBoard";
            this.textBoxBoard.ReadOnly = true;
            this.textBoxBoard.Size = new System.Drawing.Size(353, 437);
            this.textBoxBoard.TabIndex = 15;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 182);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(124, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "Проверить Онлайн";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Board
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 529);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBoxBoard);
            this.Controls.Add(this.buttonComm);
            this.Controls.Add(this.labelComms);
            this.Controls.Add(this.textBoxComm);
            this.Controls.Add(this.textBoxComms);
            this.Controls.Add(this.buttonComms);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.userList);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonGetBoard);
            this.Controls.Add(this.textBoxMsgs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Board";
            this.Text = "Board";
            this.Load += new System.EventHandler(this.Board_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxMsgs;
        private System.Windows.Forms.Button buttonGetBoard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox userList;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonComms;
        private System.Windows.Forms.TextBox textBoxComms;
        private System.Windows.Forms.TextBox textBoxComm;
        private System.Windows.Forms.Label labelComms;
        private System.Windows.Forms.Button buttonComm;
        private System.Windows.Forms.TextBox textBoxBoard;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
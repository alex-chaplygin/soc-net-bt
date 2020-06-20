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
            this.textBoxBoard = new System.Windows.Forms.TextBox();
            this.buttonGetBoard = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxBoard
            // 
            this.textBoxBoard.Location = new System.Drawing.Point(12, 12);
            this.textBoxBoard.MaxLength = 327670;
            this.textBoxBoard.Multiline = true;
            this.textBoxBoard.Name = "textBoxBoard";
            this.textBoxBoard.ReadOnly = true;
            this.textBoxBoard.Size = new System.Drawing.Size(701, 436);
            this.textBoxBoard.TabIndex = 0;
            // 
            // buttonGetBoard
            // 
            this.buttonGetBoard.Location = new System.Drawing.Point(456, 459);
            this.buttonGetBoard.Name = "buttonGetBoard";
            this.buttonGetBoard.Size = new System.Drawing.Size(124, 23);
            this.buttonGetBoard.TabIndex = 1;
            this.buttonGetBoard.Text = "Получить";
            this.buttonGetBoard.UseVisualStyleBackColor = true;
            this.buttonGetBoard.Click += new System.EventHandler(this.buttonGetBoard_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(119, 464);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Имя пользователя:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(231, 461);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(173, 20);
            this.textBoxName.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(410, 461);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(40, 20);
            this.textBox1.TabIndex = 4;
            // 
            // Board
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 495);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonGetBoard);
            this.Controls.Add(this.textBoxBoard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Board";
            this.Text = "Board";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxBoard;
        private System.Windows.Forms.Button buttonGetBoard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBox1;
    }
}
namespace ГрафическийКлиент
{
    partial class Commands
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
            this.buttonGetComms = new System.Windows.Forms.Button();
            this.textBoxComms = new System.Windows.Forms.TextBox();
            this.textGetComms = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonGetComms
            // 
            this.buttonGetComms.Location = new System.Drawing.Point(414, 418);
            this.buttonGetComms.Name = "buttonGetComms";
            this.buttonGetComms.Size = new System.Drawing.Size(96, 23);
            this.buttonGetComms.TabIndex = 0;
            this.buttonGetComms.Text = "Отправить";
            this.buttonGetComms.UseVisualStyleBackColor = true;
            this.buttonGetComms.Click += new System.EventHandler(this.buttonGetComms_Click);
            // 
            // textBoxComms
            // 
            this.textBoxComms.Location = new System.Drawing.Point(12, 420);
            this.textBoxComms.Name = "textBoxComms";
            this.textBoxComms.Size = new System.Drawing.Size(396, 20);
            this.textBoxComms.TabIndex = 1;
            // 
            // textGetComms
            // 
            this.textGetComms.Location = new System.Drawing.Point(12, 12);
            this.textGetComms.Multiline = true;
            this.textGetComms.Name = "textGetComms";
            this.textGetComms.ReadOnly = true;
            this.textGetComms.Size = new System.Drawing.Size(498, 402);
            this.textGetComms.TabIndex = 2;
            // 
            // Commands
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 450);
            this.Controls.Add(this.textGetComms);
            this.Controls.Add(this.textBoxComms);
            this.Controls.Add(this.buttonGetComms);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Commands";
            this.Text = "Commands";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGetComms;
        private System.Windows.Forms.TextBox textBoxComms;
        private System.Windows.Forms.TextBox textGetComms;
    }
}
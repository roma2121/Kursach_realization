namespace Kursach_realization
{
    partial class Information
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Information));
            richTextBox1 = new RichTextBox();
            richTextBox2 = new RichTextBox();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = Color.FromArgb(11, 83, 95);
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.ForeColor = Color.FromArgb(242, 197, 99);
            richTextBox1.Location = new Point(12, 12);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(560, 237);
            richTextBox1.TabIndex = 3;
            richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // richTextBox2
            // 
            richTextBox2.BackColor = Color.FromArgb(11, 83, 95);
            richTextBox2.BorderStyle = BorderStyle.None;
            richTextBox2.ForeColor = Color.FromArgb(242, 197, 99);
            richTextBox2.Location = new Point(12, 12);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.ReadOnly = true;
            richTextBox2.Size = new Size(560, 237);
            richTextBox2.TabIndex = 4;
            richTextBox2.Text = "Автор: Кругляков Роман Сергеевич\nг. Санкт-Петербург - ГУАП\n\n2023 г.\n";
            // 
            // Information
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 83, 95);
            ClientSize = new Size(584, 261);
            Controls.Add(richTextBox2);
            Controls.Add(richTextBox1);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            MaximumSize = new Size(600, 300);
            MinimumSize = new Size(600, 300);
            Name = "Information";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Information";
            Load += Information_Load;
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox richTextBox1;
        private RichTextBox richTextBox2;
    }
}
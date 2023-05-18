namespace Kursach_realization
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            menuStrip1 = new MenuStrip();
            информацияToolStripMenuItem = new ToolStripMenuItem();
            programToolStripMenuItem = new ToolStripMenuItem();
            authorToolStripMenuItem = new ToolStripMenuItem();
            настройкиToolStripMenuItem = new ToolStripMenuItem();
            размерКлючаToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            toolStripProgressBar1 = new ToolStripProgressBar();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            timer1 = new System.Windows.Forms.Timer(components);
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            button2 = new Button();
            button1 = new Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.FromArgb(11, 83, 95);
            menuStrip1.Items.AddRange(new ToolStripItem[] { информацияToolStripMenuItem, настройкиToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(300, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // информацияToolStripMenuItem
            // 
            информацияToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { programToolStripMenuItem, authorToolStripMenuItem });
            информацияToolStripMenuItem.Font = new Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            информацияToolStripMenuItem.ForeColor = Color.FromArgb(242, 197, 99);
            информацияToolStripMenuItem.Name = "информацияToolStripMenuItem";
            информацияToolStripMenuItem.Size = new Size(96, 20);
            информацияToolStripMenuItem.Text = " Информация";
            // 
            // programToolStripMenuItem
            // 
            programToolStripMenuItem.Font = new Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            programToolStripMenuItem.ForeColor = Color.FromArgb(242, 197, 99);
            programToolStripMenuItem.Name = "programToolStripMenuItem";
            programToolStripMenuItem.Size = new Size(149, 22);
            programToolStripMenuItem.Text = "О программе";
            programToolStripMenuItem.Click += programToolStripMenuItem_Click;
            // 
            // authorToolStripMenuItem
            // 
            authorToolStripMenuItem.Font = new Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            authorToolStripMenuItem.ForeColor = Color.FromArgb(242, 197, 99);
            authorToolStripMenuItem.Name = "authorToolStripMenuItem";
            authorToolStripMenuItem.Size = new Size(149, 22);
            authorToolStripMenuItem.Text = "Об авторе";
            authorToolStripMenuItem.Click += authorToolStripMenuItem_Click;
            // 
            // настройкиToolStripMenuItem
            // 
            настройкиToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { размерКлючаToolStripMenuItem });
            настройкиToolStripMenuItem.Font = new Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            настройкиToolStripMenuItem.ForeColor = Color.FromArgb(242, 197, 99);
            настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            настройкиToolStripMenuItem.Size = new Size(79, 20);
            настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // размерКлючаToolStripMenuItem
            // 
            размерКлючаToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem1, toolStripMenuItem2 });
            размерКлючаToolStripMenuItem.ForeColor = Color.FromArgb(242, 197, 99);
            размерКлючаToolStripMenuItem.Name = "размерКлючаToolStripMenuItem";
            размерКлючаToolStripMenuItem.Size = new Size(152, 22);
            размерКлючаToolStripMenuItem.Text = "Размер ключа";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Checked = true;
            toolStripMenuItem1.CheckOnClick = true;
            toolStripMenuItem1.CheckState = CheckState.Checked;
            toolStripMenuItem1.ForeColor = Color.FromArgb(242, 197, 99);
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(98, 22);
            toolStripMenuItem1.Text = "4096";
            toolStripMenuItem1.Click += toolStripMenuItem1_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.CheckOnClick = true;
            toolStripMenuItem2.ForeColor = Color.FromArgb(242, 197, 99);
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(98, 22);
            toolStripMenuItem2.Text = "8192";
            toolStripMenuItem2.Click += toolStripMenuItem2_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.BackColor = Color.FromArgb(11, 83, 95);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripProgressBar1, toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 254);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(300, 23);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            toolStripProgressBar1.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripProgressBar1.Maximum = 300;
            toolStripProgressBar1.Name = "toolStripProgressBar1";
            toolStripProgressBar1.Size = new Size(100, 17);
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.AutoSize = false;
            toolStripStatusLabel1.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripStatusLabel1.ForeColor = Color.FromArgb(242, 197, 99);
            toolStripStatusLabel1.Margin = new Padding(135, 3, 0, 2);
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(45, 18);
            toolStripStatusLabel1.Text = "00:00:00";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button2.BackColor = Color.Transparent;
            button2.FlatAppearance.BorderColor = Color.White;
            button2.FlatAppearance.BorderSize = 2;
            button2.FlatAppearance.MouseDownBackColor = Color.FromArgb(11, 83, 95);
            button2.FlatAppearance.MouseOverBackColor = Color.FromArgb(242, 197, 99);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button2.ForeColor = Color.White;
            button2.Location = new Point(158, 126);
            button2.Margin = new Padding(1);
            button2.Name = "button2";
            button2.Size = new Size(120, 28);
            button2.TabIndex = 7;
            button2.Text = "Расшифровка";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button1.BackColor = Color.Transparent;
            button1.FlatAppearance.BorderColor = Color.White;
            button1.FlatAppearance.MouseDownBackColor = Color.FromArgb(242, 197, 99);
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(11, 83, 95);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.White;
            button1.Location = new Point(22, 126);
            button1.Margin = new Padding(1);
            button1.Name = "button1";
            button1.Size = new Size(120, 28);
            button1.TabIndex = 6;
            button1.Text = "Шифрование";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(300, 277);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            Font = new Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MaximumSize = new Size(316, 316);
            MinimumSize = new Size(316, 316);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ShadowLock";
            FormClosing += Form1_FormClosing;
            Resize += Form1_Resize;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem информацияToolStripMenuItem;
        private ToolStripMenuItem programToolStripMenuItem;
        private ToolStripMenuItem authorToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripProgressBar toolStripProgressBar1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Timer timer1;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private ToolStripMenuItem настройкиToolStripMenuItem;
        private ToolStripMenuItem размерКлючаToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private Button button2;
        private Button button1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
using System.ComponentModel;

namespace Kursach_realization
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Устанавливаем интервал таймера в 1 секунду
            timer1.Interval = 1000;

            // Подписываемся на событие Tick таймера
            timer1.Tick += new EventHandler(timer_Tick);

            // Запускаем таймер
            timer1.Start();

            foreach (ToolStripMenuItem m in menuStrip1.Items)
            {
                SetWhiteColor(m);
            }
            menuStrip1.Renderer = new ToolStripProfessionalRenderer(new Cols());

            this.MaximizeBox = false;

            // настройка параметров BackgroundWorker
            backgroundWorker1.DoWork += worker_DoWork;
            backgroundWorker1.ProgressChanged += worker_ProgressChanged;
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
        }

        // Обработчик события Tick таймера
        private void timer_Tick(object sender, EventArgs e)
        {
            // Устанавливаем текст для ToolStripLabel
            toolStripStatusLabel1.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            // Изменение положения отображения времени в зависимости от размера формы
            int widthForm = this.Width;
            int toolStripSize = toolStripStatusLabel1.Width; // 45
            int toolStripProgressBarSize = toolStripProgressBar1.Width; // 100
            int newIndentation = widthForm - toolStripSize - toolStripProgressBarSize - 35;

            toolStripStatusLabel1.Margin = new Padding(newIndentation, 0, 3, 0);
        }

        private void programToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Information informationForm = new Information();
            informationForm.inf = 101;
            informationForm.Show();
        }

        private void authorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Information informationForm = new Information();
            informationForm.inf = 202;
            informationForm.Show();
        }

        // Создаем экземпляр класса Encryptor
        Encryptor encryptor = new Encryptor();

        private void button1_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();
            }

            toolStripProgressBar1.Value = 0;

            // запуск фонового потока
            backgroundWorker1.RunWorkerAsync();

            encryptor.StartEncrypt();

            if (backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();
            }

            toolStripProgressBar1.Value = toolStripProgressBar1.Maximum;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();
            }

            toolStripProgressBar1.Value = 0;

            // запуск фонового потока
            backgroundWorker1.RunWorkerAsync();

            encryptor.StartDencrypt();

            if (backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();

                Thread.Sleep(100);
            }

            toolStripProgressBar1.Value = toolStripProgressBar1.Maximum;
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i <= 100; i++)
            {
                if (backgroundWorker1.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                backgroundWorker1.ReportProgress(i);
                Thread.Sleep(300);
            }
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // обновление ProgressBar
            toolStripProgressBar1.Value = e.ProgressPercentage;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            toolStripMenuItem1.Checked = true;
            toolStripMenuItem2.Checked = false;

            encryptor.keySize = 4096;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            toolStripMenuItem1.Checked = false;
            toolStripMenuItem2.Checked = true;

            encryptor.keySize = 8192;
        }

        private void SetWhiteColor(ToolStripMenuItem item)
        {
            item.ForeColor = Color.FromArgb(242, 197, 99);
            foreach (ToolStripMenuItem it in item.DropDownItems)
            {
                SetWhiteColor(it);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();
            }
        }
    }

    public class Cols : ProfessionalColorTable
    {
        public override Color MenuItemSelected
        {
            // 51, 153, 255 - устанавливаем голубой цвет выбранного элемента
            // (или задаете свой)
            get { return Color.FromArgb(51, 153, 255); }
        }

        public override Color ToolStripDropDownBackground
        {
            get { return Color.FromArgb(11, 83, 95); }
        }

        public override Color ImageMarginGradientBegin
        {
            get { return Color.FromArgb(11, 83, 95); }
        }

        public override Color ImageMarginGradientEnd
        {
            get { return Color.FromArgb(11, 83, 95); }
        }

        public override Color ImageMarginGradientMiddle
        {
            get { return Color.FromArgb(11, 83, 95); }
        }

        public override Color MenuItemSelectedGradientBegin
        {
            get { return Color.FromArgb(11, 83, 95); }
        }
        public override Color MenuItemSelectedGradientEnd
        {
            get { return Color.FromArgb(11, 83, 95); }
        }

        public override Color MenuItemPressedGradientBegin
        {
            get { return Color.FromArgb(11, 83, 95); }
        }

        public override Color MenuItemPressedGradientMiddle
        {
            get { return Color.FromArgb(11, 83, 95); }
        }

        public override Color MenuItemPressedGradientEnd
        {
            get { return Color.FromArgb(11, 83, 95); }
        }

        public override Color MenuItemBorder
        {
            get { return Color.FromArgb(242, 197, 99); }
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Kursach_realization
{
    public partial class Information : Form
    {
        public Information()
        {
            InitializeComponent();

            this.Select();
        }

        public byte inf = 0;

        private void Information_Load(object sender, EventArgs e)
        {
            if (inf == 101)
            {
                this.Text = "О программе";

                richTextBox1.Visible = true;
                richTextBox2.Visible = false;
            }
            else
            {
                this.Text = "Об авторе";

                richTextBox1.Visible = false;
                richTextBox2.Visible = true;
            }
        }
    }
}

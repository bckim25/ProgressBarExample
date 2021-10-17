using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgressBarExample
{
    public partial class Form2 : Form
    {
        Timer timer = new Timer();

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            timer.Interval = 100;
            timer.Tick += new EventHandler(tick_go);
            
        }

        private void tick_go(object sender, EventArgs e)
        {
            progressBar1.Increment(1);
            label1.Text = progressBar1.Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
        }
    }
}

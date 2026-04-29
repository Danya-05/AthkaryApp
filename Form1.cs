using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AthkaryProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string selectedText = "";

        private void btnStart_Click(object sender, EventArgs e)
        {
            int minutes = (int)numericUpDown1.Value;
            timer1.Interval = minutes * 60 * 1000;

            // select the text of the checked radio button
            foreach (Control ctrl in panel1.Controls)
            {
                if (ctrl is RadioButton rb && rb.Checked)
                {
                    selectedText = rb.Text;
                    break;
                }
            }

            timer1.Enabled = true;
            numericUpDown1.Enabled = false;
            btnStart.Text = "...يعمل";
            btnStart.Enabled = false;
            panel1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            notifyIcon1.BalloonTipTitle = selectedText;
            notifyIcon1.ShowBalloonTip(3000);        
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            numericUpDown1.Enabled = true;
            btnStart.Text = "بدء";
            btnStart.Enabled = true;
            panel1.Enabled = true;
        }

        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            this.Show();
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            this.Activate();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;   // امنع الإغلاق
                this.Hide();       // خليه يختفي بس
            }

            base.OnFormClosing(e);
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            this.Activate();
        }
    }
}

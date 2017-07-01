using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace multithreading
{
    public partial class MainForm : Form
    {
        private delegate void EventHandle();
        private bool stop = false;
        public MainForm()
        {
            InitializeComponent();
        }

        private void start1_Click(object sender, EventArgs e)
        {
            Thread _progressBar1Thread = new Thread(GoProgressBar);
            _progressBar1Thread.Start();
        }

        private void GoProgressBar()
        {
            Invoke(new EventHandle(() =>
            {
                progressBar.Style = ProgressBarStyle.Marquee;
                progressBar.MarqueeAnimationSpeed = 6;
            }));
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            FinishAll();
        }

        private void start2_Click(object sender, EventArgs e)
        {
            Thread _progressBar2Thread = new Thread(new ThreadStart(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    if (stop == true)
                    {
                        progressBar2.BeginInvoke(new Action(() => progressBar2.Value = 0));
                        stop = false;
                        return;
                    }

                    Thread.Sleep(40);
                    progressBar2.BeginInvoke(new Action(() => progressBar2.Value = i));
                }
                Thread.Sleep(2000);
                progressBar2.BeginInvoke(new Action(() =>
                {
                    FinishAll();
                    stop = false;
                }));
            }));

            _progressBar2Thread.Start();
        }

        private void FinishAll()
        {
            stop = true;
            progressBar.Style = ProgressBarStyle.Continuous;
            progressBar.MarqueeAnimationSpeed = 0;
            progressBar2.Value = 0;
        }
    }
}

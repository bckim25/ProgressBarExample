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

namespace ProgressBarExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Task ProcessData(List<string> list,IProgress<ProgressReport> progress)
        {
            int index = 1;
            int totalProcess = list.Count;
            var progressReport = new ProgressReport();
            return Task.Run(() =>
            {
                for(int i = 0; i < totalProcess; i++)
                {
                    progressReport.PercentComplete = index++ * 100 / totalProcess;
                    progress.Report(progressReport);
                    Thread.Sleep(10);
                }
            });
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            for(int i = 0; i < 100; i++)
                list.Add(i.ToString());
            lblStatus.Text = "Working...";
            var progress = new Progress<ProgressReport>();
            progress.ProgressChanged += (o, report) =>
              {
                  lblStatus.Text = string.Format("Processing ...{0}%", report.PercentComplete);
                  progressBar.Value = report.PercentComplete;
                  progressBar.Update();
              };
            await ProcessData(list, progress);
            lblStatus.Text = "Done !";
        }
    }
}

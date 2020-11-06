using System;
using System.Windows.Forms;

namespace Worker
{
    public class Worker
    {
        ProgressBar progressBar { get; }

        public Worker(ProgressBar progBar)
        {
            progressBar = progBar;
        }

        public void UpdateMax(int max)
        {
            progressBar.Invoke(new Action(() => progressBar.Maximum = max));
        }

        public void UpdateMin(int min)
        {
            progressBar.Invoke(new Action(() => progressBar.Minimum = min));
        }

        public void UpdateValue(int value)
        {
            progressBar.Invoke(new Action(() => progressBar.Value = value));
        }

        public void SetMax()
        {
            progressBar.Invoke(new Action(() => progressBar.Value = progressBar.Maximum));
        }

        public void CallFinish()
        {
            progressBar.Invoke(new Action(() => progressBar.TabIndex++));
        }
    }
}

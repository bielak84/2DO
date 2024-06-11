using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2DO
{
    public partial class TaskCard : UserControl
    {
        public Task Task { get; private set; }

        public event Action<Task> EditTask;
        public event Action<Task> DeleteTask;
        public event Action<Task> CopyTask;
        public event Action<Task> ShowTask;
        public event Action<Task> MarkAsCompleted;
        public event Action<Task> MarkAsNotCompleted;

        public TaskCard(Task task)
        {
            InitializeComponent();
            Task = task;
            lblTitle.Text = task.Title;
            UpdateTimeLabel();
            //adjust margins to center controls
            lblTitle.Margin = new Padding(0, (flowLayoutPanel2.Height - lblTitle.Height) / 2, 0, 0);
            lblTimeLeft.Margin = new Padding(0, (flowLayoutPanel2.Height - lblTimeLeft.Height) / 2, 0, 0);
            lblPriority.Margin = new Padding(0, (flowLayoutPanel2.Height - lblPriority.Height) / 2, 0, 0);
            btnCopy.Margin = new Padding(0, (flowLayoutPanel1.Height - btnCopy.Height) / 2, 0, 0);
            btnDelete.Margin = new Padding(0, (flowLayoutPanel1.Height - btnDelete.Height) / 2, 0, 0);
            btnEdit.Margin = new Padding(0, (flowLayoutPanel1.Height - btnEdit.Height) / 2, 0, 0);
            btnShow.Margin = new Padding(0, (flowLayoutPanel1.Height - btnShow.Height) / 2, 0, 0);
            lblPriority.Text = $"[{TaskPriority.GetName(typeof(TaskPriority), (int)Task.Priority)}]";

            //adjust layout panel to match control minimum control width
            flowLayoutPanel2.Width = lblTitle.Width + lblTimeLeft.Width + lblPriority.Width;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditTask?.Invoke(Task);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteTask?.Invoke(Task);
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            CopyTask?.Invoke(Task);
        }
        private void btnShow_Click(object sender, EventArgs e)
        {
            ShowTask?.Invoke(Task);
        }
        public void UpdateTimeLabel()
        {
            TimeSpan timeRemaining = Task.EndDate - DateTime.Now;
            if (Task.TaskCompleted)
            {
                lblTimeLeft.Text = "[Completed]";
                flowLayoutPanel2.Width = lblTitle.Width + lblTimeLeft.Width + lblPriority.Width;
                return;
            }
            if (timeRemaining.TotalSeconds > 0)
            {
                if (timeRemaining.TotalDays >= 1)
                {
                    lblTimeLeft.Text = string.Format("[{0:%d} days {0:hh\\:mm\\:ss}]", timeRemaining);
                }
                else
                {
                    lblTimeLeft.Text = "[" + timeRemaining.ToString(@"hh\:mm\:ss") + "]";
                }
            }
            else
            {
                lblTimeLeft.Text = "[Time's up!]";
            }
            flowLayoutPanel2.Width = lblTitle.Width + lblTimeLeft.Width + lblPriority.Width;
        }

        private void markAsCompletedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MarkAsCompleted?.Invoke(Task);

        }

        private void markAsNotCompletedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MarkAsNotCompleted?.Invoke(Task);
        }
    }
}

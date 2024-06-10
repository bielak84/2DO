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
    public enum TaskFormWindowMode
    {
        Create,
        Show,
        Edit
    }
    public partial class TaskForm : Form
    {
        public TaskFormWindowMode windowMode { get; private set; }
        public Task task { get; private set; }
        public string exMsg { get; private set; }
        public Exception exception { get; private set; }
        private bool saved = false;
        List<Category> categories = new List<Category>();
        public TaskForm(TaskFormWindowMode windowMode, List<Category> categories, Task task = null)
        {
            InitializeComponent();
            this.windowMode = windowMode;
            this.task = task ?? new Task();
            this.categories = categories;
            LoadCategories();
            this.cmbCategory.SelectedIndex = 0;
            this.cmbPriority.SelectedIndex = 0;
            InitializeForm();
        }
        private void InitializeForm()
        {
            switch (this.windowMode)
            {
                case TaskFormWindowMode.Create:
                    task = new Task();
                    break;
                case TaskFormWindowMode.Show:
                    ShowTask();
                    break;
                case TaskFormWindowMode.Edit:
                    LoadTaskData();
                    break;
                default:
                    break;
            }
        }
        private void LoadCategories()
        {
            if (categories.Count == 0)
            {
                cmbCategory.Items.Add("Empty");
                return;
            }
            foreach (var category in categories)
            {
                cmbCategory.Items.Add(category.Name);
            }
        }
        private void LoadTaskData()
        {
            //load data
            txtTitle.Text = task.Title;
            txtDescription.Text = task.Description;
            dtpEndDate.Value = task.EndDate;
            dtpEndTime.Value = task.EndDate;
            cmbPriority.SelectedIndex = (int)task.Priority;
            cmbCategory.SelectedIndex = task.CategoryId;
            notificationMinutesPicker.Value = (int)task.notificationThreshold.TotalMinutes;
        }
        private void ShowTask()
        {
            LoadTaskData();

            //setup controls
            txtTitle.ReadOnly = true;
            txtDescription.ReadOnly = true;
            dtpEndTime.Enabled = false;
            dtpEndDate.Enabled = false;
            cmbPriority.Enabled = false;
            cmbCategory.Enabled = false;
            btnSave.Visible = false;
            notificationMinutesPicker.Enabled = false;
        }
        private void EditTask()
        {
            task.Title = txtTitle.Text;
            task.Description = txtDescription.Text;
            DateTime date = dtpEndDate.Value.Date + dtpEndTime.Value.TimeOfDay;
            if(task.EndDate != date)
            {
                task.notifiedOnThreshold = false;
                task.notifiedOnEndDate = false;
            }
            task.EndDate = date;
            task.notificationThreshold = TimeSpan.FromMinutes((int)notificationMinutesPicker.Value);
            task.Priority = (TaskPriority)cmbPriority.SelectedIndex;
            if(cmbCategory.SelectedIndex == 0 && cmbCategory.SelectedItem == "Empty")
            {
                task.CategoryId = -1;
                return;
            }
            task.CategoryId = cmbCategory.SelectedIndex;
        }
        private void CreateTask()
        {
            task.Title = txtTitle.Text;
            task.Description = txtDescription.Text;
            DateTime date = dtpEndDate.Value.Date + dtpEndTime.Value.TimeOfDay;
            task.EndDate = date;
            task.Priority = (TaskPriority)cmbPriority.SelectedIndex;
            task.CategoryId = cmbCategory.SelectedIndex;
            task.notificationThreshold = TimeSpan.FromMinutes((int)notificationMinutesPicker.Value);
            task.notifiedOnThreshold = false;
            task.notifiedOnEndDate = false;
        }
        private void TaskForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(windowMode == TaskFormWindowMode.Edit)
                {
                    EditTask();
                }
                else if(windowMode == TaskFormWindowMode.Create)
                {
                    CreateTask();
                }
                this.DialogResult = DialogResult.OK;
                this.saved = true;
            }
            catch (Exception ex)
            {
                this.DialogResult = DialogResult.Abort;
                this.exception = ex;
            }
            finally
            {
                this.Close();
            }
                
                
        }

        private void TaskForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //handle form close 
            if(!this.saved) 
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}

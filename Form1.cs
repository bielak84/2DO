using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Windows.Forms;

namespace _2DO
{
    public partial class Form1 : Form
    {
        private List<Task> tasks;
        private List<Category> categories;
        private FilterConfiguration taskFilter;
        private string defaultSortMode = "A-Z";
        private TaskContext _dbcontext;
        public Form1()
        {
            InitializeComponent();
            tasks = new List<Task>();
            categories = new List<Category>();
            taskFilter = new FilterConfiguration();
            taskFilter.sortOption = cmbSort.SelectedItem?.ToString() ?? defaultSortMode;
            taskFilter.HideCompleted = hideCompletedTasksCheckBox.Checked;
            cmbSort.SelectedIndex = 3;
        }
        //protected override void OnLoad(EventArgs e)
        
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            this._dbcontext?.Dispose();
            this._dbcontext = null;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this._dbcontext = new TaskContext();
            this._dbcontext.Database.EnsureCreated();
            this._dbcontext.Tasks.Load<Task>();
            this._dbcontext.Categories.Load<Category>();
            LoadTasks();
            LoadCategories();
            timer.Start();
        }
        private void LoadTasks()
        {
            Random r = new Random();
            //dummy data
            tasks = _dbcontext.Tasks.ToList();
            RefreshTaskList();
        }
        private void RefreshCategoryList()
        {
            cmbCategories.Items.Clear();
            foreach (Category category in categories)
            {
                cmbCategories.Items.Add(category.Name);
            }
            cmbCategories.SelectedIndex = 0;
        }
        private void LoadCategories()
        {
            //Add default category
            Category category = new Category();
            category.Id = 0;
            category.Name = "Default";
            categories.Add(category);
            cmbCategories.Items.Add(category.Name);

            //Add custom categories
            foreach (var c in _dbcontext.Categories)
            {
                categories.Add(c);
                cmbCategories.Items.Add(c.Name);
            }
            cmbCategories.SelectedIndex = 0;
        }
        private void RefreshTaskList()
        {
            flowLayoutPanel.Controls.Clear();
            var filter = taskFilter;


            //filter/sort tasks
            var filteredTasks = FilterTasks(txtFilter.Text);
            filteredTasks = SortTasks(filter.sortOption, filteredTasks);
            foreach (var task in filteredTasks)
            {
                if (filter != null)
                {
                    //check category | default -1 means show all tasks no matter what category they are assigned to
                    if (filter.CategoryId != 0 && task.CategoryId != filter.CategoryId)
                        continue;
                    //Hide completed tasks if filtered out
                    if (filter.HideCompleted && task.TaskCompleted)
                        continue;
                }

                var taskCard = new TaskCard(task);
                taskCard.EditTask += EditTask;
                taskCard.DeleteTask += DeleteTask;
                taskCard.CopyTask += CopyTask;
                taskCard.ShowTask += ShowTask;
                taskCard.MarkAsCompleted += MarkTaskAsCompleted;
                taskCard.MarkAsNotCompleted += MarkTaskAsNotCompleted;
                taskCard.Width = flowLayoutPanel.ClientSize.Width - taskCard.Margin.Horizontal;
                flowLayoutPanel.Controls.Add(taskCard);
            }
            //AdjustTaskCardWidths();
        }

        private void AdjustTaskCardWidths()
        {
            foreach (Control control in flowLayoutPanel.Controls)
            {
                if (control is TaskCard taskCard)
                {
                    taskCard.Width = flowLayoutPanel.ClientSize.Width - taskCard.Margin.Horizontal;
                }
            }
        }
        //Filter function supports searching tasks that contains filtered keywords only, returns list of tasks.
        private List<Task> FilterTasks(string searchText)
        {
            return tasks.Where(task =>
                task.Title.ToLower().Contains(searchText.ToLower()) ||
                task.Description.ToLower().Contains(searchText.ToLower())
            ).ToList();
        }
        private void MarkTaskAsCompleted(Task task)
        {
            task.TaskCompleted = true;
            _dbcontext.Tasks.Update(task);
            _dbcontext.SaveChanges();
        }
        private void MarkTaskAsNotCompleted(Task task)
        {
            task.TaskCompleted = false;
            _dbcontext.Tasks.Update(task);
            _dbcontext.SaveChanges();
        }
        private List<Task> SortTasks(string sortOption, List<Task> tasks)
        {
            switch (sortOption)
            {
                case "A-Z":
                    tasks.Sort((a, b) => a.Title.CompareTo(b.Title));
                    break;
                case "Z-A":
                    tasks.Sort((a, b) => b.Title.CompareTo(a.Title));
                    break;
                case "Priority":
                    tasks.Sort((a, b) => a.Priority.CompareTo(b.Priority));
                    break;
                case "End Date (Asc)":
                    tasks.Sort((a, b) => a.EndDate.CompareTo(b.EndDate));
                    break;
                case "End Date (Desc)":
                    tasks.Sort((a, b) => b.EndDate.CompareTo(a.EndDate));
                    break;
            }
            return tasks;
        }
        private void EditTask(Task task)
        {
            TaskForm taskForm = new TaskForm(windowMode: TaskFormWindowMode.Edit, categories: categories, task: task);
            if (taskForm.ShowDialog() == DialogResult.OK)
            {
                _dbcontext.Tasks.Update(taskForm.task);
                _dbcontext.SaveChanges();
                tasks.Remove(task);
                tasks.Add(taskForm.task);
                RefreshTaskList();
            }
            else
            {
                //handle other results
            }
        }
        private void UpdateNotification()
        {
            foreach(Task t in tasks)
            {
                if (t.TaskCompleted)
                    continue;
                TimeSpan timeRemaining = t.EndDate - DateTime.Now;
                if (timeRemaining > TimeSpan.Zero && timeRemaining <= t.notificationThreshold && !t.notifiedOnThreshold)
                {
                    t.notifiedOnThreshold = true;
                    ShowNotification(t.Title, $"{TaskPriority.GetName(typeof(TaskPriority), (int)t.Priority)} priorit - {timeRemaining.Minutes} minutes left");
                }
                if(timeRemaining <= TimeSpan.Zero && !t.notifiedOnEndDate)
                {
                    t.notifiedOnEndDate = true;
                    t.notifiedOnThreshold = true;
                    ShowNotification(t.Title, $"{TaskPriority.GetName(typeof(TaskPriority), (int)t.Priority)} priorit - Time's up!");
                }
            }
        }
        private void ShowNotification(string title, string text)
        {
            notifyIcon1.BalloonTipTitle = title;
            notifyIcon1.BalloonTipText = text;
            notifyIcon1.ShowBalloonTip(3000); // Show for 3 seconds
        }

        private void DeleteTask(Task task)
        {
            _dbcontext.Tasks.Remove(task);
            _dbcontext.SaveChanges();
            tasks.Remove(task);
            RefreshTaskList();
        }

        private void CopyTask(Task task)
        {
            Task newTask = task;
            var tMax = _dbcontext.Tasks.FirstOrDefault(newTask => newTask.Id == _dbcontext.Tasks.Max(x => x.Id));
            newTask.Id = tMax.Id + 1;
            _dbcontext.Tasks.Add(newTask);
            _dbcontext.SaveChanges();
            tasks.Add(newTask);
            RefreshTaskList();
        }
        private void ShowTask(Task task)
        {
            TaskForm taskForm = new TaskForm(windowMode: TaskFormWindowMode.Show, categories: categories, task: task);
            taskForm.ShowDialog();
        }

        private void flowLayoutPanel_Resize(object sender, EventArgs e)
        {
            AdjustTaskCardWidths();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            taskFilter.TxtFilterKeywords = txtFilter.Text;
            RefreshTaskList();
        }

        private void hideCompletedTasksCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            taskFilter.HideCompleted = hideCompletedTasksCheckBox.Checked;
            RefreshTaskList();
        }

        private void btnNewTask_Click(object sender, EventArgs e)
        {
            if (categories.Count == 0)
            {
                MessageBox.Show("Add at least one category before adding task!", "Error");
                return;
            }
            TaskForm taskForm = new TaskForm(windowMode: TaskFormWindowMode.Create, categories: categories);
            if (taskForm.ShowDialog() == DialogResult.OK)
            {
                _dbcontext.Tasks.Add(taskForm.task);
                _dbcontext.SaveChanges();
                tasks.Add(taskForm.task);
                RefreshTaskList();
            }
        }

        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            taskFilter.sortOption = cmbSort.SelectedItem?.ToString() ?? defaultSortMode;
            RefreshTaskList();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            foreach (Control control in flowLayoutPanel.Controls)
            {
                if (control is TaskCard taskCard)
                {
                    taskCard.UpdateTimeLabel();
                }
            }
            UpdateNotification();
        }

        private void btnCategoryManager_Click(object sender, EventArgs e)
        {
            CategoryManagerForm categoryManagerForm = new CategoryManagerForm(categories, _dbcontext);
            categoryManagerForm.ShowDialog();

            categories = categoryManagerForm.categories;
            RefreshCategoryList();
        }

        private void cmbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            taskFilter.CategoryId = cmbCategories.SelectedIndex;
            RefreshTaskList();
        }
    }
}

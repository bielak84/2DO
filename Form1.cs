using System.Windows.Forms;

namespace _2DO
{
    public partial class Form1 : Form
    {
        private List<Task> tasks;
        private List<Category> categories;
        private FilterConfiguration taskFilter;
        private string defaultSortMode = "A-Z";
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

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadTasks();
            LoadCategories();
            timer.Start();
        }
        private void LoadTasks()
        {
            Random r = new Random();
            //dummy data
            for (int i = 0; i < 25; i++)
            {
                DateTime date = DateTime.Now;
                date = date.AddDays(i);
                tasks.Add(new Task { Title = "Task " + (i + 1).ToString(), Description = $"Description {i + 1}", TaskCompleted = i % 2 == 0, EndDate = date, CategoryId = r.Next(0,5) });
            }
            RefreshTaskList();
        }
        private void RefreshCategoryList()
        {
            cmbCategories.Items.Clear();
            foreach(Category category in categories)
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
            for (int i = 1; i < 5; i++)
            {
                category = new Category();
                category.Id = i;
                category.Name = "Category " + i.ToString();
                categories.Add(category);
                cmbCategories.Items.Add(category.Name);
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
                tasks.Remove(task);
                tasks.Add(taskForm.task);
                RefreshTaskList();
            }
            else
            {
                //handle other results
            }

        }

        private void DeleteTask(Task task)
        {
            tasks.Remove(task);
            RefreshTaskList();
        }

        private void CopyTask(Task task)
        {
            Task newTask = task;
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
        }

        private void btnCategoryManager_Click(object sender, EventArgs e)
        {
            CategoryManagerForm categoryManagerForm = new CategoryManagerForm(categories);
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

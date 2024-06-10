namespace _2DO
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            flowLayoutPanel = new FlowLayoutPanel();
            panel1 = new Panel();
            lblCategoryFilter = new Label();
            cmbCategories = new ComboBox();
            btnCategoryManager = new Button();
            cmbSort = new ComboBox();
            hideCompletedTasksCheckBox = new CheckBox();
            txtFilter = new TextBox();
            btnNewTask = new Button();
            timer = new System.Windows.Forms.Timer(components);
            notifyIcon1 = new NotifyIcon(components);
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel.Location = new Point(0, 59);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Padding = new Padding(0, 0, 10, 0);
            flowLayoutPanel.Size = new Size(834, 443);
            flowLayoutPanel.TabIndex = 0;
            flowLayoutPanel.WrapContents = false;
            flowLayoutPanel.Resize += flowLayoutPanel_Resize;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(lblCategoryFilter);
            panel1.Controls.Add(cmbCategories);
            panel1.Controls.Add(btnCategoryManager);
            panel1.Controls.Add(cmbSort);
            panel1.Controls.Add(hideCompletedTasksCheckBox);
            panel1.Controls.Add(txtFilter);
            panel1.Controls.Add(btnNewTask);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(834, 60);
            panel1.TabIndex = 1;
            // 
            // lblCategoryFilter
            // 
            lblCategoryFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCategoryFilter.AutoSize = true;
            lblCategoryFilter.Location = new Point(616, 33);
            lblCategoryFilter.Name = "lblCategoryFilter";
            lblCategoryFilter.RightToLeft = RightToLeft.No;
            lblCategoryFilter.Size = new Size(88, 15);
            lblCategoryFilter.TabIndex = 6;
            lblCategoryFilter.Text = "Show category:";
            // 
            // cmbCategories
            // 
            cmbCategories.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbCategories.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategories.FormattingEnabled = true;
            cmbCategories.Location = new Point(710, 30);
            cmbCategories.Name = "cmbCategories";
            cmbCategories.Size = new Size(121, 23);
            cmbCategories.TabIndex = 5;
            cmbCategories.SelectedIndexChanged += cmbCategories_SelectedIndexChanged;
            // 
            // btnCategoryManager
            // 
            btnCategoryManager.Location = new Point(84, 3);
            btnCategoryManager.Name = "btnCategoryManager";
            btnCategoryManager.Size = new Size(75, 23);
            btnCategoryManager.TabIndex = 4;
            btnCategoryManager.Text = "Categories";
            btnCategoryManager.UseVisualStyleBackColor = true;
            btnCategoryManager.Click += btnCategoryManager_Click;
            // 
            // cmbSort
            // 
            cmbSort.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbSort.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSort.FormattingEnabled = true;
            cmbSort.Items.AddRange(new object[] { "A-Z", "Z-A", "Priority", "End Date (Asc)", "End Date (Desc)" });
            cmbSort.Location = new Point(710, 3);
            cmbSort.Name = "cmbSort";
            cmbSort.Size = new Size(121, 23);
            cmbSort.TabIndex = 3;
            cmbSort.SelectedIndexChanged += cmbSort_SelectedIndexChanged;
            // 
            // hideCompletedTasksCheckBox
            // 
            hideCompletedTasksCheckBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            hideCompletedTasksCheckBox.AutoSize = true;
            hideCompletedTasksCheckBox.Checked = true;
            hideCompletedTasksCheckBox.CheckState = CheckState.Checked;
            hideCompletedTasksCheckBox.Location = new Point(429, 5);
            hideCompletedTasksCheckBox.Name = "hideCompletedTasksCheckBox";
            hideCompletedTasksCheckBox.Size = new Size(113, 19);
            hideCompletedTasksCheckBox.TabIndex = 2;
            hideCompletedTasksCheckBox.Text = "Hide Completed";
            hideCompletedTasksCheckBox.UseVisualStyleBackColor = true;
            hideCompletedTasksCheckBox.CheckedChanged += hideCompletedTasksCheckBox_CheckedChanged;
            // 
            // txtFilter
            // 
            txtFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtFilter.Location = new Point(548, 3);
            txtFilter.Name = "txtFilter";
            txtFilter.PlaceholderText = "Search keywords...";
            txtFilter.Size = new Size(156, 23);
            txtFilter.TabIndex = 1;
            txtFilter.TextChanged += txtFilter_TextChanged;
            // 
            // btnNewTask
            // 
            btnNewTask.Location = new Point(3, 3);
            btnNewTask.Name = "btnNewTask";
            btnNewTask.Size = new Size(75, 23);
            btnNewTask.TabIndex = 0;
            btnNewTask.Text = "New Task";
            btnNewTask.UseVisualStyleBackColor = true;
            btnNewTask.Click += btnNewTask_Click;
            // 
            // timer
            // 
            timer.Interval = 1000;
            timer.Tick += timer_Tick;
            // 
            // notifyIcon1
            // 
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.Icon = SystemIcons.Information;
            notifyIcon1.Text = "notifyIcon1";
            notifyIcon1.Visible = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(834, 503);
            Controls.Add(panel1);
            Controls.Add(flowLayoutPanel);
            MaximizeBox = false;
            MinimumSize = new Size(850, 300);
            Name = "Form1";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "2DO";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel;
        private Panel panel1;
        private Button btnNewTask;
        private TextBox txtFilter;
        private CheckBox hideCompletedTasksCheckBox;
        private ComboBox cmbSort;
        private System.Windows.Forms.Timer timer;
        private Button btnCategoryManager;
        private Label lblCategoryFilter;
        private ComboBox cmbCategories;
        private NotifyIcon notifyIcon1;
    }
}

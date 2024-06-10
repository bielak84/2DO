namespace _2DO
{
    partial class TaskForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtTitle = new TextBox();
            txtDescription = new TextBox();
            dtpEndDate = new DateTimePicker();
            dtpEndTime = new DateTimePicker();
            cmbPriority = new ComboBox();
            cmbCategory = new ComboBox();
            btnSave = new Button();
            lblDeadline = new Label();
            notificationMinutesPicker = new NumericUpDown();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)notificationMinutesPicker).BeginInit();
            SuspendLayout();
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(35, 12);
            txtTitle.Name = "txtTitle";
            txtTitle.PlaceholderText = "Title..";
            txtTitle.Size = new Size(329, 23);
            txtTitle.TabIndex = 0;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(35, 41);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.PlaceholderText = "Description...";
            txtDescription.Size = new Size(329, 104);
            txtDescription.TabIndex = 1;
            // 
            // dtpEndDate
            // 
            dtpEndDate.Location = new Point(35, 167);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(239, 23);
            dtpEndDate.TabIndex = 2;
            // 
            // dtpEndTime
            // 
            dtpEndTime.Format = DateTimePickerFormat.Time;
            dtpEndTime.Location = new Point(280, 167);
            dtpEndTime.Name = "dtpEndTime";
            dtpEndTime.ShowUpDown = true;
            dtpEndTime.Size = new Size(84, 23);
            dtpEndTime.TabIndex = 3;
            // 
            // cmbPriority
            // 
            cmbPriority.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPriority.FormattingEnabled = true;
            cmbPriority.Items.AddRange(new object[] { "1 - High", "2 - Medium", "3 - Low" });
            cmbPriority.Location = new Point(243, 225);
            cmbPriority.Name = "cmbPriority";
            cmbPriority.Size = new Size(121, 23);
            cmbPriority.TabIndex = 4;
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(35, 225);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(202, 23);
            cmbCategory.TabIndex = 5;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(35, 254);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(329, 23);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // lblDeadline
            // 
            lblDeadline.AutoSize = true;
            lblDeadline.Location = new Point(35, 149);
            lblDeadline.Name = "lblDeadline";
            lblDeadline.Size = new Size(81, 15);
            lblDeadline.TabIndex = 7;
            lblDeadline.Text = "Task end date:";
            // 
            // notificationMinutesPicker
            // 
            notificationMinutesPicker.Location = new Point(244, 196);
            notificationMinutesPicker.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            notificationMinutesPicker.Name = "notificationMinutesPicker";
            notificationMinutesPicker.Size = new Size(120, 23);
            notificationMinutesPicker.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(35, 198);
            label1.Name = "label1";
            label1.Size = new Size(200, 15);
            label1.TabIndex = 9;
            label1.Text = "Set reminder notification in minutes:";
            // 
            // TaskForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(403, 292);
            Controls.Add(label1);
            Controls.Add(notificationMinutesPicker);
            Controls.Add(lblDeadline);
            Controls.Add(btnSave);
            Controls.Add(cmbCategory);
            Controls.Add(cmbPriority);
            Controls.Add(dtpEndTime);
            Controls.Add(dtpEndDate);
            Controls.Add(txtDescription);
            Controls.Add(txtTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "TaskForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Creade or edit task";
            FormClosed += TaskForm_FormClosed;
            Load += TaskForm_Load;
            ((System.ComponentModel.ISupportInitialize)notificationMinutesPicker).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTitle;
        private TextBox txtDescription;
        private DateTimePicker dtpEndDate;
        private DateTimePicker dtpEndTime;
        private ComboBox cmbPriority;
        private ComboBox cmbCategory;
        private Button btnSave;
        private Label lblDeadline;
        private NumericUpDown notificationMinutesPicker;
        private Label label1;
    }
}
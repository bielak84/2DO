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
            SuspendLayout();
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(37, 41);
            txtTitle.Name = "txtTitle";
            txtTitle.PlaceholderText = "Title..";
            txtTitle.Size = new Size(329, 23);
            txtTitle.TabIndex = 0;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(37, 70);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.PlaceholderText = "Description...";
            txtDescription.Size = new Size(329, 104);
            txtDescription.TabIndex = 1;
            // 
            // dtpEndDate
            // 
            dtpEndDate.Location = new Point(37, 180);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(239, 23);
            dtpEndDate.TabIndex = 2;
            // 
            // dtpEndTime
            // 
            dtpEndTime.Format = DateTimePickerFormat.Time;
            dtpEndTime.Location = new Point(282, 180);
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
            cmbPriority.Location = new Point(245, 209);
            cmbPriority.Name = "cmbPriority";
            cmbPriority.Size = new Size(121, 23);
            cmbPriority.TabIndex = 4;
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(37, 209);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(202, 23);
            cmbCategory.TabIndex = 5;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(37, 238);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(329, 23);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // TaskForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(403, 293);
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
            Text = "TaskForm";
            FormClosed += TaskForm_FormClosed;
            Load += TaskForm_Load;
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
    }
}
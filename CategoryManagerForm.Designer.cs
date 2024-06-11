namespace _2DO
{
    partial class CategoryManagerForm
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
            btnCreateCategory = new Button();
            cmbCategory = new ComboBox();
            txtCategoryName = new TextBox();
            lblCategoryName = new Label();
            btnCancelEdit = new Button();
            lblCategorySelect = new Label();
            btnDelete = new Button();
            SuspendLayout();
            // 
            // btnCreateCategory
            // 
            btnCreateCategory.Location = new Point(42, 97);
            btnCreateCategory.Name = "btnCreateCategory";
            btnCreateCategory.Size = new Size(209, 23);
            btnCreateCategory.TabIndex = 0;
            btnCreateCategory.Text = "Create";
            btnCreateCategory.UseVisualStyleBackColor = true;
            btnCreateCategory.Click += btnCreateCategory_Click;
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(42, 24);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(209, 23);
            cmbCategory.TabIndex = 1;
            cmbCategory.SelectedIndexChanged += cmbCategory_SelectedIndexChanged;
            // 
            // txtCategoryName
            // 
            txtCategoryName.Location = new Point(42, 68);
            txtCategoryName.Name = "txtCategoryName";
            txtCategoryName.Size = new Size(209, 23);
            txtCategoryName.TabIndex = 2;
            // 
            // lblCategoryName
            // 
            lblCategoryName.AutoSize = true;
            lblCategoryName.Location = new Point(42, 50);
            lblCategoryName.Name = "lblCategoryName";
            lblCategoryName.Size = new Size(91, 15);
            lblCategoryName.TabIndex = 3;
            lblCategoryName.Text = "Category name:";
            // 
            // btnCancelEdit
            // 
            btnCancelEdit.Enabled = false;
            btnCancelEdit.Location = new Point(42, 126);
            btnCancelEdit.Name = "btnCancelEdit";
            btnCancelEdit.Size = new Size(209, 23);
            btnCancelEdit.TabIndex = 4;
            btnCancelEdit.Text = "Cancel";
            btnCancelEdit.UseVisualStyleBackColor = true;
            btnCancelEdit.Visible = false;
            btnCancelEdit.Click += btnCancelEdit_Click;
            // 
            // lblCategorySelect
            // 
            lblCategorySelect.AutoSize = true;
            lblCategorySelect.Location = new Point(42, 6);
            lblCategorySelect.Name = "lblCategorySelect";
            lblCategorySelect.Size = new Size(90, 15);
            lblCategorySelect.TabIndex = 5;
            lblCategorySelect.Text = "Select category:";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(42, 155);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(209, 23);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "Delete selected";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            btnDelete.Visible = false;
            btnDelete.Enabled = false;
            // 
            // CategoryManagerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(285, 195);
            Controls.Add(btnDelete);
            Controls.Add(lblCategorySelect);
            Controls.Add(btnCancelEdit);
            Controls.Add(lblCategoryName);
            Controls.Add(txtCategoryName);
            Controls.Add(cmbCategory);
            Controls.Add(btnCreateCategory);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "CategoryManagerForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Category Manager";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCreateCategory;
        private ComboBox cmbCategory;
        private TextBox txtCategoryName;
        private Label lblCategoryName;
        private Button btnCancelEdit;
        private Label lblCategorySelect;
        private Button btnDelete;
    }
}
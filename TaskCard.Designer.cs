namespace _2DO
{
    partial class TaskCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblTitle = new Label();
            btnDelete = new Button();
            btnEdit = new Button();
            btnCopy = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnShow = new Button();
            flowLayoutPanel2 = new FlowLayoutPanel();
            lblTimeLeft = new Label();
            lblPriority = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            markAsCompletedToolStripMenuItem = new ToolStripMenuItem();
            markAsNotCompletedToolStripMenuItem = new ToolStripMenuItem();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(91, 3);
            lblTitle.Margin = new Padding(3);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(38, 15);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "label1";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(259, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 25);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(97, 3);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(75, 25);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnCopy
            // 
            btnCopy.Location = new Point(178, 3);
            btnCopy.Name = "btnCopy";
            btnCopy.Size = new Size(75, 25);
            btnCopy.TabIndex = 3;
            btnCopy.Text = "Copy";
            btnCopy.UseVisualStyleBackColor = true;
            btnCopy.Click += btnCopy_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnDelete);
            flowLayoutPanel1.Controls.Add(btnCopy);
            flowLayoutPanel1.Controls.Add(btnEdit);
            flowLayoutPanel1.Controls.Add(btnShow);
            flowLayoutPanel1.Dock = DockStyle.Right;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(463, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(337, 35);
            flowLayoutPanel1.TabIndex = 4;
            flowLayoutPanel1.WrapContents = false;
            // 
            // btnShow
            // 
            btnShow.Location = new Point(16, 3);
            btnShow.Name = "btnShow";
            btnShow.Size = new Size(75, 25);
            btnShow.TabIndex = 4;
            btnShow.Text = "Show";
            btnShow.UseVisualStyleBackColor = true;
            btnShow.Click += btnShow_Click;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.BorderStyle = BorderStyle.None;
            flowLayoutPanel2.Controls.Add(lblTimeLeft);
            flowLayoutPanel2.Controls.Add(lblPriority);
            flowLayoutPanel2.Controls.Add(lblTitle);
            flowLayoutPanel2.Dock = DockStyle.Left;
            flowLayoutPanel2.Location = new Point(0, 0);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(457, 35);
            flowLayoutPanel2.TabIndex = 5;
            flowLayoutPanel2.WrapContents = false;
            // 
            // lblTimeLeft
            // 
            lblTimeLeft.AutoSize = true;
            lblTimeLeft.Location = new Point(3, 0);
            lblTimeLeft.Name = "lblTimeLeft";
            lblTimeLeft.Size = new Size(38, 15);
            lblTimeLeft.TabIndex = 1;
            lblTimeLeft.Text = "label1";
            // 
            // lblPriority
            // 
            lblPriority.AutoSize = true;
            lblPriority.Location = new Point(47, 0);
            lblPriority.Name = "lblPriority";
            lblPriority.Size = new Size(38, 15);
            lblPriority.TabIndex = 2;
            lblPriority.Text = "label1";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { markAsCompletedToolStripMenuItem, markAsNotCompletedToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(197, 48);
            // 
            // markAsCompletedToolStripMenuItem
            // 
            markAsCompletedToolStripMenuItem.Name = "markAsCompletedToolStripMenuItem";
            markAsCompletedToolStripMenuItem.Size = new Size(196, 22);
            markAsCompletedToolStripMenuItem.Text = "Mark as completed";
            markAsCompletedToolStripMenuItem.Click += markAsCompletedToolStripMenuItem_Click;
            // 
            // markAsNotCompletedToolStripMenuItem
            // 
            markAsNotCompletedToolStripMenuItem.Name = "markAsNotCompletedToolStripMenuItem";
            markAsNotCompletedToolStripMenuItem.Size = new Size(196, 22);
            markAsNotCompletedToolStripMenuItem.Text = "Mark as not completed";
            markAsNotCompletedToolStripMenuItem.Click += markAsNotCompletedToolStripMenuItem_Click;
            // 
            // TaskCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BorderStyle = BorderStyle.FixedSingle;
            ContextMenuStrip = contextMenuStrip1;
            Controls.Add(flowLayoutPanel2);
            Controls.Add(flowLayoutPanel1);
            Margin = new Padding(3, 3, 3, 5);
            Name = "TaskCard";
            Size = new Size(800, 35);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitle;
        private Button btnDelete;
        private Button btnEdit;
        private Button btnCopy;
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button btnShow;
        private Label lblTimeLeft;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem markAsCompletedToolStripMenuItem;
        private ToolStripMenuItem markAsNotCompletedToolStripMenuItem;
        private Label lblPriority;
    }
}

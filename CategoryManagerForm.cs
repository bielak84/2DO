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
    public partial class CategoryManagerForm : Form
    {
        bool editMode = false;
        public List<Category> categories;
        Category currentCategory;
        private TaskContext _dbcontext;
        public CategoryManagerForm(List<Category> categories, TaskContext dbcontext)
        {
            InitializeComponent();
            this.categories = categories;
            cmbCategory.Text = "Select category..";
            LoadCategories();
            _dbcontext = dbcontext;
        }
        private void LoadCategories()
        {
            cmbCategory.Items.Clear();
            foreach (Category category in categories)
            {
                if (category.Id != 0)
                    cmbCategory.Items.Add(category.Name);
            }
        }
        private void btnCreateCategory_Click(object sender, EventArgs e)
        {
            if (editMode && currentCategory != null)
            {
                int index = categories.FindIndex(c => c == currentCategory);

                if (index == 0)
                {
                    MessageBox.Show("Category not found", "Error");
                    return;
                }
                if (txtCategoryName.Text == string.Empty)
                {
                    MessageBox.Show("Category name can not be empty!", "Error");
                    return;
                }

                currentCategory.Name = txtCategoryName.Text;
                categories[index] = currentCategory;
                _dbcontext.Categories.Update(currentCategory);
                _dbcontext.SaveChanges();
                LoadCategories();
                cmbCategory.SelectedIndex = index - 1;
            }
            else if (!editMode && currentCategory == null)
            {
                currentCategory = new Category();
                currentCategory.Name = txtCategoryName.Text;
                currentCategory.Id = categories.Count;
                categories.Add(currentCategory);
                _dbcontext.Categories.Add(currentCategory);
                _dbcontext.SaveChanges();
                LoadCategories();
                cmbCategory.SelectedIndex = currentCategory.Id - 1;
                currentCategory = null;
            }
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            editMode = true;
            btnCancelEdit.Enabled = true;
            btnCancelEdit.Visible = true;
            btnDelete.Visible = true;
            btnDelete.Enabled = true;
            btnCreateCategory.Text = "Save";
            currentCategory = categories.Where(x => x.Name.Equals(cmbCategory.SelectedItem.ToString())).First();
            txtCategoryName.Text = currentCategory.Name;
        }

        private void btnCancelEdit_Click(object sender, EventArgs e)
        {
            editMode = false;
            btnCancelEdit.Enabled = false;
            btnCancelEdit.Visible = false;
            btnDelete.Visible = false;
            btnDelete.Enabled = false;
            cmbCategory.Text = "Select category";
            btnCreateCategory.Text = "Create";
            txtCategoryName.Text = "";
            currentCategory = null;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            categories.Remove(currentCategory);
            _dbcontext.Remove(currentCategory);
            _dbcontext.SaveChanges();
            LoadCategories();
            editMode = false;
            btnCancelEdit.Enabled = false;
            btnCancelEdit.Visible = false;
            btnDelete.Visible = false;
            btnDelete.Enabled = false;
            cmbCategory.Text = "Select category";
            btnCreateCategory.Text = "Create";
            txtCategoryName.Text = "";
            currentCategory = null;
        }
    }
}

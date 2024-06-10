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
        public CategoryManagerForm(List<Category> categories)
        {
            InitializeComponent();
            this.categories = categories;
            cmbCategory.Text = "Select category..";
            LoadCategories();
        }
        private void LoadCategories()
        {
            cmbCategory.Items.Clear();
            foreach (Category category in categories)
            {
                if(category.Id != 0)
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
                LoadCategories();
                cmbCategory.SelectedIndex = index - 1;
            }
            else if (!editMode && currentCategory == null)
            {
                currentCategory = new Category();
                currentCategory.Name = txtCategoryName.Text;
                currentCategory.Id = categories.Count;
                categories.Add(currentCategory);
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
            btnCreateCategory.Text = "Save";
            currentCategory = categories.Where(x => x.Name.Equals(cmbCategory.SelectedItem.ToString())).First();
            txtCategoryName.Text = currentCategory.Name;
        }

        private void btnCancelEdit_Click(object sender, EventArgs e)
        {
            editMode = false;
            btnCancelEdit.Enabled = false;
            btnCancelEdit.Visible = false;
            cmbCategory.Text = "Select category";
            btnCreateCategory.Text = "Create";
            txtCategoryName.Text = "";
            currentCategory = null;
        }
    }
}

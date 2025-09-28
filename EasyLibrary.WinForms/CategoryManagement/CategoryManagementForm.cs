using EasyLibrary.Core.Interfaces;
using EasyLibrary.Core.Models;
using EasyLibrary.Core.Services;

namespace EasyLibrary.WinForms.CategoryManagement;

public partial class CategoryManagementForm : Form
{
    private readonly ICategoryService _categoryService;
    private List<CategoryDto> _allCategories;
    private CategoryDto _selectedCategory;

    public CategoryManagementForm()
    {
        InitializeComponent();
        _categoryService = new CategoryService();
        _allCategories = new List<CategoryDto>();

        // Subscribe to DataGridView selection event
        DgvAllCategories.SelectionChanged += DgvAllCategories_SelectionChanged;

        // Load initial data
        LoadInitialDataAsync();
    }

    private async void LoadInitialDataAsync()
    {
        try
        {
            await LoadCategoriesAsync();
            UpdateStatisticsLabels();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading initial data: {ex.Message}", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private async Task LoadCategoriesAsync()
    {
        try
        {
            _allCategories = await _categoryService.GetAllCategoriesAsync();
            DisplayCategories(_allCategories.Where(c => c.IsActive).ToList());
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading categories: {ex.Message}", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void DisplayCategories(List<CategoryDto> categories)
    {
        var categoryDisplay = categories.Select(c => new
        {
            c.Id,
            c.Name,
            c.Description,
            IsActive = c.IsActive ? "Yes" : "No",
            CreatedOn = c.CreatedOn.ToString("yyyy-MM-dd"),
            BooksCount = c.Books?.Count ?? 0
        }).ToList();

        DgvAllCategories.DataSource = categoryDisplay;

        // Configure column headers and widths
        if (DgvAllCategories.Columns.Count > 0)
        {
            DgvAllCategories.Columns["Id"].HeaderText = "ID";
            DgvAllCategories.Columns["Id"].Width = 50;
            DgvAllCategories.Columns["Name"].HeaderText = "Category Name";
            DgvAllCategories.Columns["Name"].Width = 150;
            DgvAllCategories.Columns["Description"].HeaderText = "Description";
            DgvAllCategories.Columns["Description"].Width = 300;
            DgvAllCategories.Columns["IsActive"].HeaderText = "Active";
            DgvAllCategories.Columns["IsActive"].Width = 70;
            DgvAllCategories.Columns["CreatedOn"].HeaderText = "Created";
            DgvAllCategories.Columns["CreatedOn"].Width = 100;
            DgvAllCategories.Columns["BooksCount"].HeaderText = "Books";
            DgvAllCategories.Columns["BooksCount"].Width = 70;
        }
    }

    private void UpdateStatisticsLabels()
    {
        var activeCategories = _allCategories.Where(c => c.IsActive).ToList();
        LblTotalCategories.Text = $"Total Categories: {activeCategories.Count}";
    }

    private void DgvAllCategories_SelectionChanged(object sender, EventArgs e)
    {
        if (DgvAllCategories.SelectedRows.Count > 0)
        {
            var selectedRow = DgvAllCategories.SelectedRows[0];
            var categoryId = (int)selectedRow.Cells["Id"].Value;

            _selectedCategory = _allCategories.FirstOrDefault(c => c.Id == categoryId);
            if (_selectedCategory != null)
            {
                PopulateFormFields(_selectedCategory);
            }
        }
    }

    private void PopulateFormFields(CategoryDto category)
    {
        txtCategoryName.Text = category.Name;
        TxtDescription.Text = category.Description;
        chkCategoryAvilable.Checked = category.IsActive;
    }

    private bool ValidateInput()
    {
        if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
        {
            MessageBox.Show("Please enter category name.", "Validation Error", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            txtCategoryName.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(TxtDescription.Text))
        {
            MessageBox.Show("Please enter category description.", "Validation Error", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            TxtDescription.Focus();
            return false;
        }

        // Check for duplicate category name when adding or updating
        var existingCategory = _allCategories.FirstOrDefault(c =>
            c.Name.Equals(txtCategoryName.Text.Trim(), StringComparison.OrdinalIgnoreCase) &&
            (_selectedCategory == null || c.Id != _selectedCategory.Id));

        if (existingCategory != null)
        {
            MessageBox.Show("A category with this name already exists.", "Validation Error", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            txtCategoryName.Focus();
            return false;
        }

        return true;
    }

    private CategoryDto CreateCategoryFromForm()
    {
        return new CategoryDto
        {
            Name = txtCategoryName.Text.Trim(),
            Description = TxtDescription.Text.Trim(),
            IsActive = chkCategoryAvilable.Checked
        };
    }

    private void ClearForm()
    {
        txtCategoryName.Clear();
        TxtDescription.Clear();
        chkCategoryAvilable.Checked = true;
        _selectedCategory = null;
    }

    private async void btnAddCategory_Click(object sender, EventArgs e)
    {
        try
        {
            if (!ValidateInput())
                return;

            var newCategory = CreateCategoryFromForm();
            await _categoryService.AddCategoryAsync(newCategory);

            MessageBox.Show("Category added successfully!", "Success", MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            await LoadCategoriesAsync();
            UpdateStatisticsLabels();
            ClearForm();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error adding category: {ex.Message}", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private async void BtnUpdateCategory_Click(object sender, EventArgs e)
    {
        try
        {
            if (_selectedCategory == null)
            {
                MessageBox.Show("Please select a category to update.", "Selection Required", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput())
                return;

            var updatedCategory = CreateCategoryFromForm();
            updatedCategory.Id = _selectedCategory.Id;
            updatedCategory.CreatedOn = _selectedCategory.CreatedOn;

            await _categoryService.UpdateCategoryAsync(updatedCategory);

            MessageBox.Show("Category updated successfully!", "Success", MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            await LoadCategoriesAsync();
            UpdateStatisticsLabels();
            ClearForm();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error updating category: {ex.Message}", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private async void BtnDeleteCategory_Click(object sender, EventArgs e)
    {
        try
        {
            if (_selectedCategory == null)
            {
                MessageBox.Show("Please select a category to delete.", "Selection Required", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Check if category has books before deleting
            var bookCount = _selectedCategory.Books?.Count ?? 0;
            if (bookCount > 0)
            {
                MessageBox.Show(
                    $"Cannot delete category '{_selectedCategory.Name}' because it contains {bookCount} book(s). Please move or delete the books first.",
                    "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"Are you sure you want to delete category '{_selectedCategory.Name}'?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                await _categoryService.DeleteCategoryAsync(_selectedCategory);

                MessageBox.Show("Category deleted successfully!", "Success", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                await LoadCategoriesAsync();
                UpdateStatisticsLabels();
                ClearForm();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error deleting category: {ex.Message}", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void BtnClearInformation_Click(object sender, EventArgs e)
    {
        ClearForm();
    }

    private async void BtnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            var searchTerm = txtSearchInput.Text.Trim();

            if (string.IsNullOrEmpty(searchTerm))
            {
                // If search term is empty, show all categories
                DisplayCategories(_allCategories.Where(c => c.IsActive).ToList());
                return;
            }

            // Filter categories by name or description
            var filteredCategories = _allCategories.Where(c => c.IsActive &&
                                                               (c.Name.Contains(searchTerm,
                                                                    StringComparison.OrdinalIgnoreCase) ||
                                                                c.Description.Contains(searchTerm,
                                                                    StringComparison.OrdinalIgnoreCase))).ToList();

            DisplayCategories(filteredCategories);

            if (!filteredCategories.Any())
            {
                MessageBox.Show("No categories found matching your search criteria.", "Search Results",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error searching categories: {ex.Message}", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private async void BtnRefresh_Click(object sender, EventArgs e)
    {
        try
        {
            txtSearchInput.Clear();
            await LoadCategoriesAsync();
            UpdateStatisticsLabels();
            ClearForm();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error refreshing data: {ex.Message}", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}
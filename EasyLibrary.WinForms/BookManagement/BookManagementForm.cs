using EasyLibrary.Core.Interfaces;
using EasyLibrary.Core.Models;
using EasyLibrary.Core.Services;

namespace EasyLibrary.WinForms.BookManagement;

public partial class BookManagementForm : Form
{
    private readonly IBookService _bookService;
    private readonly ICategoryService _categoryService;
    private List<BookDto> _allBooks;
    private List<CategoryDto> _categories;
    private BookDto _selectedBook;

    public BookManagementForm()
    {
        InitializeComponent();
        _bookService = new BookService();
        _categoryService = new CategoryService();
        _allBooks = new List<BookDto>();
        _categories = new List<CategoryDto>();

        // Subscribe to DataGridView selection event
        DgvAllBooks.SelectionChanged += DgvAllBooks_SelectionChanged;

        // Load initial data
        LoadInitialDataAsync();
    }

    private async void LoadInitialDataAsync()
    {
        try
        {
            await LoadCategoriesAsync();
            await LoadBooksAsync();
            await UpdateStatisticsLabelsAsync();
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
            _categories = await _categoryService.GetAllCategoriesAsync();

            cmbCategoies.DataSource = _categories.Where(c => c.IsActive).ToList();
            cmbCategoies.DisplayMember = "Name";
            cmbCategoies.ValueMember = "Id";
            cmbCategoies.SelectedIndex = -1;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading categories: {ex.Message}", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private async Task LoadBooksAsync()
    {
        try
        {
            _allBooks = await _bookService.GetAllBooksAsync();
            DisplayBooks(_allBooks.Where(b => b.IsActive).ToList());
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading books: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void DisplayBooks(List<BookDto> books)
    {
        var bookDisplay = books.Select(b => new
        {
            b.Id,
            b.Title,
            b.Author,
            b.ISBN,
            b.PublishedYear,
            Category = b.Category?.Name ?? "Unknown",
            IsAvailable = b.IsAvailable ? "Yes" : "No",
            CreatedOn = b.CreatedOn.ToString("yyyy-MM-dd")
        }).ToList();

        DgvAllBooks.DataSource = bookDisplay;

        // Configure column headers and widths
        if (DgvAllBooks.Columns.Count > 0)
        {
            DgvAllBooks.Columns["Id"].HeaderText = "ID";
            DgvAllBooks.Columns["Id"].Width = 50;
            DgvAllBooks.Columns["Title"].HeaderText = "Title";
            DgvAllBooks.Columns["Title"].Width = 150;
            DgvAllBooks.Columns["Author"].HeaderText = "Author";
            DgvAllBooks.Columns["Author"].Width = 120;
            DgvAllBooks.Columns["ISBN"].HeaderText = "ISBN";
            DgvAllBooks.Columns["ISBN"].Width = 100;
            DgvAllBooks.Columns["PublishedYear"].HeaderText = "Year";
            DgvAllBooks.Columns["PublishedYear"].Width = 60;
            DgvAllBooks.Columns["Category"].HeaderText = "Category";
            DgvAllBooks.Columns["Category"].Width = 100;
            DgvAllBooks.Columns["IsAvailable"].HeaderText = "Available";
            DgvAllBooks.Columns["IsAvailable"].Width = 80;
            DgvAllBooks.Columns["CreatedOn"].HeaderText = "Created";
            DgvAllBooks.Columns["CreatedOn"].Width = 100;
        }
    }

    private async Task UpdateStatisticsLabelsAsync()
    {
        try
        {
            var activeBooks = _allBooks.Where(b => b.IsActive).ToList();
            LblTotalBooks.Text = $"Total Books: {activeBooks.Count}";

            // Get top rated book
            var topRatedBooks = await _bookService.GetTopRatedBooksAsync(1);
            LblTopRatedBook.Text =
                topRatedBooks.Any() ? $"Top Rated Book: {topRatedBooks[0].Title}" : "Top Rated Book: NA";

            // Get low rated book
            var lowRatedBooks = await _bookService.GetLowRatedBooksAsync(1);
            LblLowRatedBook.Text =
                lowRatedBooks.Any() ? $"Low Rated Book: {lowRatedBooks[0].Title}" : "Low Rated Book: NA";

            // Get most borrowed book
            var mostBorrowedBooks = await _bookService.GetMostBorrowedBooksAsync(1);
            LblTopBorrowedBook.Text = mostBorrowedBooks.Any()
                ? $"Top Borrowed Book: {mostBorrowedBooks[0].Title}"
                : "Top Borrowed Book: NA";

            // Get most reserved book
            var mostReservedBooks = await _bookService.GetMostReservedBooksAsync(1);
            LblTopReservedBook.Text = mostReservedBooks.Any()
                ? $"Top Reserved Book: {mostReservedBooks[0].Title}"
                : "Top Reserved Book: NA";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error updating statistics: {ex.Message}", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void DgvAllBooks_SelectionChanged(object sender, EventArgs e)
    {
        if (DgvAllBooks.SelectedRows.Count > 0)
        {
            var selectedRow = DgvAllBooks.SelectedRows[0];
            var bookId = (int)selectedRow.Cells["Id"].Value;

            _selectedBook = _allBooks.FirstOrDefault(b => b.Id == bookId);
            if (_selectedBook != null)
            {
                PopulateFormFields(_selectedBook);
            }
        }
    }

    private void PopulateFormFields(BookDto book)
    {
        txtBookTitle.Text = book.Title;
        txtBookAuthor.Text = book.Author;
        txtIsbn.Text = book.ISBN;
        txtBookPublishedYear.Text = book.PublishedYear.ToString();
        chkBookAvilable.Checked = book.IsAvailable;

        // Set category
        if (book.CategoryId > 0)
        {
            cmbCategoies.SelectedValue = book.CategoryId;
        }
        else
        {
            cmbCategoies.SelectedIndex = -1;
        }
    }

    private bool ValidateInput()
    {
        if (string.IsNullOrWhiteSpace(txtBookTitle.Text))
        {
            MessageBox.Show("Please enter book title.", "Validation Error", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            txtBookTitle.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtBookAuthor.Text))
        {
            MessageBox.Show("Please enter book author.", "Validation Error", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            txtBookAuthor.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtIsbn.Text))
        {
            MessageBox.Show("Please enter book ISBN.", "Validation Error", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            txtIsbn.Focus();
            return false;
        }

        if (!int.TryParse(txtBookPublishedYear.Text, out var year) || year < 1000 || year > DateTime.Now.Year)
        {
            MessageBox.Show("Please enter a valid published year.", "Validation Error", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            txtBookPublishedYear.Focus();
            return false;
        }

        if (cmbCategoies.SelectedValue == null)
        {
            MessageBox.Show("Please select a category.", "Validation Error", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            cmbCategoies.Focus();
            return false;
        }

        return true;
    }

    private BookDto CreateBookFromForm()
    {
        return new BookDto
        {
            Title = txtBookTitle.Text.Trim(),
            Author = txtBookAuthor.Text.Trim(),
            ISBN = txtIsbn.Text.Trim(),
            PublishedYear = int.Parse(txtBookPublishedYear.Text),
            CategoryId = (int)cmbCategoies.SelectedValue,
            IsAvailable = chkBookAvilable.Checked,
            IsActive = true
        };
    }

    private void ClearForm()
    {
        txtBookTitle.Clear();
        txtBookAuthor.Clear();
        txtIsbn.Clear();
        txtBookPublishedYear.Clear();
        cmbCategoies.SelectedIndex = -1;
        chkBookAvilable.Checked = true;
        _selectedBook = null;
    }

    private async void btnAddBook_Click(object sender, EventArgs e)
    {
        try
        {
            if (!ValidateInput())
                return;

            var newBook = CreateBookFromForm();
            await _bookService.AddBookAsync(newBook);

            MessageBox.Show("Book added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            await LoadBooksAsync();
            await UpdateStatisticsLabelsAsync();
            ClearForm();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error adding book: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void BtnUpdateBook_Click(object sender, EventArgs e)
    {
        try
        {
            if (_selectedBook == null)
            {
                MessageBox.Show("Please select a book to update.", "Selection Required", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput())
                return;

            var updatedBook = CreateBookFromForm();
            updatedBook.Id = _selectedBook.Id;
            updatedBook.CreatedOn = _selectedBook.CreatedOn;

            await _bookService.UpdateBookAsync(updatedBook);

            MessageBox.Show("Book updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            await LoadBooksAsync();
            await UpdateStatisticsLabelsAsync();
            ClearForm();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error updating book: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void BtnDeleteBook_Click(object sender, EventArgs e)
    {
        try
        {
            if (_selectedBook == null)
            {
                MessageBox.Show("Please select a book to delete.", "Selection Required", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"Are you sure you want to delete '{_selectedBook.Title}'?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                await _bookService.DeleteBookAsync(_selectedBook);

                MessageBox.Show("Book deleted successfully!", "Success", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                await LoadBooksAsync();
                await UpdateStatisticsLabelsAsync();
                ClearForm();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error deleting book: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                // If search term is empty, show all books
                DisplayBooks(_allBooks.Where(b => b.IsActive).ToList());
                return;
            }

            // Filter books by title, author, or ISBN
            var filteredBooks = _allBooks.Where(b => b.IsActive &&
                                                     (b.Title.Contains(searchTerm,
                                                          StringComparison.OrdinalIgnoreCase) ||
                                                      b.Author.Contains(searchTerm,
                                                          StringComparison.OrdinalIgnoreCase) ||
                                                      b.ISBN.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)))
                .ToList();

            DisplayBooks(filteredBooks);

            if (!filteredBooks.Any())
            {
                MessageBox.Show("No books found matching your search criteria.", "Search Results",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error searching books: {ex.Message}", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private async void BtnRefresh_Click(object sender, EventArgs e)
    {
        try
        {
            txtSearchInput.Clear();
            await LoadBooksAsync();
            await UpdateStatisticsLabelsAsync();
            ClearForm();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error refreshing data: {ex.Message}", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}
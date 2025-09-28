using EasyLibrary.Core.Interfaces;
using EasyLibrary.Core.Models;
using EasyLibrary.Core.Services;

namespace EasyLibrary.WinForms.BorrowTransactions;

public partial class BorrowTransactionsForm : Form
{
    private readonly IBookService _bookService;
    private readonly IBorrowTransactionsService _borrowTransactionsService;
    private readonly IMemberService _memberService;
    private List<BookDto> _allBooks;
    private List<BorrowTransactionDto> _allBorrowTransactions;
    private List<MemberDto> _allMembers;
    private BorrowTransactionDto _selectedBorrowTransaction;

    public BorrowTransactionsForm()
    {
        InitializeComponent();
        _borrowTransactionsService = new BorrowTransactionsService();
        _bookService = new BookService();
        _memberService = new MemberService();
        _allBorrowTransactions = new List<BorrowTransactionDto>();
        _allBooks = new List<BookDto>();
        _allMembers = new List<MemberDto>();

        // Subscribe to DataGridView selection event
        DgvAllBooks.SelectionChanged += DgvAllBooks_SelectionChanged;

        // Initialize DateTimePickers
        DtpReservationDate.Value = DateTime.Now;
        DtpExpirationDate.Value = DateTime.Now; // This will be used as return date
        DtpDueDate.Value = DateTime.Now.AddDays(14); // Default 14 days loan period

        // Update labels for clarity
        label4.Text = "Borrow Date";
        label5.Text = "Return Date";
        chkActiveReservation.Text = "Active Transaction";

        // Load initial data
        LoadInitialDataAsync();
    }

    private async void LoadInitialDataAsync()
    {
        try
        {
            await LoadBooksAsync();
            await LoadMembersAsync();
            await LoadBorrowTransactionsAsync();
            UpdateStatisticsLabels();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading initial data: {ex.Message}", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private async Task LoadBooksAsync()
    {
        try
        {
            _allBooks = await _bookService.GetAllBooksAsync();

            // Show available books for new borrowing
            var availableBooks = _allBooks.Where(b => b.IsActive && b.IsAvailable).ToList();
            CmbBooks.DataSource = availableBooks;
            CmbBooks.DisplayMember = "Title";
            CmbBooks.ValueMember = "Id";
            CmbBooks.SelectedIndex = -1;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading books: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async Task LoadMembersAsync()
    {
        try
        {
            _allMembers = await _memberService.GetAllMembersAsync();

            CmbMembers.DataSource = _allMembers.Where(m => m.IsActive).ToList();
            CmbMembers.DisplayMember = "Name";
            CmbMembers.ValueMember = "Id";
            CmbMembers.SelectedIndex = -1;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading members: {ex.Message}", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private async Task LoadBorrowTransactionsAsync()
    {
        try
        {
            _allBorrowTransactions = await _borrowTransactionsService.GetAllBorrowTransactionsAsync();
            DisplayBorrowTransactions(_allBorrowTransactions.Where(bt => bt.IsActive).ToList());
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading borrow transactions: {ex.Message}", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void DisplayBorrowTransactions(List<BorrowTransactionDto> borrowTransactions)
    {
        var borrowDisplay = borrowTransactions.Select(bt => new
        {
            bt.Id,
            BookTitle = bt.Book?.Title ?? "Unknown Book",
            BookAuthor = bt.Book?.Author ?? "Unknown Author",
            MemberName = bt.Member?.Name ?? "Unknown Member",
            MemberEmail = bt.Member?.Email ?? "Unknown Email",
            BorrowDate = bt.BorrowDate.ToString("yyyy-MM-dd"),
            DueDate = bt.DueDate.ToString("yyyy-MM-dd"),
            ReturnDate = bt.ReturnDate?.ToString("yyyy-MM-dd") ?? "Not Returned",
            IsActive = bt.IsActive ? "Active" : "Inactive",
            Status = GetTransactionStatus(bt),
            DaysOverdue = GetDaysOverdue(bt),
            IsReturned = bt.ReturnDate.HasValue ? "Yes" : "No"
        }).ToList();

        DgvAllBooks.DataSource = borrowDisplay;

        // Configure column headers and widths
        if (DgvAllBooks.Columns.Count > 0)
        {
            DgvAllBooks.Columns["Id"].HeaderText = "ID";
            DgvAllBooks.Columns["Id"].Width = 50;
            DgvAllBooks.Columns["BookTitle"].HeaderText = "Book Title";
            DgvAllBooks.Columns["BookTitle"].Width = 150;
            DgvAllBooks.Columns["BookAuthor"].HeaderText = "Author";
            DgvAllBooks.Columns["BookAuthor"].Width = 120;
            DgvAllBooks.Columns["MemberName"].HeaderText = "Member";
            DgvAllBooks.Columns["MemberName"].Width = 120;
            DgvAllBooks.Columns["MemberEmail"].HeaderText = "Email";
            DgvAllBooks.Columns["MemberEmail"].Width = 150;
            DgvAllBooks.Columns["BorrowDate"].HeaderText = "Borrowed";
            DgvAllBooks.Columns["BorrowDate"].Width = 90;
            DgvAllBooks.Columns["DueDate"].HeaderText = "Due Date";
            DgvAllBooks.Columns["DueDate"].Width = 90;
            DgvAllBooks.Columns["ReturnDate"].HeaderText = "Returned";
            DgvAllBooks.Columns["ReturnDate"].Width = 90;
            DgvAllBooks.Columns["IsActive"].HeaderText = "Active";
            DgvAllBooks.Columns["IsActive"].Width = 60;
            DgvAllBooks.Columns["Status"].HeaderText = "Status";
            DgvAllBooks.Columns["Status"].Width = 80;
            DgvAllBooks.Columns["DaysOverdue"].HeaderText = "Days Overdue";
            DgvAllBooks.Columns["DaysOverdue"].Width = 90;
            DgvAllBooks.Columns["IsReturned"].HeaderText = "Returned";
            DgvAllBooks.Columns["IsReturned"].Width = 70;
        }
    }

    private string GetTransactionStatus(BorrowTransactionDto transaction)
    {
        if (!transaction.IsActive)
            return "Inactive";

        if (transaction.ReturnDate.HasValue)
            return "Returned";

        if (transaction.DueDate < DateTime.Now)
            return "Overdue";

        if (transaction.DueDate.Date == DateTime.Now.Date)
            return "Due Today";

        if (transaction.DueDate <= DateTime.Now.AddDays(2))
            return "Due Soon";

        return "Active";
    }

    private int GetDaysOverdue(BorrowTransactionDto transaction)
    {
        if (!transaction.IsActive || transaction.ReturnDate.HasValue || transaction.DueDate >= DateTime.Now)
            return 0;

        return (int)(DateTime.Now.Date - transaction.DueDate.Date).TotalDays;
    }

    private void UpdateStatisticsLabels()
    {
        var activeTransactions = _allBorrowTransactions.Where(bt => bt.IsActive && !bt.ReturnDate.HasValue).ToList();
        var overdueTransactions = activeTransactions.Where(bt => bt.DueDate < DateTime.Now).Count();
        var dueSoon = activeTransactions
            .Where(bt => bt.DueDate <= DateTime.Now.AddDays(2) && bt.DueDate >= DateTime.Now).Count();
        var totalReturned = _allBorrowTransactions.Where(bt => bt.ReturnDate.HasValue).Count();

        LblTotalBooks.Text =
            $"Active: {activeTransactions.Count} | Overdue: {overdueTransactions} | Due Soon: {dueSoon} | Returned: {totalReturned}";
    }

    private void DgvAllBooks_SelectionChanged(object sender, EventArgs e)
    {
        if (DgvAllBooks.SelectedRows.Count > 0)
        {
            var selectedRow = DgvAllBooks.SelectedRows[0];
            var transactionId = (int)selectedRow.Cells["Id"].Value;

            _selectedBorrowTransaction = _allBorrowTransactions.FirstOrDefault(bt => bt.Id == transactionId);
            if (_selectedBorrowTransaction != null)
            {
                PopulateFormFields(_selectedBorrowTransaction);
            }
        }
    }

    private void PopulateFormFields(BorrowTransactionDto transaction)
    {
        if (transaction.Book != null)
        {
            // For editing, we need to show all books, not just available ones
            var allBooks = _allBooks.Where(b => b.IsActive).ToList();
            CmbBooks.DataSource = allBooks;
            CmbBooks.SelectedValue = transaction.BookId;
        }

        if (transaction.Member != null)
        {
            CmbMembers.SelectedValue = transaction.MemberId;
        }

        DtpReservationDate.Value = transaction.BorrowDate;
        DtpDueDate.Value = transaction.DueDate;
        DtpExpirationDate.Value = transaction.ReturnDate ?? DateTime.Now;
        chkActiveReservation.Checked = transaction.IsActive;

        // Change button text based on return status
        if (transaction.ReturnDate.HasValue)
        {
            btnAddBorrowTrasaction.Text = "Mark as Returned";
            BtnUpdateBook.Text = "Update Transaction";
        }
        else
        {
            btnAddBorrowTrasaction.Text = "Return Book";
            BtnUpdateBook.Text = "Update Transaction";
        }
    }

    private bool ValidateInput()
    {
        try
        {
            // Validate Book Selection
            if (CmbBooks.SelectedValue == null)
            {
                MessageBox.Show("Please select a book.", "Validation Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                CmbBooks.Focus();
                return false;
            }

            // Validate Member Selection
            if (CmbMembers.SelectedValue == null)
            {
                MessageBox.Show("Please select a member.", "Validation Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                CmbMembers.Focus();
                return false;
            }

            // Validate that selected book and member IDs are valid integers
            if (!int.TryParse(CmbBooks.SelectedValue.ToString(), out var bookId) || bookId <= 0)
            {
                MessageBox.Show("Invalid book selection.", "Validation Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                CmbBooks.Focus();
                return false;
            }

            if (!int.TryParse(CmbMembers.SelectedValue.ToString(), out var memberId) || memberId <= 0)
            {
                MessageBox.Show("Invalid member selection.", "Validation Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                CmbMembers.Focus();
                return false;
            }

            // Validate Dates
            if (DtpDueDate.Value <= DtpReservationDate.Value)
            {
                MessageBox.Show("Due date must be after borrow date.", "Validation Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                DtpDueDate.Focus();
                return false;
            }

            if (DtpReservationDate.Value.Date > DateTime.Now.Date)
            {
                MessageBox.Show("Borrow date cannot be in the future.", "Validation Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                DtpReservationDate.Focus();
                return false;
            }

            // For return transactions, validate return date
            if (_selectedBorrowTransaction != null && !_selectedBorrowTransaction.ReturnDate.HasValue)
            {
                if (DtpExpirationDate.Value.Date < DtpReservationDate.Value.Date)
                {
                    MessageBox.Show("Return date cannot be before borrow date.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DtpExpirationDate.Focus();
                    return false;
                }
            }

            // Check for existing active borrow for the same book and member (only for new transactions)
            if (_selectedBorrowTransaction == null)
            {
                var existingBorrow = _allBorrowTransactions.FirstOrDefault(bt =>
                    bt.BookId == bookId &&
                    bt.MemberId == memberId &&
                    bt.IsActive &&
                    !bt.ReturnDate.HasValue);

                if (existingBorrow != null)
                {
                    MessageBox.Show("This member already has an active borrow for this book.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // Check if book is available
                var selectedBook = _allBooks.FirstOrDefault(b => b.Id == bookId);
                if (selectedBook != null && !selectedBook.IsAvailable)
                {
                    MessageBox.Show("This book is currently not available for borrowing.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CmbBooks.Focus();
                    return false;
                }
            }

            return true;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error during validation: {ex.Message}", "Validation Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            return false;
        }
    }

    private BorrowTransactionDto CreateBorrowTransactionFromForm()
    {
        var transaction = new BorrowTransactionDto
        {
            BookId = (int)CmbBooks.SelectedValue,
            MemberId = (int)CmbMembers.SelectedValue,
            BorrowDate = DtpReservationDate.Value.Date,
            DueDate = DtpDueDate.Value.Date,
            IsActive = chkActiveReservation.Checked
        };

        // Set return date only if the transaction is being returned
        if (_selectedBorrowTransaction != null && btnAddBorrowTrasaction.Text == "Return Book")
        {
            transaction.ReturnDate = DtpExpirationDate.Value.Date;
        }

        return transaction;
    }

    private void ClearForm()
    {
        // Reset books dropdown to show only available books
        LoadBooksAsync();

        CmbBooks.SelectedIndex = -1;
        CmbMembers.SelectedIndex = -1;
        DtpReservationDate.Value = DateTime.Now;
        DtpDueDate.Value = DateTime.Now.AddDays(14);
        DtpExpirationDate.Value = DateTime.Now;
        chkActiveReservation.Checked = true;
        _selectedBorrowTransaction = null;

        // Reset button texts
        btnAddBorrowTrasaction.Text = "Add Borrow Transaction";
        BtnUpdateBook.Text = "Update Transaction";
    }

    private async void btnAddBorrowTrasaction_Click(object sender, EventArgs e)
    {
        try
        {
            if (_selectedBorrowTransaction != null)
            {
                // Handle book return
                if (!_selectedBorrowTransaction.ReturnDate.HasValue)
                {
                    var returnTransaction = _selectedBorrowTransaction;
                    returnTransaction.ReturnDate = DtpExpirationDate.Value.Date;

                    await _borrowTransactionsService.UpdateBorrowTransactionAsync(returnTransaction);

                    MessageBox.Show("Book returned successfully!", "Success", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("This book has already been returned.", "Information", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            else
            {
                // Add new borrow transaction
                if (!ValidateInput())
                    return;

                var newTransaction = CreateBorrowTransactionFromForm();

                // Additional validation for new transactions
                if (newTransaction.BorrowDate > DateTime.Now.Date)
                {
                    MessageBox.Show("Borrow date cannot be in the future.", "Validation Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (newTransaction.DueDate <= newTransaction.BorrowDate)
                {
                    MessageBox.Show("Due date must be after borrow date.", "Validation Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                await _borrowTransactionsService.AddBorrowTransactionAsync(newTransaction);

                MessageBox.Show("Borrow transaction added successfully!", "Success", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            await LoadBorrowTransactionsAsync();
            UpdateStatisticsLabels();
            ClearForm();
        }
        catch (InvalidOperationException ex)
        {
            // Show business logic errors to the user
            MessageBox.Show(ex.Message, "Transaction Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        catch (Exception ex)
        {
            // Show generic errors
            MessageBox.Show(
                $"Error processing transaction: {ex.Message}\n\nPlease try again or contact support if the problem persists.",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void BtnUpdateBook_Click(object sender, EventArgs e)
    {
        try
        {
            if (_selectedBorrowTransaction == null)
            {
                MessageBox.Show("Please select a transaction to update.", "Selection Required", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput())
                return;

            var updatedTransaction = CreateBorrowTransactionFromForm();
            updatedTransaction.Id = _selectedBorrowTransaction.Id;
            updatedTransaction.CreatedOn = _selectedBorrowTransaction.CreatedOn;
            updatedTransaction.ReturnDate = _selectedBorrowTransaction.ReturnDate; // Preserve existing return date

            await _borrowTransactionsService.UpdateBorrowTransactionAsync(updatedTransaction);

            MessageBox.Show("Transaction updated successfully!", "Success", MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            await LoadBorrowTransactionsAsync();
            UpdateStatisticsLabels();
            ClearForm();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error updating transaction: {ex.Message}", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private async void BtnDeleteBook_Click(object sender, EventArgs e)
    {
        try
        {
            if (_selectedBorrowTransaction == null)
            {
                MessageBox.Show("Please select a transaction to delete.", "Selection Required", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var bookTitle = _selectedBorrowTransaction.Book?.Title ?? "Unknown Book";
            var memberName = _selectedBorrowTransaction.Member?.Name ?? "Unknown Member";

            var result = MessageBox.Show(
                $"Are you sure you want to delete the borrow transaction for '{bookTitle}' by '{memberName}'?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                await _borrowTransactionsService.DeleteBorrowTransactionAsync(_selectedBorrowTransaction);

                MessageBox.Show("Transaction deleted successfully!", "Success", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                await LoadBorrowTransactionsAsync();
                UpdateStatisticsLabels();
                ClearForm();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error deleting transaction: {ex.Message}", "Error", MessageBoxButtons.OK,
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
                // If search term is empty, show all active transactions
                DisplayBorrowTransactions(_allBorrowTransactions.Where(bt => bt.IsActive).ToList());
                return;
            }

            // Filter transactions by book title, member name, or member email
            var filteredTransactions = _allBorrowTransactions.Where(bt => bt.IsActive &&
                                                                          ((bt.Book?.Title?.Contains(searchTerm,
                                                                                StringComparison.OrdinalIgnoreCase) ??
                                                                            false) ||
                                                                           (bt.Book?.Author?.Contains(searchTerm,
                                                                                StringComparison.OrdinalIgnoreCase) ??
                                                                            false) ||
                                                                           (bt.Member?.Name?.Contains(searchTerm,
                                                                                StringComparison.OrdinalIgnoreCase) ??
                                                                            false) ||
                                                                           (bt.Member?.Email?.Contains(searchTerm,
                                                                                StringComparison.OrdinalIgnoreCase) ??
                                                                            false))).ToList();

            DisplayBorrowTransactions(filteredTransactions);

            if (!filteredTransactions.Any())
            {
                MessageBox.Show("No transactions found matching your search criteria.", "Search Results",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error searching transactions: {ex.Message}", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private async void BtnRefresh_Click(object sender, EventArgs e)
    {
        try
        {
            txtSearchInput.Clear();
            await LoadBooksAsync();
            await LoadMembersAsync();
            await LoadBorrowTransactionsAsync();
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
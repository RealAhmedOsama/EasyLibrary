using EasyLibrary.Core.Interfaces;
using EasyLibrary.Core.Models;
using EasyLibrary.Core.Services;

namespace EasyLibrary.WinForms.ReservationTransactions;

public partial class ReservationTransactionsForm : Form
{
    private readonly IBookService _bookService;
    private readonly IMemberService _memberService;
    private readonly IReservationTransactionService _reservationTransactionService;
    private List<BookDto> _allBooks;
    private List<MemberDto> _allMembers;
    private List<ReservationTransactionDto> _allReservations;
    private ReservationTransactionDto _selectedReservation;

    public ReservationTransactionsForm()
    {
        InitializeComponent();
        _reservationTransactionService = new ReservationTransactionService();
        _bookService = new BookService();
        _memberService = new MemberService();
        _allReservations = new List<ReservationTransactionDto>();
        _allBooks = new List<BookDto>();
        _allMembers = new List<MemberDto>();

        // Subscribe to DataGridView selection event
        DgvAllBooks.SelectionChanged += DgvAllBooks_SelectionChanged;

        // Initialize DateTimePickers
        DtpReservationDate.Value = DateTime.Now;
        DtpExpirationDate.Value = DateTime.Now.AddDays(7); // Default 7 days from now

        // Load initial data
        LoadInitialDataAsync();
    }

    private async void LoadInitialDataAsync()
    {
        try
        {
            await LoadBooksAsync();
            await LoadMembersAsync();
            await LoadReservationsAsync();
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

            // Only show available books for new reservations
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

    private async Task LoadReservationsAsync()
    {
        try
        {
            _allReservations = await _reservationTransactionService.GetAllAsync();
            DisplayReservations(_allReservations.Where(r => r.IsActive).ToList());
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading reservations: {ex.Message}", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void DisplayReservations(List<ReservationTransactionDto> reservations)
    {
        var reservationDisplay = reservations.Select(r => new
        {
            r.Id,
            BookTitle = r.Book?.Title ?? "Unknown Book",
            BookAuthor = r.Book?.Author ?? "Unknown Author",
            MemberName = r.Member?.Name ?? "Unknown Member",
            MemberEmail = r.Member?.Email ?? "Unknown Email",
            ReservationDate = r.ReservationDate.ToString("yyyy-MM-dd"),
            ExpirationDate = r.ExpirationDate.ToString("yyyy-MM-dd"),
            IsActive = r.IsActive ? "Active" : "Inactive",
            Status = GetReservationStatus(r),
            DaysRemaining = GetDaysRemaining(r)
        }).ToList();

        DgvAllBooks.DataSource = reservationDisplay;

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
            DgvAllBooks.Columns["ReservationDate"].HeaderText = "Reserved";
            DgvAllBooks.Columns["ReservationDate"].Width = 90;
            DgvAllBooks.Columns["ExpirationDate"].HeaderText = "Expires";
            DgvAllBooks.Columns["ExpirationDate"].Width = 90;
            DgvAllBooks.Columns["IsActive"].HeaderText = "Active";
            DgvAllBooks.Columns["IsActive"].Width = 60;
            DgvAllBooks.Columns["Status"].HeaderText = "Status";
            DgvAllBooks.Columns["Status"].Width = 80;
            DgvAllBooks.Columns["DaysRemaining"].HeaderText = "Days Left";
            DgvAllBooks.Columns["DaysRemaining"].Width = 80;
        }
    }

    private string GetReservationStatus(ReservationTransactionDto reservation)
    {
        if (!reservation.IsActive)
            return "Inactive";

        if (reservation.ExpirationDate < DateTime.Now)
            return "Expired";

        if (reservation.ExpirationDate.Date == DateTime.Now.Date)
            return "Expires Today";

        if (reservation.ExpirationDate <= DateTime.Now.AddDays(1))
            return "Expires Soon";

        return "Active";
    }

    private int GetDaysRemaining(ReservationTransactionDto reservation)
    {
        if (!reservation.IsActive || reservation.ExpirationDate < DateTime.Now)
            return 0;

        return (int)(reservation.ExpirationDate.Date - DateTime.Now.Date).TotalDays;
    }

    private void UpdateStatisticsLabels()
    {
        var activeReservations = _allReservations.Where(r => r.IsActive).ToList();
        var expiredReservations = activeReservations.Where(r => r.ExpirationDate < DateTime.Now).Count();
        var expiringSoon = activeReservations
            .Where(r => r.ExpirationDate <= DateTime.Now.AddDays(2) && r.ExpirationDate >= DateTime.Now).Count();

        LblTotalBooks.Text =
            $"Total: {activeReservations.Count} | Expired: {expiredReservations} | Expiring Soon: {expiringSoon}";
    }

    private void DgvAllBooks_SelectionChanged(object sender, EventArgs e)
    {
        if (DgvAllBooks.SelectedRows.Count > 0)
        {
            var selectedRow = DgvAllBooks.SelectedRows[0];
            var reservationId = (int)selectedRow.Cells["Id"].Value;

            _selectedReservation = _allReservations.FirstOrDefault(r => r.Id == reservationId);
            if (_selectedReservation != null)
            {
                PopulateFormFields(_selectedReservation);
            }
        }
    }

    private void PopulateFormFields(ReservationTransactionDto reservation)
    {
        if (reservation.Book != null)
        {
            CmbBooks.SelectedValue = reservation.BookId;
        }

        if (reservation.Member != null)
        {
            CmbMembers.SelectedValue = reservation.MemberId;
        }

        DtpReservationDate.Value = reservation.ReservationDate;
        DtpExpirationDate.Value = reservation.ExpirationDate;
        chkActiveReservation.Checked = reservation.IsActive;
    }

    private bool ValidateInput()
    {
        // Validate Book Selection
        if (CmbBooks.SelectedValue == null)
        {
            MessageBox.Show("Please select a book.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        // Validate Dates
        if (DtpExpirationDate.Value <= DtpReservationDate.Value)
        {
            MessageBox.Show("Expiration date must be after reservation date.", "Validation Error", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            DtpExpirationDate.Focus();
            return false;
        }

        if (DtpReservationDate.Value.Date > DateTime.Now.Date)
        {
            MessageBox.Show("Reservation date cannot be in the future.", "Validation Error", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            DtpReservationDate.Focus();
            return false;
        }

        // Check for existing active reservation for the same book and member
        if (_selectedReservation == null) // Only check for new reservations
        {
            var existingReservation = _allReservations.FirstOrDefault(r =>
                r.BookId == (int)CmbBooks.SelectedValue &&
                r.MemberId == (int)CmbMembers.SelectedValue &&
                r.IsActive &&
                r.ExpirationDate >= DateTime.Now);

            if (existingReservation != null)
            {
                MessageBox.Show("This member already has an active reservation for this book.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        return true;
    }

    private ReservationTransactionDto CreateReservationFromForm()
    {
        return new ReservationTransactionDto
        {
            BookId = (int)CmbBooks.SelectedValue,
            MemberId = (int)CmbMembers.SelectedValue,
            ReservationDate = DtpReservationDate.Value.Date,
            ExpirationDate = DtpExpirationDate.Value.Date,
            IsActive = chkActiveReservation.Checked
        };
    }

    private void ClearForm()
    {
        CmbBooks.SelectedIndex = -1;
        CmbMembers.SelectedIndex = -1;
        DtpReservationDate.Value = DateTime.Now;
        DtpExpirationDate.Value = DateTime.Now.AddDays(7);
        chkActiveReservation.Checked = true;
        _selectedReservation = null;
    }

    private async void btnAddBook_Click(object sender, EventArgs e)
    {
        try
        {
            if (!ValidateInput())
                return;

            var newReservation = CreateReservationFromForm();
            await _reservationTransactionService.AddAsync(newReservation);

            MessageBox.Show("Reservation added successfully!", "Success", MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            await LoadReservationsAsync();
            UpdateStatisticsLabels();
            ClearForm();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error adding reservation: {ex.Message}", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private async void BtnUpdateBook_Click(object sender, EventArgs e)
    {
        try
        {
            if (_selectedReservation == null)
            {
                MessageBox.Show("Please select a reservation to update.", "Selection Required", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput())
                return;

            var updatedReservation = CreateReservationFromForm();
            updatedReservation.Id = _selectedReservation.Id;
            updatedReservation.CreatedOn = _selectedReservation.CreatedOn;

            await _reservationTransactionService.UpdateAsync(updatedReservation);

            MessageBox.Show("Reservation updated successfully!", "Success", MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            await LoadReservationsAsync();
            UpdateStatisticsLabels();
            ClearForm();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error updating reservation: {ex.Message}", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private async void BtnDeleteBook_Click(object sender, EventArgs e)
    {
        try
        {
            if (_selectedReservation == null)
            {
                MessageBox.Show("Please select a reservation to delete.", "Selection Required", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var bookTitle = _selectedReservation.Book?.Title ?? "Unknown Book";
            var memberName = _selectedReservation.Member?.Name ?? "Unknown Member";

            var result = MessageBox.Show(
                $"Are you sure you want to delete the reservation for '{bookTitle}' by '{memberName}'?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var success = await _reservationTransactionService.DeleteAsync(_selectedReservation);

                if (success)
                {
                    MessageBox.Show("Reservation deleted successfully!", "Success", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    await LoadReservationsAsync();
                    UpdateStatisticsLabels();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Failed to delete reservation.", "Delete Failed", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error deleting reservation: {ex.Message}", "Error", MessageBoxButtons.OK,
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
                // If search term is empty, show all active reservations
                DisplayReservations(_allReservations.Where(r => r.IsActive).ToList());
                return;
            }

            // Filter reservations by book title, member name, or member email
            var filteredReservations = _allReservations.Where(r => r.IsActive &&
                                                                   ((r.Book?.Title?.Contains(searchTerm,
                                                                        StringComparison.OrdinalIgnoreCase) ?? false) ||
                                                                    (r.Book?.Author?.Contains(searchTerm,
                                                                        StringComparison.OrdinalIgnoreCase) ?? false) ||
                                                                    (r.Member?.Name?.Contains(searchTerm,
                                                                        StringComparison.OrdinalIgnoreCase) ?? false) ||
                                                                    (r.Member?.Email?.Contains(searchTerm,
                                                                        StringComparison.OrdinalIgnoreCase) ?? false)))
                .ToList();

            DisplayReservations(filteredReservations);

            if (!filteredReservations.Any())
            {
                MessageBox.Show("No reservations found matching your search criteria.", "Search Results",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error searching reservations: {ex.Message}", "Error", MessageBoxButtons.OK,
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
            await LoadReservationsAsync();
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
using EasyLibrary.Core.Interfaces;
using EasyLibrary.Core.Models;
using EasyLibrary.Core.Services;

namespace EasyLibrary.WinForms.MemberManagement;

public partial class MemberProfileForm : Form
{
    private readonly IMemberService _memberService;
    private MemberDto _currentMember;

    public MemberProfileForm()
    {
        InitializeComponent();
        _memberService = new MemberService();
    }

    public MemberProfileForm(MemberDto member) : this()
    {
        _currentMember = member;
        LoadMemberProfileAsync();
    }

    private async void LoadMemberProfileAsync()
    {
        try
        {
            if (_currentMember == null) return;

            // Display member basic information
            PopulateMemberInformation();

            // Load and display borrowed books
            await LoadBorrowedBooksAsync();

            // Load and display reserved books
            await LoadReservedBooksAsync();

            // Update the form title
            Text = $"Member Profile - {_currentMember.Name}";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading member profile: {ex.Message}", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void PopulateMemberInformation()
    {
        if (_currentMember == null) return;

        // Make controls read-only since this is a profile view
        txtMemberName.Text = _currentMember.Name;
        txtMemberName.ReadOnly = true;

        txtMemberEmail.Text = _currentMember.Email;
        txtMemberEmail.ReadOnly = true;

        txtMemberPhone.Text = _currentMember.Phone;
        txtMemberPhone.ReadOnly = true;

        DtpMembershipDate.Value = _currentMember.MembershipDate;
        DtpMembershipDate.Enabled = false;

        chkMemberStatus.Checked = _currentMember.IsActive;
        chkMemberStatus.Enabled = false;
    }

    private async Task LoadBorrowedBooksAsync()
    {
        try
        {
            var borrowedBooks = await _memberService.GetMemberBorrowedBooksAsync(_currentMember);

            // Handle the case where BorrowTransactions might be null
            var borrowTransactions = _currentMember.BorrowTransactions ?? new List<BorrowTransactionDto>();

            // Create display data for borrowed books
            var borrowDisplay = borrowTransactions.Select(bt => new
            {
                bt.Id,
                BookTitle = bt.Book?.Title ?? "Unknown",
                BookAuthor = bt.Book?.Author ?? "Unknown",
                ISBN = bt.Book?.ISBN ?? "Unknown",
                BorrowDate = bt.BorrowDate.ToString("yyyy-MM-dd"),
                DueDate = bt.DueDate.ToString("yyyy-MM-dd"),
                ReturnDate = bt.ReturnDate?.ToString("yyyy-MM-dd") ?? "Not Returned",
                Status = bt.ReturnDate == null ? "Active" : "Returned",
                IsOverdue = bt.ReturnDate == null && bt.DueDate < DateTime.Now ? "Yes" : "No"
            }).OrderByDescending(b => b.BorrowDate).ToList();

            DgvAllBorrowedBooks.DataSource = borrowDisplay;

            // Configure columns
            if (DgvAllBorrowedBooks.Columns.Count > 0)
            {
                DgvAllBorrowedBooks.Columns["Id"].HeaderText = "ID";
                DgvAllBorrowedBooks.Columns["Id"].Width = 50;
                DgvAllBorrowedBooks.Columns["BookTitle"].HeaderText = "Book Title";
                DgvAllBorrowedBooks.Columns["BookTitle"].Width = 150;
                DgvAllBorrowedBooks.Columns["BookAuthor"].HeaderText = "Author";
                DgvAllBorrowedBooks.Columns["BookAuthor"].Width = 120;
                DgvAllBorrowedBooks.Columns["ISBN"].HeaderText = "ISBN";
                DgvAllBorrowedBooks.Columns["ISBN"].Width = 100;
                DgvAllBorrowedBooks.Columns["BorrowDate"].HeaderText = "Borrow Date";
                DgvAllBorrowedBooks.Columns["BorrowDate"].Width = 90;
                DgvAllBorrowedBooks.Columns["DueDate"].HeaderText = "Due Date";
                DgvAllBorrowedBooks.Columns["DueDate"].Width = 90;
                DgvAllBorrowedBooks.Columns["ReturnDate"].HeaderText = "Return Date";
                DgvAllBorrowedBooks.Columns["ReturnDate"].Width = 90;
                DgvAllBorrowedBooks.Columns["Status"].HeaderText = "Status";
                DgvAllBorrowedBooks.Columns["Status"].Width = 70;
                DgvAllBorrowedBooks.Columns["IsOverdue"].HeaderText = "Overdue";
                DgvAllBorrowedBooks.Columns["IsOverdue"].Width = 70;
            }

            // Update statistics
            var totalBorrowed = borrowTransactions.Count;
            var activeBorrowed = borrowTransactions.Count(bt => bt.ReturnDate == null);
            LblTotalBorrowedBooks.Text = $"Total Borrowed Books: {totalBorrowed} (Active: {activeBorrowed})";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading borrowed books: {ex.Message}", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private async Task LoadReservedBooksAsync()
    {
        try
        {
            var reservedBooks = await _memberService.GetMemberReservedBooksAsync(_currentMember);

            // Handle the case where ReservationTransactions might be null
            var reservationTransactions =
                _currentMember.ReservationTransactions ?? new List<ReservationTransactionDto>();

            // Create display data for reserved books
            var reservationDisplay = reservationTransactions.Select(rt => new
            {
                rt.Id,
                BookTitle = rt.Book?.Title ?? "Unknown",
                BookAuthor = rt.Book?.Author ?? "Unknown",
                ISBN = rt.Book?.ISBN ?? "Unknown",
                ReservationDate = rt.ReservationDate.ToString("yyyy-MM-dd"),
                ExpirationDate = rt.ExpirationDate.ToString("yyyy-MM-dd"),
                Status = rt.IsActive ? "Active" : "Inactive",
                IsExpired = rt.IsActive && rt.ExpirationDate < DateTime.Now ? "Yes" : "No"
            }).OrderByDescending(r => r.ReservationDate).ToList();

            DgvAllReservedBooks.DataSource = reservationDisplay;

            // Configure columns
            if (DgvAllReservedBooks.Columns.Count > 0)
            {
                DgvAllReservedBooks.Columns["Id"].HeaderText = "ID";
                DgvAllReservedBooks.Columns["Id"].Width = 50;
                DgvAllReservedBooks.Columns["BookTitle"].HeaderText = "Book Title";
                DgvAllReservedBooks.Columns["BookTitle"].Width = 180;
                DgvAllReservedBooks.Columns["BookAuthor"].HeaderText = "Author";
                DgvAllReservedBooks.Columns["BookAuthor"].Width = 140;
                DgvAllReservedBooks.Columns["ISBN"].HeaderText = "ISBN";
                DgvAllReservedBooks.Columns["ISBN"].Width = 100;
                DgvAllReservedBooks.Columns["ReservationDate"].HeaderText = "Reserved Date";
                DgvAllReservedBooks.Columns["ReservationDate"].Width = 100;
                DgvAllReservedBooks.Columns["ExpirationDate"].HeaderText = "Expires Date";
                DgvAllReservedBooks.Columns["ExpirationDate"].Width = 100;
                DgvAllReservedBooks.Columns["Status"].HeaderText = "Status";
                DgvAllReservedBooks.Columns["Status"].Width = 70;
                DgvAllReservedBooks.Columns["IsExpired"].HeaderText = "Expired";
                DgvAllReservedBooks.Columns["IsExpired"].Width = 70;
            }

            // Update statistics
            var totalReserved = reservationTransactions.Count;
            var activeReserved = reservationTransactions.Count(rt => rt.IsActive);
            LblTottalReservedBooks.Text = $"Total Reserved Books: {totalReserved} (Active: {activeReserved})";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading reserved books: {ex.Message}", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    public void SetMember(MemberDto member)
    {
        _currentMember = member;
        LoadMemberProfileAsync();
    }
}
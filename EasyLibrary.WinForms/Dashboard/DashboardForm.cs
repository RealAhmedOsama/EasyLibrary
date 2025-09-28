using EasyLibrary.Core.Interfaces;
using EasyLibrary.Core.Models;
using EasyLibrary.Core.Services;
using Timer = System.Windows.Forms.Timer;

namespace EasyLibrary.WinForms.Dashboard;

public partial class DashboardForm : Form
{
    private readonly IDashboardService _dashboardService;
    private readonly Timer _refreshTimer;

    public DashboardForm()
    {
        InitializeComponent();
        _dashboardService = new DashboardService();

        // Initialize timer for periodic refresh
        _refreshTimer = new Timer();
        _refreshTimer.Interval = 30000; // Refresh every 30 seconds
        _refreshTimer.Tick += RefreshTimer_Tick;
        _refreshTimer.Start();

        // Set up event handlers
        Load += DashboardForm_Load;
    }

    private async void DashboardForm_Load(object sender, EventArgs e)
    {
        // Load initial data when form loads
        await LoadDashboardDataAsync();

        // Set up double-click events for list boxes
        SetupListBoxEvents();
    }

    private async void RefreshTimer_Tick(object? sender, EventArgs e)
    {
        await LoadDashboardDataAsync();
    }

    private async Task LoadDashboardDataAsync()
    {
        try
        {
            // Show loading indicators
            SetLoadingState(true);

            // Load all dashboard data in parallel for better performance
            var tasks = new[]
            {
                LoadBooksStatisticsAsync(),
                LoadMembersStatisticsAsync(),
                LoadBorrowingStatisticsAsync(),
                LoadOverdueBooksAsync(),
                LoadPendingReservationsAsync(),
                LoadTopRatedBooksAsync()
            };

            await Task.WhenAll(tasks);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading dashboard data: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            SetLoadingState(false);
        }
    }

    private void SetLoadingState(bool isLoading)
    {
        if (isLoading)
        {
            // Show loading text
            LblTotalBooksCount.Text = "Loading...";
            LblTotalMembersCount.Text = "Loading...";
            LblBorrowedTodayCount.Text = "Loading...";
            LblBorrowedThisMonthCount.Text = "Loading...";
            LblTotalOverdueBooksCount.Text = "Loading...";
            LblReservationPendingCount.Text = "Loading...";
            LblTopRatedBookName.Text = "Loading...";

            // Clear lists
            ListBoxOverdueBooks.Items.Clear();
            ListReservationPending.Items.Clear();
            ListTopRatedBooks.Items.Clear();
        }
    }

    private async Task LoadBooksStatisticsAsync()
    {
        try
        {
            var totalBooks = await _dashboardService.GetAllBooksCountAsync();
            var availableBooks = await _dashboardService.GetAvailableBooksCountAsync();

            // Update UI on main thread
            UpdateLabelSafely(LblTotalBooksCount, $"Total: {totalBooks} | Available: {availableBooks}");
        }
        catch (Exception ex)
        {
            UpdateLabelSafely(LblTotalBooksCount, "Error: Failed to load");
        }
    }

    private async Task LoadMembersStatisticsAsync()
    {
        try
        {
            var activeMembers = await _dashboardService.GetActiveMembersCountAsync();

            UpdateLabelSafely(LblTotalMembersCount, $"Active Members: {activeMembers}");
        }
        catch (Exception ex)
        {
            UpdateLabelSafely(LblTotalMembersCount, "Error: Failed to load");
        }
    }

    private async Task LoadBorrowingStatisticsAsync()
    {
        try
        {
            // Get today's date range
            var today = DateTime.Now.Date;
            var todayEnd = today.AddDays(1).AddTicks(-1);

            // Get this month's date range
            var firstDayOfMonth = new DateTime(today.Year, today.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddTicks(-1);

            // Get borrowing statistics
            var borrowedToday = await _dashboardService.GetBorrowedBooksCountAsync(today, todayEnd);
            var borrowedThisMonth = await _dashboardService.GetBorrowedBooksCountAsync(firstDayOfMonth, lastDayOfMonth);

            UpdateLabelSafely(LblBorrowedTodayCount, $"Today: {borrowedToday}");
            UpdateLabelSafely(LblBorrowedThisMonthCount, $"This Month: {borrowedThisMonth}");
        }
        catch (Exception ex)
        {
            UpdateLabelSafely(LblBorrowedTodayCount, "Error: Failed to load");
            UpdateLabelSafely(LblBorrowedThisMonthCount, "Error: Failed to load");
        }
    }

    private async Task LoadOverdueBooksAsync()
    {
        try
        {
            var overdueBooks = await _dashboardService.GetOverdueBooksCountAsync();

            if (InvokeRequired)
            {
                Invoke(() => UpdateOverdueBooksList(overdueBooks));
            }
            else
            {
                UpdateOverdueBooksList(overdueBooks);
            }
        }
        catch (Exception ex)
        {
            UpdateLabelSafely(LblTotalOverdueBooksCount, "Error: Failed to load");
        }
    }

    private void UpdateOverdueBooksList(List<BorrowTransactionDto> overdueBooks)
    {
        LblTotalOverdueBooksCount.Text = $"Overdue Books: {overdueBooks.Count}";

        ListBoxOverdueBooks.Items.Clear();

        if (overdueBooks.Count == 0)
        {
            ListBoxOverdueBooks.Items.Add("No overdue books");
            return;
        }

        // Show all overdue books in a single line format
        foreach (var overdue in overdueBooks.Take(10))
        {
            var bookTitle = overdue.Book?.Title ?? "Unknown Book";
            var memberName = overdue.Member?.Name ?? "Unknown Member";
            var daysOverdue = (DateTime.Now.Date - overdue.DueDate.Date).Days;

            var priority = daysOverdue > 7 ? "[CRITICAL]" : "[OVERDUE]";
            ListBoxOverdueBooks.Items.Add($"{priority} {bookTitle} - {memberName} ({daysOverdue} days)");
        }

        if (overdueBooks.Count > 10)
        {
            ListBoxOverdueBooks.Items.Add($"... and {overdueBooks.Count - 10} more overdue books");
        }
    }

    private async Task LoadPendingReservationsAsync()
    {
        try
        {
            var pendingReservations = await _dashboardService.GetPendingReservationsCountAsync();

            if (InvokeRequired)
            {
                Invoke(() => UpdatePendingReservationsList(pendingReservations));
            }
            else
            {
                UpdatePendingReservationsList(pendingReservations);
            }
        }
        catch (Exception ex)
        {
            UpdateLabelSafely(LblReservationPendingCount, "Error: Failed to load");
        }
    }

    private void UpdatePendingReservationsList(List<ReservationTransactionDto> pendingReservations)
    {
        LblReservationPendingCount.Text = $"Pending: {pendingReservations.Count}";

        ListReservationPending.Items.Clear();

        if (pendingReservations.Count == 0)
        {
            ListReservationPending.Items.Add("No pending reservations");
            return;
        }

        // Show all pending reservations in a single line format
        foreach (var reservation in pendingReservations.Take(10))
        {
            var bookTitle = reservation.Book?.Title ?? "Unknown Book";
            var memberName = reservation.Member?.Name ?? "Unknown Member";
            var daysUntilExpiration = (reservation.ExpirationDate.Date - DateTime.Now.Date).Days;

            string expirationInfo;
            var priority = "";
            if (daysUntilExpiration < 0)
            {
                priority = "[EXPIRED]";
                expirationInfo = $"{Math.Abs(daysUntilExpiration)} days ago";
            }
            else if (daysUntilExpiration <= 2)
            {
                priority = "[EXPIRING]";
                expirationInfo = daysUntilExpiration == 0 ? "today" : $"in {daysUntilExpiration} days";
            }
            else
            {
                expirationInfo = $"in {daysUntilExpiration} days";
            }

            ListReservationPending.Items.Add($"{priority} {bookTitle} - {memberName} (expires {expirationInfo})");
        }

        if (pendingReservations.Count > 10)
        {
            ListReservationPending.Items.Add($"... and {pendingReservations.Count - 10} more reservations");
        }
    }

    private async Task LoadTopRatedBooksAsync()
    {
        try
        {
            var topRatedBook = await _dashboardService.GetTopRatedBookAsync();
            var mostBorrowedBooks = await _dashboardService.GetMostBorrowedBooksAsync(8);

            if (InvokeRequired)
            {
                Invoke(() => UpdateTopRatedBooksList(topRatedBook, mostBorrowedBooks));
            }
            else
            {
                UpdateTopRatedBooksList(topRatedBook, mostBorrowedBooks);
            }
        }
        catch (Exception ex)
        {
            UpdateLabelSafely(LblTopRatedBookName, "Error: Failed to load");
        }
    }

    private void UpdateTopRatedBooksList(BookDto topRatedBook, List<BookDto> mostBorrowedBooks)
    {
        // Update top rated book label
        if (topRatedBook != null && topRatedBook.Id > 0)
        {
            LblTopRatedBookName.Text = $"{topRatedBook.Title}";
            if (!string.IsNullOrEmpty(topRatedBook.Author))
            {
                LblTopRatedBookName.Text += $" - {topRatedBook.Author}";
            }
        }
        else
        {
            LblTopRatedBookName.Text = "No ratings yet";
        }

        // Update top books list
        ListTopRatedBooks.Items.Clear();

        if (mostBorrowedBooks.Any())
        {
            var rank = 1;
            foreach (var book in mostBorrowedBooks)
            {
                var borrowCount = book.BorrowTransactions?.Count ?? 0;
                var rankPrefix = rank <= 3 ? $"#{rank}" : $"{rank}.";

                ListTopRatedBooks.Items.Add(
                    $"{rankPrefix} {book.Title} by {book.Author ?? "Unknown"} ({borrowCount} borrows)");
                rank++;
            }
        }
        else
        {
            ListTopRatedBooks.Items.Add("No borrowing data available yet");
        }
    }

    private void UpdateLabelSafely(Label label, string text)
    {
        if (InvokeRequired)
        {
            Invoke(() => label.Text = text);
        }
        else
        {
            label.Text = text;
        }
    }

    private void SetupListBoxEvents()
    {
        // Set up double-click events for interactive functionality
        ListBoxOverdueBooks.DoubleClick += ListBoxOverdueBooks_DoubleClick;
        ListReservationPending.DoubleClick += ListReservationPending_DoubleClick;
        ListTopRatedBooks.DoubleClick += ListTopRatedBooks_DoubleClick;

        // Set up selection changed events for better UX
        ListBoxOverdueBooks.SelectedIndexChanged += ListBoxOverdueBooks_SelectedIndexChanged;
        ListReservationPending.SelectedIndexChanged += ListReservationPending_SelectedIndexChanged;
        ListTopRatedBooks.SelectedIndexChanged += ListTopRatedBooks_SelectedIndexChanged;
    }

    private void ListBoxOverdueBooks_SelectedIndexChanged(object? sender, EventArgs e)
    {
        // Highlight selected item for better visual feedback
        if (ListBoxOverdueBooks.SelectedItem != null)
        {
            ListBoxOverdueBooks.BackColor = Color.FromArgb(255, 248, 248); // Light red background
        }
    }

    private void ListReservationPending_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (ListReservationPending.SelectedItem != null)
        {
            ListReservationPending.BackColor = Color.FromArgb(248, 252, 255); // Light blue background
        }
    }

    private void ListTopRatedBooks_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (ListTopRatedBooks.SelectedItem != null)
        {
            ListTopRatedBooks.BackColor = Color.FromArgb(248, 255, 248); // Light green background
        }
    }

    private void ListBoxOverdueBooks_DoubleClick(object? sender, EventArgs e)
    {
        if (ListBoxOverdueBooks.SelectedItem != null)
        {
            var selectedText = ListBoxOverdueBooks.SelectedItem.ToString();
            if (!string.IsNullOrEmpty(selectedText) && selectedText.Contains("["))
            {
                MessageBox.Show($"OVERDUE BOOK ALERT\n\n" +
                                $"Book: {selectedText}\n\n" +
                                $"Actions you can take:\n" +
                                $"• Contact the member via phone/email\n" +
                                $"• Send overdue notice\n" +
                                $"• Apply late fees if applicable\n" +
                                $"• Check if book needs to be replaced",
                    "Overdue Book Management", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }

    private void ListReservationPending_DoubleClick(object? sender, EventArgs e)
    {
        if (ListReservationPending.SelectedItem != null)
        {
            var selectedText = ListReservationPending.SelectedItem.ToString();
            if (!string.IsNullOrEmpty(selectedText))
            {
                MessageBox.Show($"RESERVATION DETAILS\n\n" +
                                $"Book: {selectedText}\n\n" +
                                $"Available actions:\n" +
                                $"• Notify member when book becomes available\n" +
                                $"• Cancel expired reservations\n" +
                                $"• Extend reservation if needed\n" +
                                $"• Process book handover",
                    "Reservation Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }

    private void ListTopRatedBooks_DoubleClick(object? sender, EventArgs e)
    {
        if (ListTopRatedBooks.SelectedItem != null)
        {
            var selectedText = ListTopRatedBooks.SelectedItem.ToString();
            if (!string.IsNullOrEmpty(selectedText) && selectedText.Contains("#"))
            {
                MessageBox.Show($"POPULAR BOOK INSIGHTS\n\n" +
                                $"Book: {selectedText}\n\n" +
                                $"This book is highly popular! Consider:\n" +
                                $"• Ordering additional copies\n" +
                                $"• Featuring in library promotions\n" +
                                $"• Recommending similar titles\n" +
                                $"• Creating book club discussions",
                    "Popular Book Analytics", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        // Stop the refresh timer when form is closing
        _refreshTimer?.Stop();
        _refreshTimer?.Dispose();
        base.OnFormClosing(e);
    }

    // Public method to manually refresh dashboard (can be called from MainForm)
    public async Task RefreshDashboard()
    {
        await LoadDashboardDataAsync();
    }

    // Method to pause/resume auto-refresh
    public void SetAutoRefresh(bool enabled)
    {
        if (enabled)
        {
            _refreshTimer?.Start();
        }
        else
        {
            _refreshTimer?.Stop();
        }
    }
}
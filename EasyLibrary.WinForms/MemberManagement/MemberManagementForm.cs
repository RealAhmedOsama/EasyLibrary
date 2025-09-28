using System.Text.RegularExpressions;
using EasyLibrary.Core.Interfaces;
using EasyLibrary.Core.Models;
using EasyLibrary.Core.Services;

namespace EasyLibrary.WinForms.MemberManagement;

public partial class MemberManagementForm : Form
{
    private readonly IMemberService _memberService;
    private List<MemberDto> _allMembers;
    private MemberDto _selectedMember;

    public MemberManagementForm()
    {
        InitializeComponent();
        _memberService = new MemberService();
        _allMembers = new List<MemberDto>();

        // Subscribe to DataGridView selection event
        DgvAllMembers.SelectionChanged += DgvAllMembers_SelectionChanged;

        // Subscribe to DataGridView double-click event
        DgvAllMembers.CellDoubleClick += DgvAllMembers_CellDoubleClick;

        // Initialize DateTimePicker
        DtpMembershipDate.Value = DateTime.Now;

        // Load initial data
        LoadInitialDataAsync();
    }

    private async void LoadInitialDataAsync()
    {
        try
        {
            await LoadMembersAsync();
            UpdateStatisticsLabels();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading initial data: {ex.Message}", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private async Task LoadMembersAsync()
    {
        try
        {
            _allMembers = await _memberService.GetAllMembersAsync();
            DisplayMembers(_allMembers.Where(m => m.IsActive).ToList());
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading members: {ex.Message}", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void DisplayMembers(List<MemberDto> members)
    {
        var memberDisplay = members.Select(m => new
        {
            m.Id,
            m.Name,
            m.Email,
            m.Phone,
            MembershipDate = m.MembershipDate.ToString("yyyy-MM-dd"),
            IsActive = m.IsActive ? "Yes" : "No",
            CreatedOn = m.CreatedOn.ToString("yyyy-MM-dd"),
            BorrowedBooks = m.BorrowTransactions?.Count(bt => bt.ReturnDate == null) ?? 0,
            ReservedBooks = m.ReservationTransactions?.Count ?? 0
        }).ToList();

        DgvAllMembers.DataSource = memberDisplay;

        // Configure column headers and widths
        if (DgvAllMembers.Columns.Count > 0)
        {
            DgvAllMembers.Columns["Id"].HeaderText = "ID";
            DgvAllMembers.Columns["Id"].Width = 50;
            DgvAllMembers.Columns["Name"].HeaderText = "Member Name";
            DgvAllMembers.Columns["Name"].Width = 150;
            DgvAllMembers.Columns["Email"].HeaderText = "Email";
            DgvAllMembers.Columns["Email"].Width = 180;
            DgvAllMembers.Columns["Phone"].HeaderText = "Phone";
            DgvAllMembers.Columns["Phone"].Width = 120;
            DgvAllMembers.Columns["MembershipDate"].HeaderText = "Membership Date";
            DgvAllMembers.Columns["MembershipDate"].Width = 120;
            DgvAllMembers.Columns["IsActive"].HeaderText = "Active";
            DgvAllMembers.Columns["IsActive"].Width = 60;
            DgvAllMembers.Columns["CreatedOn"].HeaderText = "Created";
            DgvAllMembers.Columns["CreatedOn"].Width = 100;
            DgvAllMembers.Columns["BorrowedBooks"].HeaderText = "Borrowed";
            DgvAllMembers.Columns["BorrowedBooks"].Width = 80;
            DgvAllMembers.Columns["ReservedBooks"].HeaderText = "Reserved";
            DgvAllMembers.Columns["ReservedBooks"].Width = 80;
        }
    }

    private void UpdateStatisticsLabels()
    {
        var activeMembers = _allMembers.Where(m => m.IsActive).ToList();
        LblTotalBooks.Text = $"Total Members: {activeMembers.Count}";
    }

    private void DgvAllMembers_SelectionChanged(object sender, EventArgs e)
    {
        if (DgvAllMembers.SelectedRows.Count > 0)
        {
            var selectedRow = DgvAllMembers.SelectedRows[0];
            var memberId = (int)selectedRow.Cells["Id"].Value;

            _selectedMember = _allMembers.FirstOrDefault(m => m.Id == memberId);
            if (_selectedMember != null)
            {
                PopulateFormFields(_selectedMember);
            }
        }
    }

    private void DgvAllMembers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        try
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = DgvAllMembers.Rows[e.RowIndex];
                var memberId = (int)selectedRow.Cells["Id"].Value;

                var selectedMember = _allMembers.FirstOrDefault(m => m.Id == memberId);
                if (selectedMember != null)
                {
                    // Open Member Profile Form
                    var profileForm = new MemberProfileForm(selectedMember);
                    profileForm.Show();
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error opening member profile: {ex.Message}", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void PopulateFormFields(MemberDto member)
    {
        txtMemberName.Text = member.Name;
        txtMemberEmail.Text = member.Email;
        txtMemberPhone.Text = member.Phone;
        DtpMembershipDate.Value = member.MembershipDate;
        chkMemberStatus.Checked = member.IsActive;
    }

    private bool ValidateInput()
    {
        // Validate Name
        if (string.IsNullOrWhiteSpace(txtMemberName.Text))
        {
            MessageBox.Show("Please enter member name.", "Validation Error", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            txtMemberName.Focus();
            return false;
        }

        // Validate Email
        if (string.IsNullOrWhiteSpace(txtMemberEmail.Text))
        {
            MessageBox.Show("Please enter member email.", "Validation Error", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            txtMemberEmail.Focus();
            return false;
        }

        if (!IsValidEmail(txtMemberEmail.Text))
        {
            MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            txtMemberEmail.Focus();
            return false;
        }

        // Validate Phone
        if (string.IsNullOrWhiteSpace(txtMemberPhone.Text))
        {
            MessageBox.Show("Please enter member phone number.", "Validation Error", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            txtMemberPhone.Focus();
            return false;
        }

        if (!IsValidPhone(txtMemberPhone.Text))
        {
            MessageBox.Show("Please enter a valid phone number.", "Validation Error", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            txtMemberPhone.Focus();
            return false;
        }

        // Validate Membership Date
        if (DtpMembershipDate.Value > DateTime.Now)
        {
            MessageBox.Show("Membership date cannot be in the future.", "Validation Error", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            DtpMembershipDate.Focus();
            return false;
        }

        // Check for duplicate email when adding or updating
        var existingMember = _allMembers.FirstOrDefault(m =>
            m.Email.Equals(txtMemberEmail.Text.Trim(), StringComparison.OrdinalIgnoreCase) &&
            (_selectedMember == null || m.Id != _selectedMember.Id));

        if (existingMember != null)
        {
            MessageBox.Show("A member with this email already exists.", "Validation Error", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            txtMemberEmail.Focus();
            return false;
        }

        return true;
    }

    private bool IsValidEmail(string email)
    {
        try
        {
            var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email.Trim(), emailPattern, RegexOptions.IgnoreCase);
        }
        catch
        {
            return false;
        }
    }

    private bool IsValidPhone(string phone)
    {
        // Remove any non-digit characters for validation
        var digitsOnly = Regex.Replace(phone, @"[^\d]", "");
        // Check if it has at least 10 digits
        return digitsOnly.Length >= 10;
    }

    private MemberDto CreateMemberFromForm()
    {
        return new MemberDto
        {
            Name = txtMemberName.Text.Trim(),
            Email = txtMemberEmail.Text.Trim(),
            Phone = txtMemberPhone.Text.Trim(),
            MembershipDate = DtpMembershipDate.Value.Date,
            IsActive = chkMemberStatus.Checked
        };
    }

    private void ClearForm()
    {
        txtMemberName.Clear();
        txtMemberEmail.Clear();
        txtMemberPhone.Clear();
        DtpMembershipDate.Value = DateTime.Now;
        chkMemberStatus.Checked = true;
        _selectedMember = null;
    }

    private async void btnAddMember_Click(object sender, EventArgs e)
    {
        try
        {
            if (!ValidateInput())
                return;

            var newMember = CreateMemberFromForm();
            await _memberService.AddMemberAsync(newMember);

            MessageBox.Show("Member added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            await LoadMembersAsync();
            UpdateStatisticsLabels();
            ClearForm();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error adding member: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void BtnUpdateMember_Click(object sender, EventArgs e)
    {
        try
        {
            if (_selectedMember == null)
            {
                MessageBox.Show("Please select a member to update.", "Selection Required", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput())
                return;

            var updatedMember = CreateMemberFromForm();
            updatedMember.Id = _selectedMember.Id;
            updatedMember.CreatedOn = _selectedMember.CreatedOn;

            await _memberService.UpdateMemberAsync(updatedMember);

            MessageBox.Show("Member updated successfully!", "Success", MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            await LoadMembersAsync();
            UpdateStatisticsLabels();
            ClearForm();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error updating member: {ex.Message}", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private async void BtnDeleteMember_Click(object sender, EventArgs e)
    {
        try
        {
            if (_selectedMember == null)
            {
                MessageBox.Show("Please select a member to delete.", "Selection Required", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Check if member has active transactions
            var activeBorrows = _selectedMember.BorrowTransactions?.Count(bt => bt.ReturnDate == null) ?? 0;
            var activeReservations = _selectedMember.ReservationTransactions?.Count ?? 0;

            if (activeBorrows > 0 || activeReservations > 0)
            {
                MessageBox.Show(
                    $"Cannot delete member '{_selectedMember.Name}' because they have {activeBorrows} active borrowed books and {activeReservations} reservations. Please complete or cancel these transactions first.",
                    "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"Are you sure you want to delete member '{_selectedMember.Name}'?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                await _memberService.DeleteMemberAsync(_selectedMember);

                MessageBox.Show("Member deleted successfully!", "Success", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                await LoadMembersAsync();
                UpdateStatisticsLabels();
                ClearForm();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error deleting member: {ex.Message}", "Error", MessageBoxButtons.OK,
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
                // If search term is empty, show all members
                DisplayMembers(_allMembers.Where(m => m.IsActive).ToList());
                return;
            }

            // Filter members by name, email, or phone
            var filteredMembers = _allMembers.Where(m => m.IsActive &&
                                                         (m.Name.Contains(searchTerm,
                                                              StringComparison.OrdinalIgnoreCase) ||
                                                          m.Email.Contains(searchTerm,
                                                              StringComparison.OrdinalIgnoreCase) ||
                                                          m.Phone.Contains(searchTerm,
                                                              StringComparison.OrdinalIgnoreCase))).ToList();

            DisplayMembers(filteredMembers);

            if (!filteredMembers.Any())
            {
                MessageBox.Show("No members found matching your search criteria.", "Search Results",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error searching members: {ex.Message}", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private async void BtnRefresh_Click(object sender, EventArgs e)
    {
        try
        {
            txtSearchInput.Clear();
            await LoadMembersAsync();
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
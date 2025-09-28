using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using EasyLibrary.Core.Interfaces;
using EasyLibrary.Core.Models;
using EasyLibrary.Core.Services;

namespace EasyLibrary.WinForms.UserManagement;

public partial class UsersManagementForm : Form
{
    private readonly IRoleService _roleService;
    private readonly IUserInRoleService _userInRoleService;
    private readonly IUserService _userService;
    private List<RoleDto> _allRoles;
    private List<UserDto> _allUsers;
    private UserDto _selectedUser;

    public UsersManagementForm()
    {
        InitializeComponent();
        _userService = new UserService();
        _roleService = new RoleService();
        _userInRoleService = new UserInRoleService();
        _allUsers = new List<UserDto>();
        _allRoles = new List<RoleDto>();

        // Subscribe to DataGridView selection event
        DgvAllUsers.SelectionChanged += DgvAllUsers_SelectionChanged;

        // Load initial data
        LoadInitialDataAsync();
    }

    private async void LoadInitialDataAsync()
    {
        try
        {
            await LoadRolesAsync();
            await LoadUsersAsync();
            UpdateStatisticsLabels();
        }
        catch (Exception ex)
        {
            MessageBox.Show($@"Error loading initial data: {ex.Message}", @"Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private async Task LoadRolesAsync()
    {
        try
        {
            _allRoles = await _roleService.GetAllRolesAsync();

            cmbRoles.DataSource = _allRoles.Where(r => r.IsActive).ToList();
            cmbRoles.DisplayMember = "RoleName";
            cmbRoles.ValueMember = "Id";
            cmbRoles.SelectedIndex = -1;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading roles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async Task LoadUsersAsync()
    {
        try
        {
            _allUsers = await _userService.GetAllUsersAsync();
            DisplayUsers(_allUsers.Where(u => u.IsActive).ToList());
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading users: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void DisplayUsers(List<UserDto> users)
    {
        var userDisplay = users.Select(u => new
        {
            u.Id,
            u.Username,
            u.Email,
            IsActive = u.IsActive ? "Yes" : "No",
            CreatedOn = u.CreatedOn.ToString("yyyy-MM-dd"),
            Roles = GetUserRolesDisplay(u),
            RolesCount = u.UserInRoles?.Count ?? 0
        }).ToList();

        DgvAllUsers.DataSource = userDisplay;

        // Configure column headers and widths
        if (DgvAllUsers.Columns.Count > 0)
        {
            DgvAllUsers.Columns["Id"].HeaderText = "ID";
            DgvAllUsers.Columns["Id"].Width = 50;
            DgvAllUsers.Columns["Username"].HeaderText = "Username";
            DgvAllUsers.Columns["Username"].Width = 150;
            DgvAllUsers.Columns["Email"].HeaderText = "Email";
            DgvAllUsers.Columns["Email"].Width = 200;
            DgvAllUsers.Columns["IsActive"].HeaderText = "Active";
            DgvAllUsers.Columns["IsActive"].Width = 60;
            DgvAllUsers.Columns["CreatedOn"].HeaderText = "Created";
            DgvAllUsers.Columns["CreatedOn"].Width = 100;
            DgvAllUsers.Columns["Roles"].HeaderText = "Roles";
            DgvAllUsers.Columns["Roles"].Width = 200;
            DgvAllUsers.Columns["RolesCount"].HeaderText = "Role Count";
            DgvAllUsers.Columns["RolesCount"].Width = 80;
        }
    }

    private string GetUserRolesDisplay(UserDto user)
    {
        Console.WriteLine($"Getting roles for user {user.Username} (ID: {user.Id})");

        if (user.UserInRoles == null || !user.UserInRoles.Any())
        {
            Console.WriteLine($"User {user.Username} has no UserInRoles or empty collection");
            return "No roles assigned";
        }

        Console.WriteLine($"User {user.Username} has {user.UserInRoles.Count} UserInRole entries");

        var roleNames = new List<string>();
        foreach (var uir in user.UserInRoles)
        {
            Console.WriteLine(
                $"UserInRole - ID: {uir.Id}, UserId: {uir.UserId}, RoleId: {uir.RoleId}, IsActive: {uir.IsActive}");

            if (uir.Role != null)
            {
                Console.WriteLine($"Role found: {uir.Role.RoleName}");
                roleNames.Add(uir.Role.RoleName);
            }
            else
            {
                Console.WriteLine("Role is null!");
            }
        }

        var result = roleNames.Any() ? string.Join(", ", roleNames) : "No roles assigned";
        Console.WriteLine($"Final result for user {user.Username}: {result}");
        return result;
    }

    private void UpdateStatisticsLabels()
    {
        var activeUsers = _allUsers.Where(u => u.IsActive).ToList();
        LblTotalBooks.Text = $"Total Users: {activeUsers.Count}";
    }

    private void DgvAllUsers_SelectionChanged(object sender, EventArgs e)
    {
        if (DgvAllUsers.SelectedRows.Count > 0)
        {
            var selectedRow = DgvAllUsers.SelectedRows[0];
            var userId = (int)selectedRow.Cells["Id"].Value;

            _selectedUser = _allUsers.FirstOrDefault(u => u.Id == userId);
            if (_selectedUser != null)
            {
                PopulateFormFields(_selectedUser);
            }
        }
    }

    private void PopulateFormFields(UserDto user)
    {
        txtUsername.Text = user.Username;
        txtUserEmail.Text = user.Email;
        txtPassword.Text = ""; // Don't show password for security
        chkUserStatus.Checked = user.IsActive;

        // Set the role if user has one assigned
        if (user.UserInRoles != null && user.UserInRoles.Any())
        {
            var firstRole = user.UserInRoles.First();
            if (firstRole.Role != null)
            {
                cmbRoles.SelectedValue = firstRole.Role.Id;
            }
        }
        else
        {
            cmbRoles.SelectedIndex = -1;
        }
    }

    private bool ValidateInput()
    {
        // Validate Username
        if (string.IsNullOrWhiteSpace(txtUsername.Text))
        {
            MessageBox.Show("Please enter username.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtUsername.Focus();
            return false;
        }

        if (txtUsername.Text.Length < 3)
        {
            MessageBox.Show("Username must be at least 3 characters long.", "Validation Error", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            txtUsername.Focus();
            return false;
        }

        // Validate Email
        if (string.IsNullOrWhiteSpace(txtUserEmail.Text))
        {
            MessageBox.Show("Please enter user email.", "Validation Error", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            txtUserEmail.Focus();
            return false;
        }

        if (!IsValidEmail(txtUserEmail.Text))
        {
            MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            txtUserEmail.Focus();
            return false;
        }

        // Validate Password (only for new users or when updating password)
        if (_selectedUser == null && string.IsNullOrWhiteSpace(txtPassword.Text))
        {
            MessageBox.Show("Please enter password for new user.", "Validation Error", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            txtPassword.Focus();
            return false;
        }

        if (!string.IsNullOrWhiteSpace(txtPassword.Text) && txtPassword.Text.Length < 6)
        {
            MessageBox.Show("Password must be at least 6 characters long.", "Validation Error", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            txtPassword.Focus();
            return false;
        }

        // Validate Role Selection
        if (cmbRoles.SelectedValue == null)
        {
            MessageBox.Show("Please select a role for the user.", "Validation Error", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            cmbRoles.Focus();
            return false;
        }

        // Check for duplicate username when adding or updating
        var existingUser = _allUsers.FirstOrDefault(u =>
            u.Username.Equals(txtUsername.Text.Trim(), StringComparison.OrdinalIgnoreCase) &&
            (_selectedUser == null || u.Id != _selectedUser.Id));

        if (existingUser != null)
        {
            MessageBox.Show("A user with this username already exists.", "Validation Error", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            txtUsername.Focus();
            return false;
        }

        // Check for duplicate email when adding or updating
        var existingEmailUser = _allUsers.FirstOrDefault(u =>
            u.Email.Equals(txtUserEmail.Text.Trim(), StringComparison.OrdinalIgnoreCase) &&
            (_selectedUser == null || u.Id != _selectedUser.Id));

        if (existingEmailUser != null)
        {
            MessageBox.Show("A user with this email already exists.", "Validation Error", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            txtUserEmail.Focus();
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

    private string HashPassword(string password)
    {
        // Simple hash implementation - in production, use proper password hashing like BCrypt
        using (var sha256 = SHA256.Create())
        {
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes);
        }
    }

    private UserDto CreateUserFromForm()
    {
        var user = new UserDto
        {
            Username = txtUsername.Text.Trim(),
            Email = txtUserEmail.Text.Trim(),
            IsActive = chkUserStatus.Checked
        };

        // Only hash password if it's provided
        if (!string.IsNullOrWhiteSpace(txtPassword.Text))
        {
            user.Password = HashPassword(txtPassword.Text);
        }
        else if (_selectedUser != null)
        {
            // Keep existing password if updating and no new password provided
            user.Password = _selectedUser.Password;
        }

        return user;
    }

    private void ClearForm()
    {
        txtUsername.Clear();
        txtUserEmail.Clear();
        txtPassword.Clear();
        cmbRoles.SelectedIndex = -1;
        chkUserStatus.Checked = true;
        _selectedUser = null;
    }

    private async void btnAddMember_Click(object sender, EventArgs e)
    {
        try
        {
            if (!ValidateInput())
                return;

            var newUser = CreateUserFromForm();
            await _userService.AddUserAsync(newUser);

            // Get the created user to get its ID
            var createdUsers = await _userService.GetAllUsersAsync();
            var createdUser = createdUsers.OrderByDescending(u => u.Id)
                .FirstOrDefault(u => u.Username == newUser.Username);

            if (createdUser != null && cmbRoles.SelectedValue != null)
            {
                // Assign role to user
                var userInRole = new UserInRoleDto
                {
                    UserId = createdUser.Id,
                    RoleId = (int)cmbRoles.SelectedValue,
                    CreatedOn = DateTime.Now,
                    IsActive = true
                };

                var createdRole = await _userInRoleService.CreateAsync(userInRole);
                Console.WriteLine($"Role assigned: UserId={createdRole.UserId}, RoleId={createdRole.RoleId}");
            }

            MessageBox.Show("User added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            await LoadUsersAsync();
            UpdateStatisticsLabels();
            ClearForm();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error adding user: {ex.Message}\n\nInner Exception: {ex.InnerException?.Message}",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void BtnUpdateMember_Click(object sender, EventArgs e)
    {
        try
        {
            if (_selectedUser == null)
            {
                MessageBox.Show("Please select a user to update.", "Selection Required", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput())
                return;

            var updatedUser = CreateUserFromForm();
            updatedUser.Id = _selectedUser.Id;
            updatedUser.CreatedOn = _selectedUser.CreatedOn;

            // Update the user first
            await _userService.UpdateUserAsync(updatedUser);

            // Handle role updates more safely
            if (cmbRoles.SelectedValue != null)
            {
                var selectedRoleId = (int)cmbRoles.SelectedValue;

                // Check if user already has roles assigned
                var allUserInRoles = await _userInRoleService.GetAllAsync();
                var currentUserRoles =
                    allUserInRoles.Where(ur => ur.UserId == _selectedUser.Id && ur.IsActive).ToList();

                // Check if the user already has the selected role
                var hasSelectedRole = currentUserRoles.Any(ur => ur.RoleId == selectedRoleId);

                if (!hasSelectedRole)
                {
                    // Remove existing roles by marking them as inactive instead of deleting
                    foreach (var existingRole in currentUserRoles)
                    {
                        try
                        {
                            existingRole.IsActive = false;
                            await _userInRoleService.UpdateAsync(existingRole);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error deactivating role: {ex.Message}");
                            // Continue with other roles
                        }
                    }

                    // Add new role
                    var userInRole = new UserInRoleDto
                    {
                        UserId = _selectedUser.Id,
                        RoleId = selectedRoleId,
                        CreatedOn = DateTime.Now,
                        IsActive = true
                    };

                    await _userInRoleService.CreateAsync(userInRole);
                }
            }

            MessageBox.Show("User updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            await LoadUsersAsync();
            UpdateStatisticsLabels();
            ClearForm();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error updating user: {ex.Message}\n\nInner Exception: {ex.InnerException?.Message}",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void BtnDeleteMember_Click(object sender, EventArgs e)
    {
        try
        {
            if (_selectedUser == null)
            {
                MessageBox.Show("Please select a user to delete.", "Selection Required", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Prevent deletion of critical system users
            var criticalUsers = new[] { "admin", "administrator", "system", "root" };
            if (criticalUsers.Any(cu => cu.Equals(_selectedUser.Username, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show(
                    $"Cannot delete system user '{_selectedUser.Username}'. System users are protected and cannot be removed.",
                    "System User Protection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"Are you sure you want to delete user '{_selectedUser.Username}'?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Handle user roles cleanup more safely
                try
                {
                    var allUserInRoles = await _userInRoleService.GetAllAsync();
                    var userRoles = allUserInRoles.Where(ur => ur.UserId == _selectedUser.Id).ToList();

                    foreach (var userRole in userRoles)
                    {
                        try
                        {
                            // Instead of deleting, mark as inactive
                            userRole.IsActive = false;
                            await _userInRoleService.UpdateAsync(userRole);
                        }
                        catch (Exception roleEx)
                        {
                            Console.WriteLine($"Error deactivating user role: {roleEx.Message}");
                            // Continue with other roles
                        }
                    }
                }
                catch (Exception roleCleanupEx)
                {
                    Console.WriteLine($"Error during role cleanup: {roleCleanupEx.Message}");
                    // Continue with user deletion
                }

                // Delete the user (or mark as inactive)
                _selectedUser.IsActive = false;
                await _userService.UpdateUserAsync(_selectedUser);

                MessageBox.Show("User deactivated successfully!", "Success", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                await LoadUsersAsync();
                UpdateStatisticsLabels();
                ClearForm();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error deleting user: {ex.Message}\n\nInner Exception: {ex.InnerException?.Message}",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                // If search term is empty, show all users
                DisplayUsers(_allUsers.Where(u => u.IsActive).ToList());
                return;
            }

            // Filter users by username or email
            var filteredUsers = _allUsers.Where(u => u.IsActive &&
                                                     (u.Username.Contains(searchTerm,
                                                          StringComparison.OrdinalIgnoreCase) ||
                                                      u.Email.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)))
                .ToList();

            DisplayUsers(filteredUsers);

            if (!filteredUsers.Any())
            {
                MessageBox.Show("No users found matching your search criteria.", "Search Results",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error searching users: {ex.Message}", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private async void BtnRefresh_Click(object sender, EventArgs e)
    {
        try
        {
            txtSearchInput.Clear();
            await LoadRolesAsync();
            await LoadUsersAsync();
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
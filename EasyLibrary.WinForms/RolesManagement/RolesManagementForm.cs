using EasyLibrary.Core.Interfaces;
using EasyLibrary.Core.Models;
using EasyLibrary.Core.Services;

namespace EasyLibrary.WinForms.RolesManagement;

public partial class RolesManagementForm : Form
{
    private readonly IRoleService _roleService;
    private List<RoleDto> _allRoles;
    private RoleDto _selectedRole;

    public RolesManagementForm()
    {
        InitializeComponent();
        _roleService = new RoleService();
        _allRoles = new List<RoleDto>();

        // Subscribe to DataGridView selection event
        DgvAllRoles.SelectionChanged += DgvAllRoles_SelectionChanged;

        // Load initial data
        LoadInitialDataAsync();
    }

    private async void LoadInitialDataAsync()
    {
        try
        {
            await LoadRolesAsync();
            UpdateStatisticsLabels();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading initial data: {ex.Message}", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private async Task LoadRolesAsync()
    {
        try
        {
            _allRoles = await _roleService.GetAllRolesAsync();
            DisplayRoles(_allRoles.Where(r => r.IsActive).ToList());
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading roles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void DisplayRoles(List<RoleDto> roles)
    {
        var roleDisplay = roles.Select(r =>
        {
            var activeUserCount =
                r.UserInRoles?.Count(uir => uir.IsActive && uir.User != null && uir.User.IsActive) ?? 0;
            Console.WriteLine($"Role {r.RoleName} (ID: {r.Id}) has {activeUserCount} active users");

            return new
            {
                r.Id,
                r.RoleName,
                r.Description,
                IsActive = r.IsActive ? "Yes" : "No",
                CreatedOn = r.CreatedOn.ToString("yyyy-MM-dd"),
                UsersCount = activeUserCount
            };
        }).ToList();

        DgvAllRoles.DataSource = roleDisplay;

        // Configure column headers and widths
        if (DgvAllRoles.Columns.Count > 0)
        {
            DgvAllRoles.Columns["Id"].HeaderText = "ID";
            DgvAllRoles.Columns["Id"].Width = 50;
            DgvAllRoles.Columns["RoleName"].HeaderText = "Role Name";
            DgvAllRoles.Columns["RoleName"].Width = 150;
            DgvAllRoles.Columns["Description"].HeaderText = "Description";
            DgvAllRoles.Columns["Description"].Width = 350;
            DgvAllRoles.Columns["IsActive"].HeaderText = "Active";
            DgvAllRoles.Columns["IsActive"].Width = 70;
            DgvAllRoles.Columns["CreatedOn"].HeaderText = "Created";
            DgvAllRoles.Columns["CreatedOn"].Width = 100;
            DgvAllRoles.Columns["UsersCount"].HeaderText = "Users";
            DgvAllRoles.Columns["UsersCount"].Width = 70;
        }
    }

    private void UpdateStatisticsLabels()
    {
        var activeRoles = _allRoles.Where(r => r.IsActive).ToList();
        LblTotalRoles.Text = $"Total Roles: {activeRoles.Count}";
    }

    private void DgvAllRoles_SelectionChanged(object sender, EventArgs e)
    {
        if (DgvAllRoles.SelectedRows.Count > 0)
        {
            var selectedRow = DgvAllRoles.SelectedRows[0];
            var roleId = (int)selectedRow.Cells["Id"].Value;

            _selectedRole = _allRoles.FirstOrDefault(r => r.Id == roleId);
            if (_selectedRole != null)
            {
                PopulateFormFields(_selectedRole);
            }
        }
    }

    private void PopulateFormFields(RoleDto role)
    {
        txtRoleName.Text = role.RoleName;
        txtRoleDescription.Text = role.Description;
        chkRoleStatus.Checked = role.IsActive;
    }

    private bool ValidateInput()
    {
        if (string.IsNullOrWhiteSpace(txtRoleName.Text))
        {
            MessageBox.Show("Please enter role name.", "Validation Error", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            txtRoleName.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtRoleDescription.Text))
        {
            MessageBox.Show("Please enter role description.", "Validation Error", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            txtRoleDescription.Focus();
            return false;
        }

        // Check for duplicate role name when adding or updating
        var existingRole = _allRoles.FirstOrDefault(r =>
            r.RoleName.Equals(txtRoleName.Text.Trim(), StringComparison.OrdinalIgnoreCase) &&
            (_selectedRole == null || r.Id != _selectedRole.Id));

        if (existingRole != null)
        {
            MessageBox.Show("A role with this name already exists.", "Validation Error", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            txtRoleName.Focus();
            return false;
        }

        return true;
    }

    private RoleDto CreateRoleFromForm()
    {
        return new RoleDto
        {
            RoleName = txtRoleName.Text.Trim(),
            Description = txtRoleDescription.Text.Trim(),
            IsActive = chkRoleStatus.Checked
        };
    }

    private void ClearForm()
    {
        txtRoleName.Clear();
        txtRoleDescription.Clear();
        chkRoleStatus.Checked = true;
        _selectedRole = null;
    }

    private async void btnAddRole_Click(object sender, EventArgs e)
    {
        try
        {
            if (!ValidateInput())
                return;

            var newRole = CreateRoleFromForm();
            await _roleService.CreateRoleAsync(newRole);

            MessageBox.Show("Role added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            await LoadRolesAsync();
            UpdateStatisticsLabels();
            ClearForm();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error adding role: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void BtnUpdateRole_Click(object sender, EventArgs e)
    {
        try
        {
            if (_selectedRole == null)
            {
                MessageBox.Show("Please select a role to update.", "Selection Required", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput())
                return;

            var updatedRole = CreateRoleFromForm();
            updatedRole.Id = _selectedRole.Id;
            updatedRole.CreatedOn = _selectedRole.CreatedOn;

            var success = await _roleService.UpdateRoleAsync(updatedRole);

            if (success)
            {
                MessageBox.Show("Role updated successfully!", "Success", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                await LoadRolesAsync();
                UpdateStatisticsLabels();
                ClearForm();
            }
            else
            {
                MessageBox.Show("Failed to update role. Role may no longer exist.", "Update Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error updating role: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void BtnDeleteRole_Click(object sender, EventArgs e)
    {
        try
        {
            if (_selectedRole == null)
            {
                MessageBox.Show("Please select a role to delete.", "Selection Required", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Check if role has active users assigned before deleting
            var activeUserCount =
                _selectedRole.UserInRoles?.Count(uir => uir.IsActive && uir.User != null && uir.User.IsActive) ?? 0;
            if (activeUserCount > 0)
            {
                MessageBox.Show(
                    $"Cannot delete role '{_selectedRole.RoleName}' because it has {activeUserCount} active user(s) assigned to it. Please remove all users from this role first.",
                    "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Prevent deletion of critical system roles
            var criticalRoles = new[] { "Administrator", "Admin", "System Admin", "Super Admin" };
            if (criticalRoles.Any(cr => cr.Equals(_selectedRole.RoleName, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show(
                    $"Cannot delete system role '{_selectedRole.RoleName}'. System roles are protected and cannot be removed.",
                    "System Role Protection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"Are you sure you want to delete role '{_selectedRole.RoleName}'?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                await _roleService.DeleteRoleAsync(_selectedRole);

                MessageBox.Show("Role deleted successfully!", "Success", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                await LoadRolesAsync();
                UpdateStatisticsLabels();
                ClearForm();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error deleting role: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                // If search term is empty, show all roles
                DisplayRoles(_allRoles.Where(r => r.IsActive).ToList());
                return;
            }

            // Filter roles by name or description
            var filteredRoles = _allRoles.Where(r => r.IsActive &&
                                                     (r.RoleName.Contains(searchTerm,
                                                          StringComparison.OrdinalIgnoreCase) ||
                                                      r.Description.Contains(searchTerm,
                                                          StringComparison.OrdinalIgnoreCase))).ToList();

            DisplayRoles(filteredRoles);

            if (!filteredRoles.Any())
            {
                MessageBox.Show("No roles found matching your search criteria.", "Search Results",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error searching roles: {ex.Message}", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private async void BtnRefresh_Click(object sender, EventArgs e)
    {
        try
        {
            txtSearchInput.Clear();
            await LoadRolesAsync();
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
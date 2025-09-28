using System.Text.RegularExpressions;
using EasyLibrary.Core.Interfaces;
using EasyLibrary.Core.Services;

namespace EasyLibrary.WinForms.Auth;

public partial class LoginForm : Form
{
    private readonly IAuthenticationService _authenticationService;

    public LoginForm()
    {
        InitializeComponent();
        _authenticationService = new AuthenticationService();

        // Set up form event handlers
        KeyPreview = true;
        KeyDown += LoginForm_KeyDown;
        txtPassword.KeyDown += TxtPassword_KeyDown;
        txtEmail.KeyDown += TxtEmail_KeyDown;

        // Focus on email field when form loads
        Load += LoginForm_Load;
    }

    private void LoginForm_Load(object sender, EventArgs e)
    {
        txtEmail.Focus();

        // For development/testing purposes, you can pre-fill with admin credentials
        // Remove these lines in production
#if DEBUG
        txtEmail.Text = "ahmed.admin@easylibrary.com";
        txtPassword.Text = "Admin@123";
#endif
    }

    private void LoginForm_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            btnLogin_Click(sender, e);
        }
        else if (e.KeyCode == Keys.Escape)
        {
            Close();
        }
    }

    private void TxtEmail_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            txtPassword.Focus();
        }
    }

    private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            btnLogin_Click(sender, e);
        }
    }

    private async void btnLogin_Click(object sender, EventArgs e)
    {
        if (!ValidateInput())
            return;

        // Disable login button and show loading state
        btnLogin.Enabled = false;
        btnLogin.Text = "Logging in...";

        try
        {
            var email = txtEmail.Text.Trim();
            var password = txtPassword.Text;

            var authResult = await _authenticationService.AuthenticateAsync(email, password);

            if (authResult.IsSuccess && authResult.User != null)
            {
                // Show success message briefly
                MessageBox.Show($"Welcome, {authResult.User.Username}!", "Login Successful",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Hide login form and show main form
                Hide();

                var mainForm = new MainForm();
                mainForm.FormClosed += (s, args) => Close();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show(authResult.ErrorMessage ?? "Login failed. Please try again.",
                    "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Clear password field for security
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred during login: {ex.Message}",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            // Clear sensitive information
            txtPassword.Clear();
            txtPassword.Focus();
        }
        finally
        {
            // Re-enable login button
            btnLogin.Enabled = true;
            btnLogin.Text = "Login Now";
        }
    }

    private bool ValidateInput()
    {
        // Validate Email
        if (string.IsNullOrWhiteSpace(txtEmail.Text))
        {
            MessageBox.Show("Please enter your email address.", "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtEmail.Focus();
            return false;
        }

        if (!IsValidEmail(txtEmail.Text))
        {
            MessageBox.Show("Please enter a valid email address.", "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtEmail.Focus();
            return false;
        }

        // Validate Password
        if (string.IsNullOrWhiteSpace(txtPassword.Text))
        {
            MessageBox.Show("Please enter your password.", "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtPassword.Focus();
            return false;
        }

        if (txtPassword.Text.Length < 3)
        {
            MessageBox.Show("Password must be at least 3 characters long.", "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtPassword.Focus();
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

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        // If user closes login form, exit the application
        Application.Exit();
        base.OnFormClosing(e);
    }
}
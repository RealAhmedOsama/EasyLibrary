using System.Security.Cryptography;
using System.Text;
using EasyLibrary.Core.Interfaces;
using EasyLibrary.Core.Models;

namespace EasyLibrary.Core.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUserService _userService = new UserService();

    public async Task<AuthenticationResult> AuthenticateAsync(string email, string password)
    {
        try
        {
            // Get all users and find by email
            var users = await _userService.GetAllUsersAsync();
            var user = users.FirstOrDefault(u =>
                u.Email.Equals(email, StringComparison.OrdinalIgnoreCase) &&
                u.IsActive);

            if (user == null)
            {
                return new AuthenticationResult
                {
                    IsSuccess = false,
                    ErrorMessage = "Invalid email or password."
                };
            }

            // Hash the provided password and compare
            var hashedPassword = HashPassword(password);
            if (user.Password != hashedPassword)
            {
                return new AuthenticationResult
                {
                    IsSuccess = false,
                    ErrorMessage = "Invalid email or password."
                };
            }

            return new AuthenticationResult
            {
                IsSuccess = true,
                User = user,
                Message = "Login successful!"
            };
        }
        catch (Exception ex)
        {
            return new AuthenticationResult
            {
                IsSuccess = false,
                ErrorMessage = $"Authentication error: {ex.Message}"
            };
        }
    }

    public async Task<bool> ValidateUserAsync(string email)
    {
        try
        {
            var users = await _userService.GetAllUsersAsync();
            return users.Any(u =>
                u.Email.Equals(email, StringComparison.OrdinalIgnoreCase) &&
                u.IsActive);
        }
        catch
        {
            return false;
        }
    }

    private string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(hashedBytes);
    }
}
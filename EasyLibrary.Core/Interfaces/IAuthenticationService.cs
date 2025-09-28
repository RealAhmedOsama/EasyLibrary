using EasyLibrary.Core.Models;

namespace EasyLibrary.Core.Interfaces;

public interface IAuthenticationService
{
    Task<AuthenticationResult> AuthenticateAsync(string email, string password);
    Task<bool> ValidateUserAsync(string email);
}
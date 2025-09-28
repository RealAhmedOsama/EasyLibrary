namespace EasyLibrary.Core.Models;

public class AuthenticationResult
{
    public bool IsSuccess { get; set; }
    public UserDto? User { get; set; }
    public string? ErrorMessage { get; set; }
    public string? Message { get; set; }
}
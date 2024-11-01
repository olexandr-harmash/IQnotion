using System.ComponentModel.DataAnnotations;

namespace IQnotion.ApplicationCore.DataTransferObjects;

public record RegisterUserDto
{
    public string FirstName { get; init; } = null!;
    public string LastName { get; init; } = null!;
    [Required(ErrorMessage = "Username is required")]
    public string? UserName { get; init; }
    [Required(ErrorMessage = "Password is required")]
    public string Password { get; init; } = null!;
    public string? Email { get; init; }
    public string? PhoneNumber { get; init; }
    public ICollection<string>? Roles { get; init; }
}
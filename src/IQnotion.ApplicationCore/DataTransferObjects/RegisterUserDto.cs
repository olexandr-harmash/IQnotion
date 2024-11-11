using System.ComponentModel.DataAnnotations;

namespace IQnotion.ApplicationCore.DataTransferObjects;

public record RegisterUserDto
{
    [Required(ErrorMessage = "FirstName is required")]
    public string FirstName { get; init; } = null!;
    [Required(ErrorMessage = "LastName is required")]
    public string LastName { get; init; } = null!;
    [Required(ErrorMessage = "Username is required")]
    public string? UserName { get; init; }
    [Required(ErrorMessage = "Password is required")]
    public string Password { get; init; } = null!;
    [Required(ErrorMessage = "Email is required")]
    public string Email { get; init; }  = null!;
    public string? PhoneNumber { get; init; }
    public ICollection<string>? Roles { get; init; }
}
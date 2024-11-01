using Microsoft.AspNetCore.Identity;

namespace IQnotion.ApplicationCore.Models;

public class User : IdentityUser<int>
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
}
using IQnotion.ApplicationCore.DataTransferObjects;
using Microsoft.AspNetCore.Identity;

namespace IQnotion.ApplicationCore.Interfaces;

public interface IIQnotionAuthorizationService
{
    Task<IdentityResult> RegisterUser(RegisterUserDto userForRegistration);
    Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);
    Task DeleteUser(int userId);
    Task<string> CreateToken();
}
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using IQnotion.ApplicationCore.DataTransferObjects;
using IQnotion.ApplicationCore.Exceptions;
using IQnotion.ApplicationCore.Interfaces;
using IQnotion.ApplicationCore.Models;
using IQnotion.ApplicationCore.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace IQnotion.ApplicationCore.Services;

public class IQnotionAuthorizationService : IIQnotionAuthorizationService
{
    private User? _user;
    private readonly UserManager<User> _userManager;
    private readonly IQnotionAuthorizationOptions _authOptions;

    public IQnotionAuthorizationService(UserManager<User> userManager, IQnotionAuthorizationOptions authOptions)
    {
        _userManager = userManager;
        _authOptions = authOptions;
    }

    public string CreateToken()
    {
        if (_user == null)
        {
            throw new UserNotFoundException();
        }

        var secret = Environment.GetEnvironmentVariable("SECRET") ?? throw new ArgumentNullException("SECRET");
        
        var signingKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secret));

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = _authOptions.ValidIssuer,
            Audience = _authOptions.ValidAudience,
            Subject = new ClaimsIdentity(
            [
                new Claim(JwtRegisteredClaimNames.Sub, _user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // Уникальный идентификатор токена
            ]),
            Expires = DateTime.UtcNow.AddMinutes(15), // Время жизни токена
            SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }

    public async Task<IdentityResult> RegisterUser(RegisterUserDto userForRegistration)
    {
        var user = new User
        {
            FirstName   = userForRegistration.FirstName,
            LastName    = userForRegistration.LastName,
            UserName    = userForRegistration.UserName,
            Email       = userForRegistration.Email,
            PhoneNumber = userForRegistration.PhoneNumber,
        };     

        return await _userManager.CreateAsync(user, userForRegistration.Password);
    }

    public async Task ValidateUser(UserForAuthenticationDto userForAuth)
    {
        var user = await _userManager.FindByNameAsync(userForAuth.UserName);

        if (user == null && await _userManager.CheckPasswordAsync(user, userForAuth.Password))
        {
            throw new UserNotFoundException();
        }

        _user = user;
    }
}
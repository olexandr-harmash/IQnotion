using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using IQnotion.ApplicationCore.DataTransferObjects;
using IQnotion.ApplicationCore.Exceptions;
using IQnotion.ApplicationCore.Interfaces;
using IQnotion.ApplicationCore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace IQnotion.ApplicationCore.Services;

public class IQnotionAuthorizationService : IIQnotionAuthorizationService
{
    private User? _user;
    private readonly UserManager<User> _userManager;
    private readonly IConfiguration _configuration;

    public IQnotionAuthorizationService(UserManager<User> userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
    }

    public async Task<string> CreateToken()
    {
        var signingCredentials = GetSigningCredentials();
        var claims = await GetClaims();
        var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
        
        return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
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

        var result = await _userManager.CreateAsync(user, userForRegistration.Password);
        
        if (result.Succeeded)
        {
            await _userManager.AddToRolesAsync(user, new List<string> { "READER" });
        }

        return result;
    }

    public async Task<bool> ValidateUser(UserForAuthenticationDto userForAuth)
    {
        _user = await _userManager.FindByNameAsync(userForAuth.UserName);

        var result = (_user != null && await _userManager.CheckPasswordAsync(_user, userForAuth.Password));
     
        return result;
    }

    private SigningCredentials GetSigningCredentials()
    {
        var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET"));
        var secret = new SymmetricSecurityKey(key);
        
        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }

    private async Task<List<Claim>> GetClaims()
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, _user.Id.ToString()),
            new Claim(ClaimTypes.Name, _user.UserName)
        };

        var roles = await _userManager.GetRolesAsync(_user);
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        return claims;
    }

    private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
    {
        var jwtSettings = _configuration.GetSection("JwtSettings");
        var tokenOptions = new JwtSecurityToken
        (
            issuer: jwtSettings["validIssuer"],
            audience: jwtSettings["validAudience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])),
            signingCredentials: signingCredentials
        );

        return tokenOptions;
    }
}
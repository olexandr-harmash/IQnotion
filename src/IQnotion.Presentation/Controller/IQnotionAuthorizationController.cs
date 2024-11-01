using IQnotion.ApplicationCore.DataTransferObjects;
using IQnotion.ApplicationCore.Exceptions;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/authorization")]
public class AuthorizationController : ControllerBase
{
    private readonly IQnotionServices _services;

    public AuthorizationController(IQnotionServices services)
    {
        _services = services;
    }

    [HttpPost]
    public async Task<IResult> RegisterUser([FromBody] RegisterUserDto userForRegistration)
    {
        try
        {
            var result = await _services.Authorization.RegisterUser(userForRegistration);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }

                return TypedResults.BadRequest(ModelState);
            }
        
            return TypedResults.StatusCode(201);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            return TypedResults.StatusCode(500);
        }
    }

    [HttpPost("login")]
    public async Task<IResult> Authenticate([FromBody] UserForAuthenticationDto user)
    {
        try
        {
            await _services.Authorization.ValidateUser(user);

            return TypedResults.Ok(new { Token = _services.Authorization.CreateToken() });
        }
        catch (UserNotFoundException)
        {
            return TypedResults.Unauthorized();
        }
        catch (Exception)
        {
            return TypedResults.StatusCode(500);
        }
    }
}

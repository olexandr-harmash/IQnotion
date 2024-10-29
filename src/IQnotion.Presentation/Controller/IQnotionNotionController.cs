using System.Security.Claims;
using IQnotion.ApplicationCore.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/notions")]
[Authorize]
public class NotionController : ControllerBase
{
    private readonly IQnotionServices _services;

    public NotionController(IQnotionServices services)
    {
        _services = services;
    }

    [HttpGet("{type}")]
    public async Task<IResult> RetrieveNotionNotViewedByUser(string type)
    {
        try
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                return TypedResults.Unauthorized();
            }

            var userId = int.Parse(userIdClaim.Value);
            var notion = await _services.Notion.RetrieveNotionNotViewedByUserAsync(userId, type);

            return TypedResults.Ok(notion);
        } 
        catch (NotionNotFoundException ex)
        {
            _services.Logger.LogWarning(ex.Message);
            return TypedResults.NotFound();
        } 
        catch (Exception ex)
        {
            _services.Logger.LogCritical(ex.Message);
            return TypedResults.StatusCode(500);
        }
    }
}

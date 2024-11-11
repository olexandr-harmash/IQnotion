using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/files")]
[Authorize]
public class FileController : ControllerBase
{
    private readonly IQnotionServices _services;

    public FileController(IQnotionServices services)
    {
        _services = services;
    }

    [HttpGet("{lang}/{*path}")]
    public IActionResult GetFileByPath(string lang, string path)
    {
        var fullPath = Path.GetFullPath(Path.Join(_services.NotionRootPath, lang, path));
        Console.WriteLine(fullPath);
        if (System.IO.File.Exists(fullPath))
        {
            return PhysicalFile(fullPath, "application/octet-stream"); // Укажите правильный MIME-тип
        }

        _services.Logger.LogWarning("File with path: {0} can't be extracted", path);
        return NotFound();
    }
}

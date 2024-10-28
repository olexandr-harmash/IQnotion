using IQnotion.ApplicationCore.Interfaces;

public class IQnotionServices(
    ILogger<IQnotionServices> logger,
    IIQnotionNotionService notion,
    IWebHostEnvironment env)
{
    public ILogger<IQnotionServices> Logger = logger;
    public IIQnotionNotionService Notion = notion;
    public IWebHostEnvironment Env = env;
}
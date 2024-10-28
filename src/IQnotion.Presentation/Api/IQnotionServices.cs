using IQnotion.ApplicationCore.Interfaces;

public class IQnotionServices(
    ILogger<IQnotionServices> logger,
    IIQnotionNotionService notion,
    IConfiguration config)
{
    public ILogger<IQnotionServices> Logger = logger;
    public IIQnotionNotionService Notion = notion;
    public IConfiguration Config = config;
    public string NotionRootPath = config["NotionRootPath"]!;
}
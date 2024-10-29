using IQnotion.ApplicationCore.Interfaces;

public class IQnotionServices(
    ILogger<IQnotionServices> logger,
    IIQnotionUnitOfWork unitOfWork,
    IIQnotionAuthorizationService authorization,
    IIQnotionNotionService notion,
    IConfiguration config)
{
    public ILogger<IQnotionServices> Logger = logger;
    public IIQnotionUnitOfWork UnitOfWork = unitOfWork;
    public IIQnotionNotionService Notion = notion;
    public IIQnotionAuthorizationService Authorization = authorization;
    public string NotionRootPath = config["NotionRootPath"]!;
}
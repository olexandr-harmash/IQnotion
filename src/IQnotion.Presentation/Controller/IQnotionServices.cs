using IQnotion.ApplicationCore.Interfaces;

public class IQnotionServices(
    ILogger<IQnotionServices> logger,
    IIQnotionUnitOfWork unitOfWork,
    IIQnotionAuthorizationService authorization,
    IConfiguration config)
{
    public ILogger<IQnotionServices> Logger = logger;
    public IIQnotionUnitOfWork UnitOfWork = unitOfWork;
    public IIQnotionAuthorizationService Authorization = authorization;
    public string NotionRootPath = config["NotionRootPath"]!;
}
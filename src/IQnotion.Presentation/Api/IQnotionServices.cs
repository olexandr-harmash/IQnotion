using IQnotion.ApplicationCore.Interfaces;

public class IQnotionServices(
    ILogger<IQnotionServices> logger,
    IIQnotionUnitOfWork unitOfWork,
    IConfiguration config)
{
    public ILogger<IQnotionServices> Logger = logger;
    public IIQnotionUnitOfWork UnitOfWork = unitOfWork;
    public string NotionRootPath = config["NotionRootPath"]!;
}
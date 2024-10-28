public static class IQnotionFileApi
{
    public static WebApplication ConfigureRouting(WebApplication app)
    {
        var group = app.MapGroup("files");

        group.MapGet("{lang}/{*path}", GetFileByPath);

        return app;
    }

    static IResult GetFileByPath(string lang, string path, IQnotionServices services)
    {
        var fullPath = Path.GetFullPath(Path.Join(services.NotionRootPath, lang, path));

        if(File.Exists(fullPath))
        {
            return TypedResults.PhysicalFile(fullPath);
        }

        services.Logger.LogWarning("File with from path: {0} can't be extracted", path);

        return TypedResults.NotFound();
    }
}
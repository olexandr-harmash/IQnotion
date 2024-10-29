using IQnotion.ApplicationCore.Exceptions;

public static class IQnotionNotionApi
{
    public static WebApplication ConfigureRouting(WebApplication app)
    {
        var group = app.MapGroup("notions");

        group.MapGet("/", RetrieveNotionNotViewedByUser);

        return app;
    }

    static async Task<IResult> RetrieveNotionNotViewedByUser(int userId, string type, IQnotionServices services)
    {
        try
        {
            var notion = await services.UnitOfWork.Notion.RetrieveNotionNotViewedByUserAsync(userId, type);
            return TypedResults.Ok(notion);
        } 
        catch(NotionNotFoundException ex)
        {
            services.Logger.LogWarning(ex.Message);
            return TypedResults.NotFound();
        } 
        catch (Exception ex)
        {
            services.Logger.LogCritical(ex.Message);
            return TypedResults.StatusCode(500);
        }
    }
}
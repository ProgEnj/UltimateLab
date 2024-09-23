using DataBaseAppBack;
namespace Maps;

public static class GetMap
{
    public static void Map(WebApplication app)
    {
        app.MapGet("/weatherforecasts", async () => 
        {
            var result = await DBTools.GetAllForecasts();
            return result.Count > 0 ?  Results.Ok(result) : Results.NotFound(new {});
        })
            .WithOpenApi();
    }
}
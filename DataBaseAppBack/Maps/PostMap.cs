using Model;
using DataBaseAppBack;
namespace Maps;

public static class PostMap
{
    public static void Map(WebApplication app)
    {
        app.MapPost("/weatherforecasts", async (WeatherForecast forecast) => await DBTools.InsertForecast(forecast) == 1 ? Results.Created() : Results.StatusCode(500))
            .WithOpenApi();
    }
}
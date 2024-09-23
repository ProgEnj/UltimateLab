using Npgsql;
using Model;
using System.Reflection.Metadata.Ecma335;
namespace DataBaseAppBack;
public static class DBTools
{
    private static string connetionString = "Host=localhost;Username=postgres;Password=postpast;Database=postgres";
    private static NpgsqlDataSource dataSource;

    static DBTools()
    {
        var dataSourceBuilder = new NpgsqlDataSourceBuilder(connetionString);
        dataSource = dataSourceBuilder.Build();
    }

    public static async Task<List<WeatherForecast>> GetAllForecasts()
    {
        using var reader = await dataSource.CreateCommand("SELECT * FROM weatherforecasts;").ExecuteReaderAsync();
        var forecasts = new List<WeatherForecast>();

        while (await reader.ReadAsync())
        {
            forecasts.Add(new WeatherForecast(reader.GetInt32(0), DateOnly.FromDateTime(reader.GetDateTime(1)), reader.GetInt32(2), reader.GetString(3)));
        }

        return forecasts;
    }

    public static async Task<int> InsertForecast(WeatherForecast forecast)
    {

        await using var connection = await dataSource.OpenConnectionAsync();

        await using var cmd = new NpgsqlCommand("INSERT INTO weatherforecasts (date, temp, summary) " + 
        "VALUES ($1, $2, $3);", connection)
        {
            Parameters = 
            {
                new() {Value = forecast.date},
                new() {Value = forecast.temp},
                new() {Value = forecast.summary}
            }
        };
        var result = await cmd.ExecuteNonQueryAsync();      
        return result;
    }

}
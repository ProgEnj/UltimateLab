using DataBaseAppBack;

namespace Model;
public class WeatherForecast
{
    public int id { get; set; }
    public DateOnly date { get; set; }
    public int temp { get; set; }
    public string summary { get; set; }

    public WeatherForecast()
    {
        this.date = DateOnly.FromDateTime(DateTime.Today);
        this.temp = Random.Shared.Next(-20, 55);
        var summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        this.summary = summaries[Random.Shared.Next(summaries.Length)];
    }

    public WeatherForecast(int id, DateOnly date, int temp, string summary)
    {
        this.id = id;
        this.date = date;
        this.temp = temp;
        this.summary = summary;
    }
}
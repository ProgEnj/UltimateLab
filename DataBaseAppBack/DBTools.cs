using Npgsql;
using Model;
using System.Reflection.Metadata.Ecma335;
using System.Data;
namespace DataBaseAppBack;
public static class DBTools
{
    private static string connetionString = "Host=localhost;Username=postgres;Password=postpast;Database=ForLabs";
    private static NpgsqlDataSource dataSource;
    static DBTools()
    {
        var dataSourceBuilder = new NpgsqlDataSourceBuilder(connetionString);
        dataSource = dataSourceBuilder.Build();
    }

    public static async Task<List<Student>> GetStudents()
    {
        using var reader = await dataSource.CreateCommand($"SELECT * FROM Students;").ExecuteReaderAsync();
        var students = new List<Student>();

        while (await reader.ReadAsync())
        {
            students.Add(new Student(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4)));
        }

        return students;
    }

    public static async Task<List<Group>> GetGroups()
    {
        using var reader = await dataSource.CreateCommand($"SELECT * FROM Groups;").ExecuteReaderAsync();
        var collection = new List<Group>();

        while (await reader.ReadAsync())
        {
            collection.Add(new Group(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3)));
        }

        return collection;
    }

    public static async Task<List<Lectern>> GetLecterns()
    {
        using var reader = await dataSource.CreateCommand($"SELECT * FROM Lecterns;").ExecuteReaderAsync();
        var collection = new List<Lectern>();

        while (await reader.ReadAsync())
        {
            collection.Add(new Lectern(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
        }

        return collection;
    }

    public static async Task<List<Speciality>> GetSpecialities()
    {
        using var reader = await dataSource.CreateCommand($"SELECT * FROM Specialities;").ExecuteReaderAsync();
        var collection = new List<Speciality>();

        while (await reader.ReadAsync())
        {
            collection.Add(new Speciality(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3)));
        }

        return collection;
    }
    // public static async Task<int> InsertForecast(WeatherForecast forecast)
    // {

    //     await using var connection = await dataSource.OpenConnectionAsync();

    //     await using var cmd = new NpgsqlCommand("INSERT INTO weatherforecasts (date, temp, summary) " + 
    //     "VALUES ($1, $2, $3);", connection)
    //     {
    //         Parameters = 
    //         {
    //             new() {Value = forecast.date},
    //             new() {Value = forecast.temp},
    //             new() {Value = forecast.summary}
    //         }
    //     };
    //     var result = await cmd.ExecuteNonQueryAsync();      
    //     return result;
    // }

}
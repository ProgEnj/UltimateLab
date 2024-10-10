using Npgsql;
using Model;
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
    public static async Task<int> InsertStudent(Student student)
    {

        await using var connection = await dataSource.OpenConnectionAsync();
        await using var cmd = new NpgsqlCommand("INSERT INTO students (surname, related_group, join_year, rating) " + 
        "VALUES ($1, $2, $3, $4);", connection)
        {
            Parameters = 
            {
                new() {Value = student.surname},
                new() {Value = student.related_group},
                new() {Value = student.join_year},
                new() {Value = student.rating}
            }
        };
        var result = await cmd.ExecuteNonQueryAsync();      
        return result;
    }

    public static async Task<int> InsertLectern(Lectern lectern)
    {

        await using var connection = await dataSource.OpenConnectionAsync();
        await using var cmd = new NpgsqlCommand("INSERT INTO lecterns (faculty, manager) " + 
        "VALUES ($1, $2);", connection)
        {
            Parameters = 
            {
                new() {Value = lectern.faculty},
                new() {Value = lectern.manager}
            }
        };
        var result = await cmd.ExecuteNonQueryAsync();      
        return result;
    }
    public static async Task<int> InsertGroup(Group group)
    {

        await using var connection = await dataSource.OpenConnectionAsync();
        await using var cmd = new NpgsqlCommand("INSERT INTO groups (code, lectern_id, speciality_id) " + 
        "VALUES ($1, $2, $3);", connection)
        {
            Parameters = 
            {
                new() {Value = group.code},
                new() {Value = group.lectern_id},
                new() {Value = group.speciality_id}
            }
        };
        var result = await cmd.ExecuteNonQueryAsync();      
        return result;
    }
    public static async Task<int> InsertSpeciality(Speciality speciality)
    {

        await using var connection = await dataSource.OpenConnectionAsync();
        await using var cmd = new NpgsqlCommand("INSERT INTO specialities (code, name, field) " + 
        "VALUES ($1, $2, $3);", connection)
        {
            Parameters = 
            {
                new() {Value = speciality.code},
                new() {Value = speciality.name},
                new() {Value = speciality.field}
            }
        };
        var result = await cmd.ExecuteNonQueryAsync();      
        return result;
    }
}
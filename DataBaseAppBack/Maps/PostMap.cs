using DataBaseAppBack;
using Model;
namespace Maps;

public static class Map
{
    public static RouteGroupBuilder PostMap(this RouteGroupBuilder group)
    {
        group.MapPost("post/students", async (Student student) => 
        {
            return await DBTools.InsertStudent(student) == 1 ? Results.Created() : Results.StatusCode(500);
        });

        group.MapPost("post/groups", async (Group group) => 
        {
            return await DBTools.InsertGroup(group) == 1 ? Results.Created() : Results.StatusCode(500);
        });

        group.MapPost("post/lecterns", async (Lectern lectern) => 
        {
            return await DBTools.InsertLectern(lectern) == 1 ? Results.Created() : Results.StatusCode(500);
        });

        group.MapPost("post/specialities", async (Speciality speciality) => 
        {
            return await DBTools.InsertSpeciality(speciality) == 1 ? Results.Created() : Results.StatusCode(500);
        });
        
        return group;
    }
}
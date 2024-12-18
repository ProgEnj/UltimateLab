using DataBaseAppBack;
namespace Maps;

public static class MapGet
{
    public static RouteGroupBuilder GetMap(this RouteGroupBuilder getGroup)
    {
        getGroup.MapGet("get/students", async (string whereOption) => 
        {
            Console.WriteLine(whereOption);
            var result = await DBTools.GetStudents(whereOption);
            return result.Count > 0 ?  Results.Ok(
                    new { columns = new string[]{"id", "surname", "related_group", "join_year", "rating"}, data = result })  
            : Results.NotFound(new {});
        });

        getGroup.MapGet("get/groups", async (string whereOption) => 
        {
            var result = await DBTools.GetGroups(whereOption);
            return result.Count > 0 ?  Results.Ok(
                    new { columns = new string[]{"id", "code", "lectern_id", "speciality_id"}, data = result })  
            : Results.NotFound(new {});
        });

        getGroup.MapGet("get/lecterns", async (string whereOption) => 
        {
            var result = await DBTools.GetLecterns(whereOption);
            return result.Count > 0 ?  Results.Ok(
                    new { columns = new string[]{"id", "faculty", "manager"}, data = result })  
            : Results.NotFound(new {});
        });

        getGroup.MapGet("get/specialities", async (string whereOption) => 
        {
            var result = await DBTools.GetSpecialities(whereOption);
            return result.Count > 0 ?  Results.Ok(
                    new { columns = new string[]{"id", "name", "field", "code"}, data = result })  
            : Results.NotFound(new {});
        });

        return getGroup;
    }
}

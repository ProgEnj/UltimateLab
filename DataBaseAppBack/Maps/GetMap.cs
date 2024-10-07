using DataBaseAppBack;
namespace Maps;

public static class MapGet
{
    public static RouteGroupBuilder GetMap(this RouteGroupBuilder getGroup)
    {
        getGroup.MapGet("get/students", async () => 
        {
            var result = await DBTools.GetStudents();
            return result.Count > 0 ?  Results.Ok(result) : Results.NotFound(new {});
        });

        getGroup.MapGet("get/groups", async () => 
        {
            var result = await DBTools.GetGroups();
            return result.Count > 0 ?  Results.Ok(result) : Results.NotFound(new {});
        });

        getGroup.MapGet("get/lecterns", async () => 
        {
            var result = await DBTools.GetLecterns();
            return result.Count > 0 ?  Results.Ok(result) : Results.NotFound(new {});
        });

        getGroup.MapGet("get/specialities", async () => 
        {
            var result = await DBTools.GetSpecialities();
            return result.Count > 0 ?  Results.Ok(result) : Results.NotFound(new {});
        });
        
        return getGroup;
    }
}
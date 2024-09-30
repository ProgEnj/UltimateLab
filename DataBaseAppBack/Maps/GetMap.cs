using DataBaseAppBack;
namespace Maps;

public static class GetMap
{
    public static RouteGroupBuilder MapGet(this RouteGroupBuilder group)
    {
        group.MapGet("get/students", async () => 
        {
            var result = await DBTools.GetStudents();
            return result.Count > 0 ?  Results.Ok(result) : Results.NotFound(new {});
        });

        group.MapGet("get/groups", async () => 
        {
            var result = await DBTools.GetGroups();
            return result.Count > 0 ?  Results.Ok(result) : Results.NotFound(new {});
        });

        group.MapGet("get/lecterns", async () => 
        {
            var result = await DBTools.GetLecterns();
            return result.Count > 0 ?  Results.Ok(result) : Results.NotFound(new {});
        });

        group.MapGet("get/specialities", async () => 
        {
            var result = await DBTools.GetSpecialities();
            return result.Count > 0 ?  Results.Ok(result) : Results.NotFound(new {});
        });
        
        return group;
    }
}
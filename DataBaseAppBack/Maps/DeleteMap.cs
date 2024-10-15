using DataBaseAppBack;
using Microsoft.AspNetCore.Mvc;
namespace Maps;

public static class MapDelete
{
    public static RouteGroupBuilder DeleteMap(this RouteGroupBuilder group)
    {
        group.MapDelete("delete", async ([FromQuery]string table, [FromQuery]int id) => 
        {
            return await DBTools.DeleteInTable(table, id) == 1 ? Results.Ok() : Results.StatusCode(500);
        });
        
        return group;
    }
}
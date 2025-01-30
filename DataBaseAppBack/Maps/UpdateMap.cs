using DataBaseAppBack;
using Microsoft.AspNetCore.Mvc;
namespace Maps;

public static class MapUpdate
{
    public static RouteGroupBuilder UpdateMap(this RouteGroupBuilder group)
    {
        group.MapPut("update", async (string table, int id, [FromBody] List<string> values) => 
        {
            return await DBTools.UpdateInTable(table, id, values) > 0 ? Results.Ok() : Results.StatusCode(500);
        });

        group.MapPut("update/product/price", async (int id) => 
        {
            return await DBTools.UpdateProductsSizeByGroups(id) > 0 ? Results.Ok() : Results.StatusCode(500);
        });
        
        return group;
    }
}

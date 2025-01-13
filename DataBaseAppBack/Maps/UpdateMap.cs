using DataBaseAppBack;
namespace Maps;

public static class MapUpdate
{
    public static RouteGroupBuilder UpdateMap(this RouteGroupBuilder group)
    {
        group.MapPut("update", async (string table, int id, [FromBody] List<string> values) => 
        {
        });
        
        return group;
    }
}

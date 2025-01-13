using DataBaseAppBack;
using Model;
namespace Maps;

public static class MapPost
{
    public static RouteGroupBuilder PostMap(this RouteGroupBuilder group)
    {
        group.MapPost("post/customers", async (Customer customer) => 
        {
        });

        group.MapPost("post/suppliers", async (Supplier supplier) => 
        {
        });

        group.MapPost("post/purchases", async (Purchase purchase) => 
        {
        });

        group.MapPost("post/selligs", async (Selling product) => 
        {
        });

        group.MapPost("post/groups", async (Group group) => 
        {
        });

        group.MapPost("post/products", async (Product product) => 
        {
        });
        
        return group;
    }
}

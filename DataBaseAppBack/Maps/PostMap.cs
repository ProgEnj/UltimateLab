using DataBaseAppBack;
using Model;
namespace Maps;

public static class MapPost
{
    public static RouteGroupBuilder PostMap(this RouteGroupBuilder group)
    {
        group.MapPost("post/purchases", async (Purchase purchase) => 
        {
            return await DBTools.InsertPurchase(purchase) == 1 ? Results.Created() : Results.StatusCode(500);
        });

        group.MapPost("post/sellings", async (Selling selling) => 
        {
            return await DBTools.InsertSelling(selling) == 1 ? Results.Created() : Results.StatusCode(500);
        });

        group.MapPost("post/groups", async (Group group) => 
        {
            Console.WriteLine(group.product_group);
            return await DBTools.InsertGroup(group) == 1 ? Results.Created() : Results.StatusCode(500);
        });

        group.MapPost("post/suppliers", async (Supplier supplier) => 
        {
            return await DBTools.InsertSupplier(supplier) == 1 ? Results.Created() : Results.StatusCode(500);
        });
        
        group.MapPost("post/customers", async (Customer customer) => 
        {
            return await DBTools.InsertCustomer(customer) == 1 ? Results.Created() : Results.StatusCode(500);
        });
        
        group.MapPost("post/products", async (Product product) => 
        {
            return await DBTools.InsertProduct(product) == 1 ? Results.Created() : Results.StatusCode(500);
        });
        
        return group;
    }
}

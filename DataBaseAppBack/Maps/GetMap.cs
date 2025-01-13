using Microsoft.EntityFrameworkCore;
using Model;
using DataBaseAppBack;
namespace Maps;

public static class MapGet
{
    public static RouteGroupBuilder GetMap(this RouteGroupBuilder getGroup)
    {
        getGroup.MapGet("get/purchases", async (string whereOption, ModelContext modelContext) => 
        {
            var result = await modelContext.Purchases.ToListAsync();
            return result.Count > 0 ? Results.Ok(
                    new { columns = new string[]{"id", "Supplier", "Group", "Product", "Date", "Amount", "Sum"}, data = result })  
            : Results.NotFound(new {});
        });
        
        getGroup.MapGet("get/sellings", async (string whereOption, ModelContext modelContext) => 
        {
            var result = await modelContext.Sellings.ToListAsync();
            return result.Count > 0 ?  Results.Ok(
                    new { columns = new string[]{"id", "Supplier", "Group", "Product", "Date", "Amount", "Sum"}, data = result })  
            : Results.NotFound(new {});
        });

        getGroup.MapGet("get/groups", async (string whereOption, ModelContext modelContext) => 
        {
            var result = await modelContext.Groups.Where().ToListAsync();
            return result.Count > 0 ?  Results.Ok(
                    new { columns = new string[]{"id", "product_group"}, data = result })  
            : Results.NotFound(new {});
        });

        getGroup.MapGet("get/suppliers", async (string whereOption, ModelContext modelContext) => 
        {
            var result = await modelContext.Suppliers.ToListAsync();
            return result.Count > 0 ?  Results.Ok(
                    new { columns = new string[]{"id", "firstName", "middleName", "lastName", "organization", "phonenumber", "accountant", "address"}, data = result })  
            : Results.NotFound(new {});
        });

        getGroup.MapGet("get/customers", async (string whereOption, ModelContext modelContext) => 
        {
            var result = await modelContext.Customers.ToListAsync();
            return result.Count > 0 ?  Results.Ok(
                    new { columns = new string[]{"id", "firstName", "middleName", "lastName", "organization", "phonenumber", "accountant", "address"}, data = result })  
            : Results.NotFound(new {});
        });

        getGroup.MapGet("get/products", async (string whereOption, ModelContext modelContext) => 
        {
            var result = await modelContext.Products.ToListAsync();
            return result.Count > 0 ?  Results.Ok(
                    new { columns = new string[]{"id", "group_id", "name", "ordering", "price"}, data = result })  
            : Results.NotFound(new {});
        });

        return getGroup;
    }
}

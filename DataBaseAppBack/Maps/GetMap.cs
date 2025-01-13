using DataBaseAppBack;
namespace Maps;

public static class MapGet
{
    public static RouteGroupBuilder GetMap(this RouteGroupBuilder getGroup)
    {
        getGroup.MapGet("get/purchases", async (string whereOption) => 
        {
            var result = await DBTools.GetPurchases();
            return result.Count > 0 ? Results.Ok(
                    new { columns = new string[]{"id", "Supplier", "Group", "Product", "Date", "Amount", "Sum"}, data = result })  
            : Results.NotFound(new {});
        });
        
        getGroup.MapGet("get/sellings", async (string whereOption) => 
        {
            var result = await DBTools.GetSellings();
            return result.Count > 0 ?  Results.Ok(
                    new { columns = new string[]{"id", "Supplier", "Group", "Product", "Date", "Amount", "Sum"}, data = result })  
            : Results.NotFound(new {});
        });

        getGroup.MapGet("get/groups", async (string whereOption) => 
        {
            var result = await DBTools.GetGroups();
            return result.Count > 0 ?  Results.Ok(
                    new { columns = new string[]{"id", "product_group"}, data = result })  
            : Results.NotFound(new {});
        });

        getGroup.MapGet("get/suppliers", async (string whereOption) => 
        {
            var result = await DBTools.GetSuppliers();
            return result.Count > 0 ?  Results.Ok(
                    new { columns = new string[]{"id", "firstName", "middleName", "lastName", "organization", "phonenumber", "accountant", "address"}, data = result })  
            : Results.NotFound(new {});
        });

        getGroup.MapGet("get/customers", async (string whereOption) => 
        {
            var result = await DBTools.GetCustomers();
            return result.Count > 0 ?  Results.Ok(
                    new { columns = new string[]{"id", "firstName", "middleName", "lastName", "organization", "phonenumber", "accountant", "address"}, data = result })  
            : Results.NotFound(new {});
        });

        getGroup.MapGet("get/products", async (string whereOption) => 
        {
            var result = await DBTools.GetProducts();
            return result.Count > 0 ?  Results.Ok(
                    new { columns = new string[]{"id", "group_id", "name", "ordering", "price"}, data = result })  
            : Results.NotFound(new {});
        });

        return getGroup;
    }
}


using DataBaseAppBack;
namespace Maps;

public static class MapGet
{
    public static RouteGroupBuilder GetMap(this RouteGroupBuilder getGroup)
    {
        getGroup.MapGet("get/purchases", async (string whereOption) => 
        {
            var result = await DBTools.GetPurchases(whereOption);
            return result.Count > 0 ? Results.Ok(
                    new { columns = new string[]{"id", "supplierid", "groupid", "productid", "date", "amount", "sum"}, data = result })  
            : Results.NotFound(new {});
        });
        
        getGroup.MapGet("get/sellings", async (string whereOption) => 
        {
            var result = await DBTools.GetSellings(whereOption);
            return result.Count > 0 ?  Results.Ok(
                    new { columns = new string[]{"id", "supplierid", "groupid", "productid", "date", "amount", "sum"}, data = result })  
            : Results.NotFound(new {});
        });

        getGroup.MapGet("get/groups", async (string whereOption) => 
        {
            var result = await DBTools.GetGroups(whereOption);
            return result.Count > 0 ?  Results.Ok(
                    new { columns = new string[]{"id", "product_group"}, data = result })  
            : Results.NotFound(new {});
        });

        getGroup.MapGet("get/suppliers", async (string whereOption) => 
        {
            var result = await DBTools.GetSuppliers(whereOption);
            return result.Count > 0 ?  Results.Ok(
                    new { columns = new string[]{"id", "firstName", "middleName", "lastName", "organization", "phonenumber", "accountant", "address"}, data = result })  
            : Results.NotFound(new {});
        });

        getGroup.MapGet("get/customers", async (string whereOption) => 
        {
            var result = await DBTools.GetCustomers(whereOption);
            return result.Count > 0 ?  Results.Ok(
                    new { columns = new string[]{"id", "firstName", "middleName", "lastName", "organization", "phonenumber", "accountant", "address"}, data = result })  
            : Results.NotFound(new {});
        });

        getGroup.MapGet("get/products", async (string whereOption) => 
        {
            var result = await DBTools.GetProducts(whereOption);
            return result.Count > 0 ?  Results.Ok(
                    new { columns = new string[]{"id", "groupId", "name", "ordering", "price"}, data = result })  
            : Results.NotFound(new {});
        });

        getGroup.MapGet("get/products/amount", async (string whereOption) => 
        {
            var result = await DBTools.GetProductAmount(whereOption);
            return result.Count > 0 ?  Results.Ok(
                    new { columns = new string[]{"id", "product_group", "amount"}, data = result })  
            : Results.NotFound(new {});
        });

        return getGroup;
    }
}


using DataBaseAppBack;
namespace Maps;

public static class MapGet
{
    public static RouteGroupBuilder GetMap(this RouteGroupBuilder getGroup)
    {
        getGroup.MapGet("get/db", () =>{
            var result = DBTools.ConnectToDB();
            return result > 0 ? Results.Ok() : Results.NotFound(new {});
        });

        getGroup.MapGet("get/db2", () =>{
            var result = DBTools.ConntectToDB2();
            return result > 0 ? Results.Ok() : Results.NotFound(new {});
        });

        getGroup.MapGet("get/db2/tables", async () =>{
            var result = await DBTools.CreateTables();
            return result > 0 ? Results.Ok() : Results.NotFound(new {});
        });

        getGroup.MapGet("get/dbinfo", async () => 
        {
            var result = await DBTools.GetDbInfo();
            return result.Count > 0 ? Results.Ok(
                    new { columns = new string[]{"database_name"}, data = result })  
            : Results.NotFound(new {});
        });

        getGroup.MapGet("get/tablesinfo", async () => 
        {
            var result = await DBTools.GetTablesInfo();
            return result.Count > 0 ? Results.Ok(
                    new { columns = new string[]{"table_name", "row_count", "column_count"}, data = result })  
            : Results.NotFound(new {});
        });

        getGroup.MapGet("get/purchases", async (string whereOption) => 
        {
            var result = await DBTools.GetPurchases(whereOption);
            return result.Count > 0 ? Results.Ok(
                    new { columns = new string[]{"id", "supplierid", "groupid", "productid", "date", "amount", "sum"}, data = result })  
            : Results.NotFound(new {});
        });

        getGroup.MapGet("get/purchases/sum", async (string whereOption) => 
        {
            var result = await DBTools.GetPurchasesSumByDate(whereOption);
            return result.Count > 0 ? Results.Ok(
                    new { columns = new string[]{"firstName", "middleName", "lastName", "date", "sum"}, data = result })
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
                    new { columns = new string[]{"id", "firstName", "middleName", "lastName", "organization", "phoneNumber", "accountant", "address"}, data = result })  
            : Results.NotFound(new {});
        });

        getGroup.MapGet("get/customers", async (string whereOption) => 
        {
            var result = await DBTools.GetCustomers(whereOption);
            return result.Count > 0 ?  Results.Ok(
                    new { columns = new string[]{"id", "firstName", "middleName", "lastName", "organization", "phoneNumber", "accountant", "address"}, data = result })  
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

        getGroup.MapGet("get/products/report", async (string whereOption) => 
        {
            var result = await ReportsService.ProductReport(whereOption);
            return result > 0 ?  Results.Ok(
                    new { columns = new string[]{"id", "product_group", "amount"}, data = result })  
            : Results.NotFound(new {});
        });

        return getGroup;
    }
}


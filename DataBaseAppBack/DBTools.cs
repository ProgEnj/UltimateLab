using System.Data;
using Npgsql;
using Model;
namespace DataBaseAppBack;
public static class DBTools
{
    private static string connetionString = "Host=localhost;Username=postgres;Password=postpast;Database=ForLabs";
    private static NpgsqlDataSource dataSource;
    static DBTools()
    {
        var dataSourceBuilder = new NpgsqlDataSourceBuilder(connetionString);
        dataSource = dataSourceBuilder.Build();
    }

    public static string TransformWhere(string whereOption)
    {
        return whereOption == "" ? "" : $"WHERE {whereOption}";
    }

    public static async Task<List<Customer>> GetCustomers(string whereOption = "")
    {
        using var reader = await dataSource.CreateCommand($"SELECT * FROM \"Customers\" {TransformWhere(whereOption)};").ExecuteReaderAsync();
        var students = new List<Customer>();

        while (await reader.ReadAsync())
        {
            students.Add(new Customer(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4),
reader.GetString(5), reader.GetString(6), reader.GetString(7)
                        ));
        }

        return students;
    }
    
    public static async Task<List<Supplier>> GetSuppliers(string whereOption = "")
    {
        using var reader = await dataSource.CreateCommand($"SELECT * FROM \"Supplier\" {TransformWhere(whereOption)};").ExecuteReaderAsync();
        var students = new List<Supplier>();

        while (await reader.ReadAsync())
        {
            students.Add(new Supplier(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4),
reader.GetString(5), reader.GetString(6), reader.GetString(7)
                        ));
        }

        return students;
    }

    public static async Task<List<Group>> GetGroups(string whereOption = "")
    {
        using var reader = await dataSource.CreateCommand($"SELECT * FROM \"Groups\" {TransformWhere(whereOption)};").ExecuteReaderAsync();
        var collection = new List<Group>();

        while (await reader.ReadAsync())
        {
            collection.Add(new Group(reader.GetInt32(0), reader.GetString(1)));
        }

        return collection;
    }

    public static async Task<List<Product>> GetProducts(string whereOption = "")
    {
        using var reader = await dataSource.CreateCommand($"SELECT * FROM \"Products\" {TransformWhere(whereOption)};").ExecuteReaderAsync();
        var collection = new List<Product>();

        while (await reader.ReadAsync())
        {
            collection.Add(new Product(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4)));
        }

        return collection;
    }

    public static async Task<List<Task3DTO>> GetProductAmount(string whereOption = "")
    {
        using var reader = await dataSource.CreateCommand(
        $@"
            SELECT ""Groups"".id, ""Groups"".product_group, SUM(amount) FROM ""Purchases""
            INNER JOIN ""Groups"" ON ""Purchases"".groupid = ""Groups"".id
            WHERE {whereOption} 
            GROUP BY product_group, ""Groups"".id"

        ).ExecuteReaderAsync();

        var collection = new List<Task3DTO>();

        while (await reader.ReadAsync())
        {
            collection.Add(new Task3DTO(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2)));
        }

        return collection;
    }

    public static async Task<List<Purchase>> GetPurchases(string whereOption = "")
    {
        using var reader = await dataSource.CreateCommand($"SELECT * FROM \"Purchases\" {TransformWhere(whereOption)};").ExecuteReaderAsync();
        var collection = new List<Purchase>();

        while (await reader.ReadAsync())
        {
            collection.Add(new Purchase(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetDateTime(4), reader.GetInt32(5), reader.GetInt32(6)));
        }

        return collection;
    }
    
    public static async Task<List<Selling>> GetSellings(string whereOption = "")
    {
        using var reader = await dataSource.CreateCommand($"SELECT * FROM \"Sellings\" {TransformWhere(whereOption)};").ExecuteReaderAsync();
        var collection = new List<Selling>();

        while (await reader.ReadAsync())
        {
            collection.Add(new Selling(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetDateTime(4), reader.GetInt32(5), reader.GetInt32(6)));
        }

        return collection;
    }
    
    public static async Task<int> InsertCustomer(Customer customer)
    {
        await using var connection = await dataSource.OpenConnectionAsync();
        await using var cmd = new NpgsqlCommand("INSERT INTO \"Customers\" (firstName, middleName, lastName, organization, phoneNumber, accountant, address) " + 
        "VALUES ($1, $2, $3, $4, $5, $6, $7);", connection)
        {
            Parameters = 
            {
                new() {Value = customer.firstName},
                new() {Value = customer.middleName},
                new() {Value = customer.lastName},
                new() {Value = customer.organization},
                new() {Value = customer.phoneNumber},
                new() {Value = customer.accountant},
                new() {Value = customer.address}
            }
        };
        var result = await cmd.ExecuteNonQueryAsync();      
        return result;
    }
    
    public static async Task<int> InsertSupplier(Supplier supplier)
    {
        await using var connection = await dataSource.OpenConnectionAsync();
        await using var cmd = new NpgsqlCommand("INSERT INTO \"Suppliers\" (firstName, middleName, lastName, organization, phoneNumber, accountant, address) " + 
        "VALUES ($1, $2, $3, $4, $5, $6, $7);", connection)
        {
            Parameters = 
            {
                new() {Value = supplier.firstName},
                new() {Value = supplier.middleName},
                new() {Value = supplier.lastName},
                new() {Value = supplier.organization},
                new() {Value = supplier.phoneNumber},
                new() {Value = supplier.accountant},
                new() {Value = supplier.address}
            }
        };
        var result = await cmd.ExecuteNonQueryAsync();      
        return result;
    }

    public static async Task<int> InsertProduct(Product product)
    {

        await using var connection = await dataSource.OpenConnectionAsync();
        await using var cmd = new NpgsqlCommand("INSERT INTO \"Products\" (name, ordering, price, groupid) " + 
        "VALUES ($1, $2, $3, $4);", connection)
        {
            Parameters = 
            {
                new() {Value = product.name},
                new() {Value = product.ordering},
                new() {Value = product.price},
                new() {Value = product.groupId}
            }
        };
        var result = await cmd.ExecuteNonQueryAsync();      
        return result;
    }
    
    public static async Task<int> InsertGroup(Group group)
    {
        await using var connection = await dataSource.OpenConnectionAsync();
        await using var cmd = new NpgsqlCommand("INSERT INTO \"Groups\" (product_group) " + 
        "VALUES ($1);", connection)
        {
            Parameters = 
            {
                new() {Value = group.product_group},
            }
        };
        var result = await cmd.ExecuteNonQueryAsync();      
        return result;
    }
    
    public static async Task<int> InsertPurchase(Purchase purchase)
    {
        await using var connection = await dataSource.OpenConnectionAsync();
        await using var cmd = new NpgsqlCommand("INSERT INTO \"Purchases\" (supplierid, groupid, productid, date, amount, sum) " + 
        "VALUES ($1, $2, $3, $4, $5, $6);", connection)
        {
            Parameters = 
            {
                new() {Value = purchase.supplierid},
                new() {Value = purchase.groupid},
                new() {Value = purchase.productid},
                new() {Value = purchase.date},
                new() {Value = purchase.amount},
                new() {Value = purchase.sum},
            }
        };
        var result = await cmd.ExecuteNonQueryAsync();      
        return result;
    }
    
    public static async Task<int> InsertSelling(Selling selling)
    {
        await using var connection = await dataSource.OpenConnectionAsync();
        await using var cmd = new NpgsqlCommand("INSERT INTO \"Sellings\" (supplierid, groupid, productid, date, amount, sum) " + 
        "VALUES ($1, $2, $3, $4, $5, $6);", connection)
        {
            Parameters = 
            {
                new() {Value = selling.customerid},
                new() {Value = selling.groupid},
                new() {Value = selling.productid},
                new() {Value = selling.date},
                new() {Value = selling.amount},
                new() {Value = selling.sum},
            }
        };
        var result = await cmd.ExecuteNonQueryAsync();      
        return result;
    }
    
    public static async Task<int> UpdateInTable(string table, int id, List<string> values)
    {
        await using var connection = await dataSource.OpenConnectionAsync();
        await using var cmd = new NpgsqlCommand($"UPDATE \"{table}\" SET {string.Join(',', values.ToArray())} WHERE " + 
        "id = $1;", connection)
        {
            Parameters = 
            {
                new() {Value = id},
            }
        };
        var result = await cmd.ExecuteNonQueryAsync();      
        return result;
    }

    public static async Task<int> UpdateProductsSizeByGroups(int id)
    {
        await using var connection = await dataSource.OpenConnectionAsync();
        await using var cmd = new NpgsqlCommand(
        $@"
            UPDATE ""Products""
            SET price = price - (price / 100)
            WHERE groupid = $1;"
        , connection)
        {
            Parameters =
            {
                new() {Value = id}
            }
        };

        var result = await cmd.ExecuteNonQueryAsync();      
        return result;
    }

    public static async Task<int> DeleteInTable(string table, int id)
    {
        await using var connection = await dataSource.OpenConnectionAsync();
        await using var cmd = new NpgsqlCommand($"DELETE FROM \"{table}\" WHERE " + 
        "id = $1;", connection)
        {
            Parameters = 
            {
                new() {Value = id},
            }
        };
        var result = await cmd.ExecuteNonQueryAsync();      
        return result;
    }
}

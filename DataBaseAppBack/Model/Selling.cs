namespace Model;

public class Selling
{

    public int id { get; set; }
    public Customer customer { get; set; }
    public Group group { get; set; }
    public Product product { get; set; }
    public DateOnly date { get; set; }
    public int amount { get; set; }
    public int sum { get; set; }
}

public record SellingDTO(int id, string supplierId, string groupId,
        string productId, DateOnly date, int amount, int sum);





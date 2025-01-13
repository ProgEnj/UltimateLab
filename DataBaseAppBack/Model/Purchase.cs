namespace Model;

public class Purchase
{
    public int id { get; set; }
    public Supplier supplier { get; set; }
    public Group group { get; set; }
    public Product product { get; set; }
    public DateOnly date { get; set; }
    public int amount { get; set; }
    public int sum { get; set; }
}

public record PurchaseDTO(int id, string supplierId, string groupId,
        string productId, DateOnly date, int amount, int sum);

namespace Model;

public class Purchase
{
    public int id { get; set; }
    public string supplierId { get; set; }
    public string groupId { get; set; }
    public string productId { get; set; }
    public DateTime date { get; set; }
    public int amount { get; set; }
    public int sum { get; set; }

    public Purchase(int id, string supplierId, string groupId, string productId, DateTime date, int amount, int sum)
    {
        this.id = id;
        this.supplierId = supplierId;
        this.groupId = groupId;
        this.productId = productId;
        this.date = date;
        this.amount = amount;
        this.sum = sum;
    }
}


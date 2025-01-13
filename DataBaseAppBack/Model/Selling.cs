namespace Model;

public class Selling
{
    public int id { get; set; }
    public string customerId { get; set; }
    public string groupId { get; set; }
    public string productId { get; set; }
    public DateTime date { get; set; }
    public int amount { get; set; }
    public int sum { get; set; }

    public Selling(int id, string customerId, string groupId, string productId, DateTime date, int amount, int sum)
    {
        this.id = id;
        this.customerId = customerId;
        this.groupId = groupId;
        this.productId = productId;
        this.date = date;
        this.amount = amount;
        this.sum = sum;
    }
}

namespace Model;

public class Selling
{
    public int id { get; set; }
    public int customerid { get; set; }
    public int groupid { get; set; }
    public int productid { get; set; }
    public DateTime date { get; set; }
    public int amount { get; set; }
    public int sum { get; set; }

    public Selling(int id, int customerId, int groupId, int productId, DateTime date, int amount, int sum)
    {
        this.id = id;
        this.customerid = customerId;
        this.groupid = groupId;
        this.productid = productId;
        this.date = date;
        this.amount = amount;
        this.sum = sum;
    }
}

namespace Model;

public class Purchase
{
    public int id { get; set; }
    public int supplierid { get; set; }
    public int groupid { get; set; }
    public int productid { get; set; }
    public DateTime date { get; set; }
    public int amount { get; set; }
    public int sum { get; set; }

    public Purchase(int id, int supplierId, int groupId, int productId, DateTime date, int amount, int sum)
    {
        this.id = id;
        this.supplierid = supplierId;
        this.groupid = groupId;
        this.productid = productId;
        this.date = date;
        this.amount = amount;
        this.sum = sum;
    }
}


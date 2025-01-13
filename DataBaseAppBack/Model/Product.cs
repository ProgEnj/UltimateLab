namespace Model;

public class Product
{
    public int id { get; set; }
    public string groupId  { get; set; }
    public string name { get; set; }
    public string ordering { get; set; }
    public int price { get; set; }

    public Product(int id, string groupId, string name, string ordering, int price)
    {
        this.id = id;
        this.groupId = groupId;
        this.name = name;
        this.ordering = ordering;
        this.price = price;
    }
}

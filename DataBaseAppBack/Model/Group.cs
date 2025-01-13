namespace Model;

public class Group
{
    public int id { get; set; }
    public string product_group { get; set; }
    
    public Group(int id, string product_group)
    {
        this.id = id;
        this.product_group = product_group;
    }
}

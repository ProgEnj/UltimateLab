namespace Model;

public class Product
{
    public int id { get; set; }
    public Group group  { get; set; }
    public string name { get; set; }
    public string ordering { get; set; }
    public int price { get; set; }
}

public record ProductDTO(int id, string groupId, string name, string ordering, int price);

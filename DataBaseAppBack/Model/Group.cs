namespace Model;

public class Group
{
    public int id { get; set; }
    public string product_group { get; set; }
}

public record GroupDTO(int id, string poduct_group);


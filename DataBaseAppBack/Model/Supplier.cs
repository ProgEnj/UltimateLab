namespace Model;

public class Supplier
{
    public int id { get; set; }

    public string firstName {get; set;}
    public string middleName { get; set; }
    public string lastName { get; set; }
    public string organization { get; set; }
    public string phoneNumber { get; set; }
    public string accountant { get; set; }
    public string address { get; set; }
}

public record SupplierDTO(int id, string firstName, string middleName, string lastName, string organization, string phoneNumber,
        string accountant, string address
        );

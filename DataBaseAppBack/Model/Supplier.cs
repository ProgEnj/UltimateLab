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

    public Supplier(int id, string firstName, string middleName, string lastName, string organization, string phoneNumber, string accountant, string address)
    {
        this.id = id;
        this.firstName = firstName;
        this.middleName = middleName;
        this.lastName = lastName;
        this.organization = organization;
        this.phoneNumber = phoneNumber;
        this.accountant = accountant;
        this.address = address;
    }
}

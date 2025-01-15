namespace Model
{
    public class Task4DTO
    {
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public DateTime date { get; set; }
        public int sum { get; set; }

        public Task4DTO(string firstName, string middleName, string lastName, DateTime date, int sum)
        {
            this.firstName = firstName;
            this.middleName = middleName;
            this.lastName = lastName;
            this.date = date;
            this.sum = sum;
        }
    }
}

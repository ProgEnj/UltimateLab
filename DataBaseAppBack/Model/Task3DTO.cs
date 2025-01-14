namespace Model
{
    public class Task3DTO
    {
        public int id { get; set; }
        public string product_group { get; set; }
        public int amount { get; set; }

        public Task3DTO(int id, string product_group, int amount)
        {
            this.id = id;
            this.product_group = product_group;
            this.amount = amount;
        }
    }
}

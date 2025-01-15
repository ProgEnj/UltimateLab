namespace Model
{
    public class DbInfo
    {
        public string database_name { get; set; }

        public DbInfo(string database_name)
        {
            this.database_name = database_name;
        }
    }
}

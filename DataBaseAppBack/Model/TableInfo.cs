namespace Model
{
    public class TableInfo
    {
        public string table_name { get; set; }
        public int row_count { get; set; }
        public int column_count { get; set; }

        public TableInfo(string table_name, int row_count, int column_count)
        {
            this.table_name = table_name;
            this.row_count = row_count;
            this.column_count = column_count;
        }
    }
}

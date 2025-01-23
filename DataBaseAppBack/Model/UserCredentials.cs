namespace Model
{
    public class UserCredentials
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public UserCredentials(int id, string username, string password)
        {
            this.id = id;
            this.username = username;
            this.password = password;
        }
    }
}

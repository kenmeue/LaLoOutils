namespace lalocation.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] PasswwordHash { get; set; }
         public byte[] PasswwordSalt { get; set; }
    }
}
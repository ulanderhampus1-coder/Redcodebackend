namespace Redcode.Models
{
    public class User
    {
        public int ID { get; set; }

        public string Username { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;
    }
}

namespace Redcode.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string Titel { get; set; } = string.Empty;
        public string Författare { get; set; } = string.Empty;
        public DateOnly Datum { get; set; }

        public int UserId { get; set; }
    }
}

namespace Redcode.Models
{
    public class Quote
    {
        public int ID { get; set; }
        public string Text { get; set; } = string.Empty;
        public string Källa { get; set; } = string.Empty;

        public int UserId { get; set; }
    }
}
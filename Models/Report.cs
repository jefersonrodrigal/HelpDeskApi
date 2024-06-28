namespace HelpDeskApi.Models
{
    public class Report
    {
        public int Id { get; set; }
        public string Subject { get; set; } = string.Empty;
        public string Incident { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public User User { get; set; }
    }
}

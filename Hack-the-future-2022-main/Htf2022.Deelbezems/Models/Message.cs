namespace Htf2022.Deelbezems.Models
{
    public class Message
    {
        public Bezem Bezem { get; set; }

        public DateTime Timestamp { get; set; }
        public int StatusType { get; set; }
        public Positie Positie { get; set; }
        public int BrandstofLevel { get; set; }

        public string TaxiStatusId { get; set; }
        public string KastId { get; set; }

    }
}

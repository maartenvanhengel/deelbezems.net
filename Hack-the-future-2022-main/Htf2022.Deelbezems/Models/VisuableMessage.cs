namespace Htf2022.Deelbezems.Models
{
    public class VisuableMessage
    {
        public string bezemId { get; set; }
        public int statusType { get; set; }
        public Positie positie { get; set; }
        public double brandstofLevel { get; set; }
        public string kastId { get; set;}
        public DateTime dateTime { get; set; }

    }
}

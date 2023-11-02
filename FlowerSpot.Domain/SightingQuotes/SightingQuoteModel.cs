namespace FlowerSpot.Domain.SightingQuotes
{
    public class SightingQuoteModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        public string Category { get; set; }

        public int SightingId { get; set; }
    }
}
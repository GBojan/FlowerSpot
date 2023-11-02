namespace FlowerSpot.Domain.SightingQuotes
{
    public class GetSightingQuoteModel
    {
        public SightingQuoteContent Contents { get; set; }
    }

    public class SightingQuoteContent
    {
        public List<SightingQuoteContentData> Quotes { get; set; }
    }

    public class SightingQuoteContentData
    {
        public string Quote { get; set; }

        public string Author { get; set; }

        public string Category { get; set; }
    }
}
using FlowerSpot.Domain.Flowers;
using FlowerSpot.Domain.SightingQuotes;

namespace FlowerSpot.Domain.Sightings
{
    public class SightingModel
    {
        public int Id { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public Uri ImageRef { get; set; }

        public int FlowerId { get; set; }

        public FlowerModel Flower { get; set; }

        public SightingQuoteModel SightingQuote { get; set; }

        public int LikeCount { get; set; }
    }
}
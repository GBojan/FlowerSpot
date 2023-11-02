using FlowerSpot.Domain.Sightings;

namespace FlowerSpot.Domain.Likes
{
    public class LikeModel
    {
        public int Id { get; set; }

        public DateTime Created { get; set; }

        public int SightingId { get; set; }

        public SightingModel Sighting { get; set; }
    }
}
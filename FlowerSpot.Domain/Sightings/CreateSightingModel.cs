using System.ComponentModel.DataAnnotations;

namespace FlowerSpot.Domain.Sightings
{
    public class CreateSightingModel
    {
        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }

        [Required]
        public Uri ImageRef { get; set; }

        [Required]
        public int FlowerId { get; set; }
    }
}
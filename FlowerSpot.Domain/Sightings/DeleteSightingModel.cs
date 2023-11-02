using System.ComponentModel.DataAnnotations;

namespace FlowerSpot.Domain.Sightings
{
    public class DeleteSightingModel
    {
        [Required]
        public int SightingId { get; set; }
    }
}
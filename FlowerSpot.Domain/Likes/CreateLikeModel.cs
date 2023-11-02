using System.ComponentModel.DataAnnotations;

namespace FlowerSpot.Domain.Likes
{
    public class CreateLikeModel
    {
        [Required]
        public int SightingId { get; set; }
    }
}
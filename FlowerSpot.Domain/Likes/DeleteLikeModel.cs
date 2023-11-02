using System.ComponentModel.DataAnnotations;

namespace FlowerSpot.Domain.Likes
{
    public class DeleteLikeModel
    {
        [Required]
        public int LikeId { get; set; }
    }
}
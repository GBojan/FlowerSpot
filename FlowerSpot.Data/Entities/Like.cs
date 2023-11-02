using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowerSpot.Data.Entities
{
    [Table("Likes")]
    public class Like
    {
        [Key]
        public int Id { get; set; }

        public DateTime Created { get; set; }

        [ForeignKey("Sightings")]
        public int SightingId { get; set; }

        public virtual Sighting Sighting { get; set; }

        [ForeignKey("AspNetUsers")]
        public string UserId { get; set; }

        public virtual IdentityUser User { get; set; }
    }
}
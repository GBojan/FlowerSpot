using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowerSpot.Data.Entities
{
    [Table("Sightings")]
    public class Sighting
    {
        [Key]
        public int Id { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public Uri ImageRef { get; set; }

        [ForeignKey("Flowers")]
        public int FlowerId { get; set; }

        public virtual Flower Flower { get; set; }

        [ForeignKey("AspNetUsers")]
        public string UserId { get; set; }

        public virtual IdentityUser User { get; set; }

        public virtual ICollection<Like> Likes { get; set; }

        public virtual SightingQuote SightingQuote { get; set; }
    }
}
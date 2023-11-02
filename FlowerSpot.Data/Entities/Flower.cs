using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowerSpot.Data.Entities
{
    [Table("Flowers")]
    public class Flower
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public Uri ImageRef { get; set; }

        public string Description { get; set; }

        [ForeignKey("AspNetUsers")]
        public string UserId { get; set; }

        public virtual IdentityUser User { get; set; }

        public virtual ICollection<Sighting> Sightings { get; set; }
    }
}
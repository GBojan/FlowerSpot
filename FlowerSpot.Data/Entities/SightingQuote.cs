using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowerSpot.Data.Entities
{
    [Table("SightingQuotes")]
    public class SightingQuote
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        public string Category { get; set; }

        [ForeignKey("Sightings")]
        public int SightingId { get; set; }

        public virtual Sighting Sighting { get; set; }
    }
}
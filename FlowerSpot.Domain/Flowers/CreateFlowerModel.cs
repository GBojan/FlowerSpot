using System.ComponentModel.DataAnnotations;

namespace FlowerSpot.Domain.Flowers
{
    public class CreateFlowerModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public Uri ImageRef { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
namespace FlowerSpot.Domain.Flowers
{
    public class FlowerModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Uri ImageRef { get; set; }

        public string Description { get; set; }
    }
}
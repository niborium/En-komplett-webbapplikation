namespace En_komplett_webbapplikation.Domain.Models
{
    public class Rover
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NasaURL { get; set; }
        public string Description { get; set; }
        public string History { get; set; }
        public int Weight { get; set; }
        public int NumberOfWheels { get; set; }
    }
}

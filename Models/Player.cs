using DiplomMag.Models;

namespace DiplomMag.models
{
    public class Player
    {
        public Guid Id { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string? Surname { get; set; } = string.Empty;
        public double Weight { get; set; }
        public double Height { get; set; }
        public string? PlayerPosition { get; set; } = string.Empty;
        public virtual Statistic Statistic { get; set; }
        public Guid GameId { get; set; }
        public virtual Game Game { get; set; }
        public Guid TeamId { get; set; }
        public virtual Team Team { get; set; }

    }
}

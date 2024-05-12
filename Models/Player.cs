using DiplomMag.Models;

namespace DiplomMag.models
{
    public class Player
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public required string PlayerPosition { get; set; }
        public virtual required Statistic Statistic { get; set; }
        public Guid GameId { get; set; }
        public virtual required Game Game { get; set; }
        public Guid TeamId { get; set; }
        public virtual required Team Team { get; set; }

    }
}

using DiplomMag.models;

namespace DiplomMag.Models
{
    public class Team
    {
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public virtual List<Player> Players { get; set; } = new List<Player> { };
    }
}


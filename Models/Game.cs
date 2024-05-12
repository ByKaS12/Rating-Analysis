namespace DiplomMag.models
{
    public class Game
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public virtual List<Player> Players { get; set; } = new List<Player> { };
        public Guid TournamentId { get; set; }
        public virtual required Tournament Tournament { get; set; }

    }






}
